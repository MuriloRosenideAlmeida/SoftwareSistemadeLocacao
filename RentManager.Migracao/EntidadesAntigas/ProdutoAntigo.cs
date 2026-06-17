using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentManager.Migracao.EntidadesAntigas
{
    public class ProdutoAntigo
    {
        public int IDPRODUTO { get; set; }
        public string NOMEPRODUTO { get; set; }
        public decimal? PRECOLOCACAO { get; set; }
        public decimal? PRECOREPOSICAO { get; set; }
        public decimal? PRECOCUSTO { get; set; }
        public short? IDESPEC { get; set; }
        public short? IDMATERIAL { get; set; }
        public short? IDMODELO { get; set; }
        public DateTime? DATACRIACAO { get; set; }
        public long? SALDO { get; set; }
    }
}
