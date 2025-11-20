namespace EstruturaFesta
{
    partial class FormBuscarClientes
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
            textBoxID = new TextBox();
            textBoxNome = new TextBox();
            textBoxDocumento = new TextBox();
            textBoxNomeFantasia = new TextBox();
            labelNome = new Label();
            labelNomeFantasia = new Label();
            labelDocumento = new Label();
            labelID = new Label();
            panel1 = new Panel();
            buttonFiltro = new Button();
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
            dataGridView1.Size = new Size(1067, 398);
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
            // textBoxID
            // 
            textBoxID.Location = new Point(55, 23);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(79, 23);
            textBoxID.TabIndex = 2;
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(186, 21);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(314, 23);
            textBoxNome.TabIndex = 2;
            // 
            // textBoxDocumento
            // 
            textBoxDocumento.Location = new Point(591, 21);
            textBoxDocumento.Name = "textBoxDocumento";
            textBoxDocumento.Size = new Size(103, 23);
            textBoxDocumento.TabIndex = 2;
            // 
            // textBoxNomeFantasia
            // 
            textBoxNomeFantasia.Location = new Point(792, 23);
            textBoxNomeFantasia.Name = "textBoxNomeFantasia";
            textBoxNomeFantasia.Size = new Size(183, 23);
            textBoxNomeFantasia.TabIndex = 2;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(140, 26);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 1;
            labelNome.Text = "Nome";
            // 
            // labelNomeFantasia
            // 
            labelNomeFantasia.AutoSize = true;
            labelNomeFantasia.Location = new Point(700, 26);
            labelNomeFantasia.Name = "labelNomeFantasia";
            labelNomeFantasia.Size = new Size(86, 15);
            labelNomeFantasia.TabIndex = 1;
            labelNomeFantasia.Text = "Nome Fantasia";
            // 
            // labelDocumento
            // 
            labelDocumento.AutoSize = true;
            labelDocumento.Location = new Point(506, 26);
            labelDocumento.Name = "labelDocumento";
            labelDocumento.Size = new Size(70, 15);
            labelDocumento.TabIndex = 1;
            labelDocumento.Text = "Documento";
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(3, 29);
            labelID.Name = "labelID";
            labelID.Size = new Size(46, 15);
            labelID.TabIndex = 1;
            labelID.Text = "Codigo";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonFiltro);
            panel1.Controls.Add(textBoxNomeFantasia);
            panel1.Controls.Add(textBoxNome);
            panel1.Controls.Add(textBoxDocumento);
            panel1.Controls.Add(textBoxID);
            panel1.Controls.Add(labelID);
            panel1.Controls.Add(labelDocumento);
            panel1.Controls.Add(labelNomeFantasia);
            panel1.Controls.Add(labelNome);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1067, 52);
            panel1.TabIndex = 3;
            // 
            // buttonFiltro
            // 
            buttonFiltro.Location = new Point(989, 21);
            buttonFiltro.Name = "buttonFiltro";
            buttonFiltro.Size = new Size(75, 23);
            buttonFiltro.TabIndex = 3;
            buttonFiltro.Text = "Filtrar";
            buttonFiltro.UseVisualStyleBackColor = true;
            buttonFiltro.Click += buttonFiltro_Click;
            // 
            // FormBuscarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "FormBuscarClientes";
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
        private TextBox textBoxID;
        private TextBox textBoxNome;
        private TextBox textBoxDocumento;
        private TextBox textBoxNomeFantasia;
        private Label labelNome;
        private Label labelNomeFantasia;
        private Label labelDocumento;
        private Label labelID;
        private Panel panel1;
        private Button buttonFiltro;
    }
}