using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentManager.Data.Entities
{
    public class ProdutoComponente
    {
        public int Id { get; set; }

        public int ProdutoPaiId { get; set; }
        public Produto ProdutoPai { get; set; }

        public int ProdutoFilhoId { get; set; }
        public Produto ProdutoFilho { get; set; }

        // Quantas unidades do filho são consumidas por 1 unidade do pai
        public int QuantidadePorUnidade { get; set; }
    }
}
