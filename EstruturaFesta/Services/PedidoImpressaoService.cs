using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using EstruturaFesta.Models;
using EstruturaFesta.Data.Entities;
using MySqlX.XDevAPI;

namespace EstruturaFesta.Services
{
    /// <summary>
    /// Serviço responsável pela geração de PDFs de pedidos de locação
    /// </summary>
    public static class PedidoImpressaoService
    {
        // ===== CONFIGURAÇÃO INICIAL =====
        public static void Inicializar()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // ===== MÉTODO PRINCIPAL DE GERAÇÃO =====
        public static void GerarPDF(DadosPedidoImpressao pedido, string caminhoArquivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

                    // CABEÇALHO
                    page.Header().Element(c => CriarCabecalho(c, pedido));

                    // CONTEÚDO
                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        // Dados do Cliente
                        col.Item().Element(c => CriarSecaoCliente(c, pedido));

                        // Dados do Pedido (Datas)
                        col.Item().PaddingTop(10).Element(c => CriarSecaoPeriodo(c, pedido));

                        // Tabela de Produtos
                        col.Item().PaddingTop(10).Element(c => CriarTabelaProdutos(c, pedido));

                        col.Item().PaddingTop(10).Row(row =>
                        {
                            // PAGAMENTOS (ESQUERDA)
                            if(pedido.Pagamentos.Any())
                            row.RelativeItem().Element(c => CriarTabelaPagamentos(c, pedido));

                            row.ConstantItem(15); // Espaço entre os blocos

                            // RESUMO FINANCEIRO (DIREITA)
                            row.ConstantItem(260).Element(c => CriarResumoFinanceiro(c, pedido));
                        });
                        // Observações (se houver)
                        if (!string.IsNullOrWhiteSpace(pedido.Observacoes))
                            col.Item().PaddingTop(10).Element(c => CriarSecaoObservacoes(c, pedido));

                        // Assinaturas
                        col.Item().PaddingTop(30).Element(c => CriarSecaoAssinaturas(c, pedido));
                    });

