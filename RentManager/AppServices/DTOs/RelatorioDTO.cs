using System;
using System.Collections.Generic;

namespace RentManager.AppServices.DTOs
{
    // ── KPIs principais (cards do topo) ──────────────────────────────────────
    public class RelatorioKPIs
    {
        public int TotalPedidos { get; set; }
        public int ClientesAtendidos { get; set; }          // clientes únicos no período
        public decimal ReceitaRecebida { get; set; }        // soma dos pagamentos Pago=true
        public decimal ReceitaTotal { get; set; }           // soma ValorTotal dos pedidos
        public int PedidosCancelados { get; set; }
        public decimal TotalValorQuebras { get; set; }
        public int ClientesNoInicio { get; set; }
        public int ClientesNoFim { get; set; }

    }

    // ── Receita agrupada por data (para o gráfico de linha/área) ─────────────
    public struct ReceitaPorData
    {
        public string Label { get; set; }   // "01 Jan", "Semana 3", "Jan 2025" etc.
        public decimal Valor { get; set; }
    }

    // ── Top produtos mais alugados (para gráfico de barras e donut) ──────────
    public class TopProdutoDTO
    {
        public string Nome { get; set; }
        public int TotalQuantidade { get; set; }            // soma das quantidades
        public int PedidosDistintos { get; set; }           // em quantos pedidos apareceu
        public double PorcentagemPresenca { get; set; }     // % do total de pedidos no período
        public decimal ValorTotalLocado { get; set; }
    }

    // ── Top clientes que mais alugaram ────────────────────────────────────────
    public class TopClienteDTO
    {
        public string Nome { get; set; }
        public int NumeroPedidos { get; set; }
        public decimal ValorTotalGasto { get; set; }
    }
    // — Distribuição de formas de pagamento
    public class TipoPagamentoDTO
    {
        public string Forma { get; set; }
        public decimal ValorTotal { get; set; }
        public double Porcentagem { get; set; }
    }

    // ── Resultado completo carregado pelo RelatorioService ───────────────────
    public class RelatorioDados
    {
        public RelatorioKPIs KPIs { get; set; } = new RelatorioKPIs();
        public List<ReceitaPorData> ReceitaPorPeriodo { get; set; } = new();
        public List<TopProdutoDTO> TopProdutos { get; set; } = new();
        public List<TopClienteDTO> TopClientes { get; set; } = new();
        public List<TipoPagamentoDTO> TiposPagamento { get; set; } = new();

        // Controle interno para evitar recarregar com o mesmo filtro
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
    public class ComparacaoPeriodo
    {
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public decimal ReceitaTotal { get; set; }
        public List<ReceitaPorData> ReceitaPorDia { get; set; } = new();
        public bool EhPersonalizada { get; set; } = false;
    }
}