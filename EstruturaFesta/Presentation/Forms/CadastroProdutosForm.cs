using EstruturaFesta.Data.Entities;
using EstruturaFesta.Data;
using System.Data;


namespace EstruturaFesta
{
    public partial class CadastroProdutosForm : Form
    {
        private Produto _produto;
        private readonly EstruturaDataBase _db;
        public CadastroProdutosForm(EstruturaDataBase db, Produto produto = null)
        {
            InitializeComponent();

            _db = db;

            textBoxPrecoLocacao.Text = "R$";
            textBoxPrecoReposicao.Text = "R$";
            textBoxCompra.Text = "R$";

            _produto = produto;

            if (_produto != null)
                PreencherCampos();
        }
        private void PreencherCampos()
        {
            if (_produto == null) return;

            textBoxNome.Text = _produto.Nome;
            numericUpDownQuantidade.Value = _produto.Quantidade;
            textBoxPrecoLocacao.Text = $"R$ {_produto.PrecoLocacao:N2}";
            textBoxEspecificacao.Text = _produto.Especificacao;
            textBoxMaterial.Text = _produto.Material;
            textBoxModelo.Text = _produto.Modelo;
            textBoxCompra.Text = $"R$ {_produto.PrecoCompra:N2}";
            textBoxPrecoReposicao.Text = $"R$ {_produto.PrecoReposicao:N2}";
            dateTimePicker1.Value = _produto.DataCompra;
        }
        
        //Metodo generico que utiliza nas 3 textbox
        private void TextBoxPreco_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (string.IsNullOrWhiteSpace(tb.Text.Replace("R$", "").Trim()))
                {
                    tb.Text = "R$ ";
                    tb.SelectionStart = tb.Text.Length;
                }
            }
        }
        //Metodo generico que utiliza nas 3 textbox
        private void TextBoxPreco_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                string valorStr = tb.Text.Replace("R$", "").Trim();

                if (string.IsNullOrEmpty(valorStr))
                {
                    tb.Text = "R$ ";
                    tb.SelectionStart = tb.Text.Length;
                    return;
                }

                if (decimal.TryParse(valorStr, out decimal valor))
                {
                    tb.Text = $"R$ {valor:N2}";
                }
                else
                {
                    tb.Text = "R$ ";
                    tb.SelectionStart = tb.Text.Length;
                }
            }
        }

        private void BntAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNome.Focus(); // Redefine o foco para a TextBox
                return;
            }
           
            
                if (_produto == null) // Novo produto
                {
                    _produto = new Produto();
                    _db.Produtos.Add(_produto);
                }
                else
                {
                    _db.Produtos.Attach(_produto);
                }

                // Atualiza os dados do produto
                _produto.Nome = textBoxNome.Text;
                _produto.Quantidade = (int)numericUpDownQuantidade.Value;
                _produto.PrecoLocacao = Convert.ToDecimal(textBoxPrecoLocacao.Text.Replace("R$", "").Trim());
                _produto.Especificacao = textBoxEspecificacao.Text;
                _produto.Material = textBoxMaterial.Text;
                _produto.Modelo = textBoxModelo.Text;
                _produto.PrecoCompra = Convert.ToDecimal(textBoxCompra.Text.Replace("R$", "").Trim());
                _produto.PrecoReposicao = Convert.ToDecimal(textBoxPrecoReposicao.Text.Replace("R$", "").Trim());
                _produto.DataCompra = dateTimePicker1.Value;

                _db.SaveChanges();

                string mensagem = _produto.ID == 0 ? "Produto adicionado com sucesso!" : "Produto atualizado com sucesso!";
                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            
        }
    }
}
