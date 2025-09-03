using EstruturaFesta.AppServices.DTOs;
using EstruturaFesta.Domain.Entities;
using EstruturaFesta.Infrastructure.Data;
using EstruturaFesta.Presentation.Forms;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace EstruturaFesta
{
    public partial class TelaPedidoForm : Form
    {
        private Button botaoBuscarProduto;
        private int linhaAtualComBotao = 0;
        private int? _pedidoId = null;

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

        public TelaPedidoForm(int pedidoId) : this()
        {
            _pedidoId = pedidoId;
            CarregarPedido(pedidoId);
        }

        private void CarregarPedido(int pedidoId)
        {
            using var db = new EstruturaDataBase();

            var pedido = db.Pedidos
                .Include(p => p.Produtos)
                .ThenInclude(pp => pp.Produto)
                .Include(p => p.Cliente)
                .FirstOrDefault(p => p.ID == pedidoId);

            if (pedido == null)
            {
                MessageBox.Show("Pedido não encontrado.");
                return;
            }

            // Desabilita eventos temporariamente
            dataGridViewProdutosLocacao.CellEndEdit -= dataGridViewProdutosLocacao_CellEndEdit;
            dateTimePickerDataPedido.ValueChanged -= dateTimePickerDataPedido_ValueChanged;

            try
            {
                // Preenche dados básicos
                textBoxIDCliente.Text = pedido.ClienteId.ToString();
                textBoxNomeCliente.Text = pedido.Cliente.Nome;
                textBoxDocumentoCliente.Text = pedido.Cliente.ObterDocumento();
                dateTimePickerDataPedido.Value = pedido.DataPedido;

                // Limpa e preenche o grid COMPLETO de uma vez
                dataGridViewProdutosLocacao.Rows.Clear();

                foreach (var item in pedido.Produtos)
                {
                    string descricaoCompleta = $"{item.Produto.Nome} {item.Produto.Material} {item.Produto.Modelo} {item.Produto.Especificacao}".Trim();

                    int estoqueDisponivel = CalcularEstoqueDisponivel(item.ProdutoId, pedido.DataPedido, item.Produto.Quantidade);

                    dataGridViewProdutosLocacao.Rows.Add(
                        item.ProdutoId,
                        descricaoCompleta,
                        estoqueDisponivel,
                        item.Quantidade,
                        item.ValorUnitario,
                        item.Quantidade * item.ValorUnitario,
                        item.Produto.PrecoReposicao
                    );
                }
            }
            finally
            {
                // Reabilita eventos
                dataGridViewProdutosLocacao.CellEndEdit += dataGridViewProdutosLocacao_CellEndEdit;
                dateTimePickerDataPedido.ValueChanged += dateTimePickerDataPedido_ValueChanged;
            }

            GarantirLinhaInicial();
            AtualizarPosicaoBotao();
        }

        private void TelaPedidoForm_Load(object sender, EventArgs e)
        {
            // Só define data atual se for um pedido NOVO
            if (!_pedidoId.HasValue)
            {
                dateTimePickerDataPedido.Value = DateTime.Now;
            }
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
            string numero = maskedTextBoxNumeroContato.Text.Trim();

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

        private void dateTimePickerDataPedido_ValueChanged(object sender, EventArgs e)
        {
            DateTime novaData = dateTimePickerDataPedido.Value.Date;

            foreach (DataGridViewRow row in dataGridViewProdutosLocacao.Rows)
            {
                // Ignora linhas sem ProdutoID
                if (row.Cells["ProdutoID"].Value == null) continue;

                // Pega o ID do produto
                if (!int.TryParse(row.Cells["ProdutoID"].Value.ToString(), out int produtoId)) continue;

                // Estoque total do produto (pegar do DataGridView ou do DTO)
                if (!int.TryParse(row.Cells["Estoque"].Value?.ToString(), out int estoqueTotal)) estoqueTotal = 0;

                // Quantidade do pedido atual
                if (!int.TryParse(row.Cells["Quantidade"].Value?.ToString(), out int quantidadePedido)) quantidadePedido = 0;

                // Calcula o estoque disponível para a nova data
                int estoqueDisponivel = CalcularEstoqueDisponivel(produtoId, novaData, estoqueTotal);

                // Atualiza a coluna de estoque
                row.Cells["Estoque"].Value = estoqueDisponivel;

                // Ajusta a quantidade do pedido se estiver maior que o disponível
                if (quantidadePedido > estoqueDisponivel)
                {
                    MessageBox.Show(
                        $"A quantidade do produto {row.Cells["Produto"].Value} foi ajustada para o máximo disponível ({estoqueDisponivel}) para a nova data.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    row.Cells["Quantidade"].Value = estoqueDisponivel;
                    quantidadePedido = estoqueDisponivel;
                }

                // Recalcula o valor total
                if (!decimal.TryParse(row.Cells["ValorUnitario"].Value?.ToString(), out decimal preco)) preco = 0;
                row.Cells["ValorTotal"].Value = quantidadePedido * preco;
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
                BeginInvoke((Action)(() =>
                {
                    dataGridViewProdutosLocacao.CurrentCell = row.Cells["Quantidade"];
                    dataGridViewProdutosLocacao.BeginEdit(true);
                }));
            }
        }

        //Evento que contem a logica de preencher todas as informações do produto selecionado
        private void dataGridViewProdutosLocacao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Isso serve para não pegar o index do cabeçalho
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

        private bool VerificarProdutoDuplicado(int produtoId, int linhaAtual)
        {
            for (int i = 0; i < dataGridViewProdutosLocacao.Rows.Count; i++)
            {
                if (i == linhaAtual) continue; // Ignora a linha atual

                var cellValue = dataGridViewProdutosLocacao.Rows[i].Cells["ProdutoID"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    if (id == produtoId)
                    {
                        MessageBox.Show(
                            $"Produto já adicionado na linha {i + 1}.",
                            "Produto duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return true; // encontrou duplicado
                    }
                }
            }
            return false; // não encontrou duplicado
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
                        ValorUnitario = p.PrecoLocacao,
                        ValorReposicao = p.PrecoReposicao
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
                row.Cells["ValorReposicao"].Value = produtoDTO.ValorReposicao;

                //Verificação de duplicação de Produtos pelo ID
                if (VerificarProdutoDuplicado(produtoDTO.ProdutoId, rowIndex))
                {
                    // Se quiser, limpa a célula duplicada para evitar repetição
                    row.Cells["ProdutoID"].Value = null;
                    row.Cells["Produto"].Value = null;
                    return;
                }
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
                dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "ValorTotal" ||
                dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "ValorReposicao")
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
            if (dataGridViewProdutosLocacao.IsHandleCreated)
            {
                BeginInvoke((Action)(() => AtualizarPosicaoBotao()));
            }
            else
            {
                // Se o handle ainda não existe, você pode adiar para o evento Shown
                this.Shown += (s, e) =>
                {
                    BeginInvoke((Action)(() => AtualizarPosicaoBotao()));
                };
            }
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

            using var db = new EstruturaDataBase();
            Pedido pedido;

            if (_pedidoId.HasValue) // EDITAR pedido existente
            {
                pedido = db.Pedidos
                    .Include(p => p.Produtos)
                    .FirstOrDefault(p => p.ID == _pedidoId.Value);

                if (pedido == null)
                {
                    MessageBox.Show("Pedido não encontrado.");
                    return;
                }

                pedido.ClienteId = clienteId;
                pedido.DataPedido = dataPedido;

                var produtosExistentes = pedido.Produtos.ToList();

                foreach (DataGridViewRow row in dataGridViewProdutosLocacao.Rows)
                {
                    if (row.IsNewRow) continue;

                    int produtoId = Convert.ToInt32(row.Cells["ProdutoID"].Value);
                    int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    decimal valorUnitario = Convert.ToDecimal(row.Cells["ValorUnitario"].Value);

                    var itemExistente = produtosExistentes.FirstOrDefault(x => x.ProdutoId == produtoId);

                    if (itemExistente != null)
                    {
                        // Atualiza estoque reservado
                        var saldo = db.SaldosPorData.FirstOrDefault(s => s.ProdutoId == produtoId && s.Data.Date == dataPedido);
                        if (saldo != null)
                        {
                            saldo.QuantidadeReservada += (quantidade - itemExistente.Quantidade);
                        }
                        else
                        {
                            db.SaldosPorData.Add(new SaldoEstoqueData
                            {
                                ProdutoId = produtoId,
                                Data = dataPedido,
                                QuantidadeReservada = quantidade
                            });
                        }

                        // Atualiza item
                        itemExistente.Quantidade = quantidade;
                        itemExistente.ValorUnitario = valorUnitario;
                        produtosExistentes.Remove(itemExistente);
                    }
                    else
                    {
                        // Novo item
                        pedido.Produtos.Add(new ProdutoPedido
                        {
                            ProdutoId = produtoId,
                            Quantidade = quantidade,
                            ValorUnitario = valorUnitario
                        });

                        // Atualiza estoque reservado
                        db.SaldosPorData.Add(new SaldoEstoqueData
                        {
                            ProdutoId = produtoId,
                            Data = dataPedido,
                            QuantidadeReservada = quantidade
                        });
                    }
                }

                // Remove itens que não estão mais no grid e atualiza estoque
                foreach (var itemRemovido in produtosExistentes)
                {
                    var saldo = db.SaldosPorData.FirstOrDefault(s => s.ProdutoId == itemRemovido.ProdutoId && s.Data.Date == dataPedido);
                    if (saldo != null)
                    {
                        saldo.QuantidadeReservada -= itemRemovido.Quantidade;
                        if (saldo.QuantidadeReservada < 0) saldo.QuantidadeReservada = 0;
                    }
                    pedido.Produtos.Remove(itemRemovido);
                }
            }
            else // NOVO pedido
            {
                var listaProdutos = new List<ProdutoPedido>();

                foreach (DataGridViewRow row in dataGridViewProdutosLocacao.Rows)
                {
                    if (row.IsNewRow) continue;

                    int produtoId = Convert.ToInt32(row.Cells["ProdutoID"].Value);
                    int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    decimal valorUnitario = Convert.ToDecimal(row.Cells["ValorUnitario"].Value);

                    listaProdutos.Add(new ProdutoPedido
                    {
                        ProdutoId = produtoId,
                        Quantidade = quantidade,
                        ValorUnitario = valorUnitario
                    });

                    db.SaldosPorData.Add(new SaldoEstoqueData
                    {
                        ProdutoId = produtoId,
                        Data = dataPedido,
                        QuantidadeReservada = quantidade
                    });
                }

                pedido = new Pedido
                {
                    ClienteId = clienteId,
                    DataPedido = dataPedido,
                    Produtos = listaProdutos
                };

                db.Pedidos.Add(pedido);
            }

            db.SaveChanges();

            MessageBox.Show("Pedido salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        //Evento vinculado ao datagrid que quando troca de celula chama o metodo de visualização do botão
        private void dataGridViewProdutosLocacao_CurrentCellChanged(object sender, EventArgs e)
        {
            AtualizarPosicaoBotao();
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

            return nomeColunaAtual == "Produto";
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
            e.Control.PreviewKeyDown -= EditingControl_PreviewKeyDown;
            e.Control.PreviewKeyDown += EditingControl_PreviewKeyDown;
        }

        //logica para fazer o foco voltar para a primeira celula
        private void EditingControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.IsInputKey = true;

            var dgv = dataGridViewProdutosLocacao;
            if (dgv.CurrentCell == null) return;

            string nomeColunaAtual = dgv.CurrentCell.OwningColumn.Name;
            int rowAtual = dgv.CurrentCell.RowIndex;

            // Finaliza a edição da célula atual
            dgv.EndEdit();

            switch (nomeColunaAtual)
            {
                case "ProdutoID":
                    BeginInvoke((Action)(() =>
                    {
                        var row = dgv.Rows[rowAtual];
                        var produtoValue = row.Cells["Produto"].Value;

                        if (produtoValue != null && !string.IsNullOrEmpty(produtoValue.ToString()))
                        {
                            // Se produto foi preenchido, pula direto para Quantidade
                            NavigateToColumn(dgv, rowAtual, "Quantidade");
                        }
                        else
                        {
                            // Se não tem produto, vai para a coluna Produto para aparecer o botão
                            NavigateToColumn(dgv, rowAtual, "Produto");
                        }
                    }));
                    break;
                case "Produto":
                    NavigateToColumn(dgv, rowAtual, "Quantidade");
                    break;

                case "Quantidade":
                    NavigateToNextRowOrReuse(dgv, rowAtual);
                    break;
            }
        }

        private void NavigateToColumn(DataGridView dgv, int row, string columnName)
        {
            BeginInvoke((Action)(() =>
            {
                if (dgv.Columns.Contains(columnName))
                {
                    int columnIndex = dgv.Columns[columnName].Index;
                    dgv.CurrentCell = dgv.Rows[row].Cells[columnIndex];
                    dgv.BeginEdit(true);
                }
            }));
        }

        private void NavigateToNextRowOrReuse(DataGridView dgv, int currentRow)
        {
            BeginInvoke((Action)(() =>
            {
                int targetRow = currentRow + 1;

                // Se está na última linha visível, cria nova
                if (currentRow == dgv.RowCount - 1)
                {
                    dgv.Rows.Add();
                    targetRow = dgv.RowCount - 1;
                }
                else
                {
                    // Caso contrário, só navega para a próxima linha existente
                    targetRow = Math.Min(targetRow, dgv.RowCount - 1);
                }

                // Navega para ProdutoID da linha alvo
                if (dgv.Columns.Contains("ProdutoID"))
                {
                    int columnIndex = dgv.Columns["ProdutoID"].Index;
                    dgv.CurrentCell = dgv.Rows[targetRow].Cells[columnIndex];
                    dgv.BeginEdit(true);
                }
            }));
        }

        private void dataGridViewProdutosLocacao_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Se é a coluna Produto e já tem um produto selecionado, cancela a edição
            if (dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "Produto")
            {
                var row = dataGridViewProdutosLocacao.Rows[e.RowIndex];
                var produtoId = row.Cells["ProdutoID"].Value;

                // Se já tem um produto selecionado (ProdutoID preenchido), não permite editar
                if (produtoId != null && !string.IsNullOrEmpty(produtoId.ToString()) &&
                    int.TryParse(produtoId.ToString(), out int id) && id > 0)
                {
                    e.Cancel = true; // Cancela a edição
                }
            }
        }

        // Metodo para Criar um Contador de linhas
        private void dataGridViewProdutosLocacao_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridViewProdutosLocacao.Rows[e.RowIndex].IsNewRow)
                return;

            string numeroLinha = (e.RowIndex + 1).ToString();
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(
                    numeroLinha,
                    dataGridViewProdutosLocacao.Font,
                    brush,
                    e.RowBounds.Left + (dataGridViewProdutosLocacao.RowHeadersWidth / 2),
                    e.RowBounds.Top + (e.RowBounds.Height / 2),
                    format
                );
            }
        }

        //Remoção de linhas
        private void dataGridViewProdutosLocacao_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // só com botão direito
            {
                // Confirmação antes de excluir
                var confirmar = MessageBox.Show(
                    "Deseja excluir esta linha?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmar == DialogResult.Yes)
                {
                    if (!dataGridViewProdutosLocacao.Rows[e.RowIndex].IsNewRow)
                    {
                        dataGridViewProdutosLocacao.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void buttonQuebra_Click(object sender, EventArgs e)
        {
            var produtosParaQuebra = dataGridViewProdutosLocacao.Rows
        .Cast<DataGridViewRow>()
        .Where(r => !r.IsNewRow)
        .Select(r => new ProdutoQuebra
        {
            ProdutoId = Convert.ToInt32(r.Cells["ProdutoId"].Value),
            Nome = r.Cells["Produto"].Value.ToString(),
            Quantidade = Convert.ToInt32(r.Cells["Quantidade"].Value),
            ValorReposicao = Convert.ToDecimal(r.Cells["ValorReposicao"].Value),
            QuantidadeQuebrada = 0
        }).ToList();

            using (var formQuebra = new QuebraProdutoForm(produtosParaQuebra))
            {
                formQuebra.ShowDialog();
            }
        }
    }
}