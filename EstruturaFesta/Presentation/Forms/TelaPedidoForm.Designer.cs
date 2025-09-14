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
            maskedTextBoxNumeroContato = new MaskedTextBox();
            GerarLink = new Button();
            linkLabelWhatsApp = new LinkLabel();
            labelObservacoes = new Label();
            labelNumeroContato = new Label();
            labelNomeContato = new Label();
            bntBuscarCliente = new Button();
            textBoxIDCliente = new TextBox();
            textBoxDescrição = new TextBox();
            textBoxContato = new TextBox();
            textBoxDocumentoCliente = new TextBox();
            textBoxNomeCliente = new TextBox();
            dataGridViewProdutosLocacao = new DataGridView();
            ProdutoID = new DataGridViewTextBoxColumn();
            Produto = new DataGridViewTextBoxColumn();
            Estoque = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            ValorUnitario = new DataGridViewTextBoxColumn();
            ValorReposicao = new DataGridViewTextBoxColumn();
            ValorTotal = new DataGridViewTextBoxColumn();
            dateTimePickerDataPedido = new DateTimePicker();
            buttonFinalizarPedido = new Button();
            labelCliente = new Label();
            labelNome = new Label();
            labelDocumentos = new Label();
            dateTimePickerEntrega = new DateTimePicker();
            dateTimePickerRetirada = new DateTimePicker();
            labelEntrega = new Label();
            labelEvento = new Label();
            labelRetirada = new Label();
            buttonQuebra = new Button();
            textBoxTotalValorQuebra = new TextBox();
            InformacoesCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).BeginInit();
            SuspendLayout();
            // 
            // InformacoesCliente
            // 
            InformacoesCliente.Controls.Add(maskedTextBoxNumeroContato);
            InformacoesCliente.Controls.Add(GerarLink);
            InformacoesCliente.Controls.Add(linkLabelWhatsApp);
            InformacoesCliente.Controls.Add(labelObservacoes);
            InformacoesCliente.Controls.Add(labelNumeroContato);
            InformacoesCliente.Controls.Add(labelNomeContato);
            InformacoesCliente.Controls.Add(bntBuscarCliente);
            InformacoesCliente.Controls.Add(textBoxIDCliente);
            InformacoesCliente.Controls.Add(textBoxDescrição);
            InformacoesCliente.Controls.Add(textBoxContato);
            InformacoesCliente.Controls.Add(textBoxDocumentoCliente);
            InformacoesCliente.Controls.Add(textBoxNomeCliente);
            InformacoesCliente.Location = new Point(12, 12);
            InformacoesCliente.Name = "InformacoesCliente";
            InformacoesCliente.Size = new Size(756, 124);
            InformacoesCliente.TabIndex = 0;
            // 
            // maskedTextBoxNumeroContato
            // 
            maskedTextBoxNumeroContato.Location = new Point(195, 72);
            maskedTextBoxNumeroContato.Mask = "(00)00000-0000";
            maskedTextBoxNumeroContato.Name = "maskedTextBoxNumeroContato";
            maskedTextBoxNumeroContato.Size = new Size(87, 23);
            maskedTextBoxNumeroContato.TabIndex = 7;
            // 
            // GerarLink
            // 
            GerarLink.Location = new Point(56, 98);
            GerarLink.Name = "GerarLink";
            GerarLink.Size = new Size(132, 23);
            GerarLink.TabIndex = 9;
            GerarLink.Text = "Gerar Link de Contato";
            GerarLink.UseVisualStyleBackColor = true;
            GerarLink.Click += GerarLink_Click;
            // 
            // linkLabelWhatsApp
            // 
            linkLabelWhatsApp.AutoSize = true;
            linkLabelWhatsApp.Location = new Point(282, 75);
            linkLabelWhatsApp.Name = "linkLabelWhatsApp";
            linkLabelWhatsApp.Size = new Size(91, 15);
            linkLabelWhatsApp.TabIndex = 7;
            linkLabelWhatsApp.TabStop = true;
            linkLabelWhatsApp.Text = "Abrir WhatsApp";
            linkLabelWhatsApp.Visible = false;
            linkLabelWhatsApp.LinkClicked += linkLabelWhatsApp_LinkClicked;
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
            labelNumeroContato.Location = new Point(192, 55);
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
            dataGridViewProdutosLocacao.Columns.AddRange(new DataGridViewColumn[] { ProdutoID, Produto, Estoque, Quantidade, ValorUnitario, ValorReposicao, ValorTotal });
            dataGridViewProdutosLocacao.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewProdutosLocacao.Location = new Point(12, 187);
            dataGridViewProdutosLocacao.MultiSelect = false;
            dataGridViewProdutosLocacao.Name = "dataGridViewProdutosLocacao";
            dataGridViewProdutosLocacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewProdutosLocacao.Size = new Size(753, 150);
            dataGridViewProdutosLocacao.TabIndex = 1;
            dataGridViewProdutosLocacao.CellBeginEdit += dataGridViewProdutosLocacao_CellBeginEdit;
            dataGridViewProdutosLocacao.CellEndEdit += dataGridViewProdutosLocacao_CellEndEdit;
            dataGridViewProdutosLocacao.CellFormatting += dataGridViewProdutosLocacao_CellFormatting;
            dataGridViewProdutosLocacao.CurrentCellChanged += dataGridViewProdutosLocacao_CurrentCellChanged;
            dataGridViewProdutosLocacao.EditingControlShowing += dataGridViewProdutosLocacao_EditingControlShowing;
            dataGridViewProdutosLocacao.RowHeaderMouseClick += dataGridViewProdutosLocacao_RowHeaderMouseClick;
            dataGridViewProdutosLocacao.RowPostPaint += dataGridViewProdutosLocacao_RowPostPaint;
            dataGridViewProdutosLocacao.RowsAdded += dataGridViewProdutosLocacao_RowsAdded;
            // 
            // ProdutoID
            // 
            ProdutoID.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ProdutoID.HeaderText = "Codigo";
            ProdutoID.Name = "ProdutoID";
            ProdutoID.Width = 71;
            // 
            // Produto
            // 
            Produto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Produto.HeaderText = "Produto";
            Produto.Name = "Produto";
            // 
            // Estoque
            // 
            Estoque.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Estoque.HeaderText = "Estoque";
            Estoque.Name = "Estoque";
            Estoque.ReadOnly = true;
            Estoque.Width = 74;
            // 
            // Quantidade
            // 
            Quantidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Quantidade.HeaderText = "Quantidade";
            Quantidade.Name = "Quantidade";
            Quantidade.Width = 94;
            // 
            // ValorUnitario
            // 
            ValorUnitario.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ValorUnitario.HeaderText = "Valor Unitario";
            ValorUnitario.Name = "ValorUnitario";
            ValorUnitario.ReadOnly = true;
            ValorUnitario.Width = 95;
            // 
            // ValorReposicao
            // 
            ValorReposicao.HeaderText = "Valor Reposição";
            ValorReposicao.Name = "ValorReposicao";
            ValorReposicao.ReadOnly = true;
            // 
            // ValorTotal
            // 
            ValorTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ValorTotal.HeaderText = "Valor Total";
            ValorTotal.Name = "ValorTotal";
            ValorTotal.ReadOnly = true;
            ValorTotal.Width = 79;
            // 
            // dateTimePickerDataPedido
            // 
            dateTimePickerDataPedido.CustomFormat = "";
            dateTimePickerDataPedido.Format = DateTimePickerFormat.Short;
            dateTimePickerDataPedido.Location = new Point(126, 158);
            dateTimePickerDataPedido.Name = "dateTimePickerDataPedido";
            dateTimePickerDataPedido.Size = new Size(97, 23);
            dateTimePickerDataPedido.TabIndex = 2;
            dateTimePickerDataPedido.Value = new DateTime(2025, 8, 20, 0, 0, 0, 0);
            dateTimePickerDataPedido.ValueChanged += dateTimePickerDataPedido_ValueChanged;
            // 
            // buttonFinalizarPedido
            // 
            buttonFinalizarPedido.Location = new Point(647, 372);
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
            labelDocumentos.Text = "CPF/CNPJ";
            // 
            // dateTimePickerEntrega
            // 
            dateTimePickerEntrega.CustomFormat = "";
            dateTimePickerEntrega.Format = DateTimePickerFormat.Short;
            dateTimePickerEntrega.Location = new Point(23, 158);
            dateTimePickerEntrega.Name = "dateTimePickerEntrega";
            dateTimePickerEntrega.Size = new Size(97, 23);
            dateTimePickerEntrega.TabIndex = 2;
            dateTimePickerEntrega.Value = new DateTime(2025, 8, 20, 0, 0, 0, 0);
            // 
            // dateTimePickerRetirada
            // 
            dateTimePickerRetirada.CustomFormat = "";
            dateTimePickerRetirada.Format = DateTimePickerFormat.Short;
            dateTimePickerRetirada.Location = new Point(229, 158);
            dateTimePickerRetirada.Name = "dateTimePickerRetirada";
            dateTimePickerRetirada.Size = new Size(97, 23);
            dateTimePickerRetirada.TabIndex = 2;
            dateTimePickerRetirada.Value = new DateTime(2025, 8, 20, 0, 0, 0, 0);
            // 
            // labelEntrega
            // 
            labelEntrega.AutoSize = true;
            labelEntrega.Location = new Point(23, 140);
            labelEntrega.Name = "labelEntrega";
            labelEntrega.Size = new Size(47, 15);
            labelEntrega.TabIndex = 7;
            labelEntrega.Text = "Entrega";
            // 
            // labelEvento
            // 
            labelEvento.AutoSize = true;
            labelEvento.Location = new Point(126, 140);
            labelEvento.Name = "labelEvento";
            labelEvento.Size = new Size(43, 15);
            labelEvento.TabIndex = 7;
            labelEvento.Text = "Evento";
            // 
            // labelRetirada
            // 
            labelRetirada.AutoSize = true;
            labelRetirada.Location = new Point(229, 140);
            labelRetirada.Name = "labelRetirada";
            labelRetirada.Size = new Size(50, 15);
            labelRetirada.TabIndex = 7;
            labelRetirada.Text = "Retirada";
            // 
            // buttonQuebra
            // 
            buttonQuebra.Location = new Point(566, 372);
            buttonQuebra.Name = "buttonQuebra";
            buttonQuebra.Size = new Size(75, 23);
            buttonQuebra.TabIndex = 8;
            buttonQuebra.Text = "Quebras";
            buttonQuebra.UseVisualStyleBackColor = true;
            buttonQuebra.Click += buttonQuebra_Click;
            // 
            // textBoxTotalValorQuebra
            // 
            textBoxTotalValorQuebra.Location = new Point(665, 343);
            textBoxTotalValorQuebra.Name = "textBoxTotalValorQuebra";
            textBoxTotalValorQuebra.Size = new Size(100, 23);
            textBoxTotalValorQuebra.TabIndex = 9;
            // 
            // TelaPedidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 749);
            Controls.Add(textBoxTotalValorQuebra);
            Controls.Add(buttonQuebra);
            Controls.Add(labelRetirada);
            Controls.Add(labelEvento);
            Controls.Add(labelEntrega);
            Controls.Add(labelDocumentos);
            Controls.Add(labelNome);
            Controls.Add(labelCliente);
            Controls.Add(buttonFinalizarPedido);
            Controls.Add(dateTimePickerRetirada);
            Controls.Add(dateTimePickerEntrega);
            Controls.Add(dateTimePickerDataPedido);
            Controls.Add(dataGridViewProdutosLocacao);
            Controls.Add(InformacoesCliente);
            Name = "TelaPedidoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela Pedido";
            Load += TelaPedidoForm_Load;
            InformacoesCliente.ResumeLayout(false);
            InformacoesCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel InformacoesCliente;
        private TextBox textBoxDescrição;
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
        private Button GerarLink;
        private LinkLabel linkLabelWhatsApp;
        private MaskedTextBox maskedTextBoxNumeroContato;
        private DataGridViewTextBoxColumn ProdutoID;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn Estoque;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn ValorUnitario;
        private DataGridViewTextBoxColumn ValorReposicao;
        private DataGridViewTextBoxColumn ValorTotal;
        private DateTimePicker dateTimePickerEntrega;
        private DateTimePicker dateTimePickerRetirada;
        private Label labelEntrega;
        private Label labelEvento;
        private Label labelRetirada;
        private Button buttonQuebra;
        private TextBox textBoxTotalValorQuebra;
    }
}