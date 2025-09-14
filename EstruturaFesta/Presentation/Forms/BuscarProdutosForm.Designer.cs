namespace EstruturaFesta
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
            panelFiltros.Size = new Size(800, 24);
            panelFiltros.TabIndex = 0;
            // 
            // labelEspecificacao
            // 
            labelEspecificacao.AutoSize = true;
            labelEspecificacao.Location = new Point(528, 4);
            labelEspecificacao.Name = "labelEspecificacao";
            labelEspecificacao.Size = new Size(78, 15);
            labelEspecificacao.TabIndex = 8;
            labelEspecificacao.Text = "Especificação";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(369, 5);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(48, 15);
            labelModelo.TabIndex = 7;
            labelModelo.Text = "Modelo";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(209, 5);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(50, 15);
            labelMaterial.TabIndex = 6;
            labelMaterial.Text = "Material";
            // 
            // labelNomeProduto
            // 
            labelNomeProduto.AutoSize = true;
            labelNomeProduto.Location = new Point(3, 4);
            labelNomeProduto.Name = "labelNomeProduto";
            labelNomeProduto.Size = new Size(103, 15);
            labelNomeProduto.TabIndex = 5;
            labelNomeProduto.Text = "Nome do Produto";
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(725, 0);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(75, 23);
            buttonFiltrar.TabIndex = 4;
            buttonFiltrar.Text = "Filtrar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // textBoxFiltroNomeProduto
            // 
            textBoxFiltroNomeProduto.Location = new Point(107, 0);
            textBoxFiltroNomeProduto.Name = "textBoxFiltroNomeProduto";
            textBoxFiltroNomeProduto.Size = new Size(100, 23);
            textBoxFiltroNomeProduto.TabIndex = 3;
            // 
            // textBoxFiltroEspecificacao
            // 
            textBoxFiltroEspecificacao.Location = new Point(611, 0);
            textBoxFiltroEspecificacao.Name = "textBoxFiltroEspecificacao";
            textBoxFiltroEspecificacao.Size = new Size(85, 23);
            textBoxFiltroEspecificacao.TabIndex = 2;
            // 
            // textBoxFiltroModelo
            // 
            textBoxFiltroModelo.Location = new Point(424, 0);
            textBoxFiltroModelo.Name = "textBoxFiltroModelo";
            textBoxFiltroModelo.Size = new Size(100, 23);
            textBoxFiltroModelo.TabIndex = 1;
            // 
            // textBoxFiltroMaterial
            // 
            textBoxFiltroMaterial.Location = new Point(262, 0);
            textBoxFiltroMaterial.Name = "textBoxFiltroMaterial";
            textBoxFiltroMaterial.Size = new Size(100, 23);
            textBoxFiltroMaterial.TabIndex = 0;
            // 
            // dataGridViewFiltroProdutos
            // 
            dataGridViewFiltroProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltroProdutos.Dock = DockStyle.Fill;
            dataGridViewFiltroProdutos.Location = new Point(0, 24);
            dataGridViewFiltroProdutos.Name = "dataGridViewFiltroProdutos";
            dataGridViewFiltroProdutos.Size = new Size(800, 426);
            dataGridViewFiltroProdutos.TabIndex = 1;
            dataGridViewFiltroProdutos.CellDoubleClick += dataGridViewFiltroProdutos_CellDoubleClick;
            dataGridViewFiltroProdutos.ColumnHeaderMouseClick += dataGridViewFiltroProdutos_ColumnHeaderMouseClick;
            // 
            // BuscarProdutosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewFiltroProdutos);
            Controls.Add(panelFiltros);
            Name = "BuscarProdutosForm";
            Text = "Buscar Produto";
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
    }
}