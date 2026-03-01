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
            designTextBoxValorTotalQuebra = new Design.DesignTextBox();
            designButtonSalvar = new Design.DesignButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuebra).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewQuebra
            // 
            dataGridViewQuebra.BackgroundColor = SystemColors.Control;
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
            // designTextBoxValorTotalQuebra
            // 
            designTextBoxValorTotalQuebra.BackColor = SystemColors.Window;
            designTextBoxValorTotalQuebra.BorderColor = Color.MediumSlateBlue;
            designTextBoxValorTotalQuebra.BorderFocusColor = Color.HotPink;
            designTextBoxValorTotalQuebra.BorderRadius = 15;
            designTextBoxValorTotalQuebra.BorderSize = 1;
            designTextBoxValorTotalQuebra.CharacterCasing = CharacterCasing.Normal;
            designTextBoxValorTotalQuebra.Font = new Font("Segoe UI", 9.5F);
            designTextBoxValorTotalQuebra.ForeColor = SystemColors.WindowText;
            designTextBoxValorTotalQuebra.Location = new Point(436, 365);
            designTextBoxValorTotalQuebra.Multiline = false;
            designTextBoxValorTotalQuebra.Name = "designTextBoxValorTotalQuebra";
            designTextBoxValorTotalQuebra.Padding = new Padding(10, 7, 10, 7);
            designTextBoxValorTotalQuebra.PasswordChar = false;
            designTextBoxValorTotalQuebra.PlaceholderColor = Color.DarkGray;
            designTextBoxValorTotalQuebra.PlaceholderText = "Valor da Quebra";
            designTextBoxValorTotalQuebra.SelectionLength = 0;
            designTextBoxValorTotalQuebra.SelectionStart = 0;
            designTextBoxValorTotalQuebra.Size = new Size(168, 32);
            designTextBoxValorTotalQuebra.TabIndex = 3;
            designTextBoxValorTotalQuebra.UnderlinedStyle = false;
            // 
            // designButtonSalvar
            // 
            designButtonSalvar.BackColor = Color.LimeGreen;
            designButtonSalvar.BackgroundColor = Color.LimeGreen;
            designButtonSalvar.BorderColor = Color.LimeGreen;
            designButtonSalvar.BorderRadius = 21;
            designButtonSalvar.BorderSize = 0;
            designButtonSalvar.FlatAppearance.BorderSize = 0;
            designButtonSalvar.FlatStyle = FlatStyle.Flat;
            designButtonSalvar.ForeColor = Color.White;
            designButtonSalvar.Location = new Point(651, 362);
            designButtonSalvar.Name = "designButtonSalvar";
            designButtonSalvar.Size = new Size(107, 40);
            designButtonSalvar.TabIndex = 4;
            designButtonSalvar.Text = "Salvar";
            designButtonSalvar.TextColor = Color.White;
            designButtonSalvar.UseVisualStyleBackColor = false;
            designButtonSalvar.Click += designButtonSalvar_Click;
            // 
            // QuebraProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(designButtonSalvar);
            Controls.Add(designTextBoxValorTotalQuebra);
            Controls.Add(dataGridViewQuebra);
            Name = "QuebraProdutoForm";
            Text = "Quebra de Produtos";
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuebra).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewQuebra;
        private DataGridViewTextBoxColumn ProdutoId;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn QuantidadeQuebrada;
        private DataGridViewTextBoxColumn ValorReposicao;
        private DataGridViewTextBoxColumn ValorTotalQuebra;
        private Design.DesignTextBox designTextBoxValorTotalQuebra;
        private Design.DesignButton designButtonSalvar;
    }
}