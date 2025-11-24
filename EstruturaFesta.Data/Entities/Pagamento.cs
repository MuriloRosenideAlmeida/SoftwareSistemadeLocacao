using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Data.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        public DateTime DataPagamento { get; set; } = DateTime.Today;
        public string FormaPagamento { get; set; }
        public bool Pago { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
