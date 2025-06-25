using EstruturaFesta.DataBase;
using System.Data;


namespace EstruturaFesta
{
    public partial class CadastroProdutosForm : Form
    {
        public CadastroProdutosForm()
        {
            InitializeComponent();
            textBoxPrecoLocacao.Text = "R$";
            textBoxPrecoReposicao.Text = "R$";
            textBoxCompra.Text = "R$";


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void TextBoxNome_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNome.Focus(); // Redefine o foco para a TextBox
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void TextBoxPrecoLocacao_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPrecoLocacao.Text.Replace("R$", "").Trim()))
            {
                textBoxPrecoLocacao.Text = "R$ ";
                textBoxPrecoLocacao.SelectionStart = textBoxPrecoLocacao.Text.Length;
                string textoAtual = new string(textBoxPrecoLocacao.Text.Where(char.IsDigit).ToArray());
            }
        }

        private void TextBoxCompra(object sender, EventArgs e)
        {

        }
        private void TextBoxCompra_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCompra.Text.Replace("R$", "").Trim()))
            {
                textBoxCompra.Text = "R$ ";
                textBoxCompra.SelectionStart = textBoxCompra.Text.Length;
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxPrecoReposicao_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPrecoReposicao.Text.Replace("R$", "").Trim()))
            {
                textBoxPrecoReposicao.Text = "R$ ";
                textBoxPrecoReposicao.SelectionStart = textBoxPrecoReposicao.Text.Length;
            }

        }

        private void BntAdicionar_Click(object sender, EventArgs e)
        {
            using (var context = new EstruturaDataBase())
            {
                var produto = new Produto
                {
                    Nome = textBoxNome.Text,
                    Quantidade = (int)numericUpDownQuantidade.Value,
                    PrecoLocacao = Convert.ToDecimal(textBoxPrecoLocacao.Text.Replace("R$", "").Trim()),
                    Especificacao = textBoxEspecificacao.Text,
                    Material = textBoxMaterial.Text,
                    Modelo = textBoxModelo.Text,
                    PrecoCompra = Convert.ToDecimal(textBoxCompra.Text.Replace("R$", "").Trim()),
                    PrecoReposicao = Convert.ToDecimal(textBoxPrecoReposicao.Text.Replace("R$", "").Trim()),
                    DataCompra = dateTimePicker1.Value

                };
                context.Add(produto);
                context.SaveChanges();
                MessageBox.Show("Produto adicionado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
