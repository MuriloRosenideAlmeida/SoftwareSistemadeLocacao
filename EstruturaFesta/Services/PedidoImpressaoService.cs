using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using EstruturaFesta.Models;

namespace EstruturaFesta.Services
{
    /// <summary>
    /// Serviço responsável pela geração de PDFs de pedidos de locação
    /// </summary>
    public static class PedidoImpressaoService
    {
        private const string CAMINHO_LOGO = @"Resources\logo.png";

        public static void Inicializar()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public static void GerarPDF(DadosPedidoImpressao pedido, string caminhoArquivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

                    page.Header().Element(c => CriarCabecalho(c, pedido));

                    page.Content().Column(col =>
                    {
                        col.Item().Element(c => CriarBoxCliente(c, pedido));
                        col.Item().PaddingTop(5).Element(c => CriarBoxDatasObservacoes(c, pedido));

                        col.Item().PaddingTop(8).AlignCenter()
                            .Text("PEDIDO").FontSize(14).Bold();

                        col.Item().PaddingTop(5).Element(c => CriarTabelaProdutos(c, pedido));

                        // VALORES E PAGAMENTOS NA MESMA LINHA
                        col.Item().PaddingTop(5).Row(row =>
                        {
                            // Condições de pagamento à ESQUERDA
                            row.RelativeItem().Element(c => CriarCondicoesPagamento(c, pedido));

                            row.ConstantItem(10); // Espaçamento

                            // Resumo financeiro à DIREITA
                            row.ConstantItem(200).Element(c => CriarResumoFinanceiro(c, pedido));
                        });

                        col.Item().PaddingTop(8).Element(CriarObservacoesFinais);
                        col.Item().PaddingTop(10).Element(CriarAssinatura);
                    });
                });
            })
            .GeneratePdf(caminhoArquivo);
        }

        // ===== CABEÇALHO (SEM CAIXA NO NÚMERO) =====
        private static void CriarCabecalho(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Border(1).BorderColor(Colors.Black).Padding(8).Row(row =>
            {
                // Logo
                row.ConstantItem(100).Column(col =>
                {
                    if (File.Exists(CAMINHO_LOGO))
                    {
                        col.Item().Height(65).Image(CAMINHO_LOGO);
                    }
                    else
                    {
                        col.Item().Height(65).Border(1).BorderColor(Colors.Grey.Medium)
                            .AlignCenter().AlignMiddle()
                            .Text("LOGO").FontSize(10).FontColor(Colors.Grey.Medium);
                    }
                });

                // Dados da empresa (LETRAS MAIORES)
                row.RelativeItem().PaddingLeft(10).Column(col =>
                {
                    col.Item().Text("Estrutura Festa Comercio e Locação de Materiais para Festa Ltda ME")
                        .FontSize(12).Bold(); // Aumentado

                    col.Item().PaddingTop(3).Text("Rua Jucelino Kubitschek de Oliveira, 04 - Jd. Europa")
                        .FontSize(11); // Aumentado

                    col.Item().Text("13460-000 - Nova Odessa - SP")
                        .FontSize(11); // Aumentado

                    col.Item().Text("Fone: (19) 3476-5005")
                        .FontSize(11); // Aumentado
                });

                // Número do pedido e data (SEM CAIXA, LETRAS MAIORES)
                row.ConstantItem(90).Column(col =>
                {
                    col.Item().PaddingTop(3).AlignCenter()
                    .Text("Numero do Pedido").FontSize(11);

                    col.Item().AlignCenter()
                        .Text(pedido.NumeroPedido.ToString())
                        .FontSize(12).Bold(); // Maior e sem caixa

                    col.Item().PaddingTop(10).AlignCenter()
                        .Text("Data do Pedido").FontSize(10); // Aumentado

                    col.Item().AlignCenter()
                        .Text(pedido.DataPedido.ToString("dd/MM/yyyy"))
                        .FontSize(11).Bold(); // Aumentado
                });
            });
        }

        // ===== DADOS DO CLIENTE (REFORMULADO) =====
        private static void CriarBoxCliente(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Border(1).BorderColor(Colors.Black).Padding(8).Column(col =>
            {
                // Título
                col.Item().Text("DADOS DO CLIENTE").FontSize(10).Bold();

                col.Item().PaddingTop(5).Row(row =>
                {
                    // COLUNA ESQUERDA - Dados principais
                    row.RelativeItem().Column(colEsq =>
                    {
                        colEsq.Item().Text(txt =>
                        {
                            txt.Span("Nome: ").FontSize(9);
                            txt.Span(pedido.NomeCliente).FontSize(9).Bold();
                        });

                        colEsq.Item().PaddingTop(3).Text(txt =>
                        {
                            txt.Span("CPF/CNPJ: ").FontSize(9);
                            txt.Span(pedido.DocumentoCliente).FontSize(9).Bold();
                        });

                        colEsq.Item().PaddingTop(3).Text(txt =>
                        {
                            txt.Span("Endereço: ").FontSize(9);
                            // Aqui você pode adicionar Rua e Número se tiver no modelo
                            txt.Span("").FontSize(9);
                        });

                        colEsq.Item().PaddingTop(3).Text(txt =>
                        {
                            txt.Span("Bairro: ").FontSize(9);
                            // Bairro e Complemento
                            txt.Span("").FontSize(9);
                        });

                        colEsq.Item().PaddingTop(3).Text(txt =>
                        {
                            txt.Span("CEP: ").FontSize(9);
                            txt.Span("").FontSize(9);
                            txt.Span("  Cidade: ").FontSize(9);
                            txt.Span("Nova Odessa").FontSize(9);
                            txt.Span("  UF: ").FontSize(9);
                            txt.Span("SP").FontSize(9);
                        });
                    });

                    // COLUNA DIREITA - Contatos alinhados
                    row.ConstantItem(200).Column(colDir =>
                    {
                        if (pedido.OutrosContatos.Any())
                        {
                            foreach (var contato in pedido.OutrosContatos.Take(5))
                            {
                                colDir.Item().Row(rowContato =>
                                {
                                    rowContato.RelativeItem()
                                        .Text(contato.NomeContato).FontSize(9);

                                    rowContato.ConstantItem(100).AlignRight()
                                        .Text(contato.Telefone).FontSize(9).Bold();
                                });
                            }
                        }
                    });
                });
            });
        }

        // ===== DATAS E OBSERVAÇÕES =====
        private static void CriarBoxDatasObservacoes(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Border(1).BorderColor(Colors.Black).Padding(6).Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Text(txt =>
                    {
                        txt.Span("Evento: ").FontSize(9);
                        txt.Span(pedido.DataPedido.ToString("dd/MM/yyyy")).FontSize(9).Bold();
                    });

                    row.RelativeItem().Text(txt =>
                    {
                        txt.Span("Entrega: ").FontSize(9);
                        txt.Span(pedido.DataEntrega.ToString("dd/MM/yyyy")).FontSize(9).Bold();
                    });

                    row.RelativeItem().Text(txt =>
                    {
                        txt.Span("Devolução: ").FontSize(9);
                        txt.Span(pedido.DataRetirada.ToString("dd/MM/yyyy")).FontSize(9).Bold();
                    });
                });

                col.Item().PaddingTop(3).Text(txt =>
                {
                    txt.Span("Observação: ").FontSize(9);
                    txt.Span(pedido.Observacoes ?? "").FontSize(9);
                });
            });
        }

        // ===== TABELA DE PRODUTOS (NOVA ORDEM, SEM GRADES INTERNAS) =====
        private static void CriarTabelaProdutos(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Border(1).BorderColor(Colors.Black).Table(table =>
            {
                // Ordem: Item, Código, Produto, Faltas, Quantidade, Valor Unit., Valor Total, Reposição
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(35);   // Item
                    columns.ConstantColumn(55);   // Código
                    columns.RelativeColumn(5);    // Produto (sem grade)
                    columns.ConstantColumn(50);   // Faltas (COM grade)
                    columns.ConstantColumn(55);   // Quantidade
                    columns.ConstantColumn(75);   // Valor Unitário
                    columns.ConstantColumn(75);   // Valor Total
                    columns.ConstantColumn(75);   // Reposição
                });

                // Cabeçalho
                table.Header(header =>
                {
                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Item").FontSize(8).Bold();

                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Código").FontSize(8).Bold();

                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Produto").FontSize(8).Bold();

                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Faltas").FontSize(8).Bold();

                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Qtd.").FontSize(8).Bold();

                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Valor Unit.").FontSize(8).Bold();

                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Valor Total").FontSize(8).Bold();

                    header.Cell().Background(Colors.Grey.Lighten3)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).AlignCenter().Text("Reposição").FontSize(8).Bold();
                });

                // Linhas dos produtos
                int itemNumero = 1;
                foreach (var item in pedido.Itens)
                {
                    var corLinha = itemNumero % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                    // Item
                    table.Cell().Background(corLinha)
                        .BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                        .Padding(3).AlignCenter().Text(itemNumero.ToString()).FontSize(8);

                    // Código
                    table.Cell().Background(corLinha)
                        .BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                        .Padding(3).AlignCenter().Text(item.ProdutoId.ToString()).FontSize(8);

                    // Produto (SEM grade lateral)
                    table.Cell().Background(corLinha)
                        .BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                        .Padding(3).Text(item.DescricaoProduto).FontSize(8);

                    // Faltas (COM grade)
                    table.Cell().Background(Colors.White)
                        .Border(1).BorderColor(Colors.Black)
                        .Padding(3).Text("").FontSize(8);

                    // Quantidade
                    table.Cell().Background(corLinha)
                        .BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                        .Padding(3).AlignCenter().Text(item.Quantidade.ToString()).FontSize(8);

                    // Valor Unitário
                    table.Cell().Background(corLinha)
                        .BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                        .Padding(3).AlignRight().Text(item.ValorUnitario.ToString("N2")).FontSize(8);

                    // Valor Total
                    table.Cell().Background(corLinha)
                        .BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                        .Padding(3).AlignRight().Text(item.ValorTotal.ToString("N2")).FontSize(8);

                    // Reposição
                    table.Cell().Background(corLinha)
                        .BorderBottom(1).BorderColor(Colors.Grey.Lighten1)
                        .Padding(3).AlignRight().Text("").FontSize(8);

                    itemNumero++;
                }

                // Linha do total
                table.Cell().ColumnSpan(4)
                    .Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3)
                    .Padding(3).AlignRight().Text($"Total Itens: {pedido.Itens.Count}")
                    .FontSize(9).Bold();

                table.Cell().ColumnSpan(2)
                    .Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3)
                    .Padding(3).AlignRight().Text("Valor Total:")
                    .FontSize(9).Bold();

                table.Cell().ColumnSpan(2)
                    .Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3)
                    .Padding(3).AlignRight().Text(pedido.SubTotal.ToString("N2"))
                    .FontSize(9).Bold();
            });
        }

        // ===== CONDIÇÕES DE PAGAMENTO (À ESQUERDA) =====
        private static void CriarCondicoesPagamento(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Column(col =>
            {
                col.Item().Text("Condições de Pagamento").FontSize(9).Bold();

                col.Item().PaddingTop(3).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(50);   // Parcela
                        columns.RelativeColumn(2);    // Tipo
                        columns.ConstantColumn(80);   // Vencimento
                        columns.ConstantColumn(80);   // Valor
                    });

                    // Cabeçalho
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten3)
                            .Border(1).BorderColor(Colors.Black)
                            .Padding(3).AlignCenter().Text("Parcela").FontSize(8).Bold();

                        header.Cell().Background(Colors.Grey.Lighten3)
                            .Border(1).BorderColor(Colors.Black)
                            .Padding(3).AlignCenter().Text("Tipo").FontSize(8).Bold();

                        header.Cell().Background(Colors.Grey.Lighten3)
                            .Border(1).BorderColor(Colors.Black)
                            .Padding(3).AlignCenter().Text("Vencimento").FontSize(8).Bold();

                        header.Cell().Background(Colors.Grey.Lighten3)
                            .Border(1).BorderColor(Colors.Black)
                            .Padding(3).AlignCenter().Text("Valor").FontSize(8).Bold();
                    });

                    // Linhas
                    int parcela = 1;
                    foreach (var pag in pedido.Pagamentos.Where(p => p.Pago))
                    {
                        table.Cell().Border(1).BorderColor(Colors.Black)
                            .Padding(3).AlignCenter().Text(parcela.ToString()).FontSize(8);

                        // Tipo com "PAGO" se estiver pago
                        table.Cell().Border(1).BorderColor(Colors.Black)
                            .Padding(3).Text(txt =>
                            {
                                txt.Span(pag.FormaPagamento).FontSize(8);
                                if (pag.Pago)
                                {
                                    txt.Span(" - PAGO").FontSize(8).Bold().FontColor(Colors.Green.Darken1);
                                }
                            });

                        table.Cell().Border(1).BorderColor(Colors.Black)
                            .Padding(3).AlignCenter().Text(pag.DataPagamento.ToString("dd/MM/yyyy")).FontSize(8);

                        table.Cell().Border(1).BorderColor(Colors.Black)
                            .Padding(3).AlignRight().Text(pag.Valor.ToString("N2")).FontSize(8);

                        parcela++;
                    }

                    // Total
                    table.Cell().ColumnSpan(3)
                        .Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3)
                        .Padding(3).AlignRight().Text("Total....:").FontSize(9).Bold();

                    table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3)
                        .Padding(3).AlignRight().Text(pedido.TotalPago.ToString("N2")).FontSize(9).Bold();
                });
            });
        }

        // ===== RESUMO FINANCEIRO (À DIREITA) =====
        private static void CriarResumoFinanceiro(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Border(1).BorderColor(Colors.Black).Padding(8).Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Text("Sub Total...:").FontSize(9);
                    row.ConstantItem(80).AlignRight().Text(pedido.SubTotal.ToString("N2")).FontSize(9).Bold();
                });

                if (pedido.Acrescimo > 0)
                {
                    col.Item().PaddingTop(3).Row(row =>
                    {
                        row.RelativeItem().Text("Acréscimo:").FontSize(9);
                        row.ConstantItem(80).AlignRight().Text(pedido.Acrescimo.ToString("N2")).FontSize(9);
                    });
                }

                if (pedido.Desconto > 0)
                {
                    col.Item().PaddingTop(3).Row(row =>
                    {
                        row.RelativeItem().Text("Desconto:").FontSize(9);
                        row.ConstantItem(80).AlignRight().Text(pedido.Desconto.ToString("N2"))
                            .FontSize(9).FontColor(Colors.Red.Darken1);
                    });
                }

                col.Item().PaddingTop(3).Row(row =>
                {
                    row.RelativeItem().Text("Sinal......:").FontSize(9);
                    row.ConstantItem(80).AlignRight().Text("").FontSize(9);
                });

                col.Item().PaddingTop(3).Row(row =>
                {
                    row.RelativeItem().Text("Faltas.........:").FontSize(9);
                    row.ConstantItem(80).AlignRight().Text("").FontSize(9);
                });

                col.Item().PaddingTop(5).BorderTop(1).BorderColor(Colors.Black);

                col.Item().PaddingTop(3).Row(row =>
                {
                    row.RelativeItem().Text("Saldo....:").FontSize(10).Bold();
                    row.ConstantItem(80).AlignRight().Text(pedido.SaldoPedido.ToString("N2"))
                        .FontSize(10).Bold().FontColor(Colors.Red.Darken1);
                });

                col.Item().PaddingTop(3).Row(row =>
                {
                    row.RelativeItem().Text("Total....:").FontSize(10).Bold();
                    row.ConstantItem(80).AlignRight().Text(pedido.ValorTotal.ToString("N2"))
                        .FontSize(10).Bold();
                });
            });
        }

        // ===== OBSERVAÇÕES FINAIS =====
        private static void CriarObservacoesFinais(IContainer container)
        {
            container.Padding(5).Text(texto =>
            {
                texto.DefaultTextStyle(x => x.FontSize(7).LineHeight(1.2f));

                texto.Line("Ps. As quebras e danos correrão por conta do Locatário. Pede-se conferir o Material");
                texto.Line("no ato da entrega ou retirada, não se atendem reclamações posteriores. As merca_");
                texto.Line("dorias deverão ser devolvidas limpas e embaladas, caso contrário incidirá um novo");
                texto.Line("aluguel a cada dia. Aos materiais não devolvidos no prazo marcado incidem novos");
                texto.Line("aluguéis. O Valor desta locação se refere a um dia de aluguel. Nos objetos de Prata");
                texto.Line("não utilizar Bom Bril ou outro material abrasivo, nem levar ao fogo.");
            });
        }

        // ===== ASSINATURA =====
        private static void CriarAssinatura(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("Conferi(mos) e Recebi(mos) os Materiais Relacionados.").FontSize(8);
                    col.Item().PaddingTop(15).BorderTop(1).BorderColor(Colors.Black);
                });

                row.ConstantItem(20);

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("De acordo e ciente.").FontSize(8);
                    col.Item().PaddingTop(3).Text("Data.: ______/______/_________").FontSize(8);
                    col.Item().PaddingTop(8).BorderTop(1).BorderColor(Colors.Black);
                });
            });
        }

        // ===== MÉTODOS PÚBLICOS =====

        public static void VisualizarPDF(DadosPedidoImpressao pedido)
        {
            try
            {
                string caminhoTemp = Path.Combine(
                    Path.GetTempPath(),
                    $"Pedido_{pedido.NumeroPedido}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                GerarPDF(pedido, caminhoTemp);

                Process.Start(new ProcessStartInfo
                {
                    FileName = caminhoTemp,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao visualizar PDF:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool SalvarPDFComDialogo(DadosPedidoImpressao pedido, out string caminhoSalvo)
        {
            caminhoSalvo = string.Empty;

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Arquivo PDF|*.pdf";
                saveDialog.Title = "Salvar Pedido em PDF";
                saveDialog.FileName = $"Pedido_{pedido.NumeroPedido}.pdf";
                saveDialog.DefaultExt = "pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GerarPDF(pedido, saveDialog.FileName);
                        caminhoSalvo = saveDialog.FileName;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar PDF:\n{ex.Message}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return false;
        }
    }
}