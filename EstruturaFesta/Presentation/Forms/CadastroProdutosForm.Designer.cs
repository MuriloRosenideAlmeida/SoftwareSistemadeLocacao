
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
            labelQuantidade = new Label();
            labelModelo = new Label();
            labelMaterial = new Label();
            labelEspecificacao = new Label();
            pictureBoxProduto = new PictureBox();
            labelImagemProduto = new Label();
            labelPrecoLocacao = new Label();
            labelPrecoCompra = new Label();
            labelPrecoReposicao = new Label();
            labelDataCompra = new Label();
            dateTimePicker1 = new DateTimePicker();
            numericUpDownQuantidade = new NumericUpDown();
            designTextBoxNome = new Design.DesignTextBox();
            labelNome = new Label();
            designTextBoxMaterial = new Design.DesignTextBox();
            designTextBoxModelo = new Design.DesignTextBox();
            designTextBoxEspecificacao = new Design.DesignTextBox();
            designTextBoxPrecoLocacao = new Design.DesignTextBox();
            designTextBoxPrecoReposicao = new Design.DesignTextBox();
            designTextBoxPrecoCompra = new Design.DesignTextBox();
            designButtonAdicionar = new Design.DesignButton();
            designButtonExcluir = new Design.DesignButton();
            iconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // labelQuantidade
            // 
            labelQuantidade.AutoSize = true;
            labelQuantidade.Location = new Point(103, 97);
            labelQuantidade.Name = "labelQuantidade";
            labelQuantidade.Size = new Size(69, 15);
            labelQuantidade.TabIndex = 0;
            labelQuantidade.Text = "Quantidade";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(123, 211);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(48, 15);
            labelModelo.TabIndex = 0;
            labelModelo.Text = "Modelo";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(121, 148);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(50, 15);
            labelMaterial.TabIndex = 0;
            labelMaterial.Text = "Material";
            // 
            // labelEspecificacao
            // 
            labelEspecificacao.AutoSize = true;
            labelEspecificacao.Location = new Point(95, 272);
            labelEspecificacao.Name = "labelEspecificacao";
            labelEspecificacao.Size = new Size(78, 15);
            labelEspecificacao.TabIndex = 0;
            labelEspecificacao.Text = "Especificação";
            // 
            // pictureBoxProduto
            // 
            pictureBoxProduto.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxProduto.Location = new Point(624, 46);
            pictureBoxProduto.Name = "pictureBoxProduto";
            pictureBoxProduto.Size = new Size(174, 151);
            pictureBoxProduto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProduto.TabIndex = 10;
            pictureBoxProduto.TabStop = false;
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
            // labelPrecoLocacao
            // 
            labelPrecoLocacao.AutoSize = true;
            labelPrecoLocacao.Location = new Point(73, 334);
            labelPrecoLocacao.Name = "labelPrecoLocacao";
            labelPrecoLocacao.Size = new Size(100, 15);
            labelPrecoLocacao.TabIndex = 0;
            labelPrecoLocacao.Text = "Preço de Locação";
            // 
            // labelPrecoCompra
            // 
            labelPrecoCompra.AutoSize = true;
            labelPrecoCompra.Location = new Point(618, 267);
            labelPrecoCompra.Name = "labelPrecoCompra";
            labelPrecoCompra.Size = new Size(99, 15);
            labelPrecoCompra.TabIndex = 0;
            labelPrecoCompra.Text = "Preço de Compra";
            // 
            // labelPrecoReposicao
            // 
            labelPrecoReposicao.AutoSize = true;
            labelPrecoReposicao.Location = new Point(618, 224);
            labelPrecoReposicao.Name = "labelPrecoReposicao";
            labelPrecoReposicao.Size = new Size(110, 15);
            labelPrecoReposicao.TabIndex = 0;
            labelPrecoReposicao.Text = "Preço de Reposição";
            // 
            // labelDataCompra
            // 
            labelDataCompra.AutoSize = true;
            labelDataCompra.Location = new Point(618, 304);
            labelDataCompra.Name = "labelDataCompra";
            labelDataCompra.Size = new Size(93, 15);
            labelDataCompra.TabIndex = 0;
            labelDataCompra.Text = "Data da Compra";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(735, 304);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(140, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // numericUpDownQuantidade
            // 
            numericUpDownQuantidade.Location = new Point(193, 95);
            numericUpDownQuantidade.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownQuantidade.Name = "numericUpDownQuantidade";
            numericUpDownQuantidade.Size = new Size(85, 23);
            numericUpDownQuantidade.TabIndex = 2;
            // 
            // designTextBoxNome
            // 
            designTextBoxNome.BackColor = SystemColors.Window;
            designTextBoxNome.BorderColor = Color.MediumSlateBlue;
            designTextBoxNome.BorderFocusColor = Color.HotPink;
            designTextBoxNome.BorderRadius = 16;
            designTextBoxNome.BorderSize = 1;
            designTextBoxNome.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNome.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNome.ForeColor = SystemColors.WindowText;
            designTextBoxNome.Location = new Point(193, 41);
            designTextBoxNome.Multiline = false;
            designTextBoxNome.Name = "designTextBoxNome";
            designTextBoxNome.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNome.PasswordChar = false;
            designTextBoxNome.PlaceholderColor = Color.DarkGray;
            designTextBoxNome.PlaceholderText = "Nome do Produto";
            designTextBoxNome.SelectionLength = 0;
            designTextBoxNome.SelectionStart = 0;
            designTextBoxNome.Size = new Size(346, 32);
            designTextBoxNome.TabIndex = 1;
            designTextBoxNome.UnderlinedStyle = false;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(132, 51);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome";
            // 
            // designTextBoxMaterial
            // 
            designTextBoxMaterial.BackColor = SystemColors.Window;
            designTextBoxMaterial.BorderColor = Color.MediumSlateBlue;
            designTextBoxMaterial.BorderFocusColor = Color.HotPink;
            designTextBoxMaterial.BorderRadius = 16;
            designTextBoxMaterial.BorderSize = 1;
            designTextBoxMaterial.CharacterCasing = CharacterCasing.Normal;
            designTextBoxMaterial.Font = new Font("Segoe UI", 9.5F);
            designTextBoxMaterial.ForeColor = SystemColors.WindowText;
            designTextBoxMaterial.Location = new Point(192, 141);
            designTextBoxMaterial.Multiline = false;
            designTextBoxMaterial.Name = "designTextBoxMaterial";
            designTextBoxMaterial.Padding = new Padding(10, 7, 10, 7);
            designTextBoxMaterial.PasswordChar = false;
            designTextBoxMaterial.PlaceholderColor = Color.DarkGray;
            designTextBoxMaterial.PlaceholderText = "Tipo de Material";
            designTextBoxMaterial.SelectionLength = 0;
            designTextBoxMaterial.SelectionStart = 0;
            designTextBoxMaterial.Size = new Size(347, 32);
            designTextBoxMaterial.TabIndex = 3;
            designTextBoxMaterial.UnderlinedStyle = false;
            // 
            // designTextBoxModelo
            // 
            designTextBoxModelo.BackColor = SystemColors.Window;
            designTextBoxModelo.BorderColor = Color.MediumSlateBlue;
            designTextBoxModelo.BorderFocusColor = Color.HotPink;
            designTextBoxModelo.BorderRadius = 16;
            designTextBoxModelo.BorderSize = 1;
            designTextBoxModelo.CharacterCasing = CharacterCasing.Normal;
            designTextBoxModelo.Font = new Font("Segoe UI", 9.5F);
            designTextBoxModelo.ForeColor = SystemColors.WindowText;
            designTextBoxModelo.Location = new Point(193, 207);
            designTextBoxModelo.Multiline = false;
            designTextBoxModelo.Name = "designTextBoxModelo";
            designTextBoxModelo.Padding = new Padding(10, 7, 10, 7);
            designTextBoxModelo.PasswordChar = false;
            designTextBoxModelo.PlaceholderColor = Color.DarkGray;
            designTextBoxModelo.PlaceholderText = "Nome do Modelo";
            designTextBoxModelo.SelectionLength = 0;
            designTextBoxModelo.SelectionStart = 0;
            designTextBoxModelo.Size = new Size(346, 32);
            designTextBoxModelo.TabIndex = 4;
            designTextBoxModelo.UnderlinedStyle = false;
            // 
            // designTextBoxEspecificacao
            // 
            designTextBoxEspecificacao.BackColor = SystemColors.Window;
            designTextBoxEspecificacao.BorderColor = Color.MediumSlateBlue;
            designTextBoxEspecificacao.BorderFocusColor = Color.HotPink;
            designTextBoxEspecificacao.BorderRadius = 16;
            designTextBoxEspecificacao.BorderSize = 1;
            designTextBoxEspecificacao.CharacterCasing = CharacterCasing.Normal;
            designTextBoxEspecificacao.Font = new Font("Segoe UI", 9.5F);
            designTextBoxEspecificacao.ForeColor = SystemColors.WindowText;
            designTextBoxEspecificacao.Location = new Point(193, 267);
            designTextBoxEspecificacao.Multiline = false;
            designTextBoxEspecificacao.Name = "designTextBoxEspecificacao";
            designTextBoxEspecificacao.Padding = new Padding(10, 7, 10, 7);
            designTextBoxEspecificacao.PasswordChar = false;
            designTextBoxEspecificacao.PlaceholderColor = Color.DarkGray;
            designTextBoxEspecificacao.PlaceholderText = "Tipo de Especificação";
            designTextBoxEspecificacao.SelectionLength = 0;
            designTextBoxEspecificacao.SelectionStart = 0;
            designTextBoxEspecificacao.Size = new Size(347, 32);
            designTextBoxEspecificacao.TabIndex = 5;
            designTextBoxEspecificacao.UnderlinedStyle = false;
            // 
            // designTextBoxPrecoLocacao
            // 
            designTextBoxPrecoLocacao.BackColor = SystemColors.Window;
            designTextBoxPrecoLocacao.BorderColor = Color.MediumSlateBlue;
            designTextBoxPrecoLocacao.BorderFocusColor = Color.HotPink;
            designTextBoxPrecoLocacao.BorderRadius = 16;
            designTextBoxPrecoLocacao.BorderSize = 1;
            designTextBoxPrecoLocacao.CharacterCasing = CharacterCasing.Normal;
            designTextBoxPrecoLocacao.Font = new Font("Segoe UI", 9.5F);
            designTextBoxPrecoLocacao.ForeColor = SystemColors.WindowText;
            designTextBoxPrecoLocacao.Location = new Point(193, 327);
            designTextBoxPrecoLocacao.Multiline = false;
            designTextBoxPrecoLocacao.Name = "designTextBoxPrecoLocacao";
            designTextBoxPrecoLocacao.Padding = new Padding(10, 7, 10, 7);
            designTextBoxPrecoLocacao.PasswordChar = false;
            designTextBoxPrecoLocacao.PlaceholderColor = SystemColors.WindowText;
            designTextBoxPrecoLocacao.PlaceholderText = "R$";
            designTextBoxPrecoLocacao.SelectionLength = 0;
            designTextBoxPrecoLocacao.SelectionStart = 0;
            designTextBoxPrecoLocacao.Size = new Size(123, 32);
            designTextBoxPrecoLocacao.TabIndex = 6;
            designTextBoxPrecoLocacao.UnderlinedStyle = false;
            designTextBoxPrecoLocacao._TextChanged += TextBoxPreco_TextChanged;
            designTextBoxPrecoLocacao.Leave += TextBoxPreco_Leave;
            // 
            // designTextBoxPrecoReposicao
            // 
            designTextBoxPrecoReposicao.BackColor = SystemColors.Window;
            designTextBoxPrecoReposicao.BorderColor = Color.MediumSlateBlue;
            designTextBoxPrecoReposicao.BorderFocusColor = Color.HotPink;
            designTextBoxPrecoReposicao.BorderRadius = 16;
            designTextBoxPrecoReposicao.BorderSize = 1;
            designTextBoxPrecoReposicao.CharacterCasing = CharacterCasing.Normal;
            designTextBoxPrecoReposicao.Font = new Font("Segoe UI", 9.5F);
            designTextBoxPrecoReposicao.ForeColor = SystemColors.WindowText;
            designTextBoxPrecoReposicao.Location = new Point(734, 216);
            designTextBoxPrecoReposicao.Multiline = false;
            designTextBoxPrecoReposicao.Name = "designTextBoxPrecoReposicao";
            designTextBoxPrecoReposicao.Padding = new Padding(10, 7, 10, 7);
            designTextBoxPrecoReposicao.PasswordChar = false;
            designTextBoxPrecoReposicao.PlaceholderColor = SystemColors.WindowText;
            designTextBoxPrecoReposicao.PlaceholderText = "R$";
            designTextBoxPrecoReposicao.SelectionLength = 0;
            designTextBoxPrecoReposicao.SelectionStart = 0;
            designTextBoxPrecoReposicao.Size = new Size(140, 32);
            designTextBoxPrecoReposicao.TabIndex = 7;
            designTextBoxPrecoReposicao.UnderlinedStyle = false;
            designTextBoxPrecoReposicao._TextChanged += TextBoxPreco_TextChanged;
            designTextBoxPrecoReposicao.Leave += TextBoxPreco_Leave;
            // 
            // designTextBoxPrecoCompra
            // 
            designTextBoxPrecoCompra.BackColor = SystemColors.Window;
            designTextBoxPrecoCompra.BorderColor = Color.MediumSlateBlue;
            designTextBoxPrecoCompra.BorderFocusColor = Color.HotPink;
            designTextBoxPrecoCompra.BorderRadius = 16;
            designTextBoxPrecoCompra.BorderSize = 1;
            designTextBoxPrecoCompra.CharacterCasing = CharacterCasing.Normal;
            designTextBoxPrecoCompra.Font = new Font("Segoe UI", 9.5F);
            designTextBoxPrecoCompra.ForeColor = SystemColors.WindowText;
            designTextBoxPrecoCompra.Location = new Point(734, 260);
            designTextBoxPrecoCompra.Multiline = false;
            designTextBoxPrecoCompra.Name = "designTextBoxPrecoCompra";
            designTextBoxPrecoCompra.Padding = new Padding(10, 7, 10, 7);
            designTextBoxPrecoCompra.PasswordChar = false;
            designTextBoxPrecoCompra.PlaceholderColor = SystemColors.WindowText;
            designTextBoxPrecoCompra.PlaceholderText = "R$";
            designTextBoxPrecoCompra.SelectionLength = 0;
            designTextBoxPrecoCompra.SelectionStart = 0;
            designTextBoxPrecoCompra.Size = new Size(140, 32);
            designTextBoxPrecoCompra.TabIndex = 8;
            designTextBoxPrecoCompra.UnderlinedStyle = false;
            designTextBoxPrecoCompra._TextChanged += TextBoxPreco_TextChanged;
            designTextBoxPrecoCompra.Leave += TextBoxPreco_Leave;
            // 
            // designButtonAdicionar
            // 
            designButtonAdicionar.BackColor = Color.LimeGreen;
            designButtonAdicionar.BackgroundColor = Color.LimeGreen;
            designButtonAdicionar.BorderColor = Color.LimeGreen;
            designButtonAdicionar.BorderRadius = 22;
            designButtonAdicionar.BorderSize = 0;
            designButtonAdicionar.FlatAppearance.BorderSize = 0;
            designButtonAdicionar.FlatStyle = FlatStyle.Flat;
            designButtonAdicionar.ForeColor = Color.White;
            designButtonAdicionar.Location = new Point(733, 374);
            designButtonAdicionar.Name = "designButtonAdicionar";
            designButtonAdicionar.Size = new Size(126, 40);
            designButtonAdicionar.TabIndex = 0;
            designButtonAdicionar.Text = "Adicionar";
            designButtonAdicionar.TextColor = Color.White;
            designButtonAdicionar.UseVisualStyleBackColor = false;
            designButtonAdicionar.Click += designButtonAdicionar_Click;
            // 
            // designButtonExcluir
            // 
            designButtonExcluir.BackColor = Color.Red;
            designButtonExcluir.BackgroundColor = Color.Red;
            designButtonExcluir.BorderColor = Color.Red;
            designButtonExcluir.BorderRadius = 22;
            designButtonExcluir.BorderSize = 0;
            designButtonExcluir.FlatAppearance.BorderSize = 0;
            designButtonExcluir.FlatStyle = FlatStyle.Flat;
            designButtonExcluir.ForeColor = Color.White;
            designButtonExcluir.Location = new Point(591, 374);
            designButtonExcluir.Name = "designButtonExcluir";
            designButtonExcluir.Size = new Size(126, 40);
            designButtonExcluir.TabIndex = 0;
            designButtonExcluir.Text = "Excluir";
            designButtonExcluir.TextColor = Color.White;
            designButtonExcluir.UseVisualStyleBackColor = false;
            designButtonExcluir.Click += designButtonExcluir_Click;
            // 
            // iconPictureBox
            // 
            iconPictureBox.BackColor = SystemColors.Control;
            iconPictureBox.ForeColor = SystemColors.GrayText;
            iconPictureBox.IconChar = FontAwesome.Sharp.IconChar.CameraAlt;
            iconPictureBox.IconColor = SystemColors.GrayText;
            iconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox.IconSize = 50;
            iconPictureBox.Location = new Point(684, 96);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(52, 50);
            iconPictureBox.TabIndex = 12;
            iconPictureBox.TabStop = false;
            iconPictureBox.Click += iconPictureBox_Click;
            // 
            // CadastroProdutosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(917, 463);
            Controls.Add(iconPictureBox);
            Controls.Add(designButtonExcluir);
            Controls.Add(designButtonAdicionar);
            Controls.Add(labelNome);
            Controls.Add(designTextBoxPrecoCompra);
            Controls.Add(designTextBoxPrecoReposicao);
            Controls.Add(designTextBoxPrecoLocacao);
            Controls.Add(designTextBoxEspecificacao);
            Controls.Add(designTextBoxModelo);
            Controls.Add(designTextBoxMaterial);
            Controls.Add(designTextBoxNome);
            Controls.Add(numericUpDownQuantidade);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelDataCompra);
            Controls.Add(labelPrecoReposicao);
            Controls.Add(labelPrecoCompra);
            Controls.Add(labelPrecoLocacao);
            Controls.Add(labelImagemProduto);
            Controls.Add(pictureBoxProduto);
            Controls.Add(labelEspecificacao);
            Controls.Add(labelMaterial);
            Controls.Add(labelModelo);
            Controls.Add(labelQuantidade);
            Name = "CadastroProdutosForm";
            Text = "Cadastro de Produtos";
            Load += CadastroProdutosForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelQuantidade;
        private Label labelModelo;
        private Label labelMaterial;
        private Label labelEspecificacao;
        private PictureBox pictureBoxProduto;
        private Label labelImagemProduto;
        private Label labelPrecoLocacao;
        private Label labelPrecoCompra;
        private Label labelPrecoReposicao;
        private Label labelDataCompra;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDownQuantidade;
        private Design.DesignTextBox designTextBoxNome;
        private Label labelNome;
        private Design.DesignTextBox designTextBoxMaterial;
        private Design.DesignTextBox designTextBoxModelo;
        private Design.DesignTextBox designTextBoxEspecificacao;
        private Design.DesignTextBox designTextBoxPrecoLocacao;
        private Design.DesignTextBox designTextBoxPrecoReposicao;
        private Design.DesignTextBox designTextBoxPrecoCompra;
        private Design.DesignButton designButtonAdicionar;
        private Design.DesignButton designButtonExcluir;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox;
    }
}