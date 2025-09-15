using EstruturaFesta.Domain.Entities;
using EstruturaFesta.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstruturaFesta.Presentation.Forms
{
    public partial class FiltroClienteForm : Form
    {
        public FiltroClienteForm()
        {
            InitializeComponent();
        }
        private void FiltrarClientes()
        {
            string filtroNome = textBoxNome.Text.Trim();
            string filtroDocumento = textBoxDocumentos.Text.Trim();

            using (var db = new EstruturaDataBase())
            {
                // Consulta base unificada
                var query = db.Clientes.AsQueryable();

                if (!string.IsNullOrEmpty(filtroNome))
                    query = query.Where(c => c.Nome.Contains(filtroNome));

                if (!string.IsNullOrEmpty(filtroDocumento))
                {
                    var pfQuery = query.OfType<ClientePF>().Where(pf => pf.CPF.Contains(filtroDocumento));
                    var pjQuery = query.OfType<ClientePJ>().Where(pj => pj.CNPJ.Contains(filtroDocumento));

                    query = pfQuery.Cast<Cliente>().Union(pjQuery);
                }

                dataGridViewFiltroClientes.DataSource = query.ToList();
            }
        }

        private void buttonFiltro_Click(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void dataGridViewFiltroClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var clienteSelecionado = dataGridViewFiltroClientes.Rows[e.RowIndex].DataBoundItem as Cliente;
            if (clienteSelecionado == null) return;

            // Busca o cliente completo no banco (para garantir que está anexado ao contexto)
            using var db = new EstruturaDataBase();
            var clienteDoBanco = db.Clientes
                .Include(c => c.Contatos)
                .FirstOrDefault(c => c.ID == clienteSelecionado.ID);

            if (clienteDoBanco == null) return;

            // Abre o formulário de cadastro, passando o objeto completo
            using (var formCadastro = new CadastroClientesForm(clienteDoBanco))
            {
                formCadastro.ShowDialog();
            }

            // Atualiza o filtro depois da edição
            FiltrarClientes();
        }
    }
}
