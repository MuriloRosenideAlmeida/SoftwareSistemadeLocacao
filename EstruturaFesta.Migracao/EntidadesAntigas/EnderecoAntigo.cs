using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Migracao.EntidadesAntigas
{
    public class EnderecoAntigo
    {
        public string CODCLIFOR { get; set; }
        public short IDENDER { get; set; }

        public string? ENDERECO { get; set; }
        public string? NUMERO { get; set; }
        public string? BAIRRO { get; set; }
        public string CODMUNICIPIO { get; set; }
        public string? CEP { get; set; }
        public string? COMPLEMENTO { get; set; }
    }
}
