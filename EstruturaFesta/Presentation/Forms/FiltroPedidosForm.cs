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
                .Select(p => new
                {
                    p.ID,
                    p.DataPedido,
                    Cliente = p.Cliente.Nome,
                    TotalProdutos = p.Produtos.Sum(prod => prod.Quantidade),
                    ValorTotal = p.Produtos.Sum(prod => prod.Quantidade * prod.ValorUnitario)
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

        
    }
}
