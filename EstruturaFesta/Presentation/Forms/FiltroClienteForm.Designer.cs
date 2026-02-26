namespace EstruturaFesta.Presentation.Forms
{
    partial class FiltroClienteForm
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
            dataGridViewFiltroClientes = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Documento = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            labelNome = new Label();
            labelDocumentos = new Label();
            designTextBoxNome = new Design.DesignTextBox();
            designTextBoxDocumentos = new Design.DesignTextBox();
            designButton = new Design.DesignButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroClientes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFiltroClientes
            // 
            dataGridViewFiltroClientes.BackgroundColor = SystemColors.Control;
            dataGridViewFiltroClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltroClientes.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Documento, Tipo });
            dataGridViewFiltroClientes.Location = new Point(2, 63);
            dataGridViewFiltroClientes.Name = "dataGridViewFiltroClientes";
            dataGridViewFiltroClientes.Size = new Size(884, 378);
            dataGridViewFiltroClientes.TabIndex = 0;
            dataGridViewFiltroClientes.CellMouseDoubleClick += dataGridViewFiltroClientes_CellMouseDoubleClick;
            dataGridViewFiltroClientes.ColumnHeaderMouseClick += dataGridViewFiltroClientes_ColumnHeaderMouseClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID.DataPropertyName = "ID";
            ID.FillWeight = 10F;
            ID.HeaderText = "Codigo";
            ID.Name = "ID";
            // 
            // Nome
            // 
            Nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nome.DataPropertyName = "Nome";
            Nome.FillWeight = 50F;
            Nome.HeaderText = "Nome Cliente";
            Nome.Name = "Nome";
            // 
            // Documento
            // 
            Documento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Documento.DataPropertyName = "Documento";
            Documento.FillWeight = 25F;
            Documento.HeaderText = "Documento";
            Documento.Name = "Documento";
            // 
            // Tipo
            // 
            Tipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Tipo.DataPropertyName = "TipoCliente";
            Tipo.FillWeight = 15F;
            Tipo.HeaderText = "Tipo Cliente";
            Tipo.Name = "Tipo";
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(32, 37);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(121, 15);
            labelNome.TabIndex = 2;
            labelNome.Text = "Nome/NomeFantasia";
            // 
            // labelDocumentos
            // 
            labelDocumentos.AutoSize = true;
            labelDocumentos.Location = new Point(395, 36);
            labelDocumentos.Name = "labelDocumentos";
            labelDocumentos.Size = new Size(60, 15);
            labelDocumentos.TabIndex = 2;
            labelDocumentos.Text = "CPF/CNPJ";
            // 
            // designTextBoxNome
            // 
            designTextBoxNome.BackColor = SystemColors.Window;
            designTextBoxNome.BorderColor = Color.MediumSlateBlue;
            designTextBoxNome.BorderFocusColor = Color.HotPink;
            designTextBoxNome.BorderRadius = 15;
            designTextBoxNome.BorderSize = 1;
            designTextBoxNome.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNome.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNome.ForeColor = SystemColors.WindowText;
            designTextBoxNome.Location = new Point(159, 26);
            designTextBoxNome.Multiline = false;
            designTextBoxNome.Name = "designTextBoxNome";
            designTextBoxNome.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNome.PasswordChar = false;
            designTextBoxNome.PlaceholderColor = Color.DarkGray;
            designTextBoxNome.PlaceholderText = "Nome do Cliente";
            designTextBoxNome.SelectionLength = 0;
            designTextBoxNome.SelectionStart = 0;
            designTextBoxNome.Size = new Size(218, 32);
            designTextBoxNome.TabIndex = 4;
            designTextBoxNome.UnderlinedStyle = false;
            // 
            // designTextBoxDocumentos
            // 
            designTextBoxDocumentos.BackColor = SystemColors.Window;
            designTextBoxDocumentos.BorderColor = Color.MediumSlateBlue;
            designTextBoxDocumentos.BorderFocusColor = Color.HotPink;
            designTextBoxDocumentos.BorderRadius = 15;
            designTextBoxDocumentos.BorderSize = 1;
            designTextBoxDocumentos.CharacterCasing = CharacterCasing.Normal;
            designTextBoxDocumentos.Font = new Font("Segoe UI", 9.5F);
            designTextBoxDocumentos.ForeColor = SystemColors.WindowText;
            designTextBoxDocumentos.Location = new Point(460, 25);
            designTextBoxDocumentos.Multiline = false;
            designTextBoxDocumentos.Name = "designTextBoxDocumentos";
            designTextBoxDocumentos.Padding = new Padding(10, 7, 10, 7);
            designTextBoxDocumentos.PasswordChar = false;
            designTextBoxDocumentos.PlaceholderColor = Color.DarkGray;
            designTextBoxDocumentos.PlaceholderText = "Documentos";
            designTextBoxDocumentos.SelectionLength = 0;
            designTextBoxDocumentos.SelectionStart = 0;
            designTextBoxDocumentos.Size = new Size(218, 32);
            designTextBoxDocumentos.TabIndex = 4;
            designTextBoxDocumentos.UnderlinedStyle = false;
            // 
            // designButton
            // 
            designButton.BackColor = Color.MediumSlateBlue;
            designButton.BackgroundColor = Color.MediumSlateBlue;
            designButton.BorderColor = Color.MediumSlateBlue;
            designButton.BorderRadius = 22;
            designButton.BorderSize = 0;
            designButton.FlatAppearance.BorderSize = 0;
            designButton.FlatStyle = FlatStyle.Flat;
            designButton.ForeColor = Color.White;
            designButton.Location = new Point(736, 17);
            designButton.Name = "designButton";
            designButton.Size = new Size(150, 40);
            designButton.TabIndex = 5;
            designButton.Text = "Filtrar";
            designButton.TextColor = Color.White;
            designButton.UseVisualStyleBackColor = false;
            designButton.Click += designButton_Click;
            // 
            // FiltroClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 473);
            Controls.Add(designButton);
            Controls.Add(designTextBoxDocumentos);
            Controls.Add(designTextBoxNome);
            Controls.Add(labelDocumentos);
            Controls.Add(labelNome);
            Controls.Add(dataGridViewFiltroClientes);
            Name = "FiltroClienteForm";
            Text = "Filtro de Cliente";
            Load += FiltroClienteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewFiltroClientes;
        private Label labelNome;
        private Label labelDocumentos;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn Tipo;
        private Design.DesignTextBox designTextBoxNome;
        private Design.DesignTextBox designTextBoxDocumentos;
        private Design.DesignButton designButton;
    }
}