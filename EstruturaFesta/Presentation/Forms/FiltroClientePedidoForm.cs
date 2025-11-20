using EstruturaFesta.Infrastructure.Data;
using EstruturaFesta.Domain.Entities;


namespace EstruturaFesta
{
    public partial class FormBuscarClientes : Form
    {

        public FormBuscarClientes()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            //WindowState = FormWindowState.Maximized;
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

        private void buttonFiltro_Click(object sender, EventArgs e)
        {
            using (var context = new EstruturaDataBase())
            {
                // Lê o texto digitado nas TextBox
                string filtroID = textBoxID.Text.Trim();
                string filtroNome = textBoxNome.Text.Trim();
                string filtroDocumento = textBoxDocumento.Text.Trim();
                string filtroFantasia = textBoxNomeFantasia.Text.Trim();

                var query = context.Clientes
                    .Select(c => new
                    {
                        c.ID,
                        Nome = c is ClientePF ? ((ClientePF)c).Nome :
                               c is ClientePJ ? ((ClientePJ)c).RazaoSocial : null,

                        Documento = c is ClientePF ? ((ClientePF)c).CPF :
                                    c is ClientePJ ? ((ClientePJ)c).CNPJ : null,

                        NomeFantasia = c is ClientePJ ? ((ClientePJ)c).NomeFantasia : null
                    })
                    .AsQueryable();

                // FILTRAR POR ID — EXATO
                if (!string.IsNullOrWhiteSpace(filtroID) && int.TryParse(filtroID, out int id))
                {
                    query = query.Where(c => c.ID == id);
                }

                // FILTRAR POR NOME — SOMENTE COMEÇA COM
                if (!string.IsNullOrWhiteSpace(filtroNome))
                {
                    string fn = filtroNome.ToUpper();
                    query = query.Where(c => c.Nome.ToUpper().StartsWith(fn));
                }

                // FILTRAR POR DOCUMENTO — SOMENTE COMEÇA COM (CPF, RG, CNPJ)
                if (!string.IsNullOrWhiteSpace(filtroDocumento))
                {
                    string fd = filtroDocumento.ToUpper();
                    query = query.Where(c => c.Documento.ToUpper().StartsWith(fd));
                }

                // FILTRAR POR NOME FANTASIA — COMEÇA COM
                if (!string.IsNullOrWhiteSpace(filtroFantasia))
                {
                    string ff = filtroFantasia.ToUpper();
                    query = query.Where(c => c.NomeFantasia != null && c.NomeFantasia.ToUpper().StartsWith(ff));
                }

                // Preenche o DataGrid
                dataGridView1.DataSource = query.ToList();
            }
        }
    }
}
