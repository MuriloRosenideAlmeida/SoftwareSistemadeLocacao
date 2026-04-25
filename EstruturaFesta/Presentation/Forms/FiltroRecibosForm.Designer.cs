namespace EstruturaFesta.Presentation.Forms
{
    partial class FiltroRecibosForm
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
            labelTitulo = new Label();
            labelInstrucao = new Label();
            designTextBoxNumeroRecibo = new Design.DesignTextBox();
            designButtonFiltrar = new Design.DesignButton();
            dataGridViewFiltroRecibos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroRecibos).BeginInit();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 15F);
            labelTitulo.Location = new Point(433, 62);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(217, 28);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Filtro de Recibos Fiscais";
            // 
            // labelInstrucao
            // 
            labelInstrucao.AutoSize = true;
            labelInstrucao.Font = new Font("Segoe UI", 15F);
            labelInstrucao.Location = new Point(353, 90);
            labelInstrucao.Name = "labelInstrucao";
            labelInstrucao.Size = new Size(400, 28);
            labelInstrucao.TabIndex = 1;
            labelInstrucao.Text = "Insira o numero do Recibo que deseja Filtrar ";
            // 
            // designTextBoxNumeroRecibo
            // 
            designTextBoxNumeroRecibo.BackColor = SystemColors.Window;
            designTextBoxNumeroRecibo.BorderColor = Color.MediumSlateBlue;
            designTextBoxNumeroRecibo.BorderFocusColor = Color.HotPink;
            designTextBoxNumeroRecibo.BorderRadius = 15;
            designTextBoxNumeroRecibo.BorderSize = 1;
            designTextBoxNumeroRecibo.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNumeroRecibo.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNumeroRecibo.ForceUpperCase = false;
            designTextBoxNumeroRecibo.ForeColor = Color.DimGray;
            designTextBoxNumeroRecibo.Location = new Point(353, 149);
            designTextBoxNumeroRecibo.Multiline = false;
            designTextBoxNumeroRecibo.Name = "designTextBoxNumeroRecibo";
            designTextBoxNumeroRecibo.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNumeroRecibo.PasswordChar = false;
            designTextBoxNumeroRecibo.PlaceholderColor = Color.DarkGray;
            designTextBoxNumeroRecibo.PlaceholderText = "Numero do Recibo";
            designTextBoxNumeroRecibo.ReadOnly = false;
            designTextBoxNumeroRecibo.SelectionLength = 0;
            designTextBoxNumeroRecibo.SelectionStart = 0;
            designTextBoxNumeroRecibo.Size = new Size(250, 32);
            designTextBoxNumeroRecibo.TabIndex = 2;
            designTextBoxNumeroRecibo.UnderlinedStyle = false;
            // 
            // designButtonFiltrar
            // 
            designButtonFiltrar.BackColor = Color.LimeGreen;
            designButtonFiltrar.BackgroundColor = Color.LimeGreen;
            designButtonFiltrar.BorderColor = Color.DarkGreen;
            designButtonFiltrar.BorderRadius = 15;
            designButtonFiltrar.BorderSize = 1;
            designButtonFiltrar.FlatAppearance.BorderSize = 0;
            designButtonFiltrar.FlatStyle = FlatStyle.Flat;
            designButtonFiltrar.ForeColor = Color.White;
            designButtonFiltrar.Location = new Point(641, 149);
            designButtonFiltrar.Name = "designButtonFiltrar";
            designButtonFiltrar.Size = new Size(150, 32);
            designButtonFiltrar.TabIndex = 3;
            designButtonFiltrar.Text = "Filtrar";
            designButtonFiltrar.TextColor = Color.White;
            designButtonFiltrar.UseVisualStyleBackColor = false;
            // 
            // dataGridViewFiltroRecibos
            // 
            dataGridViewFiltroRecibos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiltroRecibos.Location = new Point(265, 235);
            dataGridViewFiltroRecibos.Name = "dataGridViewFiltroRecibos";
            dataGridViewFiltroRecibos.Size = new Size(617, 257);
            dataGridViewFiltroRecibos.TabIndex = 4;
            dataGridViewFiltroRecibos.CellDoubleClick += DataGridViewFiltrar_CellDoubleClick;
            dataGridViewFiltroRecibos.KeyDown += DataGridViewFiltroRecibos_KeyDown;
            // 
            // FiltroRecibosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 616);
            Controls.Add(dataGridViewFiltroRecibos);
            Controls.Add(designButtonFiltrar);
            Controls.Add(designTextBoxNumeroRecibo);
            Controls.Add(labelInstrucao);
            Controls.Add(labelTitulo);
            Name = "FiltroRecibosForm";
            Text = "FiltroRecibosForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiltroRecibos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label labelInstrucao;
        private Design.DesignTextBox designTextBoxNumeroRecibo;
        private Design.DesignButton designButtonFiltrar;
        private DataGridView dataGridViewFiltroRecibos;
    }
}