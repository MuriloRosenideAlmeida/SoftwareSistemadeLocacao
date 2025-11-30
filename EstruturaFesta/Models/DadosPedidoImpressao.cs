using System;
using System.Collections.Generic;

namespace EstruturaFesta.Models
{
    /// <summary>
    /// Modelo de dados para impressão do pedido
    /// </summary>
    public class DadosPedidoImpressao
    {
        // ===== DADOS DO PEDIDO =====
        public int NumeroPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetirada { get; set; }
        public string Observacoes { get; set; }

        // ===== DADOS DO CLIENTE =====
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string DocumentoCliente { get; set; } // CPF ou CNPJ
        public string ContatoNome { get; set; }
        public string ContatoNumero { get; set; }
        public List<ContatoInfo> OutrosContatos { get; set; } = new List<ContatoInfo>();
        
        // ===== ENDEREÇO DO CLIENTE =====
        public string EnderecoRua { get; set; }
        public int EnderecoNumero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        // ===== PRODUTOS DO PEDIDO =====
        public List<ItemPedidoImpressao> Itens { get; set; } = new List<ItemPedidoImpressao>();

        // ===== VALORES =====
        public decimal SubTotal { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorQuebra { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal SaldoPedido { get; set; }

        // ===== PAGAMENTOS =====
        public List<PagamentoImpressao> Pagamentos { get; set; } = new List<PagamentoImpressao>();
        public decimal TotalPago => Pagamentos.Where(p => p.Pago).Sum(p => p.Valor);

        // ===== INFORMAÇÕES EXTRAS =====
        public decimal TotalGastoCliente { get; set; }
        public decimal SaldoCliente { get; set; }
        public string IDsSaldoCliente { get; set; }
    }

    /// <summary>
    /// Representa um item (produto) do pedido
    /// </summary>
    public class ItemPedidoImpressao
    {
        public int ProdutoId { get; set; }
        public string DescricaoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal => Quantidade * ValorUnitario;
        public decimal ValorReposicao { get; set; }
    }

    /// <summary>
    /// Representa um pagamento do pedido
    /// </summary>
    public class PagamentoImpressao
    {
        public string FormaPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
    }

    /// <summary>
    /// Representa um contato adicional do cliente
    /// </summary>
    public class ContatoInfo
    {
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
    }
}