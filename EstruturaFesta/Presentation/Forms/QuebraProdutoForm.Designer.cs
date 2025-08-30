namespace EstruturaFesta.Presentation.Forms
{
    partial class QuebraProdutoForm
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
            dataGridViewQuebra = new DataGridView();
            ProdutoId = new DataGridViewTextBoxColumn();
            Produto = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            QuantidadeQuebrada = new DataGridViewTextBoxColumn();
            ValorReposicao = new DataGridViewTextBoxColumn();
            ValorTotalQuebra = new DataGridViewTextBoxColumn();
            textBoxValorTotalQuebra = new TextBox();
            buttonSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuebra).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewQuebra
            // 
            dataGridViewQuebra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQuebra.Columns.AddRange(new DataGridViewColumn[] { ProdutoId, Produto, Quantidade, QuantidadeQuebrada, ValorReposicao, ValorTotalQuebra });
            dataGridViewQuebra.Location = new Point(85, 114);
            dataGridViewQuebra.Name = "dataGridViewQuebra";
            dataGridViewQuebra.Size = new Size(644, 150);
            dataGridViewQuebra.TabIndex = 0;
            dataGridViewQuebra.CellEndEdit += dataGridViewQuebra_CellEndEdit;
            dataGridViewQuebra.CellFormatting += dataGridViewQuebra_CellFormatting;
            dataGridViewQuebra.CellValueChanged += dataGridViewQuebra_CellValueChanged;
            dataGridViewQuebra.KeyDown += dataGridViewQuebra_KeyDown;
            // 
            // ProdutoId
            // 
            ProdutoId.DataPropertyName = "ProdutoId";
            ProdutoId.HeaderText = "Codigo";
            ProdutoId.Name = "ProdutoId";
            ProdutoId.ReadOnly = true;
            // 
            // Produto
            // 
            Produto.DataPropertyName = "Nome";
            Produto.HeaderText = "Produto";
            Produto.Name = "Produto";
            Produto.ReadOnly = true;
            // 
            // Quantidade
            // 
            Quantidade.DataPropertyName = "Quantidade";
            Quantidade.HeaderText = "Quantidade";
            Quantidade.Name = "Quantidade";
            Quantidade.ReadOnly = true;
            // 
            // QuantidadeQuebrada
            // 
            QuantidadeQuebrada.DataPropertyName = "QuantidadeQuebrada";
            QuantidadeQuebrada.HeaderText = "Quebra";
            QuantidadeQuebrada.Name = "QuantidadeQuebrada";
            // 
            // ValorReposicao
            // 
            ValorReposicao.DataPropertyName = "ValorReposicao";
            ValorReposicao.HeaderText = "ValorReposição";
            ValorReposicao.Name = "ValorReposicao";
            ValorReposicao.ReadOnly = true;
            // 
            // ValorTotalQuebra
            // 
            ValorTotalQuebra.DataPropertyName = "ValorTotal";
            ValorTotalQuebra.HeaderText = "ValorTotal";
            ValorTotalQuebra.Name = "ValorTotalQuebra";
            ValorTotalQuebra.ReadOnly = true;
            // 
            // textBoxValorTotalQuebra
            // 
            textBoxValorTotalQuebra.Location = new Point(520, 342);
            textBoxValorTotalQuebra.Name = "textBoxValorTotalQuebra";
            textBoxValorTotalQuebra.Size = new Size(100, 23);
            textBoxValorTotalQuebra.TabIndex = 1;
            // 
            // buttonSalvar
            // 
            buttonSalvar.Location = new Point(670, 333);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(75, 23);
            buttonSalvar.TabIndex = 2;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = true;
            buttonSalvar.Click += buttonSalvar_Click;
            // 
            // QuebraProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSalvar);
            Controls.Add(textBoxValorTotalQuebra);
            Controls.Add(dataGridViewQuebra);
            Name = "QuebraProdutoForm";
            Text = "FormQuebraProduto";
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuebra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewQuebra;
        private TextBox textBoxValorTotalQuebra;
        private Button buttonSalvar;
        private DataGridViewTextBoxColumn ProdutoId;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn QuantidadeQuebrada;
        private DataGridViewTextBoxColumn ValorReposicao;
        private DataGridViewTextBoxColumn ValorTotalQuebra;
    }
}