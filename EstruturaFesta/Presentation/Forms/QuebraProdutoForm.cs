using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EstruturaFesta.Data.Entities; 
using EstruturaFesta.Data; 

namespace EstruturaFesta.Presentation.Forms
{
    public partial class QuebraProdutoForm : Form
    {
        private readonly EstruturaDataBase _db;
        private int _pedidoId;
        public List<ProdutoQuebra> ProdutosQuebra { get; private set; }
        public decimal TotalValorQuebra
        {
            get
            {
                if (decimal.TryParse(textBoxValorTotalQuebra.Text,
                                     System.Globalization.NumberStyles.Currency,
                                     null,
                                     out decimal total))
                {
                    return total;
                }
                return 0;
            }
        }
        public QuebraProdutoForm(EstruturaDataBase db, List<ProdutoQuebra> produtos, int pedidoId)
        {
            InitializeComponent();
            ProdutosQuebra = produtos;
            _pedidoId = pedidoId;

            dataGridViewQuebra.AutoGenerateColumns = false;
            dataGridViewQuebra.DataSource = ProdutosQuebra;
            AtualizarValorTotalQuebra();


        }

        private void dataGridViewQuebra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Atualiza o ValorTotalQuebra da linha (coluna bindada à propriedade da classe)
            dataGridViewQuebra.InvalidateRow(e.RowIndex);

            // Atualiza o total geral
            AtualizarValorTotalQuebra();
        }

        private void dataGridViewQuebra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewQuebra.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void AtualizarValorTotalQuebra()
        {
            decimal total = ProdutosQuebra.Sum(p => p.ValorTotal);
            textBoxValorTotalQuebra.Text = total.ToString("C2");
        }
        private void dataGridViewQuebra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                var dgv = sender as DataGridView;
                if (dgv == null) return;

                int colIndex = dgv.CurrentCell.ColumnIndex;
                int rowIndex = dgv.CurrentCell.RowIndex;


                string colunaQuebra = "QuantidadeQuebrada";

                // Se não estivermos na coluna de quebra, vai para a coluna quebra
                if (dgv.Columns[colIndex].Name != colunaQuebra)
                {
                    int quebraIndex = dgv.Columns[colunaQuebra].Index;
                    dgv.CurrentCell = dgv.Rows[rowIndex].Cells[quebraIndex];
                }
                else
                {
                    // Se já estiver na coluna de quebra, vai para o próximo produto
                    int proximaLinha = rowIndex + 1;
                    if (proximaLinha < dgv.Rows.Count)
                    {
                        dgv.CurrentCell = dgv.Rows[proximaLinha].Cells[colunaQuebra];
                    }
                }
            }
        }

        private void dataGridViewQuebra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;

            string coluna = dataGridViewQuebra.Columns[e.ColumnIndex].Name;

            if (coluna == "ValorReposicao" || coluna == "ValorTotal")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valorDecimal))
                {

                    e.Value = valorDecimal.ToString("C2");
                    e.FormattingApplied = true;
                }
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            foreach (var item in ProdutosQuebra)
            {
                if (item.QuantidadeQuebrada > item.Quantidade)
                {
                    MessageBox.Show($"Quantidade quebrada do produto {item.Nome} não pode ser maior que a quantidade do pedido.");
                    return;
                }
            }

            var produtosParaBaixa = ProdutosQuebra.Where(p => p.QuantidadeQuebrada > 0).ToList();

            if (produtosParaBaixa.Count == 0)
            {
                MessageBox.Show("Nenhum produto com quantidade para baixa.");
                return;
            }

            // Monta mensagem de confirmação
            string mensagem = "Tem certeza que deseja realizar a baixa dos produtos:\n\n";
            mensagem += string.Format("{0,-30} {1,-10} {2,10}\n", "Produto", "Qtd", "Valor");

            // Adiciona uma linha separadora
            mensagem += new string('-', 55) + "\n";

            foreach (var p in produtosParaBaixa)
            {
                mensagem += string.Format("{0,-30} {1,-10} {2,10}\n",
                    p.Nome,
                    p.QuantidadeQuebrada,
                    (p.QuantidadeQuebrada * p.ValorReposicao).ToString("C2", new System.Globalization.CultureInfo("pt-BR"))
                );
            }

            var resultado = MessageBox.Show(mensagem, "Confirmação de Baixa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
                return; // Cancela

            // Salva no banco


            foreach (var item in produtosParaBaixa)
            {
                var produtoDb = _db.Produtos.Find(item.ProdutoId);
                if (produtoDb != null)
                    produtoDb.Quantidade -= item.QuantidadeQuebrada;

                _db.PerdaProdutos.Add(new PerdaProduto
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.QuantidadeQuebrada,
                    Data = DateTime.Now,
                    PedidoId = _pedidoId // vincula a baixa ao pedido
                });
            }
            _db.SaveChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
    

