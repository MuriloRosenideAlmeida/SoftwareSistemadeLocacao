using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Domain.Entities
{
    public class Pedido
    {
        public int ID { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetirada { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<ProdutoPedido> Produtos { get; set; } = new List<ProdutoPedido>();
        public virtual List<Pagamento> Pagamentos { get; set; } = new();


    }
}