                    // RODAPÉ
                    page.Footer().Element(CriarRodape);
                });
            })
            .GeneratePdf(caminhoArquivo);
        }
        // ===== CABEÇALHO =====
        private static void CriarCabecalho(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Row(row =>
            {
                // LOGO
                row.ConstantItem(90).AlignLeft().Height(60).Image("C:\\Users\\Murilo\\Pictures\\Ideias de logo\\LogoSemFundoBranco.png");

                // INFO DA EMPRESA
                row.RelativeItem().AlignRight().Column(col =>
                {
                    col.Item().Text("ESTRUTURA FESTA")
                        .FontSize(12).Bold();

                    col.Item().Text("CNPJ: 00.000.000/0001-00")
                        .FontSize(8);

                    col.Item().Text("Tel: (00) 0000-0000")
                        .FontSize(8);

                    col.Item().Text("contato@estruturafesta.com")
                        .FontSize(8);

                    col.Item().Text("Endereço: Rua tal, Nº tal, Bairro tal")
                        .FontSize(8);

                    col.Item().Text("CEP: 00000-000")
                        .FontSize(8);
                });
            });
        }

        // ===== DADOS DO CLIENTE =====
        private static void CriarSecaoCliente(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Background(Colors.Grey.Lighten3).Padding(8).Column(col =>
            {
                col.Item().Text("DADOS DO CLIENTE").Bold().FontSize(10);

                col.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Text($"Nome: {pedido.NomeCliente}").FontSize(8);
                    row.RelativeItem().Text($"Doc: {pedido.DocumentoCliente}").FontSize(8);
                });

                col.Item().PaddingTop(3).Row(row =>
                {
                    row.RelativeItem().Text($"Contato: {pedido.ContatoNome}").FontSize(8);
                    row.RelativeItem().Text($"Telefone: {pedido.ContatoNumero}").FontSize(8);
                });

                // Outros contatos (se houver)
                if (pedido.OutrosContatos.Any())
                {
                    col.Item().PaddingTop(3).Text("Outros contatos:").FontSize(7).Italic();
                    foreach (var contato in pedido.OutrosContatos.Take(3)) // Máximo 3
                    {
                        col.Item().Text($"  • {contato.NomeContato}: {contato.Telefone}")
                            .FontSize(7);
                    }
                }
            });
        }

        // ===== PERÍODO DO PEDIDO =====
        private static void CriarSecaoPeriodo(IContainer container, DadosPedidoImpressao pedido)
        {
            var dias = (pedido.DataRetirada - pedido.DataEntrega).Days;

            container.Background(Colors.Grey.Lighten3).Padding(8).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("PERÍODO DE LOCAÇÃO").Bold().FontSize(10);
                    col.Item().PaddingTop(3).Text($"Entrega: {pedido.DataEntrega:dd/MM/yyyy}").FontSize(8);
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(" "); // Espaço
                    col.Item().PaddingTop(3).Text($"Retirada: {pedido.DataRetirada:dd/MM/yyyy}").FontSize(8);
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(" "); // Espaço
                    col.Item().PaddingTop(3).Text($"Total: {dias} dia(s)").FontSize(8);
                });
            });
        }

        // ===== TABELA DE PRODUTOS =====
        private static void CriarTabelaProdutos(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Column(col =>
            {
                col.Item().Text("PRODUTOS DO PEDIDO").Bold().FontSize(10);

                col.Item().PaddingTop(5).Table(table =>
                {
                    // Colunas
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(50);   // ID
                        columns.RelativeColumn(5);    // Descrição
                        columns.ConstantColumn(60);   // Quantidade
                        columns.ConstantColumn(80);   // Valor Unit.
                        columns.ConstantColumn(80);   // Total
                    });

                    // Cabeçalho
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Blue.Darken2)
                            .Padding(5).Text("ID").FontColor(Colors.White).Bold().FontSize(8);

                        header.Cell().Background(Colors.Blue.Darken2)
                            .Padding(5).Text("Descrição").FontColor(Colors.White).Bold().FontSize(8);

                        header.Cell().Background(Colors.Blue.Darken2)
                            .Padding(5).Text("Qtd").FontColor(Colors.White).Bold().FontSize(8);

                        header.Cell().Background(Colors.Blue.Darken2)
                            .Padding(5).Text("Valor Unit.").FontColor(Colors.White).Bold().FontSize(8);

                        header.Cell().Background(Colors.Blue.Darken2)
                            .Padding(5).Text("Total").FontColor(Colors.White).Bold().FontSize(8);
                    });

                    // Linhas dos produtos
                    foreach (var item in pedido.Itens)
                    {
                        table.Cell()
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(item.ProdutoId.ToString()).FontSize(8);

                        table.Cell()
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(item.DescricaoProduto).FontSize(8);

                        table.Cell()
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).AlignCenter().Text(item.Quantidade.ToString()).FontSize(8);

                        table.Cell()
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).AlignRight().Text(item.ValorUnitario.ToString("C2")).FontSize(8);

                        table.Cell()
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).AlignRight().Text(item.ValorTotal.ToString("C2")).FontSize(8);
                    }
                });
            });
        }

        // ===== RESUMO FINANCEIRO =====
        private static void CriarResumoFinanceiro(IContainer container, DadosPedidoImpressao pedido)
        {
            container.AlignRight().Column(col =>
            {
                col.Item().Width(250).Background(Colors.Grey.Lighten3).Padding(8).Column(resumoCol =>
                {
                    resumoCol.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Subtotal:").FontSize(9);
                        row.ConstantItem(80).AlignRight().Text(pedido.SubTotal.ToString("C2")).FontSize(9);
                    });

                    if (pedido.Acrescimo > 0)
                    {
                        resumoCol.Item().PaddingTop(3).Row(row =>
                        {
                            row.RelativeItem().Text("Acréscimo:").FontSize(9);
                            row.ConstantItem(80).AlignRight().Text(pedido.Acrescimo.ToString("C2"))
                                .FontSize(9).FontColor(Colors.Green.Darken1);
                        });
                    }

                    if (pedido.Desconto > 0)
                    {
                        resumoCol.Item().PaddingTop(3).Row(row =>
                        {
                            row.RelativeItem().Text("Desconto:").FontSize(9);
                            row.ConstantItem(80).AlignRight().Text($"-{pedido.Desconto:C2}")
                                .FontSize(9).FontColor(Colors.Red.Darken1);
                        });
                    }

                    if (pedido.ValorQuebra > 0)
                    {
                        resumoCol.Item().PaddingTop(3).Row(row =>
                        {
                            row.RelativeItem().Text("Quebra:").FontSize(9);
                            row.ConstantItem(80).AlignRight().Text(pedido.ValorQuebra.ToString("C2"))
                                .FontSize(9).FontColor(Colors.Orange.Darken1);
                        });
                    }

                    resumoCol.Item().PaddingTop(5).BorderTop(1).BorderColor(Colors.Grey.Medium);

                    resumoCol.Item().PaddingTop(5).Row(row =>
                    {
                        row.RelativeItem().Text("TOTAL:").Bold().FontSize(11);
                        row.ConstantItem(80).AlignRight().Text(pedido.ValorTotal.ToString("C2"))
                            .Bold().FontSize(11).FontColor(Colors.Blue.Darken2);
                    });

                    resumoCol.Item().PaddingTop(3).Row(row =>
                    {
                        row.RelativeItem().Text("Pago:").FontSize(9);
                        row.ConstantItem(80).AlignRight().Text(pedido.TotalPago.ToString("C2"))
                            .FontSize(9).FontColor(Colors.Green.Darken1);
                    });

                    resumoCol.Item().PaddingTop(3).Row(row =>
                    {
                        row.RelativeItem().Text("Saldo:").Bold().FontSize(10);
                        row.ConstantItem(80).AlignRight().Text(pedido.SaldoPedido.ToString("C2"))
                            .Bold().FontSize(10).FontColor(pedido.SaldoPedido > 0 ? Colors.Red.Darken1 : Colors.Green.Darken1);
                    });
                });
            });
        }

        // ===== TABELA DE PAGAMENTOS =====
        private static void CriarTabelaPagamentos(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Column(col =>
            {
                col.Item().Text("PAGAMENTOS REALIZADOS").Bold().FontSize(10);

                col.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2);    // Forma Pagamento
                        columns.ConstantColumn(80);   // Data
                        columns.ConstantColumn(80);   // Valor
                        columns.ConstantColumn(50);   // Status
                    });

                    // Cabeçalho
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Green.Darken1)
                            .Padding(5).Text("Forma Pagamento").FontColor(Colors.White).Bold().FontSize(8);

                        header.Cell().Background(Colors.Green.Darken1)
                            .Padding(5).Text("Data").FontColor(Colors.White).Bold().FontSize(8);

                        header.Cell().Background(Colors.Green.Darken1)
                            .Padding(5).Text("Valor").FontColor(Colors.White).Bold().FontSize(8);

                        header.Cell().Background(Colors.Green.Darken1)
                            .Padding(5).Text("Pago").FontColor(Colors.White).Bold().FontSize(8);
                    });

                    // Linhas
                    foreach (var pag in pedido.Pagamentos)
                    {
                        var cor = pag.Pago ? Colors.Green.Lighten3 : Colors.Red.Lighten3;

                        table.Cell().Background(cor)
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(pag.FormaPagamento).FontSize(8);

                        table.Cell().Background(cor)
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(pag.DataPagamento.ToString("dd/MM/yyyy")).FontSize(8);

                        table.Cell().Background(cor)
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).AlignRight().Text(pag.Valor.ToString("C2")).FontSize(8);

                        table.Cell().Background(cor)
                            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).AlignCenter().Text(pag.Pago ? "✓" : "✗").FontSize(8);
                    }
                });
            });
        }

        // ===== OBSERVAÇÕES =====
        private static void CriarSecaoObservacoes(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Column(col =>
            {
                col.Item().Text("OBSERVAÇÕES").Bold().FontSize(10);
                col.Item().PaddingTop(3)
                    .Border(1).BorderColor(Colors.Grey.Medium)
                    .Padding(8)
                    .Text(pedido.Observacoes).FontSize(8);
            });
        }

        // ===== ASSINATURAS =====
        private static void CriarSecaoAssinaturas(IContainer container, DadosPedidoImpressao pedido)
        {
            container.Padding(10).Border(1).Column(col =>
            {
                // Titulo
                col.Item().AlignCenter().Text("NOTA PROMISSÓRIA")
                    .Bold().FontSize(14);

                col.Item().PaddingVertical(8);

                // Numero / Vencimento / Valor
                col.Item().Row(row =>
                {
                    row.RelativeItem().Text($"PEDIDO Nº: {pedido.NumeroPedido}");
                    row.RelativeItem().AlignCenter().Text($"Vencimento: {pedido.DataRetirada:dd/MM/yyyy}");
                    row.RelativeItem().AlignRight().Text("R$: __________________");
                });

                col.Item().PaddingVertical(12);

                // Texto principal da nota (igual ao formulário)
                col.Item().Text(txt =>
                {
                    txt.Span("Aos ___________________, pagarei(emos), por esta única via de NOTA PROMISSÓRIA a ");
                    txt.Span(pedido.NomeCliente).Underline();
                    txt.Span(", ou à sua ordem, a quantia de ____________________________________, ");
                    txt.Span("em moeda corrente deste país.");
                });

                col.Item().PaddingVertical(10);

                // Local do pagamento
                col.Item().Text("Pagável em: __________________________________________");

                col.Item().PaddingVertical(10);

                // Local e data
                col.Item().Row(row =>
                {
                    row.RelativeItem().Text("Cidade: __________________________");
                    row.RelativeItem().Text("Data: ____/____/________");
                });

                col.Item().PaddingTop(40);

                // Assinatura emitente
                col.Item().AlignRight().Text("________________________________________");
                col.Item().AlignRight().Text(pedido.NomeCliente).FontSize(9);
                col.Item().AlignRight().Text("Assinatura do Emitente").FontSize(8).Italic();
            });
        }

        // ===== RODAPÉ =====
        private static void CriarRodape(IContainer container)
        {
            container.AlignCenter().Text(txt =>
            {
                txt.Span("Página ").FontSize(7).FontColor(Colors.Grey.Darken1);
                txt.CurrentPageNumber().FontSize(7).FontColor(Colors.Grey.Darken1);
                txt.Span(" de ").FontSize(7).FontColor(Colors.Grey.Darken1);
                txt.TotalPages().FontSize(7).FontColor(Colors.Grey.Darken1);
                txt.Span($" • Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(7).FontColor(Colors.Grey.Darken1);
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