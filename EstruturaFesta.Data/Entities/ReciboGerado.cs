using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFesta.Data.Entities
{
    public class ReciboGerado
    {
        // ID = número da nota (auto-incremento do banco)
        [Key]
        public int Id { get; set; }

        // ── Identificação ──────────────────────────────
        public int NumeroPedido { get; set; }
        public DateTime DataEmissao { get; set; }

        // ── Pedido ─────────────────────────────────────
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetirada { get; set; }
        public string Observacoes { get; set; } = string.Empty;

        // ── Cliente ────────────────────────────────────
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public string ClienteDocumento { get; set; } = string.Empty;
        public string ClienteTelefone { get; set; } = string.Empty;

        // ── Endereço ───────────────────────────────────
        public string EnderecoRua { get; set; } = string.Empty;
        public string EnderecoNumero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;

        // ── Serviço ────────────────────────────────────
        public string DescricaoServico { get; set; } = string.Empty;

        // ── Valores ────────────────────────────────────
        public decimal SubTotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal ValorQuebra { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
