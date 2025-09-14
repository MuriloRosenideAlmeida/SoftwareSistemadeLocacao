using EstruturaFesta.AppServices.DTOs;
using EstruturaFesta.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstruturaFesta
{
    public partial class FiltroPedidos : Form
    {
        public FiltroPedidos()
        {
            InitializeComponent();
        }
        private void FiltroPedidos_Load(object sender, EventArgs e)
        {
            dateTimePickerInicial.Value = DateTime.Today;
            dateTimePickerFinal.Value = DateTime.Today.AddDays(1);
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            DateTime dataInicial = dateTimePickerInicial.Value.Date;
            DateTime dataFinal = dateTimePickerFinal.Value.Date;

            // Garante que a data final inclua o dia todo
            DateTime dataFinalInclusiva = dataFinal.AddDays(1);

            using var db = new EstruturaDataBase();

            var pedidos = db.Pedidos
                .Where(p => p.DataPedido >= dataInicial && p.DataPedido < dataFinalInclusiva)
                .Select(p => new PedidoFiltroDTO
                {
                    ID = p.ID,
                    DataPedido = p.DataPedido,
                    Cliente = p.Cliente.Nome,
                    DataEntrega = p.DataEntrega,
                    DataRetirada = p.DataRetirada
                })
                .ToList();

            dataGridViewPedidos.DataSource = pedidos;
        }

        private void dataGridViewPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora cabeçalho

            var row = dataGridViewPedidos.Rows[e.RowIndex];

            if (row.Cells["ID"].Value == null) return;

            int pedidoId = Convert.ToInt32(row.Cells["ID"].Value);

            // Abre o TelaPedidoForm passando o pedidoId
            var telaPedido = new TelaPedidoForm(pedidoId);
            telaPedido.ShowDialog();
            bntBuscar_Click(null, null);
        }

        private void dataGridViewPedidos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewPedidos.Columns[e.ColumnIndex].Name;

            var pedidos = (List<PedidoFiltroDTO>)dataGridViewPedidos.DataSource;

            // Descobre o sentido da ordenação (se já está ordenando por essa coluna, inverte)
            bool ascending = dataGridViewPedidos.SortOrder != SortOrder.Ascending;

            switch (columnName)
            {
                case "ID":
                    pedidos = ascending ? pedidos.OrderBy(p => p.ID).ToList()
                                        : pedidos.OrderByDescending(p => p.ID).ToList();
                    break;

                case "Cliente":
                    pedidos = ascending ? pedidos.OrderBy(p => p.Cliente).ToList()
                                        : pedidos.OrderByDescending(p => p.Cliente).ToList();
                    break;

                case "DataPedido":
                    pedidos = ascending ? pedidos.OrderBy(p => p.DataPedido).ToList()
                                        : pedidos.OrderByDescending(p => p.DataPedido).ToList();
                    break;

                case "DataEntrega":
                    pedidos = ascending ? pedidos.OrderBy(p => p.DataEntrega).ToList()
                                        : pedidos.OrderByDescending(p => p.DataEntrega).ToList();
                    break;

                case "DataRetirada":
                    pedidos = ascending ? pedidos.OrderBy(p => p.DataRetirada).ToList()
                                        : pedidos.OrderByDescending(p => p.DataRetirada).ToList();
                    break;
            }

            // Atualiza a lista
            dataGridViewPedidos.DataSource = pedidos;

            // Define a coluna usada e mostra a setinha
            dataGridViewPedidos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
    }
}
