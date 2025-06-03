namespace EstruturaFesta
{
    partial class FormFiltroPedidos
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
            label1 = new Label();
            label2 = new Label();
            dateTimePickerInicial = new DateTimePicker();
            dateTimePickerFinal = new DateTimePicker();
            bntBuscar = new Button();
            dataGridViewPedidos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 65);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Data Inicial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(456, 65);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Data Final";
            // 
            // dateTimePickerInicial
            // 
            dateTimePickerInicial.Location = new Point(40, 83);
            dateTimePickerInicial.Name = "dateTimePickerInicial";
            dateTimePickerInicial.Size = new Size(246, 23);
            dateTimePickerInicial.TabIndex = 2;
            // 
            // dateTimePickerFinal
            // 
            dateTimePickerFinal.Location = new Point(392, 83);
            dateTimePickerFinal.Name = "dateTimePickerFinal";
            dateTimePickerFinal.Size = new Size(250, 23);
            dateTimePickerFinal.TabIndex = 3;
            // 
            // bntBuscar
            // 
            bntBuscar.Location = new Point(686, 83);
            bntBuscar.Name = "bntBuscar";
            bntBuscar.Size = new Size(75, 23);
            bntBuscar.TabIndex = 4;
            bntBuscar.Text = "Buscar";
            bntBuscar.UseVisualStyleBackColor = true;
            bntBuscar.Click += bntBuscar_Click;
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(40, 145);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.Size = new Size(709, 240);
            dataGridViewPedidos.TabIndex = 5;
            // 
            // FormFiltroPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(bntBuscar);
            Controls.Add(dateTimePickerFinal);
            Controls.Add(dateTimePickerInicial);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormFiltroPedidos";
            Text = "FormFiltroPedidos";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerInicial;
        private DateTimePicker dateTimePickerFinal;
        private Button bntBuscar;
        private DataGridView dataGridViewPedidos;
    }
}