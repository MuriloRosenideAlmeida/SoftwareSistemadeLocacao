using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.AppServices.DTOs
{
    public class PedidoFiltroDTO
    {
        public int ID { get; set; }
        public DateTime DataPedido { get; set; }
        public string Cliente { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}
