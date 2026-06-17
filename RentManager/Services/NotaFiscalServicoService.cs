using RentManager.Models;
using RentManager.Utils;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace RentManager.Services
{
    public static class NotaFiscalServicoService
    {

        public static DadosNotaFiscalServico MontarDados(
            DadosPedidoImpressao pedido,
            int numeroNota,
            string descricaoServico)
        {
            return new DadosNotaFiscalServico
            {
                // Emissora
                EmpresaNome = DadosEmpresa.RazaoSocial,
                EmpresaCNPJ = DadosEmpresa.CNPJ,
                EmpresaRua = DadosEmpresa.Rua,
                EmpresaNumero = DadosEmpresa.Numero,
                EmpresaBairro = DadosEmpresa.Bairro,
                EmpresaCidade = DadosEmpresa.Cidade,
                EmpresaUF = DadosEmpresa.UF,
                EmpresaCEP = DadosEmpresa.CEP,
                EmpresaTelefone = DadosEmpresa.Telefone,
                EmpresaEmail = DadosEmpresa.EmpresaEmail,
                LogoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "LogoSemfundoBrancoRedimencionado.png"),

                // Identificação
                NumeroNota = numeroNota,
                DataEmissao = DateTime.Now,
                NumeroPedido = pedido.NumeroPedido,
                DataServico = pedido.DataEntrega,
                DataRetirada = pedido.DataRetirada,

                // Tomador
                ClienteNome = pedido.NomeCliente,
                ClienteDocumento = pedido.DocumentoCliente,
                ClienteRua = pedido.EnderecoRua,
                ClienteNumero = pedido.EnderecoNumero,
                ClienteBairro = pedido.Bairro,
                ClienteCidade = pedido.Cidade,
                ClienteUF = pedido.UF,
                ClienteCEP = pedido.CEP,
                ClienteTelefone = pedido.OutrosContatos.FirstOrDefault()?.Telefone
                  ?? pedido.ContatoNumero
                  ?? string.Empty,

                // Serviço
                DescricaoServico = descricaoServico,
                ValorServico = pedido.SubTotal,
                Desconto = pedido.Desconto,
                Acrescimo = pedido.Acrescimo,
                ValorTotal = pedido.ValorTotal,
                Pagamentos = pedido.Pagamentos
            };
        }

        public static void VisualizarPDF(DadosNotaFiscalServico dados)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            string tempPath = Path.Combine(Path.GetTempPath(), $"NFS_{dados.NumeroNota}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
            GerarPDF(dados, tempPath);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = tempPath,
                UseShellExecute = true
            });
        }

        public static bool SalvarComDialogo(DadosNotaFiscalServico dados, out string caminhoSalvo)
        {
            caminhoSalvo = string.Empty;

            using var dialog = new SaveFileDialog
            {
                Title = "Salvar Nota Fiscal de Serviço",
                Filter = "PDF|*.pdf",
                FileName = $"NFS_{dados.NumeroNota}_{dados.ClienteNome}"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return false;

            GerarPDF(dados, dialog.FileName);
            caminhoSalvo = dialog.FileName;
            return true;
        }
        private static void GerarPDF(DadosNotaFiscalServico d, string destino)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(35);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

                    page.Content().Column(col =>
                    {
                        // ── VIA DA EMPRESA ─────────────────────────────────
                        AdicionarVia(col, d, "VIA DA EMPRESA", assinaturaLabel: "Assinatura do Cliente", assinaturaNome: d.ClienteNome);

                        // ── LINHA SEPARADORA ───────────────────────────────
                        col.Item().PaddingVertical(8).Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().LineHorizontal(1).LineColor("#999999");

                            });
                        });

                        // ── VIA DO CLIENTE ─────────────────────────────────
                        AdicionarVia(col, d, "VIA DO CLIENTE", assinaturaLabel: "Assinatura da Empresa", assinaturaNome: d.EmpresaNome);
                    });
                });
            }).GeneratePdf(destino);
        }

        private static void AdicionarVia(ColumnDescriptor col, DadosNotaFiscalServico d, string labelVia, string assinaturaLabel, string assinaturaNome)
        {
            // ── LABEL DA VIA (pequeno, à direita) + RECIBO FISCAL ─────────
            col.Item().Row(row =>
            {
                row.RelativeItem().AlignMiddle()
                    .Text("RECIBO FISCAL")
                    .Bold().FontSize(12);

                row.AutoItem().AlignBottom()
                    .Text(labelVia)
                    .FontSize(7.5f).FontColor(Colors.Grey.Medium);
            });

            col.Item().PaddingBottom(4).LineHorizontal(0.5f).LineColor("#333333");

            col.Item().Height(4);

            // ── CABEÇALHO ──────────────────────────────────────────────────
            col.Item().Border(1).BorderColor("#cccccc").Padding(7).Row(header =>
            {
                // Logo
                if (File.Exists(d.LogoPath))
                    header.RelativeItem(2).AlignCenter().Height(60).Image(d.LogoPath);
                else
                    header.RelativeItem(2).AlignMiddle()
                        .Text(d.EmpresaNome).Bold().FontSize(12);

                // Dados da empresa
                header.RelativeItem(3).Column(emp =>
                {
                    emp.Item().Text(d.EmpresaNome).Bold().FontSize(10);
                    emp.Item().Text($"CNPJ: {d.EmpresaCNPJ}").FontSize(7.5f);
                    emp.Item().Text($"{d.EmpresaRua}, {d.EmpresaNumero} – {d.EmpresaBairro}").FontSize(8);
                    emp.Item().Text($"{d.EmpresaCidade}/{d.EmpresaUF} – CEP: {d.EmpresaCEP}").FontSize(8);
                    emp.Item().Text($"Tel: {d.EmpresaTelefone}  |  {d.EmpresaEmail}").FontSize(8);
                });

                // Número e data
                header.RelativeItem(2).AlignRight().Column(num =>
                {
                    num.Item().Text("RECIBO FISCAL DE SERVIÇO")
                        .Bold().FontSize(8).AlignRight();
                    num.Item().PaddingTop(3).Text($"Nº {d.NumeroNota:D6}").Bold().FontSize(12).AlignRight();
                    num.Item().Text($"Emissão: {d.DataEmissao:dd/MM/yyyy HH:mm}").FontSize(8).AlignRight();
                    num.Item().PaddingTop(2).Text($"Pedido Ref.: #{d.NumeroPedido}").FontSize(8).AlignRight();
                });
            });

            col.Item().Height(5);

            // ── TOMADOR ────────────────────────────────────────────────────
            col.Item().PaddingBottom(2).Text("DADOS DO TOMADOR").Bold().FontSize(8);
            col.Item().PaddingBottom(4).LineHorizontal(0.5f).LineColor("#cccccc");

            col.Item().Border(1).BorderColor("#cccccc").Padding(6).Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text(txt => { txt.Span("Nome/Razão Social: ").Bold(); txt.Span(d.ClienteNome); });
                    c.Item().Text(txt => { txt.Span("CPF/CNPJ: ").Bold(); txt.Span(d.ClienteDocumento); });
                    c.Item().Text(txt => { txt.Span("Endereço: ").Bold(); txt.Span($"{d.ClienteRua}, {d.ClienteNumero} – {d.ClienteBairro}"); });
                });
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text(txt => { txt.Span("Cidade/UF: ").Bold(); txt.Span($"{d.ClienteCidade}/{d.ClienteUF}"); });
                    c.Item().Text(txt => { txt.Span("CEP: ").Bold(); txt.Span(d.ClienteCEP); });
                    c.Item().Text(txt => { txt.Span("Telefone: ").Bold(); txt.Span(d.ClienteTelefone); });
                });
            });

            col.Item().Height(5);

            // ── DISCRIMINAÇÃO DO SERVIÇO ───────────────────────────────────
            col.Item().PaddingBottom(2).Text("DISCRIMINAÇÃO DO SERVIÇO").Bold().FontSize(8);
            col.Item().PaddingBottom(4).LineHorizontal(0.5f).LineColor("#cccccc");

            col.Item().Border(1).BorderColor("#cccccc").Padding(6).Column(desc =>
            {
                desc.Item().Text(d.DescricaoServico).FontSize(9);
                desc.Item().Height(4);
               
            });

            col.Item().Height(5);

            // ── VALOR TOTAL ────────────────────────────────────────────────
            col.Item().PaddingBottom(2).Text("VALOR DO SERVIÇO").Bold().FontSize(8);
            col.Item().PaddingBottom(4).LineHorizontal(0.5f).LineColor("#cccccc");

            col.Item().Border(1).BorderColor("#cccccc").Padding(8).Row(r =>
            {
                r.RelativeItem().Text("VALOR TOTAL DO SERVIÇO:").Bold().FontSize(11);
                r.AutoItem().Text(d.ValorTotal.ToString("C2")).Bold().FontSize(11);
            });

            col.Item().Height(8);

            // ── ASSINATURA (apenas uma por via) ────────────────────────────
            col.Item().Row(row =>
            {
                row.RelativeItem();

                row.ConstantItem(380).Row(inner =>
                {
                    // Data alinhada com a linha de assinatura
                    inner.ConstantItem(170).PaddingTop(13)
                        .Text("Data de Recebimento: ____/____/________").FontSize(8);

                    inner.ConstantItem(10);

                    // Assinatura
                    inner.RelativeItem().Column(c =>
                    {
                        c.Item().PaddingTop(20).LineHorizontal(1).LineColor("#333333");
                        c.Item().PaddingTop(3).Text(assinaturaLabel).FontSize(8).AlignCenter();
                        c.Item().Text(assinaturaNome).FontSize(7).FontColor(Colors.Grey.Medium).AlignCenter();
                    });
                });

                row.RelativeItem();
            });

            col.Item().Height(5);

            // ── RODAPÉ ─────────────────────────────────────────────────────
            col.Item().LineHorizontal(1).LineColor("#333333");
            col.Item().PaddingTop(3).Text(
                "Desobrigado de emitir Nota Fiscal por não haver incidência de ISS sobre Locação de Acordo com a LEI COMPLEMENTAR Nº 116/2003")
                .Bold().FontSize(8).FontColor(Colors.Black).AlignCenter();
        }
        private static void CelulaHeader(TableDescriptor table, string texto)
        {
            table.Cell().Background("#2d2d44").Padding(5)
                .Text(texto).Bold().FontSize(8).FontColor(Colors.White).AlignCenter();
        }

        private static void CelulaBody(TableDescriptor table, string texto, string bg)
        {
            table.Cell().Background(bg).Padding(5)
                .Text(texto).FontSize(8).AlignCenter();
        }
    }
}