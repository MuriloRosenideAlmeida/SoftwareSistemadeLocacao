using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RentManager.Models;
using RentManager.Utils;
using PdfiumViewer;
using System.Drawing.Printing;


namespace RentManager.Services
{
    public static class ContratoLocacaoService
    {
        private static readonly string CAMINHO_LOGO = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Resources",
            "logo_cortado.jpg"
        );

        public static void GerarPDF(DadosPedidoImpressao pedido, string caminhoArquivo)
        {
            // Converte número do contrato para extenso (simples)
            string dataExtenso = pedido.DataPedido == DateTime.MinValue
                ? DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("pt-BR"))
                : DateTime.Today.ToString("dd 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("pt-BR"));

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginTop(5);
                    page.MarginLeft(30);
                    page.MarginRight(30);
                    page.MarginBottom(30);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

                    page.Content().Column(col =>
                    {
                        // CABEÇALHO
                        col.Item().Row(row =>
                        {
                            // Logo
                            row.ConstantItem(80).Column(c =>
                            {
                                if (File.Exists(CAMINHO_LOGO))
                                    c.Item().Height(80).Image(CAMINHO_LOGO, ImageScaling.FitArea);
                                else
                                    c.Item().Height(80).AlignCenter().AlignMiddle()
                                        .Text("LOGO").FontSize(10).FontColor(Colors.Grey.Medium);
                            });

                            // Dados empresa (centro)
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().AlignCenter().Text(DadosEmpresa.RazaoSocial).FontSize(12).Bold();

                                c.Item().PaddingTop(0).Row(row =>
                                {
                                    row.RelativeItem().AlignCenter().Column(end =>
                                    {
                                        end.Item().PaddingTop(10).AlignCenter().Text($"{DadosEmpresa.Rua},").FontSize(9);
                                        end.Item().AlignCenter().Text($"{DadosEmpresa.Numero} - {DadosEmpresa.Bairro}").FontSize(9);
                                        end.Item().AlignCenter().Text($"{DadosEmpresa.CEP} - {DadosEmpresa.Cidade} - {DadosEmpresa.UF}").FontSize(9);
                                        end.Item().AlignCenter().Text($"Fone: {DadosEmpresa.Telefone}").FontSize(9);
                                        end.Item().AlignCenter().Text($"WhatsApp: {DadosEmpresa.WhatsApp}").FontSize(9);
                                    });


                                    // Número do contrato (direita)
                                    row.ConstantItem(120).AlignRight().Column(c =>
                                    {
                                        c.Item().PaddingTop(20).AlignRight().Text(txt =>
                                        {
                                            txt.Span("Contrato nº  ").FontSize(12).Bold();
                                            txt.Span(pedido.NumeroPedido.ToString()).FontSize(13).Bold();
                                        });
                                    });
                                });
                            });
                        });

                        // Linha separadora
                        col.Item().PaddingTop(5).PaddingBottom(8)
                            .LineHorizontal(1).LineColor(Colors.Black);

                        // TÍTULO
                        col.Item().AlignCenter().PaddingBottom(10)
                            .Text("CONTRATO DE LOCAÇÃO DE MATERIAIS PARA FESTAS E EVENTOS")
                            .FontSize(10).Bold();

                        // TEXTO INTRODUTÓRIO
                        col.Item().PaddingBottom(8).Text(txt =>
                        {
                            txt.DefaultTextStyle(x => x.FontSize(9).LineHeight(1.4f));
                            txt.Span($"Pelo presente instrumento particular, de um lado, {DadosEmpresa.RazaoSocial}, estabelecida na cidade de {DadosEmpresa.Cidade} - {DadosEmpresa.UF}, na {DadosEmpresa.Rua}, {DadosEmpresa.Numero}, {DadosEmpresa.Bairro}, inscrita no CNPJ Sob nº. {DadosEmpresa.CNPJ}, doravante denominada simplesmente LOCADORA, e do outro lado ");
                            txt.Span($"{pedido.NomeCliente} CPF/CNPJ nº {pedido.DocumentoCliente}").Bold();
                            txt.Span(", doravante denominado(a) simplesmente LOCATÁRIO(A), tem entre si, justo e contratado o presente instrumento com as condições que se regerá pelas cláusulas a seguir dispostas.");
                        });

                        // CLÁUSULAS
                        col.Item().PaddingBottom(5).Text("1.Objetivo").FontSize(9).Bold();
                        col.Item().PaddingBottom(8).Text(
                            "1.1 - O presente contrato tem por objetivo")
                            .FontSize(9).LineHeight(1.4f);

                        col.Item().PaddingBottom(5).Text("2. Responsabilidades e Obrigações").FontSize(9).Bold();

                        string[] clausulas2 = {
                            "2.1 - O LOCATÁRIO será responsável pela retirada dos materiais na sede da LOCADORA, salvo especificações em contrário no pedido supracitado, quando o cliente assim solicitar, e mediante pagamento do frete.",
                            "2.2 - O período de locação é de 24 horas, salvo especificações em contrário na realização do pedido, sendo que o valor da locação do período acima, é o constante no referido pedido. A cada dia de atraso na devolução dos materiais será cobrada uma nova locação no valor integral do pedido supracitado.",
                            "2.3 - É obrigação do LOCATÁRIO conferir os materiais locados no ato da retirada ou entrega, sendo possível ressaltar, por escrito neste instrumento, qualquer incorreção ou defeito apresentados pelos materiais ou utensílios ora locados, sob pena, na falta deste termo, presumir-se os objetos em perfeitas condições de uso.",
                            "2.4 - A partir da entrega dos materiais locados, O LOCATÁRIO assume todas e qualquer responsabilidade pelos mesmos.",
                            "2.5 - O LOCATÁRIO responsabiliza-se pelas perdas, quebras e danos de qualquer gênero que ocorram nos materiais, devendo repor-lo(s) de idêntica qualidade ou reembolsar a LOCADORA por todos os materiais danificados no ato da devolução dos mesmos. No caso de não ser reposto ou reembolsado os materiais danificados, poderá a LOCADORA realizar os reparos e ou a reposição dos mesmos, ficando desde já autorizado pelo LOCATÁRIO, que reconhece como idôneo o menor orçamento e líquido o respectivo valor do qual considere-se devedor.",
                            "2.6 - O LOCATÁRIO se responsabiliza por devolver os demais materiais limpos, em boas condições de higiene e embalados. Caso não o faça incidirá um novo aluguel a cada dia de atraso. Toalhas, capas e guardanapos favor não lavar.",
                            "2.7 - O LOCATÁRIO autoriza, aceita e reconhece o saque de letra de câmbio a favor da LOCADORA, no valor apurado dos materiais não devolvidos ou danificados, bem como por qualquer infração prevista neste contrato.",
                            "2.8 - A LOCADORA se obriga a entregar os utensílios em perfeitas condições de uso, sem danos e na data prevista, de acordo com a descrição do pedido feito, salvo condições de força maior e com aviso prévio."
                        };

                        foreach (var clausula in clausulas2)
                            col.Item().PaddingBottom(4).Text(clausula).FontSize(9).LineHeight(1.4f);

                        col.Item().PaddingTop(3).PaddingBottom(5).Text("3. Forma de Pagamento").FontSize(9).Bold();
                        col.Item().PaddingBottom(8).Text(
                            "3.1 - O pagamento no valor total do pedido será feito da seguinte forma: 40% (Quarenta por cento) de sinal no ato da assinatura do contrato e 60% (sessenta por cento) na retirada dos materiais ou através de títulos bancário. Os custos decorrentes das cláusulas 2.5 e 2.6, deverão ser quitados no ato da devolução dos materiais. No caso de inadimplência, os valores referente as despesas bancárias e de cartório, caso o título venha a ser protestado, correrão por conta do LOCATÁRIO, em caso de desistência da locação esta deverá ser feita por escrito e até 30 dias antes da data marcada, nesta caso o sinal será devolvido pela LOCADORA.")
                            .FontSize(9).LineHeight(1.4f);

                        col.Item().PaddingBottom(5).Text("4. Cessão do Contrato").FontSize(9).Bold();
                        col.Item().PaddingBottom(8).Text(
                            "4.1 - É vedada as partes ceder os direitos e obrigações deste contrato, sem prévio expresso conselho escrito de outro.")
                            .FontSize(9).LineHeight(1.4f);

                        col.Item().PaddingBottom(5).Text("5. Do Instrumento").FontSize(9).Bold();
                        col.Item().PaddingBottom(12).Text(
                            "5.1 - Todas as cláusulas do presente instrumento foram previamente examinadas e reciprocamente aceitas e aprovadas por ambas as partes, havendo o LOCATÁRIO efetuado a leitura atenta e afirmado compreender o integral sentido das expressões e palavras aqui empregadas.")
                            .FontSize(9).LineHeight(1.4f);

                        // DATA
                        col.Item().PaddingBottom(15).AlignCenter()
                            .Text($"Nova Odessa, aos {dataExtenso}")
                            .FontSize(9);

                        // ASSINATURAS
                        col.Item().Row(row =>
                        {
                            // Coluna Locadora
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text("Locadora").FontSize(9);
                                c.Item().PaddingTop(40).BorderTop(0.5f).BorderColor(Colors.Black)
                                    .Text(DadosEmpresa.RazaoSocial).FontSize(7.8f);
                            });

                            row.ConstantItem(40);

                            // Coluna Locatário
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text("Locatário:").FontSize(9);
                                c.Item().PaddingTop(2).Text(pedido.NomeCliente).FontSize(9);
                                c.Item().PaddingTop(2).Text($"CNPJ/CPF: {pedido.DocumentoCliente}").FontSize(9);
                                c.Item().PaddingTop(20).BorderTop(0.5f).BorderColor(Colors.Black)
                                    .Text("Assinatura do Locatário").FontSize(8);
                            });
                        });
                    });
                });
            })
            .GeneratePdf(caminhoArquivo);
        }
       
        public static void ImprimirDireto(DadosPedidoImpressao pedido)
        {
            try
            {
                string caminhoTemp = Path.Combine(
                    Path.GetTempPath(),
                    $"Contrato_{pedido.NumeroPedido}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                GerarPDF(pedido, caminhoTemp);

                using var documento = PdfiumViewer.PdfDocument.Load(caminhoTemp);
                using var impressora = new PrintDocument();

                impressora.PrinterSettings.PrinterName = impressora.PrinterSettings.PrinterName; // impressora padrão
                impressora.DefaultPageSettings.Landscape = false;

                int paginaAtual = 0;

                impressora.PrintPage += (s, e) =>
                {
                    var imagem = documento.Render(
                        paginaAtual,
                        (int)e.PageBounds.Width,
                        (int)e.PageBounds.Height,
                        96, 96,
                        false);

                    e.Graphics.DrawImage(imagem, e.PageBounds);
                    paginaAtual++;
                    e.HasMorePages = paginaAtual < documento.PageCount;
                };

                impressora.Print();

                MessageBox.Show("Contrato enviado para a impressora!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao imprimir:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void VisualizarPDF(DadosPedidoImpressao pedido)
        {
            try
            {
                string caminhoTemp = Path.Combine(
                    Path.GetTempPath(),
                    $"Contrato_{pedido.NumeroPedido}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
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
                MessageBox.Show($"Erro ao visualizar contrato:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool SalvarComDialogo(DadosPedidoImpressao pedido, out string caminhoSalvo)
        {
            caminhoSalvo = string.Empty;

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Arquivo PDF|*.pdf",
                Title = "Salvar Contrato em PDF",
                FileName = $"Contrato_{pedido.NumeroPedido}.pdf",
                DefaultExt = "pdf"
            };

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
                    MessageBox.Show($"Erro ao salvar contrato:\n{ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }
    }
}