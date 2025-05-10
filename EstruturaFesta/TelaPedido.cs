using EstruturaFesta.Clientes;
using EstruturaFesta.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EstruturaFesta
{
    public partial class TelaPedido : Form
    {
        public TelaPedido()
        {
            InitializeComponent();

        }

        private void comboBoxIDCliente_DropDown(object sender, EventArgs e)
        {
            FormDataGridView formDataGridView = new FormDataGridView();
            formDataGridView.ShowDialog();
        }

        public void PreencherCamposCliente(int id, string nome, string documento)
        {
            textBoxIDCliente.Text = id.ToString();
            textBoxNomeCliente.Text = nome;
            textBoxDocumentoCliente.Text = documento;

        }

        private void comboBoxIDCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bntBuscarCliente_Click(object sender, EventArgs e)
        {
            FormDataGridView formDataGridView = new FormDataGridView();
            formDataGridView.ShowDialog();
        }

        private void dataGridViewProdutosLocacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name == "ProdutoId")
            {
                // Chamar o formulário de busca de produtos
                using (var buscaForm = new FormBuscaProduto()) // você vai criar esse form
                {
                    if (buscaForm.ShowDialog() == DialogResult.OK)
                    {
                        var produtoSelecionado = buscaForm.ProdutoSelecionado;

                        var row = dataGridViewProdutosLocacao.Rows[e.RowIndex];
                        row.Cells["ProdutoId"].Value = produtoSelecionado.ID;
                        row.Cells["Descricao"].Value = produtoSelecionado.Especificacao;
                        row.Cells["Estoque"].Value = produtoSelecionado.Quantidade;
                        row.Cells["ValorUnitario"].Value = produtoSelecionado.PrecoLocacao;
                    }
                }
            }
        }

        private void dataGridViewProdutosLocacao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridViewProdutosLocacao.Rows[e.RowIndex];
            string columnName = dataGridViewProdutosLocacao.Columns[e.ColumnIndex].Name;

            if (columnName == "ProdutoId")
            {
                if (int.TryParse(row.Cells["ProdutoId"].Value?.ToString(), out int idProduto))
                {
                    using (var db = new EstruturaDataBase())
                    {
                        var produto = db.Produtos.FirstOrDefault(p => p.ID == idProduto);

                        if (produto != null)
                        {
                            row.Cells["Descricao"].Value = produto.Especificacao;
                            row.Cells["Estoque"].Value = produto.Quantidade;
                            row.Cells["ValorUnitario"].Value = produto.PrecoLocacao;
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado.");
                            row.Cells["ProdutoId"].Value = null;
                        }
                    }
                }
            }
            else if (columnName == "Quantidade")
            {
                int.TryParse(row.Cells["Quantidade"].Value?.ToString(), out int quantidade);
                int.TryParse(row.Cells["Estoque"].Value?.ToString(), out int estoque);
                decimal.TryParse(row.Cells["ValorUnitario"].Value?.ToString(), out decimal preco);

                row.Cells["Faltas"].Value = estoque - quantidade;

                if (quantidade > estoque)
                {
                    MessageBox.Show("Quantidade maior que o estoque disponível!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                row.Cells["ValorTotal"].Value = quantidade * preco;
            }
        }
    }
    
}