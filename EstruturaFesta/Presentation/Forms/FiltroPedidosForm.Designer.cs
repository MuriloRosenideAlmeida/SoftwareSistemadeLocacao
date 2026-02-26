namespace EstruturaFesta
{
    partial class FiltroPedidosForm
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
            dataGridViewPedidos = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Cliente = new DataGridViewTextBoxColumn();
            DataPedido = new DataGridViewTextBoxColumn();
            DataEntrega = new DataGridViewTextBoxColumn();
            DataRetirada = new DataGridViewTextBoxColumn();
            labelID = new Label();
            designTextBoxID = new Design.DesignTextBox();
            designButtonBuscar = new Design.DesignButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 65);
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
            dateTimePickerInicial.Format = DateTimePickerFormat.Short;
            dateTimePickerInicial.Location = new Point(235, 83);
            dateTimePickerInicial.Name = "dateTimePickerInicial";
            dateTimePickerInicial.Size = new Size(96, 23);
            dateTimePickerInicial.TabIndex = 2;
            dateTimePickerInicial.Value = new DateTime(2025, 8, 26, 0, 0, 0, 0);
            // 
            // dateTimePickerFinal
            // 
            dateTimePickerFinal.Format = DateTimePickerFormat.Short;
            dateTimePickerFinal.Location = new Point(444, 83);
            dateTimePickerFinal.Name = "dateTimePickerFinal";
            dateTimePickerFinal.Size = new Size(97, 23);
            dateTimePickerFinal.TabIndex = 3;
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.BackgroundColor = SystemColors.Control;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Columns.AddRange(new DataGridViewColumn[] { ID, Cliente, DataPedido, DataEntrega, DataRetirada });
            dataGridViewPedidos.Location = new Point(40, 145);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.Size = new Size(709, 293);
            dataGridViewPedidos.TabIndex = 5;
            dataGridViewPedidos.CellDoubleClick += dataGridViewPedidos_CellDoubleClick;
            dataGridViewPedidos.ColumnHeaderMouseClick += dataGridViewPedidos_ColumnHeaderMouseClick;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 10F;
            ID.HeaderText = "Codigo";
            ID.Name = "ID";
            // 
            // Cliente
            // 
            Cliente.DataPropertyName = "Cliente";
            Cliente.FillWeight = 40F;
            Cliente.HeaderText = "Cliente";
            Cliente.Name = "Cliente";
            // 
            // DataPedido
            // 
            DataPedido.DataPropertyName = "DataPedido";
            DataPedido.FillWeight = 17F;
            DataPedido.HeaderText = "Data Pedido";
            DataPedido.Name = "DataPedido";
            // 
            // DataEntrega
            // 
            DataEntrega.DataPropertyName = "DataEntrega";
            DataEntrega.FillWeight = 17F;
            DataEntrega.HeaderText = "Data Entrega";
            DataEntrega.Name = "DataEntrega";
            // 
            // DataRetirada
            // 
            DataRetirada.DataPropertyName = "DataRetirada";
            DataRetirada.FillWeight = 16F;
            DataRetirada.HeaderText = "Data Retirada";
            DataRetirada.Name = "DataRetirada";
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(64, 62);
            labelID.Name = "labelID";
            labelID.Size = new Size(46, 15);
            labelID.TabIndex = 7;
            labelID.Text = "Codigo";
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
            designTextBoxID.Location = new Point(44, 78);
            designTextBoxID.Multiline = false;
            designTextBoxID.Name = "designTextBoxID";
            designTextBoxID.Padding = new Padding(10, 7, 10, 7);
            designTextBoxID.PasswordChar = false;
            designTextBoxID.PlaceholderColor = Color.DarkGray;
            designTextBoxID.PlaceholderText = "Codigo";
            designTextBoxID.SelectionLength = 0;
            designTextBoxID.SelectionStart = 0;
            designTextBoxID.Size = new Size(100, 32);
            designTextBoxID.TabIndex = 8;
            designTextBoxID.UnderlinedStyle = false;
            // 
            // designButtonBuscar
            // 
            designButtonBuscar.BackColor = Color.MediumSlateBlue;
            designButtonBuscar.BackgroundColor = Color.MediumSlateBlue;
            designButtonBuscar.BorderColor = Color.PaleVioletRed;
            designButtonBuscar.BorderRadius = 20;
            designButtonBuscar.BorderSize = 0;
            designButtonBuscar.FlatAppearance.BorderSize = 0;
            designButtonBuscar.FlatStyle = FlatStyle.Flat;
            designButtonBuscar.ForeColor = Color.White;
            designButtonBuscar.Location = new Point(632, 79);
            designButtonBuscar.Name = "designButtonBuscar";
            designButtonBuscar.Size = new Size(118, 38);
            designButtonBuscar.TabIndex = 9;
            designButtonBuscar.Text = "Buscar";
            designButtonBuscar.TextColor = Color.White;
            designButtonBuscar.UseVisualStyleBackColor = false;
            designButtonBuscar.Click += designButtonBuscar_Click;
            // 
            // FiltroPedidosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 492);
            Controls.Add(designButtonBuscar);
            Controls.Add(designTextBoxID);
            Controls.Add(labelID);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(dateTimePickerFinal);
            Controls.Add(dateTimePickerInicial);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FiltroPedidosForm";
            Text = "Filtro de Pedidos";
            Load += FiltroPedidos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerInicial;
        private DateTimePicker dateTimePickerFinal;
        private DataGridView dataGridViewPedidos;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn DataPedido;
        private DataGridViewTextBoxColumn DataEntrega;
        private DataGridViewTextBoxColumn DataRetirada;
        private Label labelID;
        private Design.DesignTextBox designTextBoxID;
        private Design.DesignButton designButtonBuscar;
    }
}