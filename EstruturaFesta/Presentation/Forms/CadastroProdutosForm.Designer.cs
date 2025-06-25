
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxModelo = new TextBox();
            textBoxMaterial = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBoxEspecificacao = new TextBox();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            textBoxPrecoLocacao = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
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
            textBoxNome.Leave += TextBoxNome_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 46);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 10;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 88);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 10;
            label2.Text = "Quantidade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 177);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 10;
            label3.Text = "Modelo";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(122, 134);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 10;
            label4.Text = "Material";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(94, 221);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 10;
            label5.Text = "Especificação";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(620, 28);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 11;
            label6.Text = "Imagem do Produto";
            label6.Click += label6_Click;
            // 
            // textBoxPrecoLocacao
            // 
            textBoxPrecoLocacao.Location = new Point(193, 264);
            textBoxPrecoLocacao.Name = "textBoxPrecoLocacao";
            textBoxPrecoLocacao.Size = new Size(85, 23);
            textBoxPrecoLocacao.TabIndex = 5;
            textBoxPrecoLocacao.TextChanged += TextBoxPrecoLocacao_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 267);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.TabIndex = 10;
            label7.Text = "Preço de Locação";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(618, 267);
            label8.Name = "label8";
            label8.Size = new Size(99, 15);
            label8.TabIndex = 10;
            label8.Text = "Preço de Compra";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(618, 224);
            label9.Name = "label9";
            label9.Size = new Size(110, 15);
            label9.TabIndex = 10;
            label9.Text = "Preço de Reposição";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(618, 304);
            label10.Name = "label10";
            label10.Size = new Size(93, 15);
            label10.TabIndex = 10;
            label10.Text = "Data da Compra";
            // 
            // textBoxPrecoReposicao
            // 
            textBoxPrecoReposicao.Location = new Point(734, 221);
            textBoxPrecoReposicao.Name = "textBoxPrecoReposicao";
            textBoxPrecoReposicao.Size = new Size(125, 23);
            textBoxPrecoReposicao.TabIndex = 6;
            textBoxPrecoReposicao.TextChanged += TextBoxPrecoReposicao_Changed;
            // 
            // textBoxCompra
            // 
            textBoxCompra.Location = new Point(734, 264);
            textBoxCompra.Name = "textBoxCompra";
            textBoxCompra.Size = new Size(125, 23);
            textBoxCompra.TabIndex = 7;
            textBoxCompra.TextChanged += TextBoxCompra_Changed;
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
            // CadastroProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 463);
            Controls.Add(bntAdicionar);
            Controls.Add(numericUpDownQuantidade);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBoxCompra);
            Controls.Add(textBoxPrecoReposicao);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxPrecoLocacao);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(textBoxEspecificacao);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxMaterial);
            Controls.Add(textBoxModelo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxNome);
            Name = "CadastroProdutos";
            Text = "CadastroProdutos";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNome;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxModelo;
        private TextBox textBoxMaterial;
        private Label label4;
        private Label label5;
        private TextBox textBoxEspecificacao;
        private PictureBox pictureBox1;
        private Label label6;
        private TextBox textBoxPrecoLocacao;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBoxPrecoReposicao;
        private TextBox textBoxCompra;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDownQuantidade;
        private Button bntAdicionar;
    }
}