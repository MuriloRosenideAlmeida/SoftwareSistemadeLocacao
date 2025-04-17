using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Clientes
{
    public class Contato
    {
        public int ID { get; set; }
        public string Telefone { get; set; }
        public string NomeContato { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }


    }
}
