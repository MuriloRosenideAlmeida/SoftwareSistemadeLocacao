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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            InformacoesCliente = new Panel();
            designButtonGerarLink = new Design.DesignButton();
            designTextBoxNumeroContato = new Design.DesignTextBox();
            designTextBoxContato = new Design.DesignTextBox();
            designButtonEditarCliente = new Design.DesignButton();
            designTextBoxDescricao = new Design.DesignTextBox();
            designTextBox1 = new Design.DesignTextBox();
            designTextBoxDocumentoCliente = new Design.DesignTextBox();
            designTextBoxNomeCliente = new Design.DesignTextBox();
            designTextBoxIDPedido = new Design.DesignTextBox();
            labelIdPedido = new Label();
            labelTelefones = new Label();
            dataGridViewTelefones = new DataGridView();
            NomeContato = new DataGridViewTextBoxColumn();
            Telefone = new DataGridViewTextBoxColumn();
            linkLabelWhatsApp = new LinkLabel();
            labelObservacoes = new Label();
            labelNumeroContato = new Label();
            labelCliente = new Label();
            labelNome = new Label();
            labelDocumentos = new Label();
            labelNomeContato = new Label();
            bntBuscarCliente = new Button();
            textBoxIDCliente = new TextBox();
            dataGridViewProdutosLocacao = new DataGridView();
            ProdutoID = new DataGridViewTextBoxColumn();
            Produto = new DataGridViewTextBoxColumn();
            Estoque = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            ValorUnitario = new DataGridViewTextBoxColumn();
            ValorReposicao = new DataGridViewTextBoxColumn();
            ValorTotal = new DataGridViewTextBoxColumn();
            dateTimePickerDataPedido = new DateTimePicker();
            dateTimePickerEntrega = new DateTimePicker();
            dateTimePickerRetirada = new DateTimePicker();
            labelEntrega = new Label();
            labelEvento = new Label();
            labelRetirada = new Label();
            panelSaldo = new Panel();
            designTextBoxIDSaldo = new Design.DesignTextBox();
            designTextBoxSaldoCliente = new Design.DesignTextBox();
            designTextBoxTotalGasto = new Design.DesignTextBox();
            labelIDSaldo = new Label();
            labelTotalGasto = new Label();
            labelSaldo = new Label();
            labelReposicao = new Label();
            labelValorTotal = new Label();
            dataGridViewPagamentos = new DataGridView();
            PagamentoId = new DataGridViewTextBoxColumn();
            FormaPagamento = new DataGridViewComboBoxColumn();
            DataPagamento = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            Pago = new DataGridViewCheckBoxColumn();
            labelSaldoPedido = new Label();
            labelSubTotal = new Label();
            labelAcrescimo = new Label();
            labelDesconto = new Label();
            toolTipQuebra = new ToolTip(components);
            designTextBoxAcrescimo = new Design.DesignTextBox();
            designTextBoxDesconto = new Design.DesignTextBox();
            designTextBoxSaldoPedido = new Design.DesignTextBox();
            designTextBoxTotalValorQuebra = new Design.DesignTextBox();
            designTextBoxValorTotal = new Design.DesignTextBox();
            designTextBoxSubTotal = new Design.DesignTextBox();
            panelContabilidade = new Panel();
            designButtonFinalizarPedido = new Design.DesignButton();
            designButtonQuebra = new Design.DesignButton();
            designButtonVisualizarPDF = new Design.DesignButton();
            designButtonSalvarPDF = new Design.DesignButton();
            InformacoesCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTelefones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).BeginInit();
            panelSaldo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagamentos).BeginInit();
            panelContabilidade.SuspendLayout();
            SuspendLayout();
            // 
            // InformacoesCliente
            // 
            InformacoesCliente.Controls.Add(designButtonGerarLink);
            InformacoesCliente.Controls.Add(designTextBoxNumeroContato);
            InformacoesCliente.Controls.Add(designTextBoxContato);
            InformacoesCliente.Controls.Add(designButtonEditarCliente);
            InformacoesCliente.Controls.Add(designTextBoxDescricao);
            InformacoesCliente.Controls.Add(designTextBox1);
            InformacoesCliente.Controls.Add(designTextBoxDocumentoCliente);
            InformacoesCliente.Controls.Add(designTextBoxNomeCliente);
            InformacoesCliente.Controls.Add(designTextBoxIDPedido);
            InformacoesCliente.Controls.Add(labelIdPedido);
            InformacoesCliente.Controls.Add(labelTelefones);
            InformacoesCliente.Controls.Add(dataGridViewTelefones);
            InformacoesCliente.Controls.Add(linkLabelWhatsApp);
            InformacoesCliente.Controls.Add(labelObservacoes);
            InformacoesCliente.Controls.Add(labelNumeroContato);
            InformacoesCliente.Controls.Add(labelCliente);
            InformacoesCliente.Controls.Add(labelNome);
            InformacoesCliente.Controls.Add(labelDocumentos);
            InformacoesCliente.Controls.Add(labelNomeContato);
            InformacoesCliente.Controls.Add(bntBuscarCliente);
            InformacoesCliente.Controls.Add(textBoxIDCliente);
            InformacoesCliente.Location = new Point(2, 0);
            InformacoesCliente.Name = "InformacoesCliente";
            InformacoesCliente.Size = new Size(1009, 189);
            InformacoesCliente.TabIndex = 0;
            InformacoesCliente.Paint += InformacoesCliente_Paint;
            // 
            // designButtonGerarLink
            // 
            designButtonGerarLink.BackColor = Color.LimeGreen;
            designButtonGerarLink.BackgroundColor = Color.LimeGreen;
            designButtonGerarLink.BorderColor = Color.PaleVioletRed;
            designButtonGerarLink.BorderRadius = 14;
            designButtonGerarLink.BorderSize = 0;
            designButtonGerarLink.FlatAppearance.BorderSize = 0;
            designButtonGerarLink.FlatStyle = FlatStyle.Flat;
            designButtonGerarLink.ForeColor = Color.White;
            designButtonGerarLink.Location = new Point(351, 135);
            designButtonGerarLink.Name = "designButtonGerarLink";
            designButtonGerarLink.Size = new Size(132, 25);
            designButtonGerarLink.TabIndex = 17;
            designButtonGerarLink.Text = "WhatsApp";
            designButtonGerarLink.TextColor = Color.White;
            designButtonGerarLink.UseVisualStyleBackColor = false;
            designButtonGerarLink.Click += designButtonGerarLink_Click;
            // 
            // designTextBoxNumeroContato
            // 
            designTextBoxNumeroContato.BackColor = SystemColors.Window;
            designTextBoxNumeroContato.BorderColor = Color.MediumSlateBlue;
            designTextBoxNumeroContato.BorderFocusColor = Color.HotPink;
            designTextBoxNumeroContato.BorderRadius = 15;
            designTextBoxNumeroContato.BorderSize = 1;
            designTextBoxNumeroContato.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNumeroContato.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNumeroContato.ForeColor = SystemColors.WindowText;
            designTextBoxNumeroContato.Location = new Point(510, 98);
            designTextBoxNumeroContato.Multiline = false;
            designTextBoxNumeroContato.Name = "designTextBoxNumeroContato";
            designTextBoxNumeroContato.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNumeroContato.PasswordChar = false;
            designTextBoxNumeroContato.PlaceholderColor = Color.DarkGray;
            designTextBoxNumeroContato.PlaceholderText = "Numero ";
            designTextBoxNumeroContato.SelectionLength = 0;
            designTextBoxNumeroContato.SelectionStart = 0;
            designTextBoxNumeroContato.Size = new Size(114, 32);
            designTextBoxNumeroContato.TabIndex = 21;
            designTextBoxNumeroContato.UnderlinedStyle = false;
            // 
            // designTextBoxContato
            // 
            designTextBoxContato.BackColor = SystemColors.Window;
            designTextBoxContato.BorderColor = Color.MediumSlateBlue;
            designTextBoxContato.BorderFocusColor = Color.HotPink;
            designTextBoxContato.BorderRadius = 15;
            designTextBoxContato.BorderSize = 1;
            designTextBoxContato.CharacterCasing = CharacterCasing.Normal;
            designTextBoxContato.Font = new Font("Segoe UI", 9.5F);
            designTextBoxContato.ForeColor = SystemColors.WindowText;
            designTextBoxContato.Location = new Point(351, 98);
            designTextBoxContato.Multiline = false;
            designTextBoxContato.Name = "designTextBoxContato";
            designTextBoxContato.Padding = new Padding(10, 7, 10, 7);
            designTextBoxContato.PasswordChar = false;
            designTextBoxContato.PlaceholderColor = Color.DarkGray;
            designTextBoxContato.PlaceholderText = "Nome do Contato";
            designTextBoxContato.SelectionLength = 0;
            designTextBoxContato.SelectionStart = 0;
            designTextBoxContato.Size = new Size(153, 32);
            designTextBoxContato.TabIndex = 21;
            designTextBoxContato.UnderlinedStyle = false;
            // 
            // designButtonEditarCliente
            // 
            designButtonEditarCliente.BackColor = Color.MediumSlateBlue;
            designButtonEditarCliente.BackgroundColor = Color.MediumSlateBlue;
            designButtonEditarCliente.BorderColor = Color.PaleVioletRed;
            designButtonEditarCliente.BorderRadius = 14;
            designButtonEditarCliente.BorderSize = 0;
            designButtonEditarCliente.FlatAppearance.BorderSize = 0;
            designButtonEditarCliente.FlatStyle = FlatStyle.Flat;
            designButtonEditarCliente.ForeColor = Color.White;
            designButtonEditarCliente.Location = new Point(226, 34);
            designButtonEditarCliente.Name = "designButtonEditarCliente";
            designButtonEditarCliente.Size = new Size(75, 31);
            designButtonEditarCliente.TabIndex = 17;
            designButtonEditarCliente.Text = "Cliente";
            designButtonEditarCliente.TextColor = Color.White;
            designButtonEditarCliente.UseVisualStyleBackColor = false;
            designButtonEditarCliente.Click += designButtonEditarCliente_Click;
            // 
            // designTextBoxDescricao
            // 
            designTextBoxDescricao.BackColor = SystemColors.Window;
            designTextBoxDescricao.BorderColor = Color.MediumSlateBlue;
            designTextBoxDescricao.BorderFocusColor = Color.HotPink;
            designTextBoxDescricao.BorderRadius = 15;
            designTextBoxDescricao.BorderSize = 1;
            designTextBoxDescricao.CharacterCasing = CharacterCasing.Normal;
            designTextBoxDescricao.Font = new Font("Segoe UI", 9.5F);
            designTextBoxDescricao.ForeColor = SystemColors.WindowText;
            designTextBoxDescricao.Location = new Point(648, 97);
            designTextBoxDescricao.Multiline = true;
            designTextBoxDescricao.Name = "designTextBoxDescricao";
            designTextBoxDescricao.Padding = new Padding(10, 7, 10, 7);
            designTextBoxDescricao.PasswordChar = false;
            designTextBoxDescricao.PlaceholderColor = Color.DarkGray;
            designTextBoxDescricao.PlaceholderText = "Observações do Pedido";
            designTextBoxDescricao.SelectionLength = 0;
            designTextBoxDescricao.SelectionStart = 0;
            designTextBoxDescricao.Size = new Size(358, 64);
            designTextBoxDescricao.TabIndex = 20;
            designTextBoxDescricao.UnderlinedStyle = false;
            // 
            // designTextBox1
            // 
            designTextBox1.BackColor = SystemColors.Window;
            designTextBox1.BorderColor = Color.MediumSlateBlue;
            designTextBox1.BorderFocusColor = Color.HotPink;
            designTextBox1.BorderRadius = 0;
            designTextBox1.BorderSize = 2;
            designTextBox1.CharacterCasing = CharacterCasing.Normal;
            designTextBox1.Font = new Font("Segoe UI", 9.5F);
            designTextBox1.ForeColor = Color.DimGray;
            designTextBox1.Location = new Point(1015, 45);
            designTextBox1.Multiline = false;
            designTextBox1.Name = "designTextBox1";
            designTextBox1.Padding = new Padding(10, 7, 10, 7);
            designTextBox1.PasswordChar = false;
            designTextBox1.PlaceholderColor = Color.DarkGray;
            designTextBox1.PlaceholderText = "";
            designTextBox1.SelectionLength = 0;
            designTextBox1.SelectionStart = 0;
            designTextBox1.Size = new Size(115, 32);
            designTextBox1.TabIndex = 2;
            designTextBox1.UnderlinedStyle = false;
            // 
            // designTextBoxDocumentoCliente
            // 
            designTextBoxDocumentoCliente.BackColor = SystemColors.Window;
            designTextBoxDocumentoCliente.BorderColor = Color.MediumSlateBlue;
            designTextBoxDocumentoCliente.BorderFocusColor = Color.HotPink;
            designTextBoxDocumentoCliente.BorderRadius = 15;
            designTextBoxDocumentoCliente.BorderSize = 1;
            designTextBoxDocumentoCliente.CharacterCasing = CharacterCasing.Normal;
            designTextBoxDocumentoCliente.Font = new Font("Segoe UI", 9.5F);
            designTextBoxDocumentoCliente.ForeColor = SystemColors.WindowText;
            designTextBoxDocumentoCliente.Location = new Point(823, 33);
            designTextBoxDocumentoCliente.Multiline = false;
            designTextBoxDocumentoCliente.Name = "designTextBoxDocumentoCliente";
            designTextBoxDocumentoCliente.Padding = new Padding(10, 7, 10, 7);
            designTextBoxDocumentoCliente.PasswordChar = false;
            designTextBoxDocumentoCliente.PlaceholderColor = Color.DarkGray;
            designTextBoxDocumentoCliente.PlaceholderText = "Documentos do Cliente";
            designTextBoxDocumentoCliente.SelectionLength = 0;
            designTextBoxDocumentoCliente.SelectionStart = 0;
            designTextBoxDocumentoCliente.Size = new Size(174, 32);
            designTextBoxDocumentoCliente.TabIndex = 19;
            designTextBoxDocumentoCliente.UnderlinedStyle = false;
            // 
            // designTextBoxNomeCliente
            // 
            designTextBoxNomeCliente.BackColor = SystemColors.Window;
            designTextBoxNomeCliente.BorderColor = Color.MediumSlateBlue;
            designTextBoxNomeCliente.BorderFocusColor = Color.HotPink;
            designTextBoxNomeCliente.BorderRadius = 15;
            designTextBoxNomeCliente.BorderSize = 1;
            designTextBoxNomeCliente.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNomeCliente.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNomeCliente.ForeColor = SystemColors.WindowText;
            designTextBoxNomeCliente.Location = new Point(329, 33);
            designTextBoxNomeCliente.Multiline = false;
            designTextBoxNomeCliente.Name = "designTextBoxNomeCliente";
            designTextBoxNomeCliente.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNomeCliente.PasswordChar = false;
            designTextBoxNomeCliente.PlaceholderColor = Color.DarkGray;
            designTextBoxNomeCliente.PlaceholderText = "Nome do Cliente";
            designTextBoxNomeCliente.SelectionLength = 0;
            designTextBoxNomeCliente.SelectionStart = 0;
            designTextBoxNomeCliente.Size = new Size(475, 32);
            designTextBoxNomeCliente.TabIndex = 18;
            designTextBoxNomeCliente.UnderlinedStyle = false;
            // 
            // designTextBoxIDPedido
            // 
            designTextBoxIDPedido.BackColor = SystemColors.Window;
            designTextBoxIDPedido.BorderColor = Color.MediumSlateBlue;
            designTextBoxIDPedido.BorderFocusColor = Color.HotPink;
            designTextBoxIDPedido.BorderRadius = 15;
            designTextBoxIDPedido.BorderSize = 1;
            designTextBoxIDPedido.CharacterCasing = CharacterCasing.Normal;
            designTextBoxIDPedido.Font = new Font("Segoe UI", 9.5F);
            designTextBoxIDPedido.ForeColor = SystemColors.WindowText;
            designTextBoxIDPedido.Location = new Point(7, 33);
            designTextBoxIDPedido.Multiline = false;
            designTextBoxIDPedido.Name = "designTextBoxIDPedido";
            designTextBoxIDPedido.Padding = new Padding(10, 7, 10, 7);
            designTextBoxIDPedido.PasswordChar = false;
            designTextBoxIDPedido.PlaceholderColor = Color.DarkGray;
            designTextBoxIDPedido.PlaceholderText = "Código";
            designTextBoxIDPedido.SelectionLength = 0;
            designTextBoxIDPedido.SelectionStart = 0;
            designTextBoxIDPedido.Size = new Size(100, 32);
            designTextBoxIDPedido.TabIndex = 17;
            designTextBoxIDPedido.UnderlinedStyle = false;
            // 
            // labelIdPedido
            // 
            labelIdPedido.AutoSize = true;
            labelIdPedido.Location = new Point(12, 17);
            labelIdPedido.Name = "labelIdPedido";
            labelIdPedido.Size = new Size(46, 15);
            labelIdPedido.TabIndex = 13;
            labelIdPedido.Text = "Código";
            // 
            // labelTelefones
            // 
            labelTelefones.AutoSize = true;
            labelTelefones.Location = new Point(12, 80);
            labelTelefones.Name = "labelTelefones";
            labelTelefones.Size = new Size(51, 15);
            labelTelefones.TabIndex = 11;
            labelTelefones.Text = "Telefone";
            // 
            // dataGridViewTelefones
            // 
            dataGridViewTelefones.BackgroundColor = SystemColors.Control;
            dataGridViewTelefones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTelefones.Columns.AddRange(new DataGridViewColumn[] { NomeContato, Telefone });
            dataGridViewTelefones.Location = new Point(4, 98);
            dataGridViewTelefones.Name = "dataGridViewTelefones";
            dataGridViewTelefones.Size = new Size(341, 75);
            dataGridViewTelefones.TabIndex = 10;
            // 
            // NomeContato
            // 
            NomeContato.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomeContato.DataPropertyName = "NomeContato";
            NomeContato.HeaderText = "Nome";
            NomeContato.Name = "NomeContato";
            NomeContato.ReadOnly = true;
            // 
            // Telefone
            // 
            Telefone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Telefone.DataPropertyName = "Telefone";
            Telefone.HeaderText = "Telefone";
            Telefone.Name = "Telefone";
            Telefone.ReadOnly = true;
            // 
            // linkLabelWhatsApp
            // 
            linkLabelWhatsApp.Anchor = AnchorStyles.Left;
            linkLabelWhatsApp.AutoSize = true;
            linkLabelWhatsApp.Location = new Point(510, 140);
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
            labelObservacoes.Anchor = AnchorStyles.Right;
            labelObservacoes.AutoSize = true;
            labelObservacoes.Location = new Point(648, 80);
            labelObservacoes.Name = "labelObservacoes";
            labelObservacoes.Size = new Size(74, 15);
            labelObservacoes.TabIndex = 8;
            labelObservacoes.Text = "Observações";
            // 
            // labelNumeroContato
            // 
            labelNumeroContato.Anchor = AnchorStyles.Left;
            labelNumeroContato.AutoSize = true;
            labelNumeroContato.Location = new Point(510, 81);
            labelNumeroContato.Name = "labelNumeroContato";
            labelNumeroContato.Size = new Size(114, 15);
            labelNumeroContato.TabIndex = 7;
            labelNumeroContato.Text = "Numero do Contato";
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Location = new Point(133, 21);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(44, 15);
            labelCliente.TabIndex = 4;
            labelCliente.Text = "Cliente";
            // 
            // labelNome
            // 
            labelNome.Anchor = AnchorStyles.Left;
            labelNome.AutoSize = true;
            labelNome.Location = new Point(329, 17);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 5;
            labelNome.Text = "Nome";
            // 
            // labelDocumentos
            // 
            labelDocumentos.Anchor = AnchorStyles.Right;
            labelDocumentos.AutoSize = true;
            labelDocumentos.Location = new Point(825, 17);
            labelDocumentos.Name = "labelDocumentos";
            labelDocumentos.Size = new Size(60, 15);
            labelDocumentos.TabIndex = 6;
            labelDocumentos.Text = "CPF/CNPJ";
            // 
            // labelNomeContato
            // 
            labelNomeContato.Anchor = AnchorStyles.Left;
            labelNomeContato.AutoSize = true;
            labelNomeContato.Location = new Point(358, 81);
            labelNomeContato.Name = "labelNomeContato";
            labelNomeContato.Size = new Size(103, 15);
            labelNomeContato.TabIndex = 7;
            labelNomeContato.Text = "Nome do Contato";
            // 
            // bntBuscarCliente
            // 
            bntBuscarCliente.FlatStyle = FlatStyle.Flat;
            bntBuscarCliente.Font = new Font("Segoe UI", 7F);
            bntBuscarCliente.Location = new Point(176, 39);
            bntBuscarCliente.Name = "bntBuscarCliente";
            bntBuscarCliente.Size = new Size(23, 23);
            bntBuscarCliente.TabIndex = 1;
            bntBuscarCliente.Text = "▼";
            bntBuscarCliente.UseVisualStyleBackColor = true;
            bntBuscarCliente.Click += bntBuscarCliente_Click;
            bntBuscarCliente.PreviewKeyDown += bntBuscarCliente_PreviewKeyDown;
            // 
            // textBoxIDCliente
            // 
            textBoxIDCliente.Location = new Point(131, 39);
            textBoxIDCliente.Name = "textBoxIDCliente";
            textBoxIDCliente.Size = new Size(46, 23);
            textBoxIDCliente.TabIndex = 1;
            textBoxIDCliente.TextAlign = HorizontalAlignment.Right;
            // 
            // dataGridViewProdutosLocacao
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewProdutosLocacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewProdutosLocacao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProdutosLocacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutosLocacao.Columns.AddRange(new DataGridViewColumn[] { ProdutoID, Produto, Estoque, Quantidade, ValorUnitario, ValorReposicao, ValorTotal });
            dataGridViewProdutosLocacao.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewProdutosLocacao.EnableHeadersVisualStyles = false;
            dataGridViewProdutosLocacao.Location = new Point(31, 239);
            dataGridViewProdutosLocacao.MultiSelect = false;
            dataGridViewProdutosLocacao.Name = "dataGridViewProdutosLocacao";
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewProdutosLocacao.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewProdutosLocacao.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dataGridViewProdutosLocacao.RowTemplate.Height = 20;
            dataGridViewProdutosLocacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewProdutosLocacao.Size = new Size(1042, 150);
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
            dateTimePickerDataPedido.Location = new Point(145, 210);
            dateTimePickerDataPedido.Name = "dateTimePickerDataPedido";
            dateTimePickerDataPedido.Size = new Size(97, 23);
            dateTimePickerDataPedido.TabIndex = 2;
            dateTimePickerDataPedido.Value = new DateTime(2025, 8, 20, 0, 0, 0, 0);
            dateTimePickerDataPedido.ValueChanged += dateTimePickerDataPedido_ValueChanged;
            // 
            // dateTimePickerEntrega
            // 
            dateTimePickerEntrega.CustomFormat = "";
            dateTimePickerEntrega.Format = DateTimePickerFormat.Short;
            dateTimePickerEntrega.Location = new Point(42, 210);
            dateTimePickerEntrega.Name = "dateTimePickerEntrega";
            dateTimePickerEntrega.Size = new Size(97, 23);
            dateTimePickerEntrega.TabIndex = 2;
            dateTimePickerEntrega.Value = new DateTime(2025, 8, 20, 0, 0, 0, 0);
            // 
            // dateTimePickerRetirada
            // 
            dateTimePickerRetirada.CustomFormat = "";
            dateTimePickerRetirada.Format = DateTimePickerFormat.Short;
            dateTimePickerRetirada.Location = new Point(248, 210);
            dateTimePickerRetirada.Name = "dateTimePickerRetirada";
            dateTimePickerRetirada.Size = new Size(97, 23);
            dateTimePickerRetirada.TabIndex = 2;
            dateTimePickerRetirada.Value = new DateTime(2025, 8, 20, 0, 0, 0, 0);
            // 
            // labelEntrega
            // 
            labelEntrega.AutoSize = true;
            labelEntrega.Location = new Point(42, 192);
            labelEntrega.Name = "labelEntrega";
            labelEntrega.Size = new Size(47, 15);
            labelEntrega.TabIndex = 7;
            labelEntrega.Text = "Entrega";
            // 
            // labelEvento
            // 
            labelEvento.AutoSize = true;
            labelEvento.Location = new Point(145, 192);
            labelEvento.Name = "labelEvento";
            labelEvento.Size = new Size(43, 15);
            labelEvento.TabIndex = 7;
            labelEvento.Text = "Evento";
            // 
            // labelRetirada
            // 
            labelRetirada.AutoSize = true;
            labelRetirada.Location = new Point(248, 192);
            labelRetirada.Name = "labelRetirada";
            labelRetirada.Size = new Size(50, 15);
            labelRetirada.TabIndex = 7;
            labelRetirada.Text = "Retirada";
            // 
            // panelSaldo
            // 
            panelSaldo.Controls.Add(designTextBoxIDSaldo);
            panelSaldo.Controls.Add(designTextBoxSaldoCliente);
            panelSaldo.Controls.Add(designTextBoxTotalGasto);
            panelSaldo.Controls.Add(labelIDSaldo);
            panelSaldo.Controls.Add(labelTotalGasto);
            panelSaldo.Controls.Add(labelSaldo);
            panelSaldo.Location = new Point(1010, 0);
            panelSaldo.Name = "panelSaldo";
            panelSaldo.Size = new Size(120, 189);
            panelSaldo.TabIndex = 10;
            // 
            // designTextBoxIDSaldo
            // 
            designTextBoxIDSaldo.BackColor = SystemColors.Window;
            designTextBoxIDSaldo.BorderColor = Color.MediumSlateBlue;
            designTextBoxIDSaldo.BorderFocusColor = Color.HotPink;
            designTextBoxIDSaldo.BorderRadius = 15;
            designTextBoxIDSaldo.BorderSize = 1;
            designTextBoxIDSaldo.CharacterCasing = CharacterCasing.Normal;
            designTextBoxIDSaldo.Font = new Font("Segoe UI", 9.5F);
            designTextBoxIDSaldo.ForeColor = SystemColors.WindowText;
            designTextBoxIDSaldo.Location = new Point(2, 150);
            designTextBoxIDSaldo.Multiline = false;
            designTextBoxIDSaldo.Name = "designTextBoxIDSaldo";
            designTextBoxIDSaldo.Padding = new Padding(10, 7, 10, 7);
            designTextBoxIDSaldo.PasswordChar = false;
            designTextBoxIDSaldo.PlaceholderColor = Color.DarkGray;
            designTextBoxIDSaldo.PlaceholderText = "Saldo Aberto";
            designTextBoxIDSaldo.SelectionLength = 0;
            designTextBoxIDSaldo.SelectionStart = 0;
            designTextBoxIDSaldo.Size = new Size(113, 32);
            designTextBoxIDSaldo.TabIndex = 20;
            designTextBoxIDSaldo.UnderlinedStyle = false;
            // 
            // designTextBoxSaldoCliente
            // 
            designTextBoxSaldoCliente.BackColor = SystemColors.Window;
            designTextBoxSaldoCliente.BorderColor = Color.MediumSlateBlue;
            designTextBoxSaldoCliente.BorderFocusColor = Color.HotPink;
            designTextBoxSaldoCliente.BorderRadius = 15;
            designTextBoxSaldoCliente.BorderSize = 1;
            designTextBoxSaldoCliente.CharacterCasing = CharacterCasing.Normal;
            designTextBoxSaldoCliente.Font = new Font("Segoe UI", 9.5F);
            designTextBoxSaldoCliente.ForeColor = SystemColors.WindowText;
            designTextBoxSaldoCliente.Location = new Point(2, 97);
            designTextBoxSaldoCliente.Multiline = false;
            designTextBoxSaldoCliente.Name = "designTextBoxSaldoCliente";
            designTextBoxSaldoCliente.Padding = new Padding(10, 7, 10, 7);
            designTextBoxSaldoCliente.PasswordChar = false;
            designTextBoxSaldoCliente.PlaceholderColor = Color.DarkGray;
            designTextBoxSaldoCliente.PlaceholderText = "Saldo Pendente";
            designTextBoxSaldoCliente.SelectionLength = 0;
            designTextBoxSaldoCliente.SelectionStart = 0;
            designTextBoxSaldoCliente.Size = new Size(113, 32);
            designTextBoxSaldoCliente.TabIndex = 20;
            designTextBoxSaldoCliente.UnderlinedStyle = false;
            // 
            // designTextBoxTotalGasto
            // 
            designTextBoxTotalGasto.BackColor = SystemColors.Window;
            designTextBoxTotalGasto.BorderColor = Color.MediumSlateBlue;
            designTextBoxTotalGasto.BorderFocusColor = Color.HotPink;
            designTextBoxTotalGasto.BorderRadius = 15;
            designTextBoxTotalGasto.BorderSize = 1;
            designTextBoxTotalGasto.CharacterCasing = CharacterCasing.Normal;
            designTextBoxTotalGasto.Font = new Font("Segoe UI", 9.5F);
            designTextBoxTotalGasto.ForeColor = SystemColors.WindowText;
            designTextBoxTotalGasto.Location = new Point(0, 45);
            designTextBoxTotalGasto.Multiline = false;
            designTextBoxTotalGasto.Name = "designTextBoxTotalGasto";
            designTextBoxTotalGasto.Padding = new Padding(10, 7, 10, 7);
            designTextBoxTotalGasto.PasswordChar = false;
            designTextBoxTotalGasto.PlaceholderColor = Color.DarkGray;
            designTextBoxTotalGasto.PlaceholderText = "Total Gasto";
            designTextBoxTotalGasto.SelectionLength = 0;
            designTextBoxTotalGasto.SelectionStart = 0;
            designTextBoxTotalGasto.Size = new Size(113, 32);
            designTextBoxTotalGasto.TabIndex = 20;
            designTextBoxTotalGasto.UnderlinedStyle = false;
            // 
            // labelIDSaldo
            // 
            labelIDSaldo.AutoSize = true;
            labelIDSaldo.Location = new Point(3, 132);
            labelIDSaldo.Name = "labelIDSaldo";
            labelIDSaldo.Size = new Size(108, 15);
            labelIDSaldo.TabIndex = 1;
            labelIDSaldo.Text = "Pedidos com Saldo";
            // 
            // labelTotalGasto
            // 
            labelTotalGasto.AutoSize = true;
            labelTotalGasto.Location = new Point(5, 28);
            labelTotalGasto.Name = "labelTotalGasto";
            labelTotalGasto.Size = new Size(65, 15);
            labelTotalGasto.TabIndex = 1;
            labelTotalGasto.Text = "Total Gasto";
            // 
            // labelSaldo
            // 
            labelSaldo.AutoSize = true;
            labelSaldo.Location = new Point(5, 80);
            labelSaldo.Name = "labelSaldo";
            labelSaldo.Size = new Size(95, 15);
            labelSaldo.TabIndex = 1;
            labelSaldo.Text = "Saldo em Aberto";
            // 
            // labelReposicao
            // 
            labelReposicao.AutoSize = true;
            labelReposicao.Location = new Point(6, 145);
            labelReposicao.Name = "labelReposicao";
            labelReposicao.Size = new Size(90, 15);
            labelReposicao.TabIndex = 11;
            labelReposicao.Text = "Valor Reposição";
            // 
            // labelValorTotal
            // 
            labelValorTotal.AutoSize = true;
            labelValorTotal.Location = new Point(34, 179);
            labelValorTotal.Name = "labelValorTotal";
            labelValorTotal.Size = new Size(61, 15);
            labelValorTotal.TabIndex = 11;
            labelValorTotal.Text = "Valor Total";
            // 
            // dataGridViewPagamentos
            // 
            dataGridViewPagamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPagamentos.Columns.AddRange(new DataGridViewColumn[] { PagamentoId, FormaPagamento, DataPagamento, Valor, Pago });
            dataGridViewPagamentos.Location = new Point(42, 438);
            dataGridViewPagamentos.Name = "dataGridViewPagamentos";
            dataGridViewPagamentos.Size = new Size(452, 150);
            dataGridViewPagamentos.TabIndex = 12;
            dataGridViewPagamentos.CellEnter += dataGridViewPagamentos_CellEnter;
            dataGridViewPagamentos.CellFormatting += dataGridViewPagamentos_CellFormatting;
            dataGridViewPagamentos.CellValueChanged += dataGridViewPagamentos_CellValueChanged;
            dataGridViewPagamentos.CurrentCellDirtyStateChanged += dataGridViewPagamentos_CurrentCellDirtyStateChanged;
            dataGridViewPagamentos.EditingControlShowing += dataGridViewPagamentos_EditingControlShowing;
            dataGridViewPagamentos.RowLeave += dataGridViewPagamentos_RowLeave;
            dataGridViewPagamentos.RowPostPaint += dataGridViewPagamentos_RowPostPaint;
            dataGridViewPagamentos.KeyDown += dataGridViewPagamentos_KeyDown;
            // 
            // PagamentoId
            // 
            PagamentoId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            PagamentoId.DataPropertyName = "Id";
            PagamentoId.HeaderText = "Codigo";
            PagamentoId.MaxInputLength = 100;
            PagamentoId.MinimumWidth = 4;
            PagamentoId.Name = "PagamentoId";
            PagamentoId.Visible = false;
            // 
            // FormaPagamento
            // 
            FormaPagamento.DataPropertyName = "FormaPagamento";
            dataGridViewCellStyle3.NullValue = "DINHEIRO";
            FormaPagamento.DefaultCellStyle = dataGridViewCellStyle3;
            FormaPagamento.HeaderText = "Forma de Pagamento";
            FormaPagamento.Items.AddRange(new object[] { "DINHEIRO", "PIX", "CREDITO", "DEBITO" });
            FormaPagamento.Name = "FormaPagamento";
            // 
            // DataPagamento
            // 
            DataPagamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataPagamento.DataPropertyName = "DataPagamento";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            DataPagamento.DefaultCellStyle = dataGridViewCellStyle4;
            DataPagamento.HeaderText = "Data do Pagamento";
            DataPagamento.Name = "DataPagamento";
            // 
            // Valor
            // 
            Valor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            Valor.DefaultCellStyle = dataGridViewCellStyle5;
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            // 
            // Pago
            // 
            Pago.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Pago.DataPropertyName = "Pago";
            Pago.HeaderText = "Pago";
            Pago.Name = "Pago";
            // 
            // labelSaldoPedido
            // 
            labelSaldoPedido.AutoSize = true;
            labelSaldoPedido.Location = new Point(3, 111);
            labelSaldoPedido.Name = "labelSaldoPedido";
            labelSaldoPedido.Size = new Size(93, 15);
            labelSaldoPedido.TabIndex = 11;
            labelSaldoPedido.Text = "Saldo do Pedido";
            // 
            // labelSubTotal
            // 
            labelSubTotal.AutoSize = true;
            labelSubTotal.Location = new Point(40, 9);
            labelSubTotal.Name = "labelSubTotal";
            labelSubTotal.Size = new Size(55, 15);
            labelSubTotal.TabIndex = 15;
            labelSubTotal.Text = "Sub Total";
            // 
            // labelAcrescimo
            // 
            labelAcrescimo.AutoSize = true;
            labelAcrescimo.Location = new Point(33, 42);
            labelAcrescimo.Name = "labelAcrescimo";
            labelAcrescimo.Size = new Size(63, 15);
            labelAcrescimo.TabIndex = 15;
            labelAcrescimo.Text = "Acréscimo";
            // 
            // labelDesconto
            // 
            labelDesconto.AutoSize = true;
            labelDesconto.Location = new Point(39, 78);
            labelDesconto.Name = "labelDesconto";
            labelDesconto.Size = new Size(57, 15);
            labelDesconto.TabIndex = 15;
            labelDesconto.Text = "Desconto";
            // 
            // toolTipQuebra
            // 
            toolTipQuebra.AutoPopDelay = 10000;
            toolTipQuebra.InitialDelay = 500;
            toolTipQuebra.ReshowDelay = 100;
            toolTipQuebra.ShowAlways = true;
            // 
            // designTextBoxAcrescimo
            // 
            designTextBoxAcrescimo.BackColor = SystemColors.Window;
            designTextBoxAcrescimo.BorderColor = Color.MediumSlateBlue;
            designTextBoxAcrescimo.BorderFocusColor = Color.HotPink;
            designTextBoxAcrescimo.BorderRadius = 15;
            designTextBoxAcrescimo.BorderSize = 1;
            designTextBoxAcrescimo.CharacterCasing = CharacterCasing.Normal;
            designTextBoxAcrescimo.Font = new Font("Segoe UI", 9.5F);
            designTextBoxAcrescimo.ForeColor = SystemColors.WindowText;
            designTextBoxAcrescimo.Location = new Point(101, 34);
            designTextBoxAcrescimo.Multiline = false;
            designTextBoxAcrescimo.Name = "designTextBoxAcrescimo";
            designTextBoxAcrescimo.Padding = new Padding(10, 7, 10, 7);
            designTextBoxAcrescimo.PasswordChar = false;
            designTextBoxAcrescimo.PlaceholderColor = Color.DarkGray;
            designTextBoxAcrescimo.PlaceholderText = "Acréscimo";
            designTextBoxAcrescimo.SelectionLength = 0;
            designTextBoxAcrescimo.SelectionStart = 0;
            designTextBoxAcrescimo.Size = new Size(118, 32);
            designTextBoxAcrescimo.TabIndex = 17;
            designTextBoxAcrescimo.UnderlinedStyle = false;
            designTextBoxAcrescimo._TextChanged += designTextBoxAcrescimo_TextChanged;
            // 
            // designTextBoxDesconto
            // 
            designTextBoxDesconto.BackColor = SystemColors.Window;
            designTextBoxDesconto.BorderColor = Color.MediumSlateBlue;
            designTextBoxDesconto.BorderFocusColor = Color.HotPink;
            designTextBoxDesconto.BorderRadius = 15;
            designTextBoxDesconto.BorderSize = 1;
            designTextBoxDesconto.CharacterCasing = CharacterCasing.Normal;
            designTextBoxDesconto.Font = new Font("Segoe UI", 9.5F);
            designTextBoxDesconto.ForeColor = SystemColors.WindowText;
            designTextBoxDesconto.Location = new Point(101, 68);
            designTextBoxDesconto.Multiline = false;
            designTextBoxDesconto.Name = "designTextBoxDesconto";
            designTextBoxDesconto.Padding = new Padding(10, 7, 10, 7);
            designTextBoxDesconto.PasswordChar = false;
            designTextBoxDesconto.PlaceholderColor = Color.DarkGray;
            designTextBoxDesconto.PlaceholderText = "Desconto";
            designTextBoxDesconto.SelectionLength = 0;
            designTextBoxDesconto.SelectionStart = 0;
            designTextBoxDesconto.Size = new Size(118, 32);
            designTextBoxDesconto.TabIndex = 17;
            designTextBoxDesconto.UnderlinedStyle = false;
            designTextBoxDesconto._TextChanged += designTextBoxDesconto_TextChanged;
            // 
            // designTextBoxSaldoPedido
            // 
            designTextBoxSaldoPedido.BackColor = SystemColors.Window;
            designTextBoxSaldoPedido.BorderColor = Color.MediumSlateBlue;
            designTextBoxSaldoPedido.BorderFocusColor = Color.HotPink;
            designTextBoxSaldoPedido.BorderRadius = 15;
            designTextBoxSaldoPedido.BorderSize = 1;
            designTextBoxSaldoPedido.CharacterCasing = CharacterCasing.Normal;
            designTextBoxSaldoPedido.Font = new Font("Segoe UI", 9.5F);
            designTextBoxSaldoPedido.ForeColor = SystemColors.WindowText;
            designTextBoxSaldoPedido.Location = new Point(101, 102);
            designTextBoxSaldoPedido.Multiline = false;
            designTextBoxSaldoPedido.Name = "designTextBoxSaldoPedido";
            designTextBoxSaldoPedido.Padding = new Padding(10, 7, 10, 7);
            designTextBoxSaldoPedido.PasswordChar = false;
            designTextBoxSaldoPedido.PlaceholderColor = Color.DarkGray;
            designTextBoxSaldoPedido.PlaceholderText = "Saldo Pedido";
            designTextBoxSaldoPedido.SelectionLength = 0;
            designTextBoxSaldoPedido.SelectionStart = 0;
            designTextBoxSaldoPedido.Size = new Size(118, 32);
            designTextBoxSaldoPedido.TabIndex = 17;
            designTextBoxSaldoPedido.UnderlinedStyle = false;
            // 
            // designTextBoxTotalValorQuebra
            // 
            designTextBoxTotalValorQuebra.BackColor = SystemColors.Window;
            designTextBoxTotalValorQuebra.BorderColor = Color.MediumSlateBlue;
            designTextBoxTotalValorQuebra.BorderFocusColor = Color.HotPink;
            designTextBoxTotalValorQuebra.BorderRadius = 15;
            designTextBoxTotalValorQuebra.BorderSize = 1;
            designTextBoxTotalValorQuebra.CharacterCasing = CharacterCasing.Normal;
            designTextBoxTotalValorQuebra.Font = new Font("Segoe UI", 9.5F);
            designTextBoxTotalValorQuebra.ForeColor = SystemColors.WindowText;
            designTextBoxTotalValorQuebra.Location = new Point(101, 136);
            designTextBoxTotalValorQuebra.Multiline = false;
            designTextBoxTotalValorQuebra.Name = "designTextBoxTotalValorQuebra";
            designTextBoxTotalValorQuebra.Padding = new Padding(10, 7, 10, 7);
            designTextBoxTotalValorQuebra.PasswordChar = false;
            designTextBoxTotalValorQuebra.PlaceholderColor = Color.DarkGray;
            designTextBoxTotalValorQuebra.PlaceholderText = "Valor Reposição";
            designTextBoxTotalValorQuebra.SelectionLength = 0;
            designTextBoxTotalValorQuebra.SelectionStart = 0;
            designTextBoxTotalValorQuebra.Size = new Size(118, 32);
            designTextBoxTotalValorQuebra.TabIndex = 17;
            designTextBoxTotalValorQuebra.UnderlinedStyle = false;
            designTextBoxTotalValorQuebra._TextChanged += designTextBoxTotalValorQuebra_TextChanged;
            // 
            // designTextBoxValorTotal
            // 
            designTextBoxValorTotal.BackColor = SystemColors.Window;
            designTextBoxValorTotal.BorderColor = Color.MediumSlateBlue;
            designTextBoxValorTotal.BorderFocusColor = Color.HotPink;
            designTextBoxValorTotal.BorderRadius = 15;
            designTextBoxValorTotal.BorderSize = 1;
            designTextBoxValorTotal.CharacterCasing = CharacterCasing.Normal;
            designTextBoxValorTotal.Font = new Font("Segoe UI", 9.5F);
            designTextBoxValorTotal.ForeColor = SystemColors.WindowText;
            designTextBoxValorTotal.Location = new Point(101, 170);
            designTextBoxValorTotal.Multiline = false;
            designTextBoxValorTotal.Name = "designTextBoxValorTotal";
            designTextBoxValorTotal.Padding = new Padding(10, 7, 10, 7);
            designTextBoxValorTotal.PasswordChar = false;
            designTextBoxValorTotal.PlaceholderColor = Color.DarkGray;
            designTextBoxValorTotal.PlaceholderText = "Valor Total";
            designTextBoxValorTotal.SelectionLength = 0;
            designTextBoxValorTotal.SelectionStart = 0;
            designTextBoxValorTotal.Size = new Size(118, 32);
            designTextBoxValorTotal.TabIndex = 17;
            designTextBoxValorTotal.UnderlinedStyle = false;
            // 
            // designTextBoxSubTotal
            // 
            designTextBoxSubTotal.BackColor = SystemColors.Window;
            designTextBoxSubTotal.BorderColor = Color.MediumSlateBlue;
            designTextBoxSubTotal.BorderFocusColor = Color.HotPink;
            designTextBoxSubTotal.BorderRadius = 15;
            designTextBoxSubTotal.BorderSize = 1;
            designTextBoxSubTotal.CharacterCasing = CharacterCasing.Normal;
            designTextBoxSubTotal.Font = new Font("Segoe UI", 9.5F);
            designTextBoxSubTotal.ForeColor = SystemColors.WindowText;
            designTextBoxSubTotal.Location = new Point(101, 0);
            designTextBoxSubTotal.Multiline = false;
            designTextBoxSubTotal.Name = "designTextBoxSubTotal";
            designTextBoxSubTotal.Padding = new Padding(10, 7, 10, 7);
            designTextBoxSubTotal.PasswordChar = false;
            designTextBoxSubTotal.PlaceholderColor = Color.DarkGray;
            designTextBoxSubTotal.PlaceholderText = "SubTotal";
            designTextBoxSubTotal.SelectionLength = 0;
            designTextBoxSubTotal.SelectionStart = 0;
            designTextBoxSubTotal.Size = new Size(118, 32);
            designTextBoxSubTotal.TabIndex = 17;
            designTextBoxSubTotal.UnderlinedStyle = false;
            // 
            // panelContabilidade
            // 
            panelContabilidade.Controls.Add(designTextBoxValorTotal);
            panelContabilidade.Controls.Add(designTextBoxAcrescimo);
            panelContabilidade.Controls.Add(designTextBoxTotalValorQuebra);
            panelContabilidade.Controls.Add(labelReposicao);
            panelContabilidade.Controls.Add(designTextBoxSaldoPedido);
            panelContabilidade.Controls.Add(labelSaldoPedido);
            panelContabilidade.Controls.Add(designTextBoxDesconto);
            panelContabilidade.Controls.Add(labelValorTotal);
            panelContabilidade.Controls.Add(designTextBoxSubTotal);
            panelContabilidade.Controls.Add(labelSubTotal);
            panelContabilidade.Controls.Add(labelAcrescimo);
            panelContabilidade.Controls.Add(labelDesconto);
            panelContabilidade.Location = new Point(851, 395);
            panelContabilidade.Name = "panelContabilidade";
            panelContabilidade.Size = new Size(222, 202);
            panelContabilidade.TabIndex = 18;
            // 
            // designButtonFinalizarPedido
            // 
            designButtonFinalizarPedido.BackColor = Color.LimeGreen;
            designButtonFinalizarPedido.BackgroundColor = Color.LimeGreen;
            designButtonFinalizarPedido.BorderColor = Color.DarkGreen;
            designButtonFinalizarPedido.BorderRadius = 15;
            designButtonFinalizarPedido.BorderSize = 1;
            designButtonFinalizarPedido.FlatAppearance.BorderSize = 0;
            designButtonFinalizarPedido.FlatStyle = FlatStyle.Flat;
            designButtonFinalizarPedido.ForeColor = Color.White;
            designButtonFinalizarPedido.Location = new Point(727, 565);
            designButtonFinalizarPedido.Name = "designButtonFinalizarPedido";
            designButtonFinalizarPedido.Size = new Size(118, 32);
            designButtonFinalizarPedido.TabIndex = 19;
            designButtonFinalizarPedido.Text = "Finalizar Pedido";
            designButtonFinalizarPedido.TextColor = Color.White;
            designButtonFinalizarPedido.UseVisualStyleBackColor = false;
            designButtonFinalizarPedido.Click += designButtonFinalizarPedido_Click;
            // 
            // designButtonQuebra
            // 
            designButtonQuebra.BackColor = Color.Red;
            designButtonQuebra.BackgroundColor = Color.Red;
            designButtonQuebra.BorderColor = Color.DarkRed;
            designButtonQuebra.BorderRadius = 15;
            designButtonQuebra.BorderSize = 1;
            designButtonQuebra.FlatAppearance.BorderSize = 0;
            designButtonQuebra.FlatStyle = FlatStyle.Flat;
            designButtonQuebra.ForeColor = Color.White;
            designButtonQuebra.Location = new Point(636, 565);
            designButtonQuebra.Name = "designButtonQuebra";
            designButtonQuebra.Size = new Size(85, 32);
            designButtonQuebra.TabIndex = 20;
            designButtonQuebra.Text = "Quebras";
            designButtonQuebra.TextColor = Color.White;
            designButtonQuebra.UseVisualStyleBackColor = false;
            designButtonQuebra.Click += designButtonQuebra_Click;
            // 
            // designButtonVisualizarPDF
            // 
            designButtonVisualizarPDF.BackColor = Color.RoyalBlue;
            designButtonVisualizarPDF.BackgroundColor = Color.RoyalBlue;
            designButtonVisualizarPDF.BorderColor = Color.MidnightBlue;
            designButtonVisualizarPDF.BorderRadius = 15;
            designButtonVisualizarPDF.BorderSize = 1;
            designButtonVisualizarPDF.FlatAppearance.BorderSize = 0;
            designButtonVisualizarPDF.FlatStyle = FlatStyle.Flat;
            designButtonVisualizarPDF.ForeColor = Color.White;
            designButtonVisualizarPDF.Location = new Point(500, 565);
            designButtonVisualizarPDF.Name = "designButtonVisualizarPDF";
            designButtonVisualizarPDF.Size = new Size(130, 32);
            designButtonVisualizarPDF.TabIndex = 21;
            designButtonVisualizarPDF.Text = "Imprimir";
            designButtonVisualizarPDF.TextColor = Color.White;
            designButtonVisualizarPDF.UseVisualStyleBackColor = false;
            designButtonVisualizarPDF.Click += designButtonVisualizarPDF_Click;
            // 
            // designButtonSalvarPDF
            // 
            designButtonSalvarPDF.BackColor = Color.MediumTurquoise;
            designButtonSalvarPDF.BackgroundColor = Color.MediumTurquoise;
            designButtonSalvarPDF.BorderColor = Color.DarkSlateGray;
            designButtonSalvarPDF.BorderRadius = 15;
            designButtonSalvarPDF.BorderSize = 1;
            designButtonSalvarPDF.FlatAppearance.BorderSize = 0;
            designButtonSalvarPDF.FlatStyle = FlatStyle.Flat;
            designButtonSalvarPDF.ForeColor = Color.White;
            designButtonSalvarPDF.Location = new Point(500, 531);
            designButtonSalvarPDF.Name = "designButtonSalvarPDF";
            designButtonSalvarPDF.Size = new Size(130, 32);
            designButtonSalvarPDF.TabIndex = 22;
            designButtonSalvarPDF.Text = "Exportar para PDF";
            designButtonSalvarPDF.TextColor = Color.White;
            designButtonSalvarPDF.UseVisualStyleBackColor = false;
            designButtonSalvarPDF.Click += designButtonSalvarPDF_Click;
            // 
            // TelaPedidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 616);
            Controls.Add(designButtonSalvarPDF);
            Controls.Add(designButtonVisualizarPDF);
            Controls.Add(designButtonQuebra);
            Controls.Add(designButtonFinalizarPedido);
            Controls.Add(dataGridViewPagamentos);
            Controls.Add(labelRetirada);
            Controls.Add(labelEvento);
            Controls.Add(labelEntrega);
            Controls.Add(dateTimePickerRetirada);
            Controls.Add(dateTimePickerEntrega);
            Controls.Add(dateTimePickerDataPedido);
            Controls.Add(dataGridViewProdutosLocacao);
            Controls.Add(InformacoesCliente);
            Controls.Add(panelSaldo);
            Controls.Add(panelContabilidade);
            Name = "TelaPedidoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela Pedido";
            Load += TelaPedidoForm_Load;
            InformacoesCliente.ResumeLayout(false);
            InformacoesCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTelefones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).EndInit();
            panelSaldo.ResumeLayout(false);
            panelSaldo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagamentos).EndInit();
            panelContabilidade.ResumeLayout(false);
            panelContabilidade.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel InformacoesCliente;
        private TextBox textBoxIDCliente;
        private Button bntBuscarCliente;
        private DataGridView dataGridViewProdutosLocacao;
        private DateTimePicker dateTimePickerDataPedido;
        private Label labelCliente;
        private Label labelNome;
        private Label labelDocumentos;
        private Label labelNomeContato;
        private Label labelObservacoes;
        private Label labelNumeroContato;
        private LinkLabel linkLabelWhatsApp;
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
        private Label labelTelefones;
        private DataGridView dataGridViewTelefones;
        private DataGridViewTextBoxColumn NomeContato;
        private DataGridViewTextBoxColumn Telefone;
        private Label labelIdPedido;
        private Panel panelSaldo;
        private Label labelIDSaldo;
        private Label labelSaldo;
        private Label labelReposicao;
        private Label labelValorTotal;
        private Label labelTotalGasto;
        private DataGridView dataGridViewPagamentos;
        private Label labelSaldoPedido;
        private TextBox textBoxDesconto;
        private Label labelSubTotal;
        private Label labelAcrescimo;
        private Label labelDesconto;
        private ToolTip toolTipQuebra;
        private DataGridViewTextBoxColumn PagamentoId;
        private DataGridViewComboBoxColumn FormaPagamento;
        private DataGridViewTextBoxColumn DataPagamento;
        private DataGridViewTextBoxColumn Valor;
        private DataGridViewCheckBoxColumn Pago;
        private Design.DesignTextBox designTextBoxIDPedido;
        private Design.DesignTextBox designTextBoxNomeCliente;
        private Design.DesignTextBox designTextBoxDocumentoCliente;
        private Design.DesignTextBox designTextBox1;
        private Design.DesignTextBox designTextBoxTotalGasto;
        private Design.DesignTextBox designTextBoxSaldoCliente;
        private Design.DesignTextBox designTextBoxDescricao;
        private Design.DesignButton designButtonEditarCliente;
        private Design.DesignTextBox designTextBoxIDSaldo;
        private Design.DesignTextBox designTextBoxContato;
        private Design.DesignTextBox designTextBoxNumeroContato;
        private Design.DesignButton designButtonGerarLink;
        private Design.DesignTextBox designTextBoxAcrescimo;
        private Design.DesignTextBox designTextBoxDesconto;
        private Design.DesignTextBox designTextBoxSaldoPedido;
        private Design.DesignTextBox designTextBoxTotalValorQuebra;
        private Design.DesignTextBox designTextBoxValorTotal;
        private Design.DesignTextBox designTextBoxSubTotal;
        private Panel panelContabilidade;
        private Design.DesignButton designButtonFinalizarPedido;
        private Design.DesignButton designButtonQuebra;
        private Design.DesignButton designButtonVisualizarPDF;
        private Design.DesignButton designButtonSalvarPDF;
    }
}