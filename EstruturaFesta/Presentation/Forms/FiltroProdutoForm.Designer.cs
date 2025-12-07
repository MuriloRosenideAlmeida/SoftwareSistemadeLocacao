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
            textBoxFiltroNomeProduto = new TextBox();
            textBoxFiltroMaterial = new TextBox();
            textBoxFiltroModelo = new TextBox();
            textBoxFiltroEspecificacao = new TextBox();
            buttonFiltrar = new Button();
            labelNomeProduto = new Label();
            labelMaterial = new Label();
            labelModelo = new Label();
            labelEspecificacao = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroProdutos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFiltroProdutos
            // 
            dataGridViewFiltroProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewFiltroProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltroProdutos.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Material, Modelo, Especificacao, Estoque, ValorUnitario, ValorReposicao });
            dataGridViewFiltroProdutos.Location = new Point(-1, 47);
            dataGridViewFiltroProdutos.Name = "dataGridViewFiltroProdutos";
            dataGridViewFiltroProdutos.Size = new Size(1132, 553);
            dataGridViewFiltroProdutos.TabIndex = 0;
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
            // textBoxFiltroNomeProduto
            // 
            textBoxFiltroNomeProduto.Location = new Point(122, 18);
            textBoxFiltroNomeProduto.Name = "textBoxFiltroNomeProduto";
            textBoxFiltroNomeProduto.Size = new Size(159, 23);
            textBoxFiltroNomeProduto.TabIndex = 1;
            // 
            // textBoxFiltroMaterial
            // 
            textBoxFiltroMaterial.Location = new Point(299, 19);
            textBoxFiltroMaterial.Name = "textBoxFiltroMaterial";
            textBoxFiltroMaterial.Size = new Size(156, 23);
            textBoxFiltroMaterial.TabIndex = 1;
            // 
            // textBoxFiltroModelo
            // 
            textBoxFiltroModelo.Location = new Point(476, 19);
            textBoxFiltroModelo.Name = "textBoxFiltroModelo";
            textBoxFiltroModelo.Size = new Size(143, 23);
            textBoxFiltroModelo.TabIndex = 1;
            // 
            // textBoxFiltroEspecificacao
            // 
            textBoxFiltroEspecificacao.Location = new Point(647, 19);
            textBoxFiltroEspecificacao.Name = "textBoxFiltroEspecificacao";
            textBoxFiltroEspecificacao.Size = new Size(175, 23);
            textBoxFiltroEspecificacao.TabIndex = 1;
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(1043, 18);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(75, 23);
            buttonFiltrar.TabIndex = 2;
            buttonFiltrar.Text = "Filtrar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // labelNomeProduto
            // 
            labelNomeProduto.AutoSize = true;
            labelNomeProduto.Location = new Point(122, 1);
            labelNomeProduto.Name = "labelNomeProduto";
            labelNomeProduto.Size = new Size(40, 15);
            labelNomeProduto.TabIndex = 3;
            labelNomeProduto.Text = "Nome";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(299, 1);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(50, 15);
            labelMaterial.TabIndex = 3;
            labelMaterial.Text = "Material";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(476, 1);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(48, 15);
            labelModelo.TabIndex = 3;
            labelModelo.Text = "Modelo";
            // 
            // labelEspecificacao
            // 
            labelEspecificacao.AutoSize = true;
            labelEspecificacao.Location = new Point(647, 0);
            labelEspecificacao.Name = "labelEspecificacao";
            labelEspecificacao.Size = new Size(78, 15);
            labelEspecificacao.TabIndex = 3;
            labelEspecificacao.Text = "Especificação";
            // 
            // FiltroProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 600);
            Controls.Add(labelEspecificacao);
            Controls.Add(labelModelo);
            Controls.Add(labelMaterial);
            Controls.Add(labelNomeProduto);
            Controls.Add(buttonFiltrar);
            Controls.Add(textBoxFiltroEspecificacao);
            Controls.Add(textBoxFiltroModelo);
            Controls.Add(textBoxFiltroMaterial);
            Controls.Add(textBoxFiltroNomeProduto);
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
        private TextBox textBoxFiltroNomeProduto;
        private TextBox textBoxFiltroMaterial;
        private TextBox textBoxFiltroModelo;
        private TextBox textBoxFiltroEspecificacao;
        private Button buttonFiltrar;
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
    }
}