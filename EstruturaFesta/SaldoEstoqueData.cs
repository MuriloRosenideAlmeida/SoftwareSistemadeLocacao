using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta
{
    public class SaldoEstoqueData
    {
        public int ID { get; set; }
        public int ProdutoId { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeReservada { get; set; }

        public Produto Produto { get; set; }
    }
}
