namespace EstruturaFesta
{
    partial class TelaPedidoForm
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
            labelObservacoes = new Label();
            labelNumeroContato = new Label();
            labelNomeContato = new Label();
            bntBuscarCliente = new Button();
            textBoxIDCliente = new TextBox();
            textBoxDescrição = new TextBox();
            textBoxNumeroContato = new TextBox();
            textBoxContato = new TextBox();
            textBoxDocumentoCliente = new TextBox();
            textBoxNomeCliente = new TextBox();
            dataGridViewProdutosLocacao = new DataGridView();
            dateTimePickerDataPedido = new DateTimePicker();
            buttonFinalizarPedido = new Button();
            labelCliente = new Label();
            labelNome = new Label();
            labelDocumentos = new Label();
            ProdutoID = new DataGridViewTextBoxColumn();
            Produto = new DataGridViewTextBoxColumn();
            Estoque = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            ValorUnitario = new DataGridViewTextBoxColumn();
            ValorTotal = new DataGridViewTextBoxColumn();
            InformacoesCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).BeginInit();
            SuspendLayout();
            // 
            // InformacoesCliente
            // 
            InformacoesCliente.Controls.Add(labelObservacoes);
            InformacoesCliente.Controls.Add(labelNumeroContato);
            InformacoesCliente.Controls.Add(labelNomeContato);
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
            // labelObservacoes
            // 
            labelObservacoes.AutoSize = true;
            labelObservacoes.Location = new Point(379, 34);
            labelObservacoes.Name = "labelObservacoes";
            labelObservacoes.Size = new Size(74, 15);
            labelObservacoes.TabIndex = 8;
            labelObservacoes.Text = "Observações";
            // 
            // labelNumeroContato
            // 
            labelNumeroContato.AutoSize = true;
            labelNumeroContato.Location = new Point(195, 55);
            labelNumeroContato.Name = "labelNumeroContato";
            labelNumeroContato.Size = new Size(114, 15);
            labelNumeroContato.TabIndex = 7;
            labelNumeroContato.Text = "Numero do Contato";
            // 
            // labelNomeContato
            // 
            labelNomeContato.AutoSize = true;
            labelNomeContato.Location = new Point(5, 55);
            labelNomeContato.Name = "labelNomeContato";
            labelNomeContato.Size = new Size(103, 15);
            labelNomeContato.TabIndex = 7;
            labelNomeContato.Text = "Nome do Contato";
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
            dataGridViewProdutosLocacao.Columns.AddRange(new DataGridViewColumn[] { ProdutoID, Produto, Estoque, Quantidade, ValorUnitario, ValorTotal });
            dataGridViewProdutosLocacao.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewProdutosLocacao.Location = new Point(12, 187);
            dataGridViewProdutosLocacao.MultiSelect = false;
            dataGridViewProdutosLocacao.Name = "dataGridViewProdutosLocacao";
            dataGridViewProdutosLocacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewProdutosLocacao.Size = new Size(753, 150);
            dataGridViewProdutosLocacao.TabIndex = 1;
            dataGridViewProdutosLocacao.CellEndEdit += dataGridViewProdutosLocacao_CellEndEdit;
            dataGridViewProdutosLocacao.CellFormatting += dataGridViewProdutosLocacao_CellFormatting;
            dataGridViewProdutosLocacao.CurrentCellChanged += dataGridViewProdutosLocacao_CurrentCellChanged;
            dataGridViewProdutosLocacao.EditingControlShowing += dataGridViewProdutosLocacao_EditingControlShowing;
            dataGridViewProdutosLocacao.RowsAdded += dataGridViewProdutosLocacao_RowsAdded;
            // 
            // dateTimePickerDataPedido
            // 
            dateTimePickerDataPedido.CustomFormat = "";
            dateTimePickerDataPedido.Location = new Point(73, 158);
            dateTimePickerDataPedido.Name = "dateTimePickerDataPedido";
            dateTimePickerDataPedido.Size = new Size(200, 23);
            dateTimePickerDataPedido.TabIndex = 2;
            dateTimePickerDataPedido.Value = new DateTime(2025, 8, 19, 21, 44, 54, 0);
            // 
            // buttonFinalizarPedido
            // 
            buttonFinalizarPedido.Location = new Point(647, 352);
            buttonFinalizarPedido.Name = "buttonFinalizarPedido";
            buttonFinalizarPedido.Size = new Size(118, 23);
            buttonFinalizarPedido.TabIndex = 3;
            buttonFinalizarPedido.Text = "Finalizar Pedido";
            buttonFinalizarPedido.UseVisualStyleBackColor = true;
            buttonFinalizarPedido.Click += buttonFinalizarPedido_Click;
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Location = new Point(16, 0);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(44, 15);
            labelCliente.TabIndex = 4;
            labelCliente.Text = "Cliente";
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(142, 0);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 5;
            labelNome.Text = "Nome";
            // 
            // labelDocumentos
            // 
            labelDocumentos.AutoSize = true;
            labelDocumentos.Location = new Point(594, 0);
            labelDocumentos.Name = "labelDocumentos";
            labelDocumentos.Size = new Size(60, 15);
            labelDocumentos.TabIndex = 6;
            labelDocumentos.Text = "CFP/CNPJ";
            // 
            // ProdutoID
            // 
            ProdutoID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProdutoID.HeaderText = "Codigo";
            ProdutoID.Name = "ProdutoID";
            // 
            // Produto
            // 
            Produto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Produto.HeaderText = "Produto";
            Produto.Name = "Produto";
            // 
            // Estoque
            // 
            Estoque.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Estoque.HeaderText = "Estoque";
            Estoque.Name = "Estoque";
            Estoque.ReadOnly = true;
            // 
            // Quantidade
            // 
            Quantidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Quantidade.HeaderText = "Quantidade";
            Quantidade.Name = "Quantidade";
            // 
            // ValorUnitario
            // 
            ValorUnitario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ValorUnitario.HeaderText = "Valor Unitario";
            ValorUnitario.Name = "ValorUnitario";
            ValorUnitario.ReadOnly = true;
            // 
            // ValorTotal
            // 
            ValorTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ValorTotal.HeaderText = "Valor Total";
            ValorTotal.Name = "ValorTotal";
            ValorTotal.ReadOnly = true;
            // 
            // TelaPedidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 749);
            Controls.Add(labelDocumentos);
            Controls.Add(labelNome);
            Controls.Add(labelCliente);
            Controls.Add(buttonFinalizarPedido);
            Controls.Add(dateTimePickerDataPedido);
            Controls.Add(dataGridViewProdutosLocacao);
            Controls.Add(InformacoesCliente);
            Name = "TelaPedidoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela Pedido";
            InformacoesCliente.ResumeLayout(false);
            InformacoesCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DateTimePicker dateTimePickerDataPedido;
        private Button buttonFinalizarPedido;
        private Label labelCliente;
        private Label labelNome;
        private Label labelDocumentos;
        private Label labelNomeContato;
        private Label labelObservacoes;
        private Label labelNumeroContato;
        private DataGridViewTextBoxColumn ProdutoID;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn Estoque;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn ValorUnitario;
        private DataGridViewTextBoxColumn ValorTotal;
    }
}