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
        private bool baixaRealizada = false;
        private int? _pedidoId = null;
        private Dictionary<int, int> _quantidadesOriginais = new();
        private Dictionary<int, int> _estoqueOriginal = new();

        #region Contrutores e Inicializadores do Form
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
            this.Load += (s, e) => CarregarPedido(pedidoId);
        }

        private void CarregarPedido(int pedidoId)
        {
            using var db = new EstruturaDataBase();

            var pedido = db.Pedidos
                .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                .Include(p => p.Cliente)
                    .ThenInclude(c => c.Contatos)
                .FirstOrDefault(p => p.ID == pedidoId);

            if (pedido == null)
            {
                MessageBox.Show("Pedido não encontrado.");
                return;
            }

            // Carregar cache de quantidades originais
            _quantidadesOriginais = pedido.Produtos
                .ToDictionary(pp => pp.ProdutoId, pp => pp.Quantidade);

            // Carregar cache de estoque original
            _estoqueOriginal = pedido.Produtos
                .ToDictionary(pp => pp.ProdutoId, pp => pp.Produto.Quantidade);

            // Desabilita eventos temporariamente
            dataGridViewProdutosLocacao.CellEndEdit -= dataGridViewProdutosLocacao_CellEndEdit;
            dateTimePickerDataPedido.ValueChanged -= dateTimePickerDataPedido_ValueChanged;

            try
            {
                // Preenche dados básicos
                textBoxIDPedido.Text = pedido.ID.ToString();
                textBoxIDCliente.Text = pedido.ClienteId.ToString();
                textBoxNomeCliente.Text = pedido.Cliente.Nome;
                textBoxDocumentoCliente.Text = pedido.Cliente.ObterDocumento();
                dataGridViewTelefones.Rows.Clear();
                if (pedido.Cliente.Contatos != null)
                {
                    foreach (var contato in pedido.Cliente.Contatos.OrderBy(c => c.ID))
                    {
                        dataGridViewTelefones.Rows.Add(contato.NomeContato, contato.Telefone);
                    }
                }
                dateTimePickerDataPedido.Value = pedido.DataPedido;
                dateTimePickerEntrega.Value = pedido.DataEntrega;
                dateTimePickerRetirada.Value = pedido.DataRetirada;

                // Limpa e preenche o grid COMPLETO de uma vez
                dataGridViewProdutosLocacao.Rows.Clear();

                foreach (var item in pedido.Produtos)
                {
                    string descricaoCompleta = $"{item.Produto.Nome} {item.Produto.Material} {item.Produto.Modelo} {item.Produto.Especificacao}".Trim();

                    int estoqueDisponivel = CalcularEstoqueDisponivel(item.ProdutoId, pedido.DataPedido);

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
            dateTimePickerEntrega.Value = DateTime.Today;
            dateTimePickerRetirada.Value = DateTime.Today.AddDays(1);
            // Só define data atual se for um pedido NOVO
            if (!_pedidoId.HasValue)
            {
                dateTimePickerDataPedido.Value = DateTime.Today;
                textBoxIDPedido.Text = "Novo Pedido";
            }
        }

        private void TelaPedido_Shown(object sender, EventArgs e)
        {
            GarantirLinhaInicial();
            AtualizarPosicaoBotao();
        }
        #endregion

        #region Parte do cliente
        private void bntBuscarCliente_Click(object sender, EventArgs e)
        {
            new FormBuscarClientes().ShowDialog();
        }
        //Pega as informações necessarias do cliente e preenche as textbox
        public void PreencherCamposCliente(int id, string nome, string documento)
        {
            textBoxIDCliente.Text = id.ToString();
            textBoxNomeCliente.Text = nome;
            textBoxDocumentoCliente.Text = documento;
            // Limpar grid de contatos
            dataGridViewTelefones.Rows.Clear();

            // Buscar contatos do cliente
            using var db = new EstruturaDataBase();
            var contatos = db.Contatos
                             .Where(c => c.ClienteID == id)
                             .OrderBy(c => c.ID)
                             .ToList();

            // Preencher grid de contatos
            foreach (var contato in contatos)
            {
                dataGridViewTelefones.Rows.Add(contato.NomeContato, contato.Telefone);
            }
        }
        private void buttonEditarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIDCliente.Text))
            {
                MessageBox.Show("Nenhum cliente selecionado para edição.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = int.Parse(textBoxIDCliente.Text);

            using var db = new EstruturaDataBase();
            var cliente = db.Clientes
                            .Include(c => c.Contatos)
                            .FirstOrDefault(c => c.ID == clienteId);

            if (cliente == null)
            {
                MessageBox.Show("Cliente não encontrado no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var formCliente = new CadastroClientesForm(cliente))
            {
                if (formCliente.ShowDialog() == DialogResult.OK)
                {
                    PreencherCamposCliente(cliente.ID,
                cliente is ClientePF pf ? pf.Nome : ((ClientePJ)cliente).NomeFantasia,
                cliente.ObterDocumento());
                }
            }
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

                // Quantidade do pedido atual
                if (!int.TryParse(row.Cells["Quantidade"].Value?.ToString(), out int quantidadePedido)) quantidadePedido = 0;

                // Calcula o estoque disponível para a nova data diretamente do banco
                int estoqueDisponivel = CalcularEstoqueDisponivel(produtoId, novaData);

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

        //Parte do panel
        private void panelSaldo_Paint(object sender, PaintEventArgs e)
        {

            decimal valor;

            // Verifica se a TextBox tem um valor válido e se é maior que 0
            if (decimal.TryParse(textBoxSaldoCliente.Text, out valor) && valor > 0)
            {
                // Desenha a borda para vermelho se tiver saldo
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    Rectangle rect = new Rectangle(0, 0, panelSaldo.Width - 1, panelSaldo.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }



        }
        #endregion

        #region Parte do Botão
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
        private void bntBuscarCliente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true; // Previne que Enter seja tratado como click
            }
        }
        private void BotaoBuscarProduto_Click(object sender, EventArgs e)
        {
            AbrirBuscaProduto(linhaAtualComBotao);
        }
        #endregion

        #region Parte do Datagrid
        private bool EstaLinhaVisivel(int linha)
        {
            int primeiraVisivel = dataGridViewProdutosLocacao.FirstDisplayedScrollingRowIndex;
            if (primeiraVisivel < 0) return true;

            int totalVisiveis = dataGridViewProdutosLocacao.DisplayedRowCount(true);
            return linha >= primeiraVisivel && linha < primeiraVisivel + totalVisiveis;
        }

        private void GarantirLinhaInicial()
        {
            if (dataGridViewTelefones.Rows.Count == 0 ||
                (dataGridViewTelefones.Rows.Count == 1 && dataGridViewTelefones.Rows[0].IsNewRow))
            {
                dataGridViewTelefones.Rows.Add();
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
                int estoqueDisponivel = CalcularEstoqueDisponivel(produto.ProdutoId, dataPedido);

                row.Cells["ProdutoID"].Value = produto.ProdutoId;
                row.Cells["Produto"].Value = descricaoCompleta;
                row.Cells["Estoque"].Value = produto.QuantidadeEstoque;
                row.Cells["ValorUnitario"].Value = produto.ValorUnitario;
                row.Cells["ValorReposicao"].Value = produto.ValorReposicao;

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
            if (e.RowIndex < 0) return;

            string coluna = dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name;

            // Se alterou ProdutoID
            if (coluna == "ProdutoID")
            {
                var cellValue = dataGridViewProdutosLocacao.Rows[e.RowIndex].Cells["ProdutoID"].Value?.ToString();
                if (int.TryParse(cellValue, out int novoProdutoId) && novoProdutoId > 0)
                {
                    PreencherProdutoNoDataGridView(novoProdutoId, e.RowIndex);
                }
                return;
            }

            if (coluna != "Quantidade") return;

            var row = dataGridViewProdutosLocacao.Rows[e.RowIndex];
            if (!int.TryParse(row.Cells["ProdutoID"].Value?.ToString(), out int produtoId)) return;
            if (!int.TryParse(row.Cells["Quantidade"].Value?.ToString(), out int quantidadeNova)) return;

            int estoqueDisponivel = CalcularEstoqueDisponivel(produtoId, dateTimePickerDataPedido.Value);

            if (_pedidoId.HasValue) // Pedido existente
            {
                int quantidadeAntiga = ObterQuantidadeOriginalPedido(produtoId);
                int diferenca = quantidadeNova - quantidadeAntiga;

                if (diferenca > 0 && diferenca > estoqueDisponivel)
                {
                    MessageBox.Show($"Estoque insuficiente! Disponível: {estoqueDisponivel}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    quantidadeNova = quantidadeAntiga + estoqueDisponivel;
                    row.Cells["Quantidade"].Value = quantidadeNova;
                }
            }
            else // Novo pedido
            {
                if (quantidadeNova > estoqueDisponivel)
                {
                    MessageBox.Show($"Quantidade maior que disponível ({estoqueDisponivel})!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    quantidadeNova = estoqueDisponivel;
                    row.Cells["Quantidade"].Value = quantidadeNova;
                }
            }

            // Recalcula valor total
            decimal.TryParse(row.Cells["ValorUnitario"].Value?.ToString(), out decimal preco);
            row.Cells["ValorTotal"].Value = quantidadeNova * preco;
            AtualizarTotais();

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
                int estoqueDisponivel = CalcularEstoqueDisponivel(produtoDTO.ProdutoId, dataPedido);

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
        private int CalcularEstoqueDisponivel(int produtoId, DateTime data)
        {
            using var db = new EstruturaDataBase();

            // Busca o estoque total do produto diretamente do banco
            int estoqueTotal = db.Produtos
                .Where(p => p.ID == produtoId)
                .Select(p => p.Quantidade)
                .FirstOrDefault();

            // Soma todas as quantidades já reservadas para a data específica
            int quantidadeReservada = db.SaldosPorData
                .Where(s => s.ProdutoId == produtoId && s.Data.Date == data.Date)
                .Sum(s => s.QuantidadeReservada);

            // Calcula estoque disponível
            int disponivel = estoqueTotal - quantidadeReservada;

            // Nunca retorna valor negativo
            return Math.Max(0, disponivel);
        }

        private int ObterQuantidadeOriginalPedido(int produtoId)
        {
            return _quantidadesOriginais.TryGetValue(produtoId, out int qtd) ? qtd : 0;
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

        //Evento vinculado ao datagrid que quando troca de celula chama o metodo de visualização do botão
        private void dataGridViewProdutosLocacao_CurrentCellChanged(object sender, EventArgs e)
        {
            AtualizarPosicaoBotao();
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
                        AtualizarTotais();
                    }
                }
            }
        }
        #endregion

        #region Parte do Pagamento
        private void AtualizarSaldo()
        {
            // Pega o total do pedido
            if (!decimal.TryParse(textBoxValorTotal.Text, out decimal totalPedido))
                totalPedido = 0;

            decimal totalPago = 0;

            // Percorre as linhas do DataGrid
            foreach (DataGridViewRow row in dataGridViewPagamentos.Rows)
            {
                if (row.IsNewRow) continue;

                bool pago = false;
                decimal valor = 0;

                // Verifica se o checkbox foi marcado
                if (row.Cells["Pago"].Value != null)
                    bool.TryParse(row.Cells["Pago"].Value.ToString(), out pago);

                // Pega o valor digitado
                if (row.Cells["Valor"].Value != null)
                    decimal.TryParse(row.Cells["Valor"].Value.ToString(), out valor);

                if (pago)
                    totalPago += valor;
            }

            // Calcula saldo restante
            decimal saldo = totalPedido - totalPago;

            // Atualiza a TextBox de saldo
            textBoxSaldoPedido.Text = saldo.ToString("N2");
        }
        private void textBoxAcrescimo_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotais();
        }

        private void textBoxDesconto_TextChanged(object sender, EventArgs e)
        {
            AtualizarTotais();
        }

        private void dataGridViewPagamentos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Necessário para que o check seja "confirmado" logo ao clicar
            if (dataGridViewPagamentos.IsCurrentCellDirty)
            {
                dataGridViewPagamentos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewPagamentos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarSaldo();
            AtualizarTotais();
        }

        private void dataGridViewPagamentos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridViewPagamentos.Rows[e.RowIndex];

            bool pago = false;
            decimal valor = 0;

            // Verifica se checkbox Pago está marcada
            if (row.Cells["Pago"].Value != null)
                bool.TryParse(row.Cells["Pago"].Value.ToString(), out pago);

            // Pega o valor da célula Valor
            if (row.Cells["Valor"].Value != null)
                decimal.TryParse(row.Cells["Valor"].Value.ToString(), out valor);

            // Define a cor da linha
            if (pago)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else if (!pago && valor > 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                // Mantém cor padrão se não houver valor ou pagamento
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void AtualizarCorLinha(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridViewPagamentos.Rows.Count) return;
            var row = dataGridViewPagamentos.Rows[rowIndex];
            if (row.IsNewRow) return;

            bool pago = row.Cells["Pago"].Value != null && (bool)row.Cells["Pago"].Value;
            bool temValor = row.Cells["Valor"].Value != null && decimal.TryParse(row.Cells["Valor"].Value.ToString(), out decimal valorTemp) && valorTemp > 0;

            if (pago)
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            else if (temValor && !pago)
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            else
                row.DefaultCellStyle.BackColor = Color.White;

            // Mantém texto legível
            row.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void AtualizarTotais()
        {
            decimal subTotal = 0;
            decimal acrescimo = 0;
            decimal desconto = 0;
            decimal total = 0;
            decimal totalPago = 0;
            decimal saldo = 0;

            // Soma os valores dos produtos
            foreach (DataGridViewRow row in dataGridViewProdutosLocacao.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ValorTotal"]?.Value != null &&
                    decimal.TryParse(row.Cells["ValorTotal"].Value.ToString(), out decimal valorTotalProdutos))
                {
                    subTotal += valorTotalProdutos;
                }
            }

            // Lê acrescimo e desconto
            decimal.TryParse(textBoxAcrescimo.Text, out acrescimo);
            decimal.TryParse(textBoxDesconto.Text, out desconto);

            // Calcula valor total
            total = subTotal + acrescimo - desconto;

            // Soma pagamentos marcados como "Pago"
            foreach (DataGridViewRow row in dataGridViewPagamentos.Rows)
            {
                if (row.IsNewRow) continue;

                bool pago = false;
                if (row.Cells["Pago"] is DataGridViewCheckBoxCell checkCell && checkCell.Value != null)
                    pago = (bool)checkCell.Value;

                if (pago && row.Cells["Valor"]?.Value != null &&
                    decimal.TryParse(row.Cells["Valor"].Value.ToString(), out decimal valorPago))
                {
                    totalPago += valorPago;
                }
            }

            // Calcula saldo
            saldo = total - totalPago;

            // Atualiza as TextBox
            textBoxSubTotal.Text = subTotal.ToString("N2");
            textBoxValorTotal.Text = total.ToString("N2");
            textBoxSaldoPedido.Text = saldo.ToString("N2");
        }

        private void dataGridViewPagamentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var coluna = dataGridViewPagamentos.Columns[e.ColumnIndex].Name;

            // Formata DataPagamento
            if (coluna == "DataPagamento" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime data))
                {
                    e.Value = data.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }

            // Formata Valor como moeda
            if (coluna == "Valor" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    e.Value = valor.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewPagamentos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.PreviewKeyDown -= PagamentosEditingControl_PreviewKeyDown;
            e.Control.PreviewKeyDown += PagamentosEditingControl_PreviewKeyDown;


            // Remove handlers antigos para evitar duplicação
            e.Control.KeyPress -= MaskedDate_KeyPress;

            // Aplica apenas na coluna de DataPagamento
            if (dataGridViewPagamentos.CurrentCell.OwningColumn.Name == "DataPagamento")
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += MaskedDate_KeyPress;
                }
            }


        }

        private void MaskedDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Apenas números e backspace são permitidos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            TextBox tb = sender as TextBox;
            if (tb == null) return;

            // Se for backspace, deixa remover normalmente
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Insere a barra "/" automaticamente nos lugares corretos
            string texto = tb.Text.Replace("/", "");

            if (texto.Length == 2 || texto.Length == 4)
                tb.Text += "/";

            // Move o cursor para o final
            tb.SelectionStart = tb.Text.Length;
        }

        private void PagamentosEditingControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            var dgv = dataGridViewPagamentos;
            if (dgv.CurrentCell == null) return;

            e.IsInputKey = true;
            dgv.EndEdit();

            string colunaAtual = dgv.CurrentCell.OwningColumn.Name;
            int linhaAtual = dgv.CurrentCell.RowIndex;

            switch (colunaAtual)
            {
                case "FormaPagamento":
                    NavigateToPagamentoColumn(dgv, linhaAtual, "DataPagamento");
                    break;

                case "DataPagamento":
                    NavigateToPagamentoColumn(dgv, linhaAtual, "Valor");
                    break;

                case "Valor":
                    NavigateToPagamentoColumn(dgv, linhaAtual, "Pago");
                    break;
            }
        }

        private void NavigateToPagamentoColumn(DataGridView dgv, int row, string columnName)
        {
            BeginInvoke((Action)(() =>
            {
                if (!dgv.Columns.Contains(columnName)) return;

                int colIndex = dgv.Columns[columnName].Index;
                if (row < dgv.Rows.Count)
                {
                    dgv.CurrentCell = dgv.Rows[row].Cells[colIndex];
                    dgv.BeginEdit(true);
                }
            }));
        }

        private void dataGridViewPagamentos_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = dataGridViewPagamentos;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (dgv.CurrentCell == null) return;

                var coluna = dgv.CurrentCell.OwningColumn.Name;
                int linhaAtual = dgv.CurrentCell.RowIndex;

                // ENTER na última coluna -> próxima linha
                if (coluna == "Pago")
                {
                    int proximaLinha = linhaAtual + 1;
                    if (proximaLinha >= dgv.Rows.Count) return; // DataGrid cria automaticamente

                    NavigateToPagamentoColumn(dgv, proximaLinha, "FormaPagamento");
                }
            }

            // SPACE para alternar o check
            if (e.KeyCode == Keys.Space && dgv.CurrentCell != null && dgv.CurrentCell.OwningColumn.Name == "Pago")
            {
                e.Handled = true;
                var cell = dgv.CurrentCell as DataGridViewCheckBoxCell;

                if (cell != null)
                {
                    bool atual = cell.Value != null && (bool)cell.Value;
                    cell.Value = !atual;
                    dgv.EndEdit();
                    AtualizarSaldo();
                }
            }
        }

        // Preenche data automaticamente quando a célula recebe foco
        private void dataGridViewPagamentos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = dataGridViewPagamentos;

            if (dgv.Rows[e.RowIndex].IsNewRow)
            {
                var row = dgv.Rows[e.RowIndex];

                // Preenche valores padrão apenas quando a linha é nova
                row.Cells["DataPagamento"].Value ??= DateTime.Today;
                row.Cells["Pago"].Value ??= false;
            }
        }

        #endregion

        #region Botoes Finais
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
            var dataEntrega = dateTimePickerEntrega.Value.Date;
            var dataRetirada = dateTimePickerRetirada.Value.Date;

            using var db = new EstruturaDataBase();
            Pedido pedido;

            if (_pedidoId.HasValue) // Editar pedido existente
            {
                pedido = db.Pedidos.Include(p => p.Produtos).FirstOrDefault(p => p.ID == _pedidoId.Value);
                if (pedido == null) { MessageBox.Show("Pedido não encontrado."); return; }

                pedido.ClienteId = clienteId;
                pedido.DataPedido = dataPedido;
                pedido.DataEntrega = dataEntrega;
                pedido.DataRetirada = dataRetirada;

                var produtosExistentes = pedido.Produtos.ToList();

                foreach (DataGridViewRow row in dataGridViewProdutosLocacao.Rows)
                {
                    if (row.IsNewRow) continue;

                    int produtoId = Convert.ToInt32(row.Cells["ProdutoID"].Value);
                    int quantidadeNova = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    decimal valorUnitario = Convert.ToDecimal(row.Cells["ValorUnitario"].Value);

                    var itemExistente = produtosExistentes.FirstOrDefault(x => x.ProdutoId == produtoId);

                    int estoqueDisponivel = CalcularEstoqueDisponivel(produtoId, dataPedido); // 2 parâmetros

                    int diferenca = quantidadeNova - (itemExistente?.Quantidade ?? 0); // diferença em relação ao antigo

                    if (diferenca > 0 && diferenca > estoqueDisponivel)
                    {
                        MessageBox.Show($"Estoque insuficiente para o produto {row.Cells["Produto"].Value}. Disponível: {estoqueDisponivel}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        quantidadeNova = (itemExistente?.Quantidade ?? 0) + estoqueDisponivel;
                        row.Cells["Quantidade"].Value = quantidadeNova;
                        diferenca = estoqueDisponivel;
                    }

                    // Ajusta o saldo no banco apenas com a diferença
                    var saldo = db.SaldosPorData.FirstOrDefault(s => s.ProdutoId == produtoId && s.Data.Date == dataPedido);
                    if (saldo != null)
                    {
                        saldo.QuantidadeReservada += diferenca;
                    }
                    else
                    {
                        db.SaldosPorData.Add(new SaldoEstoqueData
                        {
                            ProdutoId = produtoId,
                            Data = dataPedido,
                            QuantidadeReservada = quantidadeNova
                        });
                    }

                    if (itemExistente != null)
                    {
                        itemExistente.Quantidade = quantidadeNova;
                        itemExistente.ValorUnitario = valorUnitario;
                        produtosExistentes.Remove(itemExistente);
                    }
                    else
                    {
                        pedido.Produtos.Add(new ProdutoPedido
                        {
                            ProdutoId = produtoId,
                            Quantidade = quantidadeNova,
                            ValorUnitario = valorUnitario
                        });
                    }
                }

                // Remove produtos que foram excluídos
                foreach (var itemRemovido in produtosExistentes)
                {
                    var saldo = db.SaldosPorData.FirstOrDefault(s => s.ProdutoId == itemRemovido.ProdutoId && s.Data.Date == dataPedido);
                    if (saldo != null) saldo.QuantidadeReservada -= itemRemovido.Quantidade;
                    pedido.Produtos.Remove(itemRemovido);
                }
            }
            else // Novo pedido
            {
                var listaProdutos = new List<ProdutoPedido>();

                foreach (DataGridViewRow row in dataGridViewProdutosLocacao.Rows)
                {
                    if (row.IsNewRow) continue;

                    int produtoId = Convert.ToInt32(row.Cells["ProdutoID"].Value);
                    int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    decimal valorUnitario = Convert.ToDecimal(row.Cells["ValorUnitario"].Value);

                    int estoqueDisponivel = CalcularEstoqueDisponivel(produtoId, dataPedido);
                    if (quantidade > estoqueDisponivel)
                    {
                        MessageBox.Show($"Estoque insuficiente para o produto {row.Cells["Produto"].Value}. Disponível: {estoqueDisponivel}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        quantidade = estoqueDisponivel;
                        row.Cells["Quantidade"].Value = quantidade;
                    }

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
                    DataEntrega = dataEntrega,
                    DataRetirada = dataRetirada,
                    Produtos = listaProdutos
                };

                db.Pedidos.Add(pedido);
            }

            db.SaveChanges();
            MessageBox.Show("Pedido salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buttonQuebra_Click(object sender, EventArgs e)
        {
            if (_pedidoId == null)
            {
                MessageBox.Show("Pedido não identificado.");
                return;
            }

            using var db = new EstruturaDataBase();

            // Verifica se já houve baixa para este pedido
            bool baixaJaRealizada = db.PerdaProdutos.Any(p => p.PedidoId == _pedidoId);

            if (baixaJaRealizada)
            {
                var resultado = MessageBox.Show(
                    "Este pedido já realizou a baixa de produtos, deseja realizar novamente?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                    return;
            }
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

            using var formQuebra = new QuebraProdutoForm(produtosParaQuebra, _pedidoId.Value);
            formQuebra.ShowDialog();

            // Se o usuário clicou OK no form, marca que houve baixa
            if (formQuebra.DialogResult == DialogResult.OK)
            {
                textBoxTotalValorQuebra.Text = formQuebra.TotalValorQuebra.ToString("C2");
                baixaRealizada = true;
            }

        }
        #endregion

    }
}