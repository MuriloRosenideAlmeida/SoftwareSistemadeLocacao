using EstruturaFesta.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlX.XDevAPI;
using System.Linq;
using System.Data.Common;
using System.Windows.Forms;
using EstruturaFesta.Domain.Entities;


namespace EstruturaFesta
{
    public partial class FormDataGridView : Form
    {

        public FormDataGridView()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void FormDataGridView_Load(object sender, EventArgs e)
        {
            using (var context = new EstruturaDataBase())
            {
                var clientes = context.Clientes
       .Select(c => new
       {
           c.ID,
           Nome = c is ClientePF ? ((ClientePF)c).Nome : ((ClientePJ)c).RazaoSocial,
           Documento = c is ClientePF ? ((ClientePF)c).CPF : ((ClientePJ)c).CNPJ,
           NomeFantasia = c is ClientePJ ? ((ClientePJ)c).NomeFantasia : null
       })
       .ToList();

                // Vincula a lista ao DataGridView
                dataGridView1.DataSource = clientes;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            var row = dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (row != null)
            {

                dynamic clienteSelecionado = row;

                int id = clienteSelecionado.ID;
                string nome = clienteSelecionado.Nome;
                string documento = clienteSelecionado.Documento;
                TelaPedidoForm formCadastro = (TelaPedidoForm)Application.OpenForms["TelaPedidoForm"];
                if (formCadastro != null)
                {
                    // Chamar o método da instância do formulário
                    formCadastro.PreencherCamposCliente(id, nome, documento);
                    this.Close(); // Fecha o form de seleção após enviar os dados
                }
                else
                {
                    MessageBox.Show("O formulário de cadastro não está aberto.");
                } 
            }
        }
    }
}
