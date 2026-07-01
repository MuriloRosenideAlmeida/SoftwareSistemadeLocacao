using RentManager.AppServices.DTOs;
using RentManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RentManager.Services
{
    public class RelatorioService
    {
        private readonly RentManagerDataBase _db;

        public RelatorioService(RentManagerDataBase db)
        {
            _db = db;
        }

        public RelatorioDados? CarregarDados(DateTime inicio, DateTime fim, RelatorioDados? anterior = null)
        {
            inicio = inicio.Date;
            fim = new DateTime(fim.Year, fim.Month, fim.Day, 23, 59, 59);

            if (anterior != null && anterior.DataInicio == inicio && anterior.DataFim == fim)
                return null;

            var dados = new RelatorioDados
            {
                DataInicio = inicio,
                DataFim = fim
            };

            CarregarKPIs(dados, inicio, fim);
            CarregarReceitaPorPeriodo(dados, inicio, fim);
            CarregarTopProdutos(dados, inicio, fim);
            CarregarTopClientes(dados, inicio, fim);
            CarregarTiposPagamento(dados, inicio, fim);

            return dados;
        }

        // ════════════════════════════════════════════════════════════
        // KPIs
        // ════════════════════════════════════════════════════════════
        private void CarregarKPIs(RelatorioDados dados, DateTime inicio, DateTime fim)
        {
            var pedidosNoPeriodo = _db.Pedidos
                .Where(p => p.DataPedido >= inicio && p.DataPedido <= fim)
                .ToList();

            int totalPedidos = pedidosNoPeriodo.Count(p => p.Status != "CANCELADO");
            int cancelados = pedidosNoPeriodo.Count(p => p.Status == "CANCELADO");

            int clientesUnicos = pedidosNoPeriodo
                .Where(p => p.Status != "CANCELADO")
                .Select(p => p.ClienteId)
                .Distinct()
                .Count();

            var idsPedidosAtivos = pedidosNoPeriodo
                .Where(p => p.Status != "CANCELADO")
                .Select(p => p.ID)
                .ToList();

            var pagamentosNoPeriodo = _db.Pagamentos
                .Where(pg => idsPedidosAtivos.Contains(pg.PedidoId))
                .ToList();

            decimal receitaRecebida = pagamentosNoPeriodo
                .Where(pg => pg.Pago)
                .Sum(pg => pg.Valor);

            decimal receitaTotal = _db.ProdutosPedidos
                .Where(pp => idsPedidosAtivos.Contains(pp.PedidoId))
                .Sum(pp => (decimal?)pp.Quantidade * pp.ValorUnitario) ?? 0;

            var acrescimosDescontos = pedidosNoPeriodo
                .Where(p => p.Status != "CANCELADO")
                .Select(p => new { p.Acrescimo, p.Desconto })
                .ToList();

            receitaTotal += acrescimosDescontos.Sum(x => x.Acrescimo);
            receitaTotal -= acrescimosDescontos.Sum(x => x.Desconto);

            int clientesNoInicio = _db.Clientes
                .Count(c => c.DataCadastro < inicio);

            int clientesNoFim = _db.Clientes
                .Count(c => c.DataCadastro <= fim);

            decimal totalQuebras = _db.PerdaProdutos
                .Include(p => p.Produto)
                .Where(p => p.Data >= inicio && p.Data <= fim)
                .Sum(p => (decimal?)p.Quantidade * p.Produto.PrecoReposicao) ?? 0;

            dados.KPIs = new RelatorioKPIs
            {
                TotalPedidos = totalPedidos,
                ClientesAtendidos = clientesUnicos,
                ReceitaRecebida = receitaRecebida,
                ReceitaTotal = receitaTotal,
                PedidosCancelados = cancelados,
                TotalValorQuebras = totalQuebras,
                ClientesNoInicio = clientesNoInicio,
                ClientesNoFim = clientesNoFim,
            };
        }

        // ════════════════════════════════════════════════════════════
        // RECEITA POR PERÍODO — cada dia do período, soma pagamentos pagos
        // ════════════════════════════════════════════════════════════
        private void CarregarReceitaPorPeriodo(RelatorioDados dados, DateTime inicio, DateTime fim)
        {
            // Busca todos os pagamentos pagos cujo pedido está no período
            var pagamentos = _db.Pagamentos
                .Include(pg => pg.Pedido)
                .Where(pg => pg.Pago
                          && pg.Pedido.DataPedido >= inicio
                          && pg.Pedido.DataPedido <= fim
                          && pg.Pedido.Status != "CANCELADO")
                .Select(pg => new
                {
                    // Usa a data do PAGAMENTO para agrupar por dia
                    Data = pg.DataPagamento.Date,
                    pg.Valor
                })
                .ToList();

            if (!pagamentos.Any())
            {
                dados.ReceitaPorPeriodo = new List<ReceitaPorData>();
                return;
            }

            // Gera todos os dias do período para que dias sem pagamento apareçam zerados
            int numeroDias = (fim.Date - inicio.Date).Days + 1;
            var resultado = new List<ReceitaPorData>();

            for (int i = 0; i < numeroDias; i++)
            {
                var dia = inicio.Date.AddDays(i);
                decimal v = pagamentos.Where(p => p.Data == dia).Sum(p => p.Valor);

                resultado.Add(new ReceitaPorData
                {
                    Label = dia.ToString("dd/MM", CultureInfo.InvariantCulture),
                    Valor = v
                });
            }

            dados.ReceitaPorPeriodo = resultado;
        }

        // ════════════════════════════════════════════════════════════
        // TOP 20 PRODUTOS — recorrência + valor total locado
        // ════════════════════════════════════════════════════════════
        private void CarregarTopProdutos(RelatorioDados dados, DateTime inicio, DateTime fim)
        {
            int totalPedidos = dados.KPIs.TotalPedidos;

            var topProdutos = _db.ProdutosPedidos
                .Include(pp => pp.Produto)
                .Include(pp => pp.Pedido)
                .Where(pp => pp.Pedido.DataPedido >= inicio
                          && pp.Pedido.DataPedido <= fim
                          && pp.Pedido.Status != "CANCELADO")
                .GroupBy(pp => new
                {
                    pp.ProdutoId,
                    pp.Produto.Nome,
                    pp.Produto.Material,
                    pp.Produto.Modelo,
                    pp.Produto.Especificacao
                })
                .Select(g => new TopProdutoDTO
                {
                    Nome = (g.Key.Nome + " " + g.Key.Material + " " + g.Key.Modelo + " " + g.Key.Especificacao).Trim(),
                    TotalQuantidade = g.Sum(x => x.Quantidade),
                    PedidosDistintos = g.Select(x => x.PedidoId).Distinct().Count(),
                    PorcentagemPresenca = totalPedidos > 0
                        ? Math.Round((double)g.Select(x => x.PedidoId).Distinct().Count() / totalPedidos * 100, 1)
                        : 0,
                    // Soma quantidade * valorUnitario de todas as linhas do grupo
                    ValorTotalLocado = g.Sum(x => x.Quantidade * x.ValorUnitario)
                })
                .OrderByDescending(x => x.PedidosDistintos)
                .Take(20)
                .ToList();

            dados.TopProdutos = topProdutos;
        }

        // ════════════════════════════════════════════════════════════
        // TOP 20 CLIENTES
        // ════════════════════════════════════════════════════════════
        private void CarregarTopClientes(RelatorioDados dados, DateTime inicio, DateTime fim)
        {
            var topClientes = _db.Pedidos
                .Include(p => p.Cliente)
                .Where(p => p.DataPedido >= inicio
                         && p.DataPedido <= fim
                         && p.Status != "CANCELADO")
                .GroupBy(p => new { p.ClienteId, p.Cliente.Nome })
                .Select(g => new TopClienteDTO
                {
                    Nome = g.Key.Nome ?? "—",
                    NumeroPedidos = g.Count(),
                    ValorTotalGasto = _db.Pagamentos
                        .Where(pg => pg.Pago && g.Select(p => p.ID).Contains(pg.PedidoId))
                        .Sum(pg => (decimal?)pg.Valor) ?? 0
                })
                .OrderByDescending(x => x.NumeroPedidos)
                .Take(20)
                .ToList();

            dados.TopClientes = topClientes;
        }

        // ════════════════════════════════════════════════════════════
        // TIPOS DE PAGAMENTO — % de cada forma nos pagamentos pagos
        // ════════════════════════════════════════════════════════════
        private void CarregarTiposPagamento(RelatorioDados dados, DateTime inicio, DateTime fim)
        {
            // Pega pagamentos pagos de pedidos ativos no período
            var idsPedidosAtivos = _db.Pedidos
                .Where(p => p.DataPedido >= inicio && p.DataPedido <= fim && p.Status != "CANCELADO")
                .Select(p => p.ID)
                .ToList();

            var pagamentos = _db.Pagamentos
                .Where(pg => pg.Pago && idsPedidosAtivos.Contains(pg.PedidoId))
                .ToList();

            decimal totalGeral = pagamentos.Sum(pg => pg.Valor);
            if (totalGeral == 0)
            {
                dados.TiposPagamento = new List<TipoPagamentoDTO>();
                return;
            }

            dados.TiposPagamento = pagamentos
                .GroupBy(pg => string.IsNullOrWhiteSpace(pg.FormaPagamento) ? "OUTROS" : pg.FormaPagamento.Trim().ToUpper())
                .Select(g => new TipoPagamentoDTO
                {
                    Forma = g.Key,
                    ValorTotal = g.Sum(x => x.Valor),
                    Porcentagem = Math.Round((double)g.Sum(x => x.Valor) / (double)totalGeral * 100, 1)
                })
                .OrderByDescending(x => x.ValorTotal)
                .ToList();
        }
        /// <summary>
        /// Carrega a receita recebida dia a dia para um período de comparação,
        /// normalizando os índices para que coincidam com o período principal.
        /// </summary>
        public ComparacaoPeriodo CarregarComparacao(DateTime inicioRef, DateTime fimRef,
            DateTime inicioComp, DateTime fimComp, string nomeComp)
        {
            inicioComp = inicioComp.Date;
            fimComp = fimComp.Date;

            var pagamentos = _db.Pagamentos
                .Include(pg => pg.Pedido)
                .Where(pg => pg.Pago
                          && pg.Pedido.DataPedido >= inicioComp
                          && pg.Pedido.DataPedido <= new DateTime(fimComp.Year, fimComp.Month, fimComp.Day, 23, 59, 59)
                          && pg.Pedido.Status != "CANCELADO")
                .Select(pg => new { Data = pg.DataPagamento.Date, pg.Valor })
                .ToList();

            decimal receitaTotal = pagamentos.Sum(p => p.Valor);

            // Número de dias do período de comparação
            int numeroDias = (fimComp - inicioComp).Days + 1;
            // Número de dias do período principal (para alinhar o eixo X)
            int diasRef = (fimRef.Date - inicioRef.Date).Days + 1;
            int diasParaIterar = Math.Min(numeroDias, diasRef);

            var receitaPorDia = new List<ReceitaPorData>();
            for (int i = 0; i < diasParaIterar; i++)
            {
                var dia = inicioComp.AddDays(i);
                // Label usa o índice do período principal para alinhar no gráfico
                var labelRef = inicioRef.Date.AddDays(i)
                    .ToString("dd/MM", System.Globalization.CultureInfo.InvariantCulture);
                decimal v = pagamentos.Where(p => p.Data == dia).Sum(p => p.Valor);
                receitaPorDia.Add(new ReceitaPorData { Label = labelRef, Valor = v });
            }

            return new ComparacaoPeriodo
            {
                Nome = nomeComp,
                Inicio = inicioComp,
                Fim = fimComp,
                ReceitaTotal = receitaTotal,
                ReceitaPorDia = receitaPorDia
            };
        }
    }
}