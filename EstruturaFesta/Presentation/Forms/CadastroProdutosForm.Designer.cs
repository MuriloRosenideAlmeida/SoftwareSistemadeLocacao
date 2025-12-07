
namespace EstruturaFesta
{
    partial class CadastroProdutosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxNome = new TextBox();
            labelNome = new Label();
            labelQuantidade = new Label();
            labelModelo = new Label();
            textBoxModelo = new TextBox();
            textBoxMaterial = new TextBox();
            labelMaterial = new Label();
            labelEspecificacao = new Label();
            textBoxEspecificacao = new TextBox();
            pictureBox1 = new PictureBox();
            labelImagemProduto = new Label();
            textBoxPrecoLocacao = new TextBox();
            labelPrecoLocacao = new Label();
            labelPrecoCompra = new Label();
            labelPrecoReposicao = new Label();
            labelDataCompra = new Label();
            textBoxPrecoReposicao = new TextBox();
            textBoxCompra = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            numericUpDownQuantidade = new NumericUpDown();
            bntAdicionar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantidade).BeginInit();
            SuspendLayout();
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(193, 42);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(346, 23);
            textBoxNome.TabIndex = 0;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(132, 46);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 10;
            labelNome.Text = "Nome";
            // 
            // labelQuantidade
            // 
            labelQuantidade.AutoSize = true;
            labelQuantidade.Location = new Point(103, 88);
            labelQuantidade.Name = "labelQuantidade";
            labelQuantidade.Size = new Size(69, 15);
            labelQuantidade.TabIndex = 10;
            labelQuantidade.Text = "Quantidade";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(124, 177);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(48, 15);
            labelModelo.TabIndex = 10;
            labelModelo.Text = "Modelo";
            // 
            // textBoxModelo
            // 
            textBoxModelo.Location = new Point(193, 177);
            textBoxModelo.Name = "textBoxModelo";
            textBoxModelo.Size = new Size(346, 23);
            textBoxModelo.TabIndex = 3;
            // 
            // textBoxMaterial
            // 
            textBoxMaterial.Location = new Point(193, 131);
            textBoxMaterial.Name = "textBoxMaterial";
            textBoxMaterial.Size = new Size(346, 23);
            textBoxMaterial.TabIndex = 2;
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(122, 134);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(50, 15);
            labelMaterial.TabIndex = 10;
            labelMaterial.Text = "Material";
            // 
            // labelEspecificacao
            // 
            labelEspecificacao.AutoSize = true;
            labelEspecificacao.Location = new Point(94, 221);
            labelEspecificacao.Name = "labelEspecificacao";
            labelEspecificacao.Size = new Size(78, 15);
            labelEspecificacao.TabIndex = 10;
            labelEspecificacao.Text = "Especificação";
            // 
            // textBoxEspecificacao
            // 
            textBoxEspecificacao.Location = new Point(193, 221);
            textBoxEspecificacao.Name = "textBoxEspecificacao";
            textBoxEspecificacao.Size = new Size(346, 23);
            textBoxEspecificacao.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(624, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 151);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // labelImagemProduto
            // 
            labelImagemProduto.AutoSize = true;
            labelImagemProduto.Location = new Point(620, 28);
            labelImagemProduto.Name = "labelImagemProduto";
            labelImagemProduto.Size = new Size(114, 15);
            labelImagemProduto.TabIndex = 11;
            labelImagemProduto.Text = "Imagem do Produto";
            // 
            // textBoxPrecoLocacao
            // 
            textBoxPrecoLocacao.Location = new Point(193, 264);
            textBoxPrecoLocacao.Name = "textBoxPrecoLocacao";
            textBoxPrecoLocacao.Size = new Size(85, 23);
            textBoxPrecoLocacao.TabIndex = 5;
            textBoxPrecoLocacao.TextChanged += TextBoxPreco_TextChanged;
            textBoxPrecoLocacao.Leave += TextBoxPreco_Leave;
            // 
            // labelPrecoLocacao
            // 
            labelPrecoLocacao.AutoSize = true;
            labelPrecoLocacao.Location = new Point(72, 267);
            labelPrecoLocacao.Name = "labelPrecoLocacao";
            labelPrecoLocacao.Size = new Size(100, 15);
            labelPrecoLocacao.TabIndex = 10;
            labelPrecoLocacao.Text = "Preço de Locação";
            // 
            // labelPrecoCompra
            // 
            labelPrecoCompra.AutoSize = true;
            labelPrecoCompra.Location = new Point(618, 267);
            labelPrecoCompra.Name = "labelPrecoCompra";
            labelPrecoCompra.Size = new Size(99, 15);
            labelPrecoCompra.TabIndex = 10;
            labelPrecoCompra.Text = "Preço de Compra";
            // 
            // labelPrecoReposicao
            // 
            labelPrecoReposicao.AutoSize = true;
            labelPrecoReposicao.Location = new Point(618, 224);
            labelPrecoReposicao.Name = "labelPrecoReposicao";
            labelPrecoReposicao.Size = new Size(110, 15);
            labelPrecoReposicao.TabIndex = 10;
            labelPrecoReposicao.Text = "Preço de Reposição";
            // 
            // labelDataCompra
            // 
            labelDataCompra.AutoSize = true;
            labelDataCompra.Location = new Point(618, 304);
            labelDataCompra.Name = "labelDataCompra";
            labelDataCompra.Size = new Size(93, 15);
            labelDataCompra.TabIndex = 10;
            labelDataCompra.Text = "Data da Compra";
            // 
            // textBoxPrecoReposicao
            // 
            textBoxPrecoReposicao.Location = new Point(734, 221);
            textBoxPrecoReposicao.Name = "textBoxPrecoReposicao";
            textBoxPrecoReposicao.Size = new Size(125, 23);
            textBoxPrecoReposicao.TabIndex = 6;
            textBoxPrecoReposicao.TextChanged += TextBoxPreco_TextChanged;
            textBoxPrecoReposicao.Leave += TextBoxPreco_Leave;
            // 
            // textBoxCompra
            // 
            textBoxCompra.Location = new Point(734, 264);
            textBoxCompra.Name = "textBoxCompra";
            textBoxCompra.Size = new Size(125, 23);
            textBoxCompra.TabIndex = 7;
            textBoxCompra.TextChanged += TextBoxPreco_TextChanged;
            textBoxCompra.Leave += TextBoxPreco_Leave;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(734, 304);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(125, 23);
            dateTimePicker1.TabIndex = 8;
            // 
            // numericUpDownQuantidade
            // 
            numericUpDownQuantidade.Location = new Point(193, 86);
            numericUpDownQuantidade.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            numericUpDownQuantidade.Size = new Size(85, 23);
            numericUpDownQuantidade.TabIndex = 1;
            // 
            // bntAdicionar
            // 
            bntAdicionar.Location = new Point(624, 370);
            bntAdicionar.Name = "bntAdicionar";
            bntAdicionar.Size = new Size(110, 43);
            bntAdicionar.TabIndex = 9;
            bntAdicionar.Text = "Adicionar";
            bntAdicionar.UseVisualStyleBackColor = true;
            bntAdicionar.Click += BntAdicionar_Click;
            // 
            // CadastroProdutosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 463);
            Controls.Add(bntAdicionar);
            Controls.Add(numericUpDownQuantidade);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBoxCompra);
            Controls.Add(textBoxPrecoReposicao);
            Controls.Add(labelDataCompra);
            Controls.Add(labelPrecoReposicao);
            Controls.Add(labelPrecoCompra);
            Controls.Add(labelPrecoLocacao);
            Controls.Add(textBoxPrecoLocacao);
            Controls.Add(labelImagemProduto);
            Controls.Add(pictureBox1);
            Controls.Add(textBoxEspecificacao);
            Controls.Add(labelEspecificacao);
            Controls.Add(labelMaterial);
            Controls.Add(textBoxMaterial);
            Controls.Add(textBoxModelo);
            Controls.Add(labelModelo);
            Controls.Add(labelQuantidade);
            Controls.Add(labelNome);
            Controls.Add(textBoxNome);
            Name = "CadastroProdutosForm";
            Text = "Cadastro de Produtos";
            Load += CadastroProdutosForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNome;
        private Label labelNome;
        private Label labelQuantidade;
        private Label labelModelo;
        private TextBox textBoxModelo;
        private TextBox textBoxMaterial;
        private Label labelMaterial;
        private Label labelEspecificacao;
        private TextBox textBoxEspecificacao;
        private PictureBox pictureBox1;
        private Label labelImagemProduto;
        private TextBox textBoxPrecoLocacao;
        private Label labelPrecoLocacao;
        private Label labelPrecoCompra;
        private Label labelPrecoReposicao;
        private Label labelDataCompra;
        private TextBox textBoxPrecoReposicao;
        private TextBox textBoxCompra;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDownQuantidade;
        private Button bntAdicionar;
    }
}