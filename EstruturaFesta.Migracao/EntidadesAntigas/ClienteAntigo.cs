using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Migracao.EntidadesAntigas
{
    public class ClienteAntigo
    {
        public string CODCLIFOR { get; set; }
        public string? NOMEFANTASIA { get; set; }
        public string RAZAOSOCIAL { get; set; }
        public short TIPOPESSOA { get; set; }
        public string CNPJ_CPF { get; set; }
        public string? INSCRESTADUAL { get; set; }
        public string? INSCRMUNICIPAL { get; set; }
        public DateTime? DATANASCIMENTO { get; set; }
        public string? RG_NUMERO { get; set; }
        public string? SIGLAESTADO { get; set; }
        public string NOMEPAI { get; set; }
        public string NOMEMAE { get; set; }
    }

}
