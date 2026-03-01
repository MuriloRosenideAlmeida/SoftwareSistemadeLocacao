using EstruturaFesta.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EstruturaFesta.Services
{
    public static class NotaFiscalServicoService
    {
        // ============================================================
        // DADOS FIXOS DA EMPRESA — edite aqui
        // ============================================================
        private const string EmpresaNome = "ESTRUTURA FESTA LTDA";
        private const string EmpresaCNPJ = "00.000.000/0001-00";
        private const string EmpresaRua = "Rua das Festas";
        private const string EmpresaNumero = "100";
        private const string EmpresaBairro = "Centro";
        private const string EmpresaCidade = "Sua Cidade";
        private const string EmpresaUF = "SP";
        private const string EmpresaCEP = "00000-000";
        private const string EmpresaTelefone = "(00) 00000-0000";
        private const string EmpresaEmail = "contato@estruturafesta.com.br";
        private const string LogoPath = @"Assets\logo.png"; // coloque sua logo aqui
        // ============================================================

        public static DadosNotaFiscalServico MontarDados(
            DadosPedidoImpressao pedido,
            int numeroNota,
            string descricaoServico)
        {
            return new DadosNotaFiscalServico
            {
                // Emissora
                EmpresaNome = EmpresaNome,
                EmpresaCNPJ = EmpresaCNPJ,
                EmpresaRua = EmpresaRua,
                EmpresaNumero = EmpresaNumero,
                EmpresaBairro = EmpresaBairro,
                EmpresaCidade = EmpresaCidade,
                EmpresaUF = EmpresaUF,
                EmpresaCEP = EmpresaCEP,
                EmpresaTelefone = EmpresaTelefone,
                EmpresaEmail = EmpresaEmail,
                LogoPath = LogoPath,

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
                ClienteTelefone = pedido.ContatoNumero,

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
                                c.Item().PaddingTop(2).Text("✂ ─────────────────────────────────────────────────────────────────────")
                                    .FontSize(7).FontColor(Colors.Grey.Medium).AlignCenter();
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
            // ── FAIXA DA VIA ───────────────────────────────────────────────
            col.Item()
                .Background(labelVia == "VIA DA EMPRESA" ? "#1a1a2e" : "#2e4a1a")
                .Padding(4)
                .Text(labelVia)
                .Bold().FontSize(9).FontColor(Colors.White).AlignCenter();

            col.Item().Height(4);

            // ── CABEÇALHO ──────────────────────────────────────────────────
            col.Item().Border(1).BorderColor("#1a1a2e").Padding(8).Row(header =>
            {
                // Logo
                if (File.Exists(d.LogoPath))
                    header.RelativeItem(2).AlignMiddle().Image(d.LogoPath).FitWidth();
                else
                    header.RelativeItem(2).AlignMiddle()
                        .Text(d.EmpresaNome).Bold().FontSize(12).FontColor("#1a1a2e");

                // Dados da empresa
                header.RelativeItem(3).Column(emp =>
                {
                    emp.Item().Text(d.EmpresaNome).Bold().FontSize(10).FontColor("#1a1a2e");
                    emp.Item().Text($"CNPJ: {d.EmpresaCNPJ}").FontSize(7.5f);
                    emp.Item().Text($"{d.EmpresaRua}, {d.EmpresaNumero} – {d.EmpresaBairro}").FontSize(7.5f);
                    emp.Item().Text($"{d.EmpresaCidade}/{d.EmpresaUF} – CEP: {d.EmpresaCEP}").FontSize(7.5f);
                    emp.Item().Text($"Tel: {d.EmpresaTelefone}  |  {d.EmpresaEmail}").FontSize(7.5f);
                });

                // Número e data
                header.RelativeItem(2).AlignRight().Column(num =>
                {
                    num.Item().Background("#1a1a2e").Padding(5)
                        .Text("NOTA FISCAL DE SERVIÇO")
                        .Bold().FontSize(8).FontColor(Colors.White).AlignCenter();
                    num.Item().PaddingTop(3).Text($"Nº {d.NumeroNota:D6}").Bold().FontSize(12).AlignCenter();
                    num.Item().Text($"Emissão: {d.DataEmissao:dd/MM/yyyy HH:mm}").FontSize(7.5f).AlignCenter();
                    num.Item().PaddingTop(2).Text($"Pedido Ref.: #{d.NumeroPedido}").FontSize(7.5f).AlignCenter();
                });
            });

            col.Item().Height(5);

            // ── TOMADOR ────────────────────────────────────────────────────
            col.Item().Background("#1a1a2e").Padding(3)
                .Text("DADOS DO TOMADOR").Bold().FontSize(8).FontColor(Colors.White);

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
            col.Item().Background("#1a1a2e").Padding(3)
                .Text("DISCRIMINAÇÃO DO SERVIÇO").Bold().FontSize(8).FontColor(Colors.White);

            col.Item().Border(1).BorderColor("#cccccc").Padding(6).Column(desc =>
            {
                desc.Item().Text(d.DescricaoServico).FontSize(9);
                desc.Item().Height(4);
                desc.Item().Text(txt =>
                {
                    txt.Span("Período: ").Bold();
                    txt.Span($"{d.DataServico:dd/MM/yyyy} até {d.DataRetirada:dd/MM/yyyy}");
                });
            });

            col.Item().Height(5);

            // ── VALOR TOTAL ────────────────────────────────────────────────
            col.Item().Background("#1a1a2e").Padding(3)
                .Text("VALOR DO SERVIÇO").Bold().FontSize(8).FontColor(Colors.White);

            col.Item().Border(1).BorderColor("#1a1a2e").Background("#f0f0f0").Padding(8).Row(r =>
            {
                r.RelativeItem().Text("VALOR TOTAL DO SERVIÇO:").Bold().FontSize(11);
                r.AutoItem().Text(d.ValorTotal.ToString("C2")).Bold().FontSize(11).FontColor("#1a1a2e");
            });

            col.Item().Height(8);

            // ── ASSINATURA (apenas uma por via) ────────────────────────────
            col.Item().AlignCenter().Width(200).Column(c =>
            {
                c.Item().PaddingTop(20).LineHorizontal(1).LineColor("#333333");
                c.Item().PaddingTop(3).Text(assinaturaLabel).FontSize(8).AlignCenter();
                c.Item().Text(assinaturaNome).FontSize(7).FontColor(Colors.Grey.Medium).AlignCenter();
            });

            col.Item().Height(5);

            // ── RODAPÉ ─────────────────────────────────────────────────────
            col.Item().LineHorizontal(1).LineColor("#cccccc");
            col.Item().PaddingTop(3).Text(
                "Este documento é um recibo de serviço e não substitui a Nota Fiscal Eletrônica de Serviços (NFS-e) oficial.")
                .FontSize(6.5f).FontColor(Colors.Grey.Medium).AlignCenter();
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