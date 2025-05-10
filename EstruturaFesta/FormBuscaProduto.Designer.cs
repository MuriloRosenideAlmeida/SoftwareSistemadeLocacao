namespace EstruturaFesta
{
    partial class FormBuscaProduto
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
            panelFiltros = new Panel();
            textBoxFiltroMaterial = new TextBox();
            textBoxFiltroModelo = new TextBox();
            textBoxFiltroEspecificacao = new TextBox();
            textBoxNomeProduto = new TextBox();
            dataGridView1 = new DataGridView();
            panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panelFiltros
            // 
            panelFiltros.BackColor = SystemColors.MenuBar;
            panelFiltros.Controls.Add(textBoxNomeProduto);
            panelFiltros.Controls.Add(textBoxFiltroEspecificacao);
            panelFiltros.Controls.Add(textBoxFiltroModelo);
            panelFiltros.Controls.Add(textBoxFiltroMaterial);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 0);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(800, 24);
            panelFiltros.TabIndex = 0;
            // 
            // textBoxFiltroMaterial
            // 
            textBoxFiltroMaterial.Location = new Point(100, 0);
            textBoxFiltroMaterial.Name = "textBoxFiltroMaterial";
            textBoxFiltroMaterial.Size = new Size(100, 23);
            textBoxFiltroMaterial.TabIndex = 0;
            // 
            // textBoxFiltroModelo
            // 
            textBoxFiltroModelo.Location = new Point(200, 0);
            textBoxFiltroModelo.Name = "textBoxFiltroModelo";
            textBoxFiltroModelo.Size = new Size(100, 23);
            textBoxFiltroModelo.TabIndex = 1;
            // 
            // textBoxFiltroEspecificacao
            // 
            textBoxFiltroEspecificacao.Location = new Point(300, 0);
            textBoxFiltroEspecificacao.Name = "textBoxFiltroEspecificacao";
            textBoxFiltroEspecificacao.Size = new Size(85, 23);
            textBoxFiltroEspecificacao.TabIndex = 2;
            // 
            // textBoxNomeProduto
            // 
            textBoxNomeProduto.Location = new Point(0, 0);
            textBoxNomeProduto.Name = "textBoxNomeProduto";
            textBoxNomeProduto.Size = new Size(100, 23);
            textBoxNomeProduto.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 426);
            dataGridView1.TabIndex = 1;
            // 
            // FormBuscaProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panelFiltros);
            Name = "FormBuscaProduto";
            Text = "FormBuscaProduto";
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFiltros;
        private TextBox textBoxFiltroMaterial;
        private TextBox textBoxNomeProduto;
        private TextBox textBoxFiltroEspecificacao;
        private TextBox textBoxFiltroModelo;
        private DataGridView dataGridView1;
    }
}