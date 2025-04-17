using EstruturaFesta.Clientes;
using EstruturaFesta.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EstruturaFesta
{
    public partial class TelaPedido : Form
    {
        public TelaPedido()
        {
            InitializeComponent();

        }

        private void comboBoxIDCliente_DropDown(object sender, EventArgs e)
        {
            FormDataGridView formDataGridView = new FormDataGridView();
            formDataGridView.ShowDialog();
        }

        public void PreencherCamposCliente(int id, string nome, string documento)
        {
            textBoxIDCliente.Text = id.ToString();
            textBoxNomeCliente.Text = nome;
            textBoxDocumentoCliente.Text = documento;
            
        }

        private void comboBoxIDCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bntBuscarCliente_Click(object sender, EventArgs e)
        {
            FormDataGridView formDataGridView = new FormDataGridView();
            formDataGridView.ShowDialog();
        }
    }
}