using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Models
{
    public class DadosNotaFiscalServico
    {
        // Emissora (fixo no código)
        public string EmpresaNome { get; set; }
        public string EmpresaCNPJ { get; set; }
        public string EmpresaRua { get; set; }
        public string EmpresaNumero { get; set; }
        public string EmpresaBairro { get; set; }
        public string EmpresaCidade { get; set; }
        public string EmpresaUF { get; set; }
        public string EmpresaCEP { get; set; }
        public string EmpresaTelefone { get; set; }
        public string EmpresaEmail { get; set; }
        public string LogoPath { get; set; } // caminho da imagem da logo

        // Número sequencial da nota
        public int NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }

        // Pedido vinculado
        public int NumeroPedido { get; set; }
        public DateTime DataServico { get; set; }    // DataEntrega
        public DateTime DataRetirada { get; set; }

        // Tomador (cliente)
        public string ClienteNome { get; set; }
        public string ClienteDocumento { get; set; }
        public string ClienteRua { get; set; }
        public string ClienteNumero { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteCidade { get; set; }
        public string ClienteUF { get; set; }
        public string ClienteCEP { get; set; }
        public string ClienteTelefone { get; set; }

        // Serviço
        public string DescricaoServico { get; set; } // descrição genérica
        public decimal ValorServico { get; set; }    // valor total do pedido
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal ValorTotal { get; set; }

        // Pagamentos
        public List<PagamentoImpressao> Pagamentos { get; set; } = new();
    }
}

