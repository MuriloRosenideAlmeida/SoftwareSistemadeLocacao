using EstruturaFesta.Data.Entities;
using EstruturaFesta.Data;
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
using EstruturaFesta.Utils;

namespace EstruturaFesta.Presentation.Forms
{
    public partial class FiltroClienteForm : Form
    {
        private readonly EstruturaDataBase _db;
        private bool ordenacaoAscendente = true;
        public FiltroClienteForm(EstruturaDataBase db)
        {
            InitializeComponent();
            _db = db;
        }
        private void FiltroClienteForm_Load(object sender, EventArgs e)
        {
            SistemaUpperCase.AplicarMaiusculo(this);
        }
        private void FiltrarClientes()
        {
            string filtroNome = textBoxNome.Text.Trim();
            string filtroDocumento = textBoxDocumentos.Text.Trim();



            var query = _db.Clientes
                .Select(c => new
                {
                    c.ID,
                    c.Nome,
                    Documento = c is ClientePF ? ((ClientePF)c).CPF :
                                c is ClientePJ ? ((ClientePJ)c).CNPJ : "",
                    TipoCliente = c is ClientePF ? "Pessoa Física" : "Pessoa Jurídica",
                    ClienteEntity = c
                })
                .AsQueryable();

            if (!string.IsNullOrEmpty(filtroNome))
                query = query.Where(c => c.Nome.Contains(filtroNome));

            if (!string.IsNullOrEmpty(filtroDocumento))
                query = query.Where(c => c.Documento.Contains(filtroDocumento));

            dataGridViewFiltroClientes.AutoGenerateColumns = false;
            dataGridViewFiltroClientes.DataSource = query.ToList();

        }

        private void buttonFiltro_Click(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void dataGridViewFiltroClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dynamic linha = dataGridViewFiltroClientes.Rows[e.RowIndex].DataBoundItem;
            var clienteSelecionado = linha.ClienteEntity as Cliente;

            if (clienteSelecionado == null) return;



            var clienteDoBanco = _db.Clientes
                .Include(c => c.Contatos)
                .FirstOrDefault(c => c.ID == clienteSelecionado.ID);

            if (clienteDoBanco == null) return;

            using (var formCadastro = new CadastroClientesForm(_db, clienteDoBanco))
                formCadastro.ShowDialog();

            FiltrarClientes();
        }

        private void dataGridViewFiltroClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewFiltroClientes.DataSource == null)
                return;

            string coluna = dataGridViewFiltroClientes.Columns[e.ColumnIndex].Name;

            // Converte o DataSource atual para lista dinâmica
            var lista = ((IEnumerable<dynamic>)dataGridViewFiltroClientes.DataSource).ToList();

            switch (coluna)
            {
                case "colID":
                    lista = ordenacaoAscendente
                        ? lista.OrderBy(c => c.ID).ToList()
                        : lista.OrderByDescending(c => c.ID).ToList();
                    break;

                case "colNome":
                    lista = ordenacaoAscendente
                        ? lista.OrderBy(c => c.Nome).ToList()
                        : lista.OrderByDescending(c => c.Nome).ToList();
                    break;

                case "colTipoCliente":
                    lista = ordenacaoAscendente
                        ? lista.OrderBy(c => c.TipoCliente).ToList()
                        : lista.OrderByDescending(c => c.TipoCliente).ToList();
                    break;
            }

            // Inverte para a próxima ordenação
            ordenacaoAscendente = !ordenacaoAscendente;

            // Aplica de volta no DataGridView
            dataGridViewFiltroClientes.DataSource = lista;

            // Atualiza o ícone da coluna clicada
            dataGridViewFiltroClientes.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                ordenacaoAscendente ? SortOrder.Ascending : SortOrder.Descending;
        }

    }
}