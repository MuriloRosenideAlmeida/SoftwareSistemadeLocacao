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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            InformacoesCliente = new Panel();
            buttonEditarCliente = new Button();
            labelIdPedido = new Label();
            textBoxIDPedido = new TextBox();
            labelTelefones = new Label();
            dataGridViewTelefones = new DataGridView();
            NomeContato = new DataGridViewTextBoxColumn();
            Telefone = new DataGridViewTextBoxColumn();
            maskedTextBoxNumeroContato = new MaskedTextBox();
            GerarLink = new Button();
            linkLabelWhatsApp = new LinkLabel();
            labelObservacoes = new Label();
            labelNumeroContato = new Label();
            labelCliente = new Label();
            labelNome = new Label();
            labelDocumentos = new Label();
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
            dateTimePickerEntrega = new DateTimePicker();
            dateTimePickerRetirada = new DateTimePicker();
            labelEntrega = new Label();
            labelEvento = new Label();
            labelRetirada = new Label();
            buttonQuebra = new Button();
            textBoxTotalValorQuebra = new TextBox();
            panelSaldo = new Panel();
            labelIDSaldo = new Label();
            labelTotalGasto = new Label();
            labelSaldo = new Label();
            labelNomePanel = new Label();
            textBoxIDSaldo = new TextBox();
            textBoxTotalGasto = new TextBox();
            textBoxSaldoCliente = new TextBox();
            labelReposicao = new Label();
            textBoxValorTotal = new TextBox();
            labelValorTotal = new Label();
            dataGridViewPagamentos = new DataGridView();
            PagamentoId = new DataGridViewTextBoxColumn();
            FormaPagamento = new DataGridViewComboBoxColumn();
            DataPagamento = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            Pago = new DataGridViewCheckBoxColumn();
            textBoxSaldoPedido = new TextBox();
            labelSaldoPedido = new Label();
            textBoxSubTotal = new TextBox();
            textBoxAcrescimo = new TextBox();
            textBoxDesconto = new TextBox();
            labelSubTotal = new Label();
            labelAcrescimo = new Label();
            labelDesconto = new Label();
            toolTipQuebra = new ToolTip(components);
            InformacoesCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTelefones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).BeginInit();
            panelSaldo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagamentos).BeginInit();
            SuspendLayout();
            // 
            // InformacoesCliente
            // 
            InformacoesCliente.Controls.Add(buttonEditarCliente);
            InformacoesCliente.Controls.Add(labelIdPedido);
            InformacoesCliente.Controls.Add(textBoxIDPedido);
            InformacoesCliente.Controls.Add(labelTelefones);
            InformacoesCliente.Controls.Add(dataGridViewTelefones);
            InformacoesCliente.Controls.Add(maskedTextBoxNumeroContato);
            InformacoesCliente.Controls.Add(GerarLink);
            InformacoesCliente.Controls.Add(linkLabelWhatsApp);
            InformacoesCliente.Controls.Add(labelObservacoes);
            InformacoesCliente.Controls.Add(labelNumeroContato);
            InformacoesCliente.Controls.Add(labelCliente);
            InformacoesCliente.Controls.Add(labelNome);
            InformacoesCliente.Controls.Add(labelDocumentos);
            InformacoesCliente.Controls.Add(labelNomeContato);
            InformacoesCliente.Controls.Add(bntBuscarCliente);
            InformacoesCliente.Controls.Add(textBoxIDCliente);
            InformacoesCliente.Controls.Add(textBoxDescrição);
            InformacoesCliente.Controls.Add(textBoxContato);
            InformacoesCliente.Controls.Add(textBoxDocumentoCliente);
            InformacoesCliente.Controls.Add(textBoxNomeCliente);
            InformacoesCliente.Location = new Point(0, 0);
            InformacoesCliente.Name = "InformacoesCliente";
            InformacoesCliente.Size = new Size(1009, 189);
            InformacoesCliente.TabIndex = 0;
            // 
            // buttonEditarCliente
            // 
            buttonEditarCliente.Location = new Point(223, 35);
            buttonEditarCliente.Name = "buttonEditarCliente";
            buttonEditarCliente.Size = new Size(75, 23);
            buttonEditarCliente.TabIndex = 14;
            buttonEditarCliente.Text = "Cliente";
            buttonEditarCliente.UseVisualStyleBackColor = true;
            buttonEditarCliente.Click += buttonEditarCliente_Click;
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
            // textBoxIDPedido
            // 
            textBoxIDPedido.Location = new Point(12, 35);
            textBoxIDPedido.Name = "textBoxIDPedido";
            textBoxIDPedido.ReadOnly = true;
            textBoxIDPedido.Size = new Size(100, 23);
            textBoxIDPedido.TabIndex = 12;
            textBoxIDPedido.TextAlign = HorizontalAlignment.Right;
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
            // maskedTextBoxNumeroContato
            // 
            maskedTextBoxNumeroContato.Anchor = AnchorStyles.Left;
            maskedTextBoxNumeroContato.Location = new Point(510, 98);
            maskedTextBoxNumeroContato.Mask = "(00)00000-0000";
            maskedTextBoxNumeroContato.Name = "maskedTextBoxNumeroContato";
            maskedTextBoxNumeroContato.Size = new Size(87, 23);
            maskedTextBoxNumeroContato.TabIndex = 7;
            // 
            // GerarLink
            // 
            GerarLink.Anchor = AnchorStyles.Left;
            GerarLink.Location = new Point(351, 123);
            GerarLink.Name = "GerarLink";
            GerarLink.Size = new Size(132, 23);
            GerarLink.TabIndex = 9;
            GerarLink.Text = "Gerar Link de Contato";
            GerarLink.UseVisualStyleBackColor = true;
            GerarLink.Click += GerarLink_Click;
            // 
            // linkLabelWhatsApp
            // 
            linkLabelWhatsApp.Anchor = AnchorStyles.Left;
            linkLabelWhatsApp.AutoSize = true;
            linkLabelWhatsApp.Location = new Point(510, 131);
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
            labelNumeroContato.Location = new Point(510, 80);
            labelNumeroContato.Name = "labelNumeroContato";
            labelNumeroContato.Size = new Size(114, 15);
            labelNumeroContato.TabIndex = 7;
            labelNumeroContato.Text = "Numero do Contato";
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Location = new Point(142, 17);
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
            labelNomeContato.Location = new Point(351, 80);
            labelNomeContato.Name = "labelNomeContato";
            labelNomeContato.Size = new Size(103, 15);
            labelNomeContato.TabIndex = 7;
            labelNomeContato.Text = "Nome do Contato";
            // 
            // bntBuscarCliente
            // 
            bntBuscarCliente.FlatStyle = FlatStyle.Flat;
            bntBuscarCliente.Font = new Font("Segoe UI", 7F);
            bntBuscarCliente.Location = new Point(185, 35);
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
            textBoxIDCliente.Location = new Point(140, 35);
            textBoxIDCliente.Name = "textBoxIDCliente";
            textBoxIDCliente.Size = new Size(46, 23);
            textBoxIDCliente.TabIndex = 1;
            textBoxIDCliente.TextAlign = HorizontalAlignment.Right;
            // 
            // textBoxDescrição
            // 
            textBoxDescrição.Anchor = AnchorStyles.Right;
            textBoxDescrição.Location = new Point(648, 98);
            textBoxDescrição.Multiline = true;
            textBoxDescrição.Name = "textBoxDescrição";
            textBoxDescrição.Size = new Size(356, 63);
            textBoxDescrição.TabIndex = 6;
            // 
            // textBoxContato
            // 
            textBoxContato.Anchor = AnchorStyles.Left;
            textBoxContato.Location = new Point(351, 98);
            textBoxContato.Name = "textBoxContato";
            textBoxContato.Size = new Size(153, 23);
            textBoxContato.TabIndex = 4;
            // 
            // textBoxDocumentoCliente
            // 
            textBoxDocumentoCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxDocumentoCliente.Location = new Point(825, 35);
            textBoxDocumentoCliente.Name = "textBoxDocumentoCliente";
            textBoxDocumentoCliente.Size = new Size(172, 23);
            textBoxDocumentoCliente.TabIndex = 3;
            // 
            // textBoxNomeCliente
            // 
            textBoxNomeCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxNomeCliente.Location = new Point(329, 35);
            textBoxNomeCliente.Name = "textBoxNomeCliente";
            textBoxNomeCliente.Size = new Size(475, 23);
            textBoxNomeCliente.TabIndex = 2;
            // 
            // dataGridViewProdutosLocacao
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewProdutosLocacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewProdutosLocacao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProdutosLocacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutosLocacao.Columns.AddRange(new DataGridViewColumn[] { ProdutoID, Produto, Estoque, Quantidade, ValorUnitario, ValorReposicao, ValorTotal });
            dataGridViewProdutosLocacao.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewProdutosLocacao.EnableHeadersVisualStyles = false;
            dataGridViewProdutosLocacao.Location = new Point(31, 239);
            dataGridViewProdutosLocacao.MultiSelect = false;
            dataGridViewProdutosLocacao.Name = "dataGridViewProdutosLocacao";
            dataGridViewCellStyle7.SelectionBackColor = Color.White;
            dataGridViewProdutosLocacao.RowsDefaultCellStyle = dataGridViewCellStyle7;
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
            // buttonFinalizarPedido
            // 
            buttonFinalizarPedido.Location = new Point(955, 565);
            buttonFinalizarPedido.Name = "buttonFinalizarPedido";
            buttonFinalizarPedido.Size = new Size(118, 23);
            buttonFinalizarPedido.TabIndex = 3;
            buttonFinalizarPedido.Text = "Finalizar Pedido";
            buttonFinalizarPedido.UseVisualStyleBackColor = true;
            buttonFinalizarPedido.Click += buttonFinalizarPedido_Click;
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
            // buttonQuebra
            // 
            buttonQuebra.Location = new Point(865, 565);
            buttonQuebra.Name = "buttonQuebra";
            buttonQuebra.Size = new Size(75, 23);
            buttonQuebra.TabIndex = 8;
            buttonQuebra.Text = "Quebras";
            buttonQuebra.UseVisualStyleBackColor = true;
            buttonQuebra.Click += buttonQuebra_Click;
            // 
            // textBoxTotalValorQuebra
            // 
            textBoxTotalValorQuebra.Location = new Point(955, 507);
            textBoxTotalValorQuebra.Name = "textBoxTotalValorQuebra";
            textBoxTotalValorQuebra.Size = new Size(118, 23);
            textBoxTotalValorQuebra.TabIndex = 9;
            textBoxTotalValorQuebra.TextChanged += textBoxTotalValorQuebra_TextChanged;
            // 
            // panelSaldo
            // 
            panelSaldo.Controls.Add(labelIDSaldo);
            panelSaldo.Controls.Add(labelTotalGasto);
            panelSaldo.Controls.Add(labelSaldo);
            panelSaldo.Controls.Add(labelNomePanel);
            panelSaldo.Controls.Add(textBoxIDSaldo);
            panelSaldo.Controls.Add(textBoxTotalGasto);
            panelSaldo.Controls.Add(textBoxSaldoCliente);
            panelSaldo.Location = new Point(1010, 0);
            panelSaldo.Name = "panelSaldo";
            panelSaldo.Size = new Size(117, 189);
            panelSaldo.TabIndex = 10;
            panelSaldo.Paint += panelSaldo_Paint;
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
            labelTotalGasto.Location = new Point(5, 36);
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
            // labelNomePanel
            // 
            labelNomePanel.AutoSize = true;
            labelNomePanel.Location = new Point(5, 9);
            labelNomePanel.Name = "labelNomePanel";
            labelNomePanel.Size = new Size(36, 15);
            labelNomePanel.TabIndex = 1;
            labelNomePanel.Text = "Saldo";
            // 
            // textBoxIDSaldo
            // 
            textBoxIDSaldo.Location = new Point(5, 150);
            textBoxIDSaldo.Name = "textBoxIDSaldo";
            textBoxIDSaldo.Size = new Size(106, 23);
            textBoxIDSaldo.TabIndex = 0;
            // 
            // textBoxTotalGasto
            // 
            textBoxTotalGasto.Location = new Point(5, 54);
            textBoxTotalGasto.Name = "textBoxTotalGasto";
            textBoxTotalGasto.Size = new Size(106, 23);
            textBoxTotalGasto.TabIndex = 0;
            // 
            // textBoxSaldoCliente
            // 
            textBoxSaldoCliente.Location = new Point(5, 98);
            textBoxSaldoCliente.Name = "textBoxSaldoCliente";
            textBoxSaldoCliente.Size = new Size(106, 23);
            textBoxSaldoCliente.TabIndex = 0;
            // 
            // labelReposicao
            // 
            labelReposicao.AutoSize = true;
            labelReposicao.Location = new Point(859, 510);
            labelReposicao.Name = "labelReposicao";
            labelReposicao.Size = new Size(90, 15);
            labelReposicao.TabIndex = 11;
            labelReposicao.Text = "Valor Reposição";
            // 
            // textBoxValorTotal
            // 
            textBoxValorTotal.Location = new Point(955, 536);
            textBoxValorTotal.Name = "textBoxValorTotal";
            textBoxValorTotal.Size = new Size(118, 23);
            textBoxValorTotal.TabIndex = 9;
            // 
            // labelValorTotal
            // 
            labelValorTotal.AutoSize = true;
            labelValorTotal.Location = new Point(888, 539);
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
            dataGridViewCellStyle8.NullValue = "Dinheiro";
            FormaPagamento.DefaultCellStyle = dataGridViewCellStyle8;
            FormaPagamento.HeaderText = "Forma de Pagamento";
            FormaPagamento.Items.AddRange(new object[] { "Dinheiro", "Pix", "Credito", "Debito" });
            FormaPagamento.Name = "FormaPagamento";
            // 
            // DataPagamento
            // 
            DataPagamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataPagamento.DataPropertyName = "DataPagamento";
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            DataPagamento.DefaultCellStyle = dataGridViewCellStyle9;
            DataPagamento.HeaderText = "Data do Pagamento";
            DataPagamento.Name = "DataPagamento";
            // 
            // Valor
            // 
            Valor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            Valor.DefaultCellStyle = dataGridViewCellStyle10;
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
            // textBoxSaldoPedido
            // 
            textBoxSaldoPedido.Location = new Point(955, 478);
            textBoxSaldoPedido.Name = "textBoxSaldoPedido";
            textBoxSaldoPedido.Size = new Size(118, 23);
            textBoxSaldoPedido.TabIndex = 13;
            // 
            // labelSaldoPedido
            // 
            labelSaldoPedido.AutoSize = true;
            labelSaldoPedido.Location = new Point(856, 481);
            labelSaldoPedido.Name = "labelSaldoPedido";
            labelSaldoPedido.Size = new Size(93, 15);
            labelSaldoPedido.TabIndex = 11;
            labelSaldoPedido.Text = "Saldo do Pedido";
            // 
            // textBoxSubTotal
            // 
            textBoxSubTotal.Location = new Point(955, 395);
            textBoxSubTotal.Name = "textBoxSubTotal";
            textBoxSubTotal.Size = new Size(118, 23);
            textBoxSubTotal.TabIndex = 14;
            // 
            // textBoxAcrescimo
            // 
            textBoxAcrescimo.Location = new Point(955, 424);
            textBoxAcrescimo.Name = "textBoxAcrescimo";
            textBoxAcrescimo.Size = new Size(118, 23);
            textBoxAcrescimo.TabIndex = 14;
            textBoxAcrescimo.TextChanged += textBoxAcrescimo_TextChanged;
            // 
            // textBoxDesconto
            // 
            textBoxDesconto.Location = new Point(955, 452);
            textBoxDesconto.Name = "textBoxDesconto";
            textBoxDesconto.Size = new Size(118, 23);
            textBoxDesconto.TabIndex = 14;
            textBoxDesconto.TextChanged += textBoxDesconto_TextChanged;
            // 
            // labelSubTotal
            // 
            labelSubTotal.AutoSize = true;
            labelSubTotal.Location = new Point(894, 398);
            labelSubTotal.Name = "labelSubTotal";
            labelSubTotal.Size = new Size(55, 15);
            labelSubTotal.TabIndex = 15;
            labelSubTotal.Text = "Sub Total";
            // 
            // labelAcrescimo
            // 
            labelAcrescimo.AutoSize = true;
            labelAcrescimo.Location = new Point(886, 427);
            labelAcrescimo.Name = "labelAcrescimo";
            labelAcrescimo.Size = new Size(63, 15);
            labelAcrescimo.TabIndex = 15;
            labelAcrescimo.Text = "Acréscimo";
            // 
            // labelDesconto
            // 
            labelDesconto.AutoSize = true;
            labelDesconto.Location = new Point(892, 455);
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
            // TelaPedidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 600);
            Controls.Add(labelDesconto);
            Controls.Add(labelAcrescimo);
            Controls.Add(labelSubTotal);
            Controls.Add(textBoxDesconto);
            Controls.Add(textBoxAcrescimo);
            Controls.Add(textBoxSubTotal);
            Controls.Add(textBoxSaldoPedido);
            Controls.Add(dataGridViewPagamentos);
            Controls.Add(labelValorTotal);
            Controls.Add(labelSaldoPedido);
            Controls.Add(labelReposicao);
            Controls.Add(panelSaldo);
            Controls.Add(textBoxValorTotal);
            Controls.Add(textBoxTotalValorQuebra);
            Controls.Add(buttonQuebra);
            Controls.Add(labelRetirada);
            Controls.Add(labelEvento);
            Controls.Add(labelEntrega);
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewTelefones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutosLocacao).EndInit();
            panelSaldo.ResumeLayout(false);
            panelSaldo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPagamentos).EndInit();
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
        private Label labelTelefones;
        private DataGridView dataGridViewTelefones;
        private DataGridViewTextBoxColumn NomeContato;
        private DataGridViewTextBoxColumn Telefone;
        private Label labelIdPedido;
        private TextBox textBoxIDPedido;
        private Panel panelSaldo;
        private Label labelIDSaldo;
        private Label labelSaldo;
        private Label labelNomePanel;
        private TextBox textBoxIDSaldo;
        private TextBox textBoxSaldoCliente;
        private Label labelReposicao;
        private TextBox textBoxValorTotal;
        private Label labelValorTotal;
        private Label labelTotalGasto;
        private TextBox textBoxTotalGasto;
        private Button buttonEditarCliente;
        private DataGridView dataGridViewPagamentos;
        private TextBox textBoxSaldoPedido;
        private Label labelSaldoPedido;
        private TextBox textBoxSubTotal;
        private TextBox textBoxAcrescimo;
        private TextBox textBoxDesconto;
        private Label labelSubTotal;
        private Label labelAcrescimo;
        private Label labelDesconto;
        private DataGridViewTextBoxColumn PagamentoId;
        private DataGridViewComboBoxColumn FormaPagamento;
        private DataGridViewTextBoxColumn DataPagamento;
        private DataGridViewTextBoxColumn Valor;
        private DataGridViewCheckBoxColumn Pago;
        private ToolTip toolTipQuebra;
    }
}