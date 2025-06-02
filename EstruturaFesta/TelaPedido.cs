using EstruturaFesta.Clientes;
using EstruturaFesta.DataBase;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EstruturaFesta
{
    public partial class TelaPedido : Form
    {
        private Button botaoBuscarProduto;
        private int linhaAtualComBotao = 0;

        public TelaPedido()
        {
            InitializeComponent();
            ConfigurarBotaoBuscaProduto();

            dataGridViewProdutosLocacao.Resize += (s, e) => AtualizarPosicaoBotao();
            dataGridViewProdutosLocacao.Scroll += (s, e) => AtualizarPosicaoBotao();
            dataGridViewProdutosLocacao.RowsAdded += (s, e) => AtualizarPosicaoBotao();
            dataGridViewProdutosLocacao.RowsRemoved += (s, e) => AtualizarPosicaoBotao();
            this.Shown += TelaPedido_Shown;
        }

        private void TelaPedido_Shown(object sender, EventArgs e)
        {
            GarantirLinhaInicial();
            AtualizarPosicaoBotao();
        }

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

        private void AtualizarPosicaoBotao()
        {
            if (dataGridViewProdutosLocacao.Rows.Count == 0)
            {
                botaoBuscarProduto.Visible = false;
                return;
            }

            int linhaDisponivel = -1;

            for (int i = 0; i < dataGridViewProdutosLocacao.Rows.Count; i++)
            {
                var row = dataGridViewProdutosLocacao.Rows[i];
                if (row.IsNewRow) continue;

                if (ProdutoIdEstaVazio(row))
                {
                    linhaDisponivel = i;
                    break;
                }
            }

            if (linhaDisponivel == -1)
            {
                if (dataGridViewProdutosLocacao.AllowUserToAddRows &&
                    !dataGridViewProdutosLocacao.Rows[^1].IsNewRow)
                {
                    dataGridViewProdutosLocacao.Rows.Add();
                    linhaDisponivel = dataGridViewProdutosLocacao.Rows.Count - 2;
                }
                else
                {
                    botaoBuscarProduto.Visible = false;
                    return;
                }
            }

            linhaAtualComBotao = linhaDisponivel;

            if (!dataGridViewProdutosLocacao.Columns.Contains("Produto"))
            {
                botaoBuscarProduto.Visible = false;
                return;
            }

            if (EstaLinhaVisivel(linhaDisponivel))
            {
                var cellRect = dataGridViewProdutosLocacao.GetCellDisplayRectangle(
                    dataGridViewProdutosLocacao.Columns["Produto"].Index, linhaDisponivel, false);

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
            else
            {
                botaoBuscarProduto.Visible = false;
            }
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
            using var buscaForm = new FormBuscaProduto();
            if (buscaForm.ShowDialog() == DialogResult.OK)
            {
                var produto = buscaForm.ProdutoSelecionado;
                var row = dataGridViewProdutosLocacao.Rows[linha];

                // Junta as características em uma descrição única
                string descricaoCompleta = $"{produto.Nome} {produto.Material} {produto.Modelo} {produto.Especificacao}".Trim();

                row.Cells["Produto"].Value = descricaoCompleta;
                row.Cells["Estoque"].Value = produto.QuantidadeEstoque;
                row.Cells["ValorUnitario"].Value = produto.ValorUnitario;

                AtualizarPosicaoBotao();
            }
        }

        private void dataGridViewProdutosLocacao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridViewProdutosLocacao.Rows[e.RowIndex];
            string coluna = dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name;

            if (coluna == "Produto")
            {
                if (int.TryParse(row.Cells["Produto"].Value?.ToString(), out int idProduto))
                {
                    using var db = new EstruturaDataBase();
                    var produto = db.Produtos.FirstOrDefault(p => p.ID == idProduto);

                    if (produto != null)
                    {
                        // Monta a descrição completa do produto
                        string descricaoCompleta = $"{produto.Nome} {produto.Material} {produto.Modelo} {produto.Especificacao}".Trim();

                        row.Cells["Produto"].Value = descricaoCompleta;
                        row.Cells["Estoque"].Value = produto.Quantidade;
                        row.Cells["ValorUnitario"].Value = produto.PrecoLocacao;
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                        row.Cells["Produto"].Value = null;
                    }
                }

                AtualizarPosicaoBotao();
            }
            else if (coluna == "Quantidade")
            {
                int.TryParse(row.Cells["Quantidade"].Value?.ToString(), out int quantidade);
                int.TryParse(row.Cells["Estoque"].Value?.ToString(), out int estoque);
                decimal.TryParse(row.Cells["ValorUnitario"].Value?.ToString(), out decimal preco);

                string descricaoProduto = row.Cells["Produto"].Value?.ToString();

                using var db = new EstruturaDataBase();
                var dataPedido = dateTimePickerDataPedido.Value.Date;

                var produto = db.Produtos.FirstOrDefault(p =>
                    (p.Nome + " " + p.Material + " " + p.Modelo + " " + p.Especificacao).Trim() == descricaoProduto);

                if (produto != null)
                {
                    int quantidadeJaReservada = db.SaldosPorData
                        .Where(s => s.ProdutoId == produto.ID && s.Data == dataPedido)
                        .Sum(s => s.QuantidadeReservada);

                    int disponivel = produto.Quantidade - quantidadeJaReservada;

                    if (quantidade > disponivel)
                    {
                        MessageBox.Show($"Quantidade maior que disponível ({disponivel})!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Grava a reserva
                        db.SaldosPorData.Add(new SaldoEstoqueData
                        {
                            ProdutoId = produto.ID,
                            Data = dataPedido,
                            QuantidadeReservada = quantidade
                        });

                        db.SaveChanges();
                    }
                }

                row.Cells["ValorTotal"].Value = quantidade * preco;
            }
        }

        public void PreencherCamposCliente(int id, string nome, string documento)
        {
            textBoxIDCliente.Text = id.ToString();
            textBoxNomeCliente.Text = nome;
            textBoxDocumentoCliente.Text = documento;
        }

        private void bntBuscarCliente_Click(object sender, EventArgs e)
        {
            new FormDataGridView().ShowDialog();
        }

        private void dataGridViewProdutosLocacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                var dgv = dataGridViewProdutosLocacao;
                int col = dgv.CurrentCell.ColumnIndex;
                int row = dgv.CurrentCell.RowIndex;

                dgv.EndEdit(); // Finaliza edição atual

                // Tenta ir para próxima célula
                if (col < dgv.ColumnCount - 1)
                {
                    col++;
                }
                else
                {
                    // Vai para a primeira célula da próxima linha
                    col = 0;
                    row++;
                    if (row >= dgv.RowCount)
                    {
                        dgv.Rows.Add(); // adiciona nova linha se estiver na última
                    }
                }

                dgv.CurrentCell = dgv[col, row];
                dgv.BeginEdit(true);
            }
        }

        private void dataGridViewProdutosLocacao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "Quantidade" ||
        dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "Estoque")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int valorInt))
                {
                    e.Value = valorInt.ToString();
                    e.FormattingApplied = true;
                }
            }

            if (dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "ValorUnitario" ||
                dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "ValorTotal")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal valorDecimal))
                {
                    e.Value = valorDecimal.ToString("N2"); // Duas casas decimais, com vírgula
                    e.FormattingApplied = true;
                }
            }
        }

        private void bntBuscarCliente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true; // Previne que Enter seja tratado como click
            }
        }
    }
}