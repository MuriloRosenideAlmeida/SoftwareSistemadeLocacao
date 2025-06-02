namespace EstruturaFesta
{
    partial class TelaPedido
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
            InformacoesCliente = new Panel();
            bntBuscarCliente = new Button();
            textBoxIDCliente = new TextBox();
            textBoxDescrição = new TextBox();
            textBoxNumeroContato = new TextBox();
            textBoxContato = new TextBox();
            textBoxDocumentoCliente = new TextBox();
            textBoxNomeCliente = new TextBox();
            dataGridViewProdutosLocacao = new DataGridView();
            Produto = new DataGridViewTextBoxColumn();
            Estoque = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            ValorUnitario = new DataGridViewTextBoxColumn();
            ValorTotal = new DataGridViewTextBoxColumn();
            dateTimePickerDataPedido = new DateTimePicker();
            InformacoesCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).BeginInit();
            SuspendLayout();
            // 
            // InformacoesCliente
            // 
            InformacoesCliente.Controls.Add(bntBuscarCliente);
            InformacoesCliente.Controls.Add(textBoxIDCliente);
            InformacoesCliente.Controls.Add(textBoxDescrição);
            InformacoesCliente.Controls.Add(textBoxNumeroContato);
            InformacoesCliente.Controls.Add(textBoxContato);
            InformacoesCliente.Controls.Add(textBoxDocumentoCliente);
            InformacoesCliente.Controls.Add(textBoxNomeCliente);
            InformacoesCliente.Location = new Point(12, 12);
            InformacoesCliente.Name = "InformacoesCliente";
            InformacoesCliente.Size = new Size(756, 124);
            InformacoesCliente.TabIndex = 0;
            // 
            // bntBuscarCliente
            // 
            bntBuscarCliente.FlatStyle = FlatStyle.Flat;
            bntBuscarCliente.Font = new Font("Segoe UI", 7F);
            bntBuscarCliente.Location = new Point(103, 3);
            bntBuscarCliente.Name = "bntBuscarCliente";
            bntBuscarCliente.Size = new Size(21, 23);
            bntBuscarCliente.TabIndex = 1;
            bntBuscarCliente.Text = "▼";
            bntBuscarCliente.UseVisualStyleBackColor = true;
            bntBuscarCliente.Click += bntBuscarCliente_Click;
            bntBuscarCliente.PreviewKeyDown += bntBuscarCliente_PreviewKeyDown;
            // 
            // textBoxIDCliente
            // 
            textBoxIDCliente.Location = new Point(3, 3);
            textBoxIDCliente.Name = "textBoxIDCliente";
            textBoxIDCliente.Size = new Size(100, 23);
            textBoxIDCliente.TabIndex = 1;
            // 
            // textBoxDescrição
            // 
            textBoxDescrição.Location = new Point(378, 49);
            textBoxDescrição.Multiline = true;
            textBoxDescrição.Name = "textBoxDescrição";
            textBoxDescrição.Size = new Size(375, 63);
            textBoxDescrição.TabIndex = 6;
            // 
            // textBoxNumeroContato
            // 
            textBoxNumeroContato.Location = new Point(194, 72);
            textBoxNumeroContato.Name = "textBoxNumeroContato";
            textBoxNumeroContato.Size = new Size(162, 23);
            textBoxNumeroContato.TabIndex = 5;
            // 
            // textBoxContato
            // 
            textBoxContato.Location = new Point(3, 72);
            textBoxContato.Name = "textBoxContato";
            textBoxContato.Size = new Size(185, 23);
            textBoxContato.TabIndex = 4;
            // 
            // textBoxDocumentoCliente
            // 
            textBoxDocumentoCliente.Location = new Point(581, 3);
            textBoxDocumentoCliente.Name = "textBoxDocumentoCliente";
            textBoxDocumentoCliente.Size = new Size(172, 23);
            textBoxDocumentoCliente.TabIndex = 3;
            // 
            // textBoxNomeCliente
            // 
            textBoxNomeCliente.Location = new Point(130, 3);
            textBoxNomeCliente.Name = "textBoxNomeCliente";
            textBoxNomeCliente.Size = new Size(433, 23);
            textBoxNomeCliente.TabIndex = 2;
            // 
            // dataGridViewProdutosLocacao
            // 
            dataGridViewProdutosLocacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutosLocacao.Columns.AddRange(new DataGridViewColumn[] { Produto, Estoque, Quantidade, ValorUnitario, ValorTotal });
            dataGridViewProdutosLocacao.Location = new Point(12, 187);
            dataGridViewProdutosLocacao.Name = "dataGridViewProdutosLocacao";
            dataGridViewProdutosLocacao.Size = new Size(753, 150);
            dataGridViewProdutosLocacao.TabIndex = 1;
            dataGridViewProdutosLocacao.CellEndEdit += dataGridViewProdutosLocacao_CellEndEdit;
            dataGridViewProdutosLocacao.CellFormatting += dataGridViewProdutosLocacao_CellFormatting;
            dataGridViewProdutosLocacao.KeyDown += dataGridViewProdutosLocacao_KeyDown;
            // 
            // Produto
            // 
            Produto.HeaderText = "Produto";
            Produto.Name = "Produto";
            // 
            // Estoque
            // 
            Estoque.HeaderText = "Estoque";
            Estoque.Name = "Estoque";
            Estoque.ReadOnly = true;
            // 
            // Quantidade
            // 
            Quantidade.HeaderText = "Quantidade";
            Quantidade.Name = "Quantidade";
            // 
            // ValorUnitario
            // 
            ValorUnitario.HeaderText = "Valor Unitario";
            ValorUnitario.Name = "ValorUnitario";
            ValorUnitario.ReadOnly = true;
            // 
            // ValorTotal
            // 
            ValorTotal.HeaderText = "Valor Total";
            ValorTotal.Name = "ValorTotal";
            ValorTotal.ReadOnly = true;
            // 
            // dateTimePickerDataPedido
            // 
            dateTimePickerDataPedido.Location = new Point(73, 158);
            dateTimePickerDataPedido.Name = "dateTimePickerDataPedido";
            dateTimePickerDataPedido.Size = new Size(200, 23);
            dateTimePickerDataPedido.TabIndex = 2;
            // 
            // TelaPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 749);
            Controls.Add(dateTimePickerDataPedido);
            Controls.Add(dataGridViewProdutosLocacao);
            Controls.Add(InformacoesCliente);
            Name = "TelaPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaPedido";
            InformacoesCliente.ResumeLayout(false);
            InformacoesCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel InformacoesCliente;
        private TextBox textBoxDescrição;
        private TextBox textBoxNumeroContato;
        private TextBox textBoxContato;
        private TextBox textBoxDocumentoCliente;
        private TextBox textBoxNomeCliente;
        private TextBox textBoxIDCliente;
        private Button bntBuscarCliente;
        private DataGridView dataGridViewProdutosLocacao;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn Estoque;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn ValorUnitario;
        private DataGridViewTextBoxColumn ValorTotal;
        private DateTimePicker dateTimePickerDataPedido;
    }
}