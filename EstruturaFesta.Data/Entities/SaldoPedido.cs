using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Data.Entities
{
    public class SaldoPedido
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public decimal Saldo { get; set; }
    }
}
