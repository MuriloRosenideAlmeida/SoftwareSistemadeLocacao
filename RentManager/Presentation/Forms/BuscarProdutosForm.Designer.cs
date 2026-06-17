namespace RentManager
{
    partial class BuscarProdutosForm
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
            panelFiltros = new Panel();
            labelEspecificacao = new Label();
            labelModelo = new Label();
            labelMaterial = new Label();
            labelNomeProduto = new Label();
            buttonFiltrar = new Button();
            textBoxFiltroNomeProduto = new TextBox();
            textBoxFiltroEspecificacao = new TextBox();
            textBoxFiltroModelo = new TextBox();
            textBoxFiltroMaterial = new TextBox();
            dataGridViewFiltroProdutos = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            Modelo = new DataGridViewTextBoxColumn();
            Especificacao = new DataGridViewTextBoxColumn();
            QuantidadeEstoque = new DataGridViewTextBoxColumn();
            ValorUnitario = new DataGridViewTextBoxColumn();
            ValorReposicao = new DataGridViewTextBoxColumn();
            panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroProdutos).BeginInit();
            SuspendLayout();
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = SystemColors.MenuBar;
            panelFiltros.Controls.Add(labelEspecificacao);
            panelFiltros.Controls.Add(labelModelo);
            panelFiltros.Controls.Add(labelMaterial);
            panelFiltros.Controls.Add(labelNomeProduto);
            panelFiltros.Controls.Add(buttonFiltrar);
            panelFiltros.Controls.Add(textBoxFiltroNomeProduto);
            panelFiltros.Controls.Add(textBoxFiltroEspecificacao);
            panelFiltros.Controls.Add(textBoxFiltroModelo);
            panelFiltros.Controls.Add(textBoxFiltroMaterial);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 0);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(1134, 24);
            panelFiltros.TabIndex = 0;
            // 
            // labelEspecificacao
            // 
            labelEspecificacao.AutoSize = true;
            labelEspecificacao.Location = new Point(637, 4);
            labelEspecificacao.Name = "labelEspecificacao";
            labelEspecificacao.Size = new Size(78, 15);
            labelEspecificacao.TabIndex = 8;
            labelEspecificacao.Text = "Especificação";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(448, 5);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(48, 15);
            labelModelo.TabIndex = 7;
            labelModelo.Text = "Modelo";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(261, 6);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(50, 15);
            labelMaterial.TabIndex = 6;
            labelMaterial.Text = "Material";
            // 
            // labelNomeProduto
            // 
            labelNomeProduto.AutoSize = true;
            labelNomeProduto.Location = new Point(23, 4);
            labelNomeProduto.Name = "labelNomeProduto";
            labelNomeProduto.Size = new Size(103, 15);
            labelNomeProduto.TabIndex = 5;
            labelNomeProduto.Text = "Nome do Produto";
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(1047, 1);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(75, 23);
            buttonFiltrar.TabIndex = 4;
            buttonFiltrar.Text = "Filtrar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // textBoxFiltroNomeProduto
            // 
            textBoxFiltroNomeProduto.Location = new Point(127, 0);
            textBoxFiltroNomeProduto.Name = "textBoxFiltroNomeProduto";
            textBoxFiltroNomeProduto.Size = new Size(128, 23);
            textBoxFiltroNomeProduto.TabIndex = 0;
            // 
            // textBoxFiltroEspecificacao
            // 
            textBoxFiltroEspecificacao.Location = new Point(720, 0);
            textBoxFiltroEspecificacao.Name = "textBoxFiltroEspecificacao";
            textBoxFiltroEspecificacao.Size = new Size(113, 23);
            textBoxFiltroEspecificacao.TabIndex = 3;
            // 
            // textBoxFiltroModelo
            // 
            textBoxFiltroModelo.Location = new Point(503, 0);
            textBoxFiltroModelo.Name = "textBoxFiltroModelo";
            textBoxFiltroModelo.Size = new Size(128, 23);
            textBoxFiltroModelo.TabIndex = 2;
            // 
            // textBoxFiltroMaterial
            // 
            textBoxFiltroMaterial.Location = new Point(314, 1);
            textBoxFiltroMaterial.Name = "textBoxFiltroMaterial";
            textBoxFiltroMaterial.Size = new Size(128, 23);
            textBoxFiltroMaterial.TabIndex = 1;
            // 
            // dataGridViewFiltroProdutos
            // 
            dataGridViewFiltroProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltroProdutos.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Material, Modelo, Especificacao, QuantidadeEstoque, ValorUnitario, ValorReposicao });
            dataGridViewFiltroProdutos.Dock = DockStyle.Fill;
            dataGridViewFiltroProdutos.Location = new Point(0, 24);
            dataGridViewFiltroProdutos.Name = "dataGridViewFiltroProdutos";
            dataGridViewFiltroProdutos.Size = new Size(1134, 637);
            dataGridViewFiltroProdutos.TabIndex = 1;
            dataGridViewFiltroProdutos.CellDoubleClick += dataGridViewFiltroProdutos_CellDoubleClick;
            dataGridViewFiltroProdutos.ColumnHeaderMouseClick += dataGridViewFiltroProdutos_ColumnHeaderMouseClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID.DataPropertyName = "ProdutoId";
            ID.FillWeight = 63.51208F;
            ID.HeaderText = "Codigo";
            ID.Name = "ID";
            // 
            // Nome
            // 
            Nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nome.DataPropertyName = "Nome";
            Nome.FillWeight = 119.221924F;
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // Material
            // 
            Material.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Material.DataPropertyName = "Material";
            Material.FillWeight = 119.221924F;
            Material.HeaderText = "Material";
            Material.Name = "Material";
            // 
            // Modelo
            // 
            Modelo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Modelo.DataPropertyName = "Modelo";
            Modelo.FillWeight = 119.221924F;
            Modelo.HeaderText = "Modelo";
            Modelo.Name = "Modelo";
            // 
            // Especificacao
            // 
            Especificacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Especificacao.DataPropertyName = "Especificacao";
            Especificacao.FillWeight = 119.221924F;
            Especificacao.HeaderText = "Especificação";
            Especificacao.Name = "Especificacao";
            // 
            // QuantidadeEstoque
            // 
            QuantidadeEstoque.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            QuantidadeEstoque.DataPropertyName = "QuantidadeEstoque";
            QuantidadeEstoque.FillWeight = 62.2252F;
            QuantidadeEstoque.HeaderText = "Quantidade Estoque";
            QuantidadeEstoque.Name = "QuantidadeEstoque";
            // 
            // ValorUnitario
            // 
            ValorUnitario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ValorUnitario.DataPropertyName = "ValorUnitario";
            ValorUnitario.FillWeight = 80.21748F;
            ValorUnitario.HeaderText = "Valor Unitario";
            ValorUnitario.Name = "ValorUnitario";
            // 
            // ValorReposicao
            // 
            ValorReposicao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ValorReposicao.DataPropertyName = "ValorReposicao";
            ValorReposicao.FillWeight = 77.15733F;
            ValorReposicao.HeaderText = "Valor Reposição";
            ValorReposicao.Name = "ValorReposicao";
            // 
            // BuscarProdutosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 661);
            Controls.Add(dataGridViewFiltroProdutos);
            Controls.Add(panelFiltros);
            Name = "BuscarProdutosForm";
            Text = "Buscar Produto";
            Load += BuscarProdutosForm_Load;
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroProdutos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFiltros;
        private TextBox textBoxFiltroMaterial;
        private TextBox textBoxFiltroNomeProduto;
        private TextBox textBoxFiltroEspecificacao;
        private TextBox textBoxFiltroModelo;
        private DataGridView dataGridViewFiltroProdutos;
        private Button buttonFiltrar;
        private Label labelModelo;
        private Label labelMaterial;
        private Label labelNomeProduto;
        private Label labelEspecificacao;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Modelo;
        private DataGridViewTextBoxColumn Especificacao;
        private DataGridViewTextBoxColumn QuantidadeEstoque;
        private DataGridViewTextBoxColumn ValorUnitario;
        private DataGridViewTextBoxColumn ValorReposicao;
    }
}