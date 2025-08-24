using EstruturaFesta.Infrastructure.Data;
using EstruturaFesta.Domain.Entities;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EstruturaFesta.AppServices.DTOs;
using System.Diagnostics;

namespace EstruturaFesta
{
    public partial class TelaPedidoForm : Form
    {
        private Button botaoBuscarProduto;
        private int linhaAtualComBotao = 0;

        public TelaPedidoForm()
        {
            InitializeComponent();
            ConfigurarBotaoBuscaProduto();

            dataGridViewProdutosLocacao.Resize += (s, e) => AtualizarPosicaoBotao();
            dataGridViewProdutosLocacao.Scroll += (s, e) => AtualizarPosicaoBotao();
            dataGridViewProdutosLocacao.RowsRemoved += (s, e) => AtualizarPosicaoBotao();
            this.Shown += TelaPedido_Shown;
            dataGridViewProdutosLocacao.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewProdutosLocacao.StandardTab = false;

        }

        private void TelaPedido_Shown(object sender, EventArgs e)
        {
            GarantirLinhaInicial();
            AtualizarPosicaoBotao();
        }
        // Parte do cliente
        private void bntBuscarCliente_Click(object sender, EventArgs e)
        {
            new FormDataGridView().ShowDialog();
        }

        private void bntBuscarCliente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true; // Previne que Enter seja tratado como click
            }
        }
        
        public void PreencherCamposCliente(int id, string nome, string documento)
        {
            textBoxIDCliente.Text = id.ToString();
            textBoxNomeCliente.Text = nome;
            textBoxDocumentoCliente.Text = documento;
        }

        private void GerarLink_Click(object sender, EventArgs e)
        {
            string numero = textBoxNumeroContato.Text.Trim();

            // Remove espaços e caracteres não numéricos
            numero = new string(numero.Where(char.IsDigit).ToArray());

            if (string.IsNullOrWhiteSpace(numero))
            {
                MessageBox.Show("Digite um número de contato válido.");
                return;
            }

            // Monta link no formato do WhatsApp
            string linkWhatsApp = $"https://wa.me/55{numero}"; // 55 = código do Brasil

            // Exibe no LinkLabel
            linkLabelWhatsApp.Tag = linkWhatsApp; // guarda o link dentro do Tag
            linkLabelWhatsApp.Visible = true;
        }

        private void linkLabelWhatsApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelWhatsApp.Tag != null)
            {
                string link = linkLabelWhatsApp.Tag.ToString();
                Process.Start(new ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true // abre no navegador padrão
                });
            }
        }
        
        // Parte do Produto
        private void ConfigurarBotaoBuscaProduto()
        {
            botaoBuscarProduto = new Button
            {
                Text = "🔍",
                Size = new Size(25, 20),
                Cursor = Cursors.Hand,
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Popup
            };
            botaoBuscarProduto.Click += BotaoBuscarProduto_Click;
            Controls.Add(botaoBuscarProduto);
        }

        private void BotaoBuscarProduto_Click(object sender, EventArgs e)
        {
            AbrirBuscaProduto(linhaAtualComBotao);
        }

        private bool ProdutoIdEstaVazio(DataGridViewRow row)
        {
            var produtoId = row.Cells["Produto"].Value;
            return produtoId == null || string.IsNullOrEmpty(produtoId.ToString());
        }

        private bool EstaLinhaVisivel(int linha)
        {
            int primeiraVisivel = dataGridViewProdutosLocacao.FirstDisplayedScrollingRowIndex;
            if (primeiraVisivel < 0) return true;

            int totalVisiveis = dataGridViewProdutosLocacao.DisplayedRowCount(true);
            return linha >= primeiraVisivel && linha < primeiraVisivel + totalVisiveis;
        }

        private void GarantirLinhaInicial()
        {
            if (dataGridViewProdutosLocacao.Rows.Count == 0 ||
                (dataGridViewProdutosLocacao.Rows.Count == 1 && dataGridViewProdutosLocacao.Rows[0].IsNewRow))
            {
                dataGridViewProdutosLocacao.Rows.Add();
            }
        }

        private void AbrirBuscaProduto(int linha)
        {
            using var buscaForm = new BuscarProdutosForm();
            if (buscaForm.ShowDialog() == DialogResult.OK)
            {
                var produto = buscaForm.ProdutoSelecionado;
                var row = dataGridViewProdutosLocacao.Rows[linha];

                // Junta as características em uma descrição única
                string descricaoCompleta = $"{produto.Nome} {produto.Material} {produto.Modelo} {produto.Especificacao}".Trim();

                var dataPedido = dateTimePickerDataPedido.Value.Date;
                int estoqueDisponivel = CalcularEstoqueDisponivel(produto.ProdutoId, dataPedido, produto.QuantidadeEstoque);

                row.Cells["ProdutoID"].Value = produto.ProdutoId;
                row.Cells["Produto"].Value = descricaoCompleta;
                row.Cells["Estoque"].Value = produto.QuantidadeEstoque;
                row.Cells["ValorUnitario"].Value = produto.ValorUnitario;

                // Move o foco para a célula de quantidade
                this.BeginInvoke((Action)(() =>
                {
                    dataGridViewProdutosLocacao.CurrentCell = row.Cells["Quantidade"];
                    dataGridViewProdutosLocacao.BeginEdit(true);
                }));
            }
        }

        //Evento que contem a logica de preencher todas as informações do produto selecionado
        private void dataGridViewProdutosLocacao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {//Isso serve para não pegar o index do cabeçalho
            if (e.RowIndex < 0) return;

            //Isso pega o nome da coluna que foi editada e consigo criar If para cada coluna
            string coluna = dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name;

            // Quando o usuário digitar o código na coluna "Codigo"
            if (coluna == "ProdutoID")
            {
                var cellValue = dataGridViewProdutosLocacao.Rows[e.RowIndex].Cells["ProdutoID"].Value?.ToString();
                if (int.TryParse(cellValue, out int produtoId) && produtoId > 0)
                {
                    PreencherProdutoNoDataGridView(produtoId, e.RowIndex);
                }
            }

            else if (coluna == "Quantidade")
            {
                var row = dataGridViewProdutosLocacao.Rows[e.RowIndex];
                int.TryParse(row.Cells["Quantidade"].Value?.ToString(), out int quantidade);
                int disponivel = 0;
                int.TryParse(row.Cells["Estoque"].Value?.ToString(), out disponivel);

                if (quantidade > disponivel)
                {
                    MessageBox.Show($"Quantidade maior que disponível ({disponivel})!", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["Quantidade"].Value = disponivel;
                    quantidade = disponivel;
                }

                decimal.TryParse(row.Cells["ValorUnitario"].Value?.ToString(), out decimal preco);
                row.Cells["ValorTotal"].Value = quantidade * preco;
            }

        }

        //Metodo que centraliza a logica de preencher o produto e converte tudo para DTO
        private void PreencherProdutoNoDataGridView(int produtoId, int rowIndex)
        {
            using (var db = new EstruturaDataBase())
            {
                // Busca e converte para DTO 
                var produtoDTO = db.Produtos
                    .Where(p => p.ID == produtoId)
                    .Select(p => new ProdutoDTO
                    {
                        ProdutoId = p.ID,
                        Nome = p.Nome,
                        Material = p.Material,
                        Modelo = p.Modelo,
                        Especificacao = p.Especificacao,
                        QuantidadeEstoque = p.Quantidade,
                        ValorUnitario = p.PrecoLocacao
                    })
                    .FirstOrDefault();

                if (produtoDTO == null)
                {
                    MessageBox.Show("Produto não encontrado!");
                    dataGridViewProdutosLocacao.Rows[rowIndex].Cells["ProdutoID"].Value = "";
                    return;
                }

                // Monta a descrição
                string descricaoCompleta = $"{produtoDTO.Nome} {produtoDTO.Material} {produtoDTO.Modelo} {produtoDTO.Especificacao}".Trim();

                // Calcula o estoque disponível para a data selecionada
                var dataPedido = dateTimePickerDataPedido.Value.Date;
                int estoqueDisponivel = CalcularEstoqueDisponivel(produtoDTO.ProdutoId, dataPedido, produtoDTO.QuantidadeEstoque);

                // Preenche no DataGridView
                var row = dataGridViewProdutosLocacao.Rows[rowIndex];
                row.Cells["ProdutoID"].Value = produtoDTO.ProdutoId;
                row.Cells["Produto"].Value = descricaoCompleta;
                row.Cells["Estoque"].Value = estoqueDisponivel;
                row.Cells["ValorUnitario"].Value = produtoDTO.ValorUnitario;

                // Move o foco para a célula de quantidade após preencher
                this.BeginInvoke((Action)(() =>
                {
                    dataGridViewProdutosLocacao.CurrentCell = row.Cells["Quantidade"];
                    dataGridViewProdutosLocacao.BeginEdit(true);
                }));
            }
        }

        // Método para calcular o estoque disponível considerando as reservas da data
        private int CalcularEstoqueDisponivel(int produtoId, DateTime data, int quantidadeEstoque)
        {
            using (var db = new EstruturaDataBase())
            {
                // Soma todas as quantidades reservadas para este produto na data específica
                int quantidadeReservada = db.SaldosPorData
                    .Where(s => s.ProdutoId == produtoId && s.Data.Date == data.Date)
                    .Sum(s => s.QuantidadeReservada);

                // Retorna a quantidade disponível (estoque total - reservado)
                int disponivel = quantidadeEstoque - quantidadeReservada;

                // Garante que não retorne valor negativo
                return Math.Max(0, disponivel);
            }
        }

        private void dataGridViewProdutosLocacao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "Quantidade" ||
        dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "Estoque")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int valorInt))
                {
                    e.Value = valorInt.ToString("N0");
                    e.FormattingApplied = true;
                }
            }

            if (dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "ValorUnitario" ||
                dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "ValorTotal")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal valorDecimal))
                {
                    e.Value = valorDecimal.ToString("C2"); // Duas casas decimais, com vírgula
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewProdutosLocacao_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BeginInvoke((Action)(() => AtualizarPosicaoBotao()));
        }

        //Logica do botão para finalizar um pedido
        private void buttonFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIDCliente.Text))
            {
                MessageBox.Show("Selecione um cliente antes de finalizar o pedido.", "Cliente obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxIDCliente.Text, out int clienteId))
            {
                MessageBox.Show("ID do cliente inválido.");
                return;
            }

            var dataPedido = dateTimePickerDataPedido.Value.Date;

            var listaProdutos = new List<ProdutoPedido>();

            foreach (DataGridViewRow row in dataGridViewProdutosLocacao.Rows)
            {
                if (row.IsNewRow) continue;

                string descricao = row.Cells["Produto"].Value?.ToString();
                int.TryParse(row.Cells["Quantidade"].Value?.ToString(), out int quantidade);
                decimal.TryParse(row.Cells["ValorUnitario"].Value?.ToString(), out decimal valorUnitario);

                if (string.IsNullOrWhiteSpace(descricao) || quantidade <= 0) continue;

                using var dbBusca = new EstruturaDataBase();
                var produto = dbBusca.Produtos.FirstOrDefault(p =>
                    (p.Nome + " " + p.Material + " " + p.Modelo + " " + p.Especificacao).Trim() == descricao);

                if (produto != null)
                {
                    listaProdutos.Add(new ProdutoPedido
                    {
                        ProdutoId = produto.ID,
                        Quantidade = quantidade,
                        ValorUnitario = valorUnitario
                    });
                }
            }

            if (!listaProdutos.Any())
            {
                MessageBox.Show("Adicione ao menos um produto válido ao pedido.");
                return;
            }

            using (var db = new EstruturaDataBase())
            {
                var pedido = new Pedido
                {
                    ClienteId = clienteId,
                    DataPedido = dataPedido,
                    Produtos = listaProdutos
                };

                db.Pedidos.Add(pedido);
                db.SaveChanges();

                foreach (var item in listaProdutos)
                {
                    db.SaldosPorData.Add(new SaldoEstoqueData
                    {
                        ProdutoId = item.ProdutoId,
                        Data = dataPedido,
                        QuantidadeReservada = item.Quantidade
                    });
                }

                db.SaveChanges();
            }

            MessageBox.Show("Pedido salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reabre a tela limpa
            this.Hide();
            var novoPedido = new TelaPedidoForm();
            novoPedido.Show();
            this.Close();
        }

        //Evento vinculado ao datagrid que quando troca de celula chama o metodo de visualização do botão
        private void dataGridViewProdutosLocacao_CurrentCellChanged(object sender, EventArgs e)
        {
            AtualizarVisibilidadeBotao();
        }

        //Torna o botão visivel chamando o metodo
        private void AtualizarPosicaoBotao()
        {
            AtualizarVisibilidadeBotao();
        }

        //Logica para tornar visivel 
        private void AtualizarVisibilidadeBotao()
        {
            // Verifica se deve mostrar o botão
            if (!DeveMostrarBotao())
            {
                botaoBuscarProduto.Visible = false;
                return;
            }

            // Posiciona o botão na célula atual
            PosicionarBotaoNaCelulaAtual();
        }

        //Logica para a aparição do botão
        private bool DeveMostrarBotao()
        {
            // Verifica se há DataGridView e células válidas
            if (dataGridViewProdutosLocacao.CurrentCell == null ||
                dataGridViewProdutosLocacao.Rows.Count == 0)
                return false;

            // Verifica se a coluna atual é "Produto"
            string nomeColunaAtual = dataGridViewProdutosLocacao.CurrentCell.OwningColumn.Name;
            if (nomeColunaAtual != "Produto")
                return false;

            // Verifica se a linha atual tem produto vazio
            int linhaAtual = dataGridViewProdutosLocacao.CurrentCell.RowIndex;
            var row = dataGridViewProdutosLocacao.Rows[linhaAtual];

            return ProdutoIdEstaVazio(row);
        }

        private void PosicionarBotaoNaCelulaAtual()
        {
            int linhaAtual = dataGridViewProdutosLocacao.CurrentCell.RowIndex;
            int colunaAtual = dataGridViewProdutosLocacao.CurrentCell.ColumnIndex;

            // Atualiza a linha atual para o click do botão
            linhaAtualComBotao = linhaAtual;

            // Verifica se a linha está visível
            if (!EstaLinhaVisivel(linhaAtual))
            {
                botaoBuscarProduto.Visible = false;
                return;
            }

            // Calcula a posição do botão
            var cellRect = dataGridViewProdutosLocacao.GetCellDisplayRectangle(colunaAtual, linhaAtual, false);

            if (cellRect.Width > 0 && cellRect.Height > 0)
            {
                Point cellLocation = dataGridViewProdutosLocacao.PointToScreen(
                    new Point(cellRect.Right - botaoBuscarProduto.Width - 3,
                              cellRect.Y + (cellRect.Height - botaoBuscarProduto.Height) / 2));

                botaoBuscarProduto.Location = PointToClient(cellLocation);
                botaoBuscarProduto.Visible = true;
                botaoBuscarProduto.BringToFront();
            }
            else
            {
                botaoBuscarProduto.Visible = false;
            }
        }

        //Evento vinculado ao datagrid que faz implementa o previewKeyDown
        private void dataGridViewProdutosLocacao_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.PreviewKeyDown += EditingControl_PreviewKeyDown;
        }

        //logica para fazer o foco voltar para a primeira celula
        private void EditingControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Isso garante que o Enter não seja ignorado
            if (e.KeyCode == Keys.Enter)
                e.IsInputKey = true;
            if (e.KeyCode == Keys.Enter)
            {
                var dgv = dataGridViewProdutosLocacao;
                if (dgv.CurrentCell == null) return;

                string nomeColunaAtual = dgv.CurrentCell.OwningColumn.Name;

                if (nomeColunaAtual == "Quantidade")
                {
                    e.IsInputKey = true;

                    // Força o fim da edição da célula atual
                    dgv.EndEdit();

                    int row = dgv.CurrentCell.RowIndex;

                    // Vai para a coluna Codigo da próxima linha
                    BeginInvoke((Action)(() =>
                    {
                        if (row + 1 < dgv.RowCount)
                        {
                            int colunaProduto = dgv.Columns["ProdutoID"].Index;
                            dgv.CurrentCell = dgv.Rows[row + 1].Cells[colunaProduto];
                        }
                        else
                        {
                            // Adiciona nova linha e vai para coluna Codigo
                            dgv.Rows.Add();
                            int colunaProduto = dgv.Columns["ProdutoID"].Index;
                            dgv.CurrentCell = dgv.Rows[row + 1].Cells[colunaProduto];
                        }
                        dgv.BeginEdit(true);
                    }));
                }
            }
        }

       
    }
}    