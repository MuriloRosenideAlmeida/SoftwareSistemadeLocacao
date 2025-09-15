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
            textBoxNome = new TextBox();
            textBoxDocumentos = new TextBox();
            labelNome = new Label();
            labelDocumentos = new Label();
            buttonFiltro = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroClientes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFiltroClientes
            // 
            dataGridViewFiltroClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltroClientes.Location = new Point(2, 63);
            dataGridViewFiltroClientes.Name = "dataGridViewFiltroClientes";
            dataGridViewFiltroClientes.Size = new Size(795, 338);
            dataGridViewFiltroClientes.TabIndex = 0;
            dataGridViewFiltroClientes.CellMouseDoubleClick += dataGridViewFiltroClientes_CellMouseDoubleClick;
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(159, 34);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(209, 23);
            textBoxNome.TabIndex = 1;
            // 
            // textBoxDocumentos
            // 
            textBoxDocumentos.Location = new Point(449, 34);
            textBoxDocumentos.Name = "textBoxDocumentos";
            textBoxDocumentos.Size = new Size(211, 23);
            textBoxDocumentos.TabIndex = 1;
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
            labelDocumentos.Location = new Point(383, 37);
            labelDocumentos.Name = "labelDocumentos";
            labelDocumentos.Size = new Size(60, 15);
            labelDocumentos.TabIndex = 2;
            labelDocumentos.Text = "CPF/CNPJ";
            // 
            // buttonFiltro
            // 
            buttonFiltro.Location = new Point(698, 33);
            buttonFiltro.Name = "buttonFiltro";
            buttonFiltro.Size = new Size(75, 23);
            buttonFiltro.TabIndex = 3;
            buttonFiltro.Text = "Filtrar";
            buttonFiltro.UseVisualStyleBackColor = true;
            buttonFiltro.Click += buttonFiltro_Click;
            // 
            // FiltroClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonFiltro);
            Controls.Add(labelDocumentos);
            Controls.Add(labelNome);
            Controls.Add(textBoxDocumentos);
            Controls.Add(textBoxNome);
            Controls.Add(dataGridViewFiltroClientes);
            Name = "FiltroClienteForm";
            Text = "FiltroClienteForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewFiltroClientes;
        private TextBox textBoxNome;
        private TextBox textBoxDocumentos;
        private Label labelNome;
        private Label labelDocumentos;
        private Button buttonFiltro;
    }
}