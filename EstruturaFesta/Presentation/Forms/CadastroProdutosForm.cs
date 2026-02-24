using EstruturaFesta.Data.Entities;
using EstruturaFesta.Data;
using System.Data;
using EstruturaFesta.Utils;
using EstruturaFesta.Design;


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
            _produto = produto;

            if (_produto != null)
                PreencherCampos();
        }
        private void CadastroProdutosForm_Load(object sender, EventArgs e)
        {
            SistemaUpperCase.AplicarMaiusculo(this);

            if (_produto == null)
            {
                designButtonExcluir.Visible = false;
            }
        }
        private void PreencherCampos()
        {
            if (_produto == null) return;
            designTextBoxNome.Text = _produto.Nome;
            numericUpDownQuantidade.Value = _produto.Quantidade;
            designTextBoxPrecoLocacao.Text = $"R$ {_produto.PrecoLocacao:N2}";
            designTextBoxEspecificacao.Text = _produto.Especificacao;
            designTextBoxMaterial.Text = _produto.Material;
            designTextBoxModelo.Text = _produto.Modelo;
            designTextBoxPrecoCompra.Text = $"R$ {_produto.PrecoCompra:N2}";
            designTextBoxPrecoReposicao.Text = $"R$ {_produto.PrecoReposicao:N2}";
            dateTimePicker1.Value = _produto.DataCompra;
            if (!string.IsNullOrEmpty(_produto.NomeImagem))
            {
                string caminhoImagem = Path.Combine(
                    Application.StartupPath,
                    "ImagensProdutos",
                    _produto.NomeImagem);

                if (File.Exists(caminhoImagem))
                {
                    pictureBoxProduto.Image = Image.FromFile(caminhoImagem);
                    pictureBoxProduto.Tag = _produto.NomeImagem;
                }
            }
        }

        //Metodo generico que utiliza nas 3 textbox
        private void TextBoxPreco_TextChanged(object sender, EventArgs e)
        {
            if (sender is DesignTextBox dtb)
            {
                if (string.IsNullOrWhiteSpace(dtb.Text.Replace("R$", "").Trim()))
                {
                    dtb.Text = "R$ ";
                    dtb.SelectionStart = dtb.Text.Length;
                }
            }
        }
        //Metodo generico que utiliza nas 3 textbox
        private void TextBoxPreco_Leave(object sender, EventArgs e)
        {
            if (sender is DesignTextBox dtb)
            {
                string valorStr = dtb.Text.Replace("R$", "").Trim();

                if (string.IsNullOrEmpty(valorStr))
                {
                    dtb.Text = "R$ ";
                    dtb.SelectionStart = dtb.Text.Length;
                    return;
                }

                if (decimal.TryParse(valorStr, out decimal valor))
                {
                    dtb.Text = $"R$ {valor:N2}";
                }
                else
                {
                    dtb.Text = "R$ ";
                    dtb.SelectionStart = dtb.Text.Length;
                }
            }
        }

        private void designButtonAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(designTextBoxNome.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                designTextBoxNome.Focus(); // Redefine o foco para a TextBox
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
            _produto.Nome = designTextBoxNome.Text;
            _produto.Quantidade = (int)numericUpDownQuantidade.Value;
            _produto.PrecoLocacao = Convert.ToDecimal(designTextBoxPrecoLocacao.Text.Replace("R$", "").Trim());
            _produto.Especificacao = designTextBoxEspecificacao.Text;
            _produto.Material = designTextBoxMaterial.Text;
            _produto.Modelo = designTextBoxModelo.Text;
            _produto.PrecoCompra = Convert.ToDecimal(designTextBoxPrecoCompra.Text.Replace("R$", "").Trim());
            _produto.PrecoReposicao = Convert.ToDecimal(designTextBoxPrecoReposicao.Text.Replace("R$", "").Trim());
            _produto.DataCompra = dateTimePicker1.Value;
            _produto.NomeImagem = pictureBoxProduto.Tag?.ToString();

            _db.SaveChanges();

            string mensagem = _produto.ID == 0 ? "Produto adicionado com sucesso!" : "Produto atualizado com sucesso!";
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

        }

        private void designButtonExcluir_Click(object sender, EventArgs e)
        {
            if (_produto == null)
            {
                MessageBox.Show("Nenhum produto selecionado para exclusão.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                $"Tem certeza que deseja excluir o produto: \n\n" + $"{_produto.Nome} " +
                $"{_produto.Modelo} " +
                $"{_produto.Material} " +
                $"{_produto.Especificacao}\n\n" +
                $"Esta ação não poderá ser desfeita.",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    _db.Produtos.Remove(_produto);
                    if (!string.IsNullOrEmpty(_produto.NomeImagem))
                    {
                        string caminhoImagem = Path.Combine(
                            Application.StartupPath,
                            "ImagensProdutos",
                            _produto.NomeImagem);

                        if (File.Exists(caminhoImagem))
                            File.Delete(caminhoImagem);
                    }
                    _db.SaveChanges();

                    MessageBox.Show("Produto excluído com sucesso!",
                                    "Sucesso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir o produto.\n" + ex.Message,
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void iconPictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string pastaDestino = Path.Combine(
                        Application.StartupPath,
                        "ImagensProdutos");

                    if (!Directory.Exists(pastaDestino))
                        Directory.CreateDirectory(pastaDestino);
                    if (pictureBoxProduto.Tag != null)
                    {
                        string imagemAntiga = Path.Combine(
                            pastaDestino,
                            pictureBoxProduto.Tag.ToString());

                        if (pictureBoxProduto.Image != null)
                        {
                            pictureBoxProduto.Image.Dispose();
                            pictureBoxProduto.Image = null;
                        }
                        if (File.Exists(imagemAntiga))
                            File.Delete(imagemAntiga);
                    }

                    string nomeArquivo = Guid.NewGuid().ToString() +
                                         Path.GetExtension(ofd.FileName);

                    string caminhoFinal = Path.Combine(pastaDestino, nomeArquivo);

                    File.Copy(ofd.FileName, caminhoFinal, true);

                    using (var imgTemp = Image.FromFile(caminhoFinal))
                    {
                        pictureBoxProduto.Image = new Bitmap(imgTemp);
                    }

                    pictureBoxProduto.Tag = nomeArquivo;
                }
            }
        }
    }
}
