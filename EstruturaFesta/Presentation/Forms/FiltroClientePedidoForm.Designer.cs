namespace EstruturaFesta
{
    partial class FiltroClientePedidoForm
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
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Documento = new DataGridViewTextBoxColumn();
            NomeFantasia = new DataGridViewTextBoxColumn();
            labelNome = new Label();
            labelNomeFantasia = new Label();
            labelDocumento = new Label();
            labelID = new Label();
            panel1 = new Panel();
            designButtonFiltro = new Design.DesignButton();
            designTextBoxNomeFantasia = new Design.DesignTextBox();
            designTextBoxDocumento = new Design.DesignTextBox();
            designTextBoxNome = new Design.DesignTextBox();
            designTextBoxID = new Design.DesignTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Documento, NomeFantasia });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 52);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1108, 398);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID.DataPropertyName = "ID";
            ID.FillWeight = 25F;
            ID.HeaderText = "Codigo";
            ID.Name = "ID";
            // 
            // Nome
            // 
            Nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nome.DataPropertyName = "Nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // Documento
            // 
            Documento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Documento.DataPropertyName = "Documento";
            Documento.FillWeight = 50F;
            Documento.HeaderText = "Documento";
            Documento.Name = "Documento";
            // 
            // NomeFantasia
            // 
            NomeFantasia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomeFantasia.DataPropertyName = "NomeFantasia";
            NomeFantasia.HeaderText = "NomeFantasia";
            NomeFantasia.Name = "NomeFantasia";
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(140, 22);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 1;
            labelNome.Text = "Nome";
            // 
            // labelNomeFantasia
            // 
            labelNomeFantasia.AutoSize = true;
            labelNomeFantasia.Location = new Point(700, 22);
            labelNomeFantasia.Name = "labelNomeFantasia";
            labelNomeFantasia.Size = new Size(86, 15);
            labelNomeFantasia.TabIndex = 1;
            labelNomeFantasia.Text = "Nome Fantasia";
            // 
            // labelDocumento
            // 
            labelDocumento.AutoSize = true;
            labelDocumento.Location = new Point(506, 22);
            labelDocumento.Name = "labelDocumento";
            labelDocumento.Size = new Size(70, 15);
            labelDocumento.TabIndex = 1;
            labelDocumento.Text = "Documento";
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(3, 22);
            labelID.Name = "labelID";
            labelID.Size = new Size(46, 15);
            labelID.TabIndex = 1;
            labelID.Text = "Codigo";
            // 
            // panel1
            // 
            panel1.Controls.Add(designButtonFiltro);
            panel1.Controls.Add(designTextBoxNomeFantasia);
            panel1.Controls.Add(designTextBoxDocumento);
            panel1.Controls.Add(designTextBoxNome);
            panel1.Controls.Add(designTextBoxID);
            panel1.Controls.Add(labelID);
            panel1.Controls.Add(labelDocumento);
            panel1.Controls.Add(labelNomeFantasia);
            panel1.Controls.Add(labelNome);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1108, 52);
            panel1.TabIndex = 3;
            // 
            // designButtonFiltro
            // 
            designButtonFiltro.BackColor = Color.LimeGreen;
            designButtonFiltro.BackgroundColor = Color.LimeGreen;
            designButtonFiltro.BorderColor = Color.LimeGreen;
            designButtonFiltro.BorderRadius = 22;
            designButtonFiltro.BorderSize = 0;
            designButtonFiltro.FlatAppearance.BorderSize = 0;
            designButtonFiltro.FlatStyle = FlatStyle.Flat;
            designButtonFiltro.ForeColor = Color.White;
            designButtonFiltro.Location = new Point(989, 9);
            designButtonFiltro.Name = "designButtonFiltro";
            designButtonFiltro.Size = new Size(97, 40);
            designButtonFiltro.TabIndex = 7;
            designButtonFiltro.Text = "Buscar";
            designButtonFiltro.TextColor = Color.White;
            designButtonFiltro.UseVisualStyleBackColor = false;
            designButtonFiltro.Click += designButtonFiltro_Click;
            // 
            // designTextBoxNomeFantasia
            // 
            designTextBoxNomeFantasia.BackColor = SystemColors.Window;
            designTextBoxNomeFantasia.BorderColor = Color.MediumSlateBlue;
            designTextBoxNomeFantasia.BorderFocusColor = Color.HotPink;
            designTextBoxNomeFantasia.BorderRadius = 15;
            designTextBoxNomeFantasia.BorderSize = 1;
            designTextBoxNomeFantasia.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNomeFantasia.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNomeFantasia.ForeColor = SystemColors.WindowText;
            designTextBoxNomeFantasia.Location = new Point(792, 12);
            designTextBoxNomeFantasia.Multiline = false;
            designTextBoxNomeFantasia.Name = "designTextBoxNomeFantasia";
            designTextBoxNomeFantasia.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNomeFantasia.PasswordChar = false;
            designTextBoxNomeFantasia.PlaceholderColor = Color.DarkGray;
            designTextBoxNomeFantasia.PlaceholderText = "Nome Fantasia";
            designTextBoxNomeFantasia.SelectionLength = 0;
            designTextBoxNomeFantasia.SelectionStart = 0;
            designTextBoxNomeFantasia.Size = new Size(183, 32);
            designTextBoxNomeFantasia.TabIndex = 6;
            designTextBoxNomeFantasia.UnderlinedStyle = false;
            // 
            // designTextBoxDocumento
            // 
            designTextBoxDocumento.BackColor = SystemColors.Window;
            designTextBoxDocumento.BorderColor = Color.MediumSlateBlue;
            designTextBoxDocumento.BorderFocusColor = Color.HotPink;
            designTextBoxDocumento.BorderRadius = 15;
            designTextBoxDocumento.BorderSize = 1;
            designTextBoxDocumento.CharacterCasing = CharacterCasing.Normal;
            designTextBoxDocumento.Font = new Font("Segoe UI", 9.5F);
            designTextBoxDocumento.ForeColor = SystemColors.WindowText;
            designTextBoxDocumento.Location = new Point(582, 12);
            designTextBoxDocumento.Multiline = false;
            designTextBoxDocumento.Name = "designTextBoxDocumento";
            designTextBoxDocumento.Padding = new Padding(10, 7, 10, 7);
            designTextBoxDocumento.PasswordChar = false;
            designTextBoxDocumento.PlaceholderColor = Color.DarkGray;
            designTextBoxDocumento.PlaceholderText = "Documento";
            designTextBoxDocumento.SelectionLength = 0;
            designTextBoxDocumento.SelectionStart = 0;
            designTextBoxDocumento.Size = new Size(112, 32);
            designTextBoxDocumento.TabIndex = 5;
            designTextBoxDocumento.UnderlinedStyle = false;
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
            designTextBoxNome.Location = new Point(186, 12);
            designTextBoxNome.Multiline = false;
            designTextBoxNome.Name = "designTextBoxNome";
            designTextBoxNome.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNome.PasswordChar = false;
            designTextBoxNome.PlaceholderColor = Color.DarkGray;
            designTextBoxNome.PlaceholderText = "Nome / Razão Social";
            designTextBoxNome.SelectionLength = 0;
            designTextBoxNome.SelectionStart = 0;
            designTextBoxNome.Size = new Size(314, 32);
            designTextBoxNome.TabIndex = 4;
            designTextBoxNome.UnderlinedStyle = false;
            // 
            // designTextBoxID
            // 
            designTextBoxID.BackColor = SystemColors.Window;
            designTextBoxID.BorderColor = Color.MediumSlateBlue;
            designTextBoxID.BorderFocusColor = Color.HotPink;
            designTextBoxID.BorderRadius = 15;
            designTextBoxID.BorderSize = 1;
            designTextBoxID.CharacterCasing = CharacterCasing.Normal;
            designTextBoxID.Font = new Font("Segoe UI", 9.5F);
            designTextBoxID.ForeColor = SystemColors.WindowText;
            designTextBoxID.Location = new Point(55, 13);
            designTextBoxID.Multiline = false;
            designTextBoxID.Name = "designTextBoxID";
            designTextBoxID.Padding = new Padding(10, 7, 10, 7);
            designTextBoxID.PasswordChar = false;
            designTextBoxID.PlaceholderColor = Color.DarkGray;
            designTextBoxID.PlaceholderText = "Codigo";
            designTextBoxID.SelectionLength = 0;
            designTextBoxID.SelectionStart = 0;
            designTextBoxID.Size = new Size(79, 32);
            designTextBoxID.TabIndex = 4;
            designTextBoxID.UnderlinedStyle = false;
            // 
            // FiltroClientePedidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "FiltroClientePedidoForm";
            Text = "Filtro de Clientes";
            Load += FormDataGridView_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn NomeFantasia;
        private Label labelNome;
        private Label labelNomeFantasia;
        private Label labelDocumento;
        private Label labelID;
        private Panel panel1;
        private Design.DesignTextBox designTextBoxID;
        private Design.DesignTextBox designTextBoxNome;
        private Design.DesignButton designButtonFiltro;
        private Design.DesignTextBox designTextBoxNomeFantasia;
        private Design.DesignTextBox designTextBoxDocumento;
    }
}