using EstruturaFesta.AppServices.DTOs;
using EstruturaFesta.Data;
using EstruturaFesta.Presentation.Forms;
using EstruturaFesta.Utils;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class FiltroPedidosForm : Form
    {
        private readonly EstruturaDataBase _db;
        public FiltroPedidosForm(EstruturaDataBase db)
        {
            InitializeComponent();
            ConfigurarEstiloDataGrid();
            dataGridViewPedidos.RowPostPaint += dataGridViewPedidos_RowPostPaint;
            _db = db;
        }
        public event Action<int> PedidoSelecionado;
        private void FiltroPedidos_Load(object sender, EventArgs e)
        {
            dateTimePickerInicial.Value = DateTime.Today;
            dateTimePickerFinal.Value = DateTime.Today.AddDays(1);
            SistemaUpperCase.AplicarMaiusculo(this);
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                if (int.TryParse(textBoxID.Text, out int idProcurado))
                {
                    var pedido = _db.Pedidos
                        .Where(p => p.ID == idProcurado)
                        .Select(p => new PedidoFiltroDTO
                        {
                            ID = p.ID,
                            DataPedido = p.DataPedido,
                            Cliente = p.Cliente.Nome,
                            DataEntrega = p.DataEntrega,
                            DataRetirada = p.DataRetirada
                        })
                        .ToList();

                    dataGridViewPedidos.AutoGenerateColumns = false;
                    dataGridViewPedidos.DataSource = pedido;
                    return;
                }
                else
                {
                    MessageBox.Show("ID inválido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DateTime dataInicial = dateTimePickerInicial.Value.Date;
            DateTime dataFinal = dateTimePickerFinal.Value.Date;
            DateTime dataFinalInclusiva = dataFinal.AddDays(1);

            

            var pedidos = _db.Pedidos
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

            dataGridViewPedidos.AutoGenerateColumns = false;
            dataGridViewPedidos.DataSource = pedidos;

        }

        private void ConfigurarEstiloDataGrid()
        {
            dataGridViewPedidos.AllowUserToAddRows = false;
            dataGridViewPedidos.AllowUserToDeleteRows = false;
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewPedidos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string numeroLinha = (e.RowIndex + 1).ToString();

            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(
                    numeroLinha,
                    dataGridViewPedidos.Font,
                    brush,
                    e.RowBounds.Left + (dataGridViewPedidos.RowHeadersWidth / 2),
                    e.RowBounds.Top + (e.RowBounds.Height / 2),
                    format
                );
            }
        }

        private void dataGridViewPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewPedidos.Rows[e.RowIndex];
            if (row.Cells["ID"].Value == null) return;

            int pedidoId = Convert.ToInt32(row.Cells["ID"].Value);


            PedidoSelecionado?.Invoke(pedidoId);
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
