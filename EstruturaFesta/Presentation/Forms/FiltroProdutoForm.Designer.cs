namespace EstruturaFesta.Presentation.Forms
{
    partial class FiltroProdutoForm
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
            dataGridViewFiltroProdutos = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            Modelo = new DataGridViewTextBoxColumn();
            Especificacao = new DataGridViewTextBoxColumn();
            Estoque = new DataGridViewTextBoxColumn();
            ValorUnitario = new DataGridViewTextBoxColumn();
            ValorReposicao = new DataGridViewTextBoxColumn();
            labelNomeProduto = new Label();
            labelMaterial = new Label();
            labelModelo = new Label();
            labelEspecificacao = new Label();
            designTextBoxMaterial = new Design.DesignTextBox();
            designTextBoxNome = new Design.DesignTextBox();
            designTextBoxEspecificacao = new Design.DesignTextBox();
            designTextBoxModelo = new Design.DesignTextBox();
            designTextBoxID = new Design.DesignTextBox();
            labelID = new Label();
            designButtonFiltrar = new Design.DesignButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroProdutos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFiltroProdutos
            // 
            dataGridViewFiltroProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewFiltroProdutos.BackgroundColor = SystemColors.Control;
            dataGridViewFiltroProdutos.BorderStyle = BorderStyle.None;
            dataGridViewFiltroProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltroProdutos.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Material, Modelo, Especificacao, Estoque, ValorUnitario, ValorReposicao });
            dataGridViewFiltroProdutos.Location = new Point(0, 68);
            dataGridViewFiltroProdutos.Name = "dataGridViewFiltroProdutos";
            dataGridViewFiltroProdutos.Size = new Size(1132, 532);
            dataGridViewFiltroProdutos.TabIndex = 0;
            dataGridViewFiltroProdutos.CellContentClick += dataGridViewFiltroProdutos_CellDoubleClick;
            dataGridViewFiltroProdutos.CellDoubleClick += dataGridViewFiltroProdutos_CellDoubleClick;
            dataGridViewFiltroProdutos.ColumnHeaderMouseClick += dataGridViewFiltroProdutos_ColumnHeaderMouseClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID.DataPropertyName = "ProdutoId";
            ID.FillWeight = 45F;
            ID.HeaderText = "Codigo";
            ID.Name = "ID";
            // 
            // Nome
            // 
            Nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // Material
            // 
            Material.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Material.DataPropertyName = "Material";
            Material.HeaderText = "Material";
            Material.Name = "Material";
            // 
            // Modelo
            // 
            Modelo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Modelo.DataPropertyName = "Modelo";
            Modelo.HeaderText = "Modelo";
            Modelo.Name = "Modelo";
            // 
            // Especificacao
            // 
            Especificacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Especificacao.DataPropertyName = "Especificacao";
            Especificacao.HeaderText = "Especificação";
            Especificacao.Name = "Especificacao";
            // 
            // Estoque
            // 
            Estoque.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Estoque.DataPropertyName = "QuantidadeEstoque";
            Estoque.FillWeight = 60F;
            Estoque.HeaderText = "Quantidade Estoque";
            Estoque.Name = "Estoque";
            // 
            // ValorUnitario
            // 
            ValorUnitario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ValorUnitario.DataPropertyName = "ValorUnitario";
            ValorUnitario.FillWeight = 60F;
            ValorUnitario.HeaderText = "Valor Unitario";
            ValorUnitario.Name = "ValorUnitario";
            // 
            // ValorReposicao
            // 
            ValorReposicao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ValorReposicao.DataPropertyName = "ValorReposicao";
            ValorReposicao.FillWeight = 60F;
            ValorReposicao.HeaderText = "Valor Reposição";
            ValorReposicao.Name = "ValorReposicao";
            // 
            // labelNomeProduto
            // 
            labelNomeProduto.AutoSize = true;
            labelNomeProduto.Location = new Point(125, 12);
            labelNomeProduto.Name = "labelNomeProduto";
            labelNomeProduto.Size = new Size(40, 15);
            labelNomeProduto.TabIndex = 0;
            labelNomeProduto.Text = "Nome";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(301, 12);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(50, 15);
            labelMaterial.TabIndex = 0;
            labelMaterial.Text = "Material";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(477, 12);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(48, 15);
            labelModelo.TabIndex = 0;
            labelModelo.Text = "Modelo";
            // 
            // labelEspecificacao
            // 
            labelEspecificacao.AutoSize = true;
            labelEspecificacao.Location = new Point(653, 12);
            labelEspecificacao.Name = "labelEspecificacao";
            labelEspecificacao.Size = new Size(78, 15);
            labelEspecificacao.TabIndex = 0;
            labelEspecificacao.Text = "Especificação";
            // 
            // designTextBoxMaterial
            // 
            designTextBoxMaterial.BackColor = SystemColors.Window;
            designTextBoxMaterial.BorderColor = Color.MediumSlateBlue;
            designTextBoxMaterial.BorderFocusColor = Color.HotPink;
            designTextBoxMaterial.BorderRadius = 15;
            designTextBoxMaterial.BorderSize = 1;
            designTextBoxMaterial.CharacterCasing = CharacterCasing.Normal;
            designTextBoxMaterial.Font = new Font("Segoe UI", 9.5F);
            designTextBoxMaterial.ForeColor = SystemColors.WindowText;
            designTextBoxMaterial.Location = new Point(297, 30);
            designTextBoxMaterial.Multiline = false;
            designTextBoxMaterial.Name = "designTextBoxMaterial";
            designTextBoxMaterial.Padding = new Padding(10, 7, 10, 7);
            designTextBoxMaterial.PasswordChar = false;
            designTextBoxMaterial.PlaceholderColor = Color.DarkGray;
            designTextBoxMaterial.PlaceholderText = "Material do Produto";
            designTextBoxMaterial.SelectionLength = 0;
            designTextBoxMaterial.SelectionStart = 0;
            designTextBoxMaterial.Size = new Size(173, 32);
            designTextBoxMaterial.TabIndex = 3;
            designTextBoxMaterial.UnderlinedStyle = false;
            // 
            // designTextBoxNome
            // 
            designTextBoxNome.BackColor = SystemColors.Window;
            designTextBoxNome.BorderColor = Color.MediumSlateBlue;
            designTextBoxNome.BorderFocusColor = Color.HotPink;
            designTextBoxNome.BorderRadius = 15;
            designTextBoxNome.BorderSize = 1;
            designTextBoxNome.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNome.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNome.ForeColor = SystemColors.WindowText;
            designTextBoxNome.Location = new Point(119, 30);
            designTextBoxNome.Multiline = false;
            designTextBoxNome.Name = "designTextBoxNome";
            designTextBoxNome.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNome.PasswordChar = false;
            designTextBoxNome.PlaceholderColor = Color.DarkGray;
            designTextBoxNome.PlaceholderText = "Nome do Produto";
            designTextBoxNome.SelectionLength = 0;
            designTextBoxNome.SelectionStart = 0;
            designTextBoxNome.Size = new Size(171, 32);
            designTextBoxNome.TabIndex = 2;
            designTextBoxNome.UnderlinedStyle = false;
            // 
            // designTextBoxEspecificacao
            // 
            designTextBoxEspecificacao.BackColor = SystemColors.Window;
            designTextBoxEspecificacao.BorderColor = Color.MediumSlateBlue;
            designTextBoxEspecificacao.BorderFocusColor = Color.HotPink;
            designTextBoxEspecificacao.BorderRadius = 15;
            designTextBoxEspecificacao.BorderSize = 1;
            designTextBoxEspecificacao.CharacterCasing = CharacterCasing.Normal;
            designTextBoxEspecificacao.Font = new Font("Segoe UI", 9F);
            designTextBoxEspecificacao.ForeColor = SystemColors.WindowText;
            designTextBoxEspecificacao.Location = new Point(645, 30);
            designTextBoxEspecificacao.Multiline = false;
            designTextBoxEspecificacao.Name = "designTextBoxEspecificacao";
            designTextBoxEspecificacao.Padding = new Padding(10, 7, 10, 7);
            designTextBoxEspecificacao.PasswordChar = false;
            designTextBoxEspecificacao.PlaceholderColor = Color.DarkGray;
            designTextBoxEspecificacao.PlaceholderText = "Especificação do Produto";
            designTextBoxEspecificacao.SelectionLength = 0;
            designTextBoxEspecificacao.SelectionStart = 0;
            designTextBoxEspecificacao.Size = new Size(186, 30);
            designTextBoxEspecificacao.TabIndex = 5;
            designTextBoxEspecificacao.UnderlinedStyle = false;
            // 
            // designTextBoxModelo
            // 
            designTextBoxModelo.BackColor = SystemColors.Window;
            designTextBoxModelo.BorderColor = Color.MediumSlateBlue;
            designTextBoxModelo.BorderFocusColor = Color.HotPink;
            designTextBoxModelo.BorderRadius = 15;
            designTextBoxModelo.BorderSize = 1;
            designTextBoxModelo.CharacterCasing = CharacterCasing.Normal;
            designTextBoxModelo.Font = new Font("Segoe UI", 9.5F);
            designTextBoxModelo.ForeColor = SystemColors.WindowText;
            designTextBoxModelo.Location = new Point(472, 30);
            designTextBoxModelo.Multiline = false;
            designTextBoxModelo.Name = "designTextBoxModelo";
            designTextBoxModelo.Padding = new Padding(10, 7, 10, 7);
            designTextBoxModelo.PasswordChar = false;
            designTextBoxModelo.PlaceholderColor = Color.DarkGray;
            designTextBoxModelo.PlaceholderText = "Modelo do Produto";
            designTextBoxModelo.SelectionLength = 0;
            designTextBoxModelo.SelectionStart = 0;
            designTextBoxModelo.Size = new Size(171, 32);
            designTextBoxModelo.TabIndex = 4;
            designTextBoxModelo.UnderlinedStyle = false;
            // 
            // designTextBoxID
            // 
            designTextBoxID.BackColor = SystemColors.Window;
            designTextBoxID.BorderColor = Color.MediumSlateBlue;
            designTextBoxID.BorderFocusColor = Color.HotPink;
            designTextBoxID.BorderRadius = 15;
            designTextBoxID.BorderSize = 1;
            designTextBoxID.CharacterCasing = CharacterCasing.Normal;
            designTextBoxID.Font = new Font("Segoe UI", 9.5F);
            designTextBoxID.ForeColor = SystemColors.WindowText;
            designTextBoxID.Location = new Point(40, 30);
            designTextBoxID.Multiline = false;
            designTextBoxID.Name = "designTextBoxID";
            designTextBoxID.Padding = new Padding(10, 7, 10, 7);
            designTextBoxID.PasswordChar = false;
            designTextBoxID.PlaceholderColor = Color.DarkGray;
            designTextBoxID.PlaceholderText = "Codigo";
            designTextBoxID.SelectionLength = 0;
            designTextBoxID.SelectionStart = 0;
            designTextBoxID.Size = new Size(73, 32);
            designTextBoxID.TabIndex = 1;
            designTextBoxID.UnderlinedStyle = false;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(49, 12);
            labelID.Name = "labelID";
            labelID.Size = new Size(46, 15);
            labelID.TabIndex = 0;
            labelID.Text = "Codigo";
            // 
            // designButtonFiltrar
            // 
            designButtonFiltrar.BackColor = Color.MediumSlateBlue;
            designButtonFiltrar.BackgroundColor = Color.MediumSlateBlue;
            designButtonFiltrar.BorderColor = Color.MediumSlateBlue;
            designButtonFiltrar.BorderRadius = 22;
            designButtonFiltrar.BorderSize = 0;
            designButtonFiltrar.FlatAppearance.BorderSize = 0;
            designButtonFiltrar.FlatStyle = FlatStyle.Flat;
            designButtonFiltrar.ForeColor = Color.White;
            designButtonFiltrar.Location = new Point(958, 21);
            designButtonFiltrar.Name = "designButtonFiltrar";
            designButtonFiltrar.Size = new Size(150, 40);
            designButtonFiltrar.TabIndex = 6;
            designButtonFiltrar.Text = "Filtrar Produtos";
            designButtonFiltrar.TextColor = Color.White;
            designButtonFiltrar.UseVisualStyleBackColor = false;
            designButtonFiltrar.Click += designButtonFiltrar_Click;
            // 
            // FiltroProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 600);
            Controls.Add(designButtonFiltrar);
            Controls.Add(labelID);
            Controls.Add(designTextBoxID);
            Controls.Add(designTextBoxModelo);
            Controls.Add(designTextBoxNome);
            Controls.Add(designTextBoxEspecificacao);
            Controls.Add(designTextBoxMaterial);
            Controls.Add(labelEspecificacao);
            Controls.Add(labelModelo);
            Controls.Add(labelMaterial);
            Controls.Add(labelNomeProduto);
            Controls.Add(dataGridViewFiltroProdutos);
            Name = "FiltroProdutoForm";
            Text = "Filtro de Produtos";
            Load += FiltroProdutoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewFiltroProdutos;
        private Label labelNomeProduto;
        private Label labelMaterial;
        private Label labelModelo;
        private Label labelEspecificacao;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Modelo;
        private DataGridViewTextBoxColumn Especificacao;
        private DataGridViewTextBoxColumn Estoque;
        private DataGridViewTextBoxColumn ValorUnitario;
        private DataGridViewTextBoxColumn ValorReposicao;
        private Design.DesignTextBox designTextBoxMaterial;
        private Design.DesignTextBox designTextBoxNome;
        private Design.DesignTextBox designTextBoxEspecificacao;
        private Design.DesignTextBox designTextBoxModelo;
        private Design.DesignTextBox designTextBoxID;
        private Label labelID;
        private Design.DesignButton designButtonFiltrar;
    }
}