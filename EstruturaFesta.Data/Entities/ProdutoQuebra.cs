using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Data.Entities
{
    public class ProdutoQuebra
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeQuebrada { get; set; }
        public decimal ValorReposicao { get; set; }
        public decimal ValorTotal => QuantidadeQuebrada * ValorReposicao;
    }
}