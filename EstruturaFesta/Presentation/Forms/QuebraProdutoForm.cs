using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EstruturaFesta.Domain.Entities; 
using EstruturaFesta.Infrastructure.Data; 

namespace EstruturaFesta.Presentation.Forms
{
    public partial class QuebraProdutoForm : Form
    {
        public List<ProdutoQuebra> ProdutosQuebra { get; private set; }
        public QuebraProdutoForm(List<ProdutoQuebra> produtos)
        {
            InitializeComponent();
            ProdutosQuebra = produtos;

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
            using (var context = new EstruturaDataBase())
            {
                foreach (var item in ProdutosQuebra)
                {
                    if (item.QuantidadeQuebrada > 0)
                    {
                        var produtoDb = context.Produtos.Find(item.ProdutoId);
                        produtoDb.Quantidade -= item.QuantidadeQuebrada;

                        context.PerdaProdutos.Add(new PerdaProduto
                        {
                            ProdutoId = item.ProdutoId,
                            Quantidade = item.QuantidadeQuebrada,
                            Data = DateTime.Now,

                        });
                    }
                }
                context.SaveChanges();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
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
    }
}
    

