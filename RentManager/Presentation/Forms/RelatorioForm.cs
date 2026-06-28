using RentManager.AppServices.DTOs;
using RentManager.Data;
using RentManager.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RentManager.Presentation.Forms
{
    public partial class RelatorioForm : Form
    {
        // ── Dependências ──────────────────────────────────────────────────────
        private readonly RelatorioService _service;
        private RelatorioDados? _dadosAtuais;

        // ── Controles de filtro ───────────────────────────────────────────────
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFim;
        private Button btnHoje;
        private Button btn7Dias;
        private Button btn30Dias;
        private Button btnEsteMes;
        private Button btnPersonalizado;
        private Button btnAplicar;

        // ── KPI Cards ─────────────────────────────────────────────────────────
        private Panel pnlTotalPedidos;
        private Panel pnlReceitaRecebida;
        private Panel pnlReceitaTotal;
        private Panel pnlClientesAtendidos;
        private Panel pnlCancelados;
        private Panel pnlValorQuebras;

        private Label lblValTotalPedidos;
        private Label lblValReceitaRecebida;
        private Label lblValReceitaTotal;
        private Label lblValClientesAtendidos;
        private Label lblValCancelados;
        private Label lblValorQuebras;

        // ── Gráficos ──────────────────────────────────────────────────────────
        private Chart chartReceita;
        private Chart chartProdutosPizza;
        private Chart chartPagamentosPizza;

        // ── Listagens ─────────────────────────────────────────────────────────
        private Panel pnlTopProdutos;
        private Panel pnlTopClientes;
        private Panel pnlCadastroClientes;

        // ── Layout — posições Y de cada seção ────────────────────────────────
        // KPIs:          y=65   h=80
        // Gráficos pizza: y=155  h=220
        // Gráfico receita:y=385  h=220
        // Tops:          y=615  h=600   (top 20 × 28px + cabeçalho)
        // Cadastro:      y=1225 h=100
        private const int Y_PIZZAS = 385;
        private const int H_PIZZAS = 250;
        private const int Y_RECEITA = 155;
        private const int H_RECEITA = 220;
        private const int Y_TOPS = 645;
        private const int H_TOPS = 610;
        private const int Y_CADASTRO = 1265;

        // ── Construtor ────────────────────────────────────────────────────────
        public RelatorioForm(RentManagerDataBase db)
        {
            _service = new RelatorioService(db);
            InitializeComponents();

            dtpInicio.Value = DateTime.Today.AddDays(-30);
            dtpFim.Value = DateTime.Today;
            CarregarDados();
        }

        // ════════════════════════════════════════════════════════════
        // INICIALIZAÇÃO
        // ════════════════════════════════════════════════════════════
        private void InitializeComponents()
        {
            this.Text = "Relatórios e Dashboard";
            this.Size = new Size(1100, 720);
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Font = new Font("Arial", 9f);
            this.AutoScroll = true;

            CriarBarraFiltros();
            CriarKPICards();
            CriarGraficosPizza();
            CriarGraficoReceita();
            CriarListagens();
            CriarCardCadastroClientes();
        }

        // ════════════════════════════════════════════════════════════
        // BARRA DE FILTROS
        // ════════════════════════════════════════════════════════════
        private void CriarBarraFiltros()
        {
            var pnlFiltro = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(1070, 45),
                BackColor = Color.White
            };

            int x = 10;
            btnHoje = CriarBotaoFiltro("Hoje", ref x);
            btn7Dias = CriarBotaoFiltro("7 dias", ref x);
            btn30Dias = CriarBotaoFiltro("30 dias", ref x);
            btnEsteMes = CriarBotaoFiltro("Este mês", ref x);
            btnPersonalizado = CriarBotaoFiltro("Personalizado", ref x);

            x += 10;

            dtpInicio = new DateTimePicker
            {
                Location = new Point(x, 10),
                Size = new Size(130, 25),
                Format = DateTimePickerFormat.Short,
                Enabled = false
            };
            x += 140;

            var lblAte = new Label { Text = "até", Location = new Point(x, 13), AutoSize = true };
            x += 30;

            dtpFim = new DateTimePicker
            {
                Location = new Point(x, 10),
                Size = new Size(130, 25),
                Format = DateTimePickerFormat.Short,
                Enabled = false
            };
            x += 140;

            btnAplicar = new Button
            {
                Text = "Aplicar",
                Location = new Point(x, 8),
                Size = new Size(70, 28),
                BackColor = Color.FromArgb(46, 125, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Visible = false
            };
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.Click += (s, e) => CarregarDados();

            pnlFiltro.Controls.AddRange(new Control[]
            {
                btnHoje, btn7Dias, btn30Dias, btnEsteMes, btnPersonalizado,
                dtpInicio, lblAte, dtpFim, btnAplicar
            });

            btnHoje.Click += (s, e) => { DefinirPeriodo(DateTime.Today, DateTime.Today); DesabilitarPersonalizado(); };
            btn7Dias.Click += (s, e) => { DefinirPeriodo(DateTime.Today.AddDays(-7), DateTime.Today); DesabilitarPersonalizado(); };
            btn30Dias.Click += (s, e) => { DefinirPeriodo(DateTime.Today.AddDays(-30), DateTime.Today); DesabilitarPersonalizado(); };
            btnEsteMes.Click += (s, e) => { DefinirPeriodo(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), DateTime.Today); DesabilitarPersonalizado(); };
            btnPersonalizado.Click += (s, e) => HabilitarPersonalizado();

            this.Controls.Add(pnlFiltro);
        }

        private Button CriarBotaoFiltro(string texto, ref int x)
        {
            var btn = new Button
            {
                Text = texto,
                Location = new Point(x, 8),
                Size = new Size(90, 28),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(240, 242, 245),
                ForeColor = Color.FromArgb(50, 50, 50),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            x += 100;
            return btn;
        }

        // ════════════════════════════════════════════════════════════
        // KPI CARDS
        // ════════════════════════════════════════════════════════════
        private void CriarKPICards()
        {
            int y = 65;
            int largura = 170;
            int altura = 80;
            int x = 10;

            pnlTotalPedidos = CriarCard("Total de Pedidos", Color.FromArgb(25, 118, 210), ref x, y, largura, altura);
            lblValTotalPedidos = ObterLabelValor(pnlTotalPedidos);

            pnlReceitaRecebida = CriarCard("Receita Recebida", Color.FromArgb(46, 125, 50), ref x, y, largura, altura);
            lblValReceitaRecebida = ObterLabelValor(pnlReceitaRecebida);

            pnlReceitaTotal = CriarCard("Receita Total", Color.FromArgb(2, 136, 209), ref x, y, largura, altura);
            lblValReceitaTotal = ObterLabelValor(pnlReceitaTotal);

            pnlClientesAtendidos = CriarCard("Clientes Atendidos", Color.FromArgb(230, 81, 0), ref x, y, largura, altura);
            lblValClientesAtendidos = ObterLabelValor(pnlClientesAtendidos);

            pnlCancelados = CriarCard("Cancelamentos", Color.FromArgb(198, 40, 40), ref x, y, largura, altura);
            lblValCancelados = ObterLabelValor(pnlCancelados);

            pnlValorQuebras = CriarCard("Valor em Quebras", Color.FromArgb(183, 28, 28), ref x, y, largura, altura);
            lblValorQuebras = ObterLabelValor(pnlValorQuebras);
        }

        private Panel CriarCard(string titulo, Color cor, ref int x, int y, int largura, int altura)
        {
            var panel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(largura, altura),
                BackColor = Color.White
            };

            var barra = new Panel { Dock = DockStyle.Top, Height = 4, BackColor = cor };

            var lblTitulo = new Label
            {
                Text = titulo,
                Location = new Point(10, 12),
                Size = new Size(largura - 15, 18),
                Font = new Font("Arial", 8f),
                ForeColor = Color.FromArgb(120, 120, 120)
            };

            var lblValor = new Label
            {
                Text = "—",
                Location = new Point(10, 35),
                Size = new Size(largura - 15, 30),
                Font = new Font("Arial", 13f, FontStyle.Bold),
                ForeColor = cor,
                Name = "lblValor"
            };

            panel.Controls.AddRange(new Control[] { barra, lblTitulo, lblValor });
            this.Controls.Add(panel);

            x += largura + 10;
            return panel;
        }

        private Label ObterLabelValor(Panel card) =>
            card.Controls.OfType<Label>().First(l => l.Name == "lblValor");

        // ════════════════════════════════════════════════════════════
        // GRÁFICOS PIZZA — linha entre KPIs e gráfico de barras
        // Esquerda: % produtos mais locados (top 10)
        // Direita:  % formas de pagamento
        // ════════════════════════════════════════════════════════════
        private void CriarGraficosPizza()
        {
            // ── Pizza produtos (maior) ────────────────────────────────────────
            chartProdutosPizza = new Chart
            {
                Location = new Point(10, Y_PIZZAS),
                Size = new Size(620, H_PIZZAS),
                BackColor = Color.White
            };

            var areaProd = new ChartArea("areaProd") { BackColor = Color.White };
            chartProdutosPizza.ChartAreas.Add(areaProd);

            var legendProd = new Legend
            {
                Docking = Docking.Right,
                Font = new Font("Arial", 7f),
                IsTextAutoFit = false,
                MaximumAutoSize = 50
            };
            chartProdutosPizza.Legends.Add(legendProd);

            chartProdutosPizza.Titles.Add(new Title
            {
                Text = "Top 10 Produtos — % Recorrência",
                Font = new Font("Arial", 10f, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft,
                ForeColor = Color.FromArgb(60, 60, 60)
            });

            var serieProd = new Series("Produtos")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "#0.0\\%",
                Font = new Font("Arial", 7f),
                LegendText = "#VALX"   // mostra o nome (X) na legenda
            };
            chartProdutosPizza.Series.Add(serieProd);
            this.Controls.Add(chartProdutosPizza);

            // ── Pizza pagamentos (menor) ──────────────────────────────────────
            chartPagamentosPizza = new Chart
            {
                Location = new Point(640, Y_PIZZAS),
                Size = new Size(440, H_PIZZAS),
                BackColor = Color.White
            };

            var areaPag = new ChartArea("areaPag") { BackColor = Color.White };
            chartPagamentosPizza.ChartAreas.Add(areaPag);

            var legendPag = new Legend
            {
                Docking = Docking.Right,
                Font = new Font("Arial", 8f),
                IsTextAutoFit = false,
                MaximumAutoSize = 45
            };
            chartPagamentosPizza.Legends.Add(legendPag);

            chartPagamentosPizza.Titles.Add(new Title
            {
                Text = "Formas de Pagamento — % do Total Recebido",
                Font = new Font("Arial", 10f, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft,
                ForeColor = Color.FromArgb(60, 60, 60)
            });

            var seriePag = new Series("Pagamentos")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "#0.0\\%",
                Font = new Font("Arial", 8f),
                LegendText = "#VALX"   // mostra o nome (X) na legenda
            };
            chartPagamentosPizza.Series.Add(seriePag);
            this.Controls.Add(chartPagamentosPizza);
        }

        // ════════════════════════════════════════════════════════════
        // GRÁFICO DE RECEITA — barras diárias
        // ════════════════════════════════════════════════════════════
        private void CriarGraficoReceita()
        {
            chartReceita = new Chart
            {
                Location = new Point(10, Y_RECEITA),
                Size = new Size(1070, H_RECEITA),
                BackColor = Color.White
            };

            var area = new ChartArea("Area1") { BackColor = Color.White };
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.Font = new Font("Arial", 7f);
            area.AxisY.LabelStyle.Format = "C0";
            chartReceita.ChartAreas.Add(area);

            var legend = new Legend
            {
                Docking = Docking.Top,
                Font = new Font("Arial", 8f),
                IsTextAutoFit = false
            };
            chartReceita.Legends.Add(legend);

            chartReceita.Titles.Add(new Title
            {
                Text = "Receita Recebida por Dia",
                Font = new Font("Arial", 10f, FontStyle.Bold),
                Alignment = ContentAlignment.TopLeft,
                ForeColor = Color.FromArgb(60, 60, 60)
            });

            var serie = new Series("Receita Diária")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(46, 125, 50),
                BorderColor = Color.FromArgb(27, 94, 32),
                BorderWidth = 1,
                XValueMember = "Label",
                YValueMembers = "Valor"
            };
            chartReceita.Series.Add(serie);

            this.Controls.Add(chartReceita);
        }

        // ════════════════════════════════════════════════════════════
        // LISTAGENS — Top 20 Produtos e Top 20 Clientes
        // ════════════════════════════════════════════════════════════
        private void CriarListagens()
        {
            // largura total disponível: 1080 → dividir em ~530 + 530
            int larguraPainel = 530;

            // ── Top 20 Produtos ───────────────────────────────────────────────
            pnlTopProdutos = new Panel
            {
                Location = new Point(10, Y_TOPS),
                Size = new Size(larguraPainel, H_TOPS),
                BackColor = Color.White
            };

            pnlTopProdutos.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(larguraPainel, 4),
                BackColor = Color.FromArgb(25, 118, 210)
            });

            pnlTopProdutos.Controls.Add(new Label
            {
                Text = "Top 20 Produtos — Recorrência e Valor Locado",
                Location = new Point(10, 10),
                Size = new Size(larguraPainel - 20, 20),
                Font = new Font("Arial", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });

            // Cabeçalho das colunas
            pnlTopProdutos.Controls.Add(CriarLabelHeader("#", new Point(0, 34), 25));
            pnlTopProdutos.Controls.Add(CriarLabelHeader("Produto", new Point(30, 34), 250));
            pnlTopProdutos.Controls.Add(CriarLabelHeader("Recorrência", new Point(355, 34), 80, ContentAlignment.MiddleRight));
            pnlTopProdutos.Controls.Add(CriarLabelHeader("Valor Total", new Point(390, 34), 130, ContentAlignment.MiddleRight));

            this.Controls.Add(pnlTopProdutos);

            // ── Top 20 Clientes ───────────────────────────────────────────────
            pnlTopClientes = new Panel
            {
                Location = new Point(550, Y_TOPS),
                Size = new Size(larguraPainel, H_TOPS),
                BackColor = Color.White
            };

            pnlTopClientes.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(larguraPainel, 4),
                BackColor = Color.FromArgb(123, 31, 162)
            });

            pnlTopClientes.Controls.Add(new Label
            {
                Text = "Top 20 Clientes — Pedidos no Período",
                Location = new Point(10, 10),
                Size = new Size(larguraPainel - 20, 20),
                Font = new Font("Arial", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });

            // Cabeçalho das colunas
            pnlTopClientes.Controls.Add(CriarLabelHeader("#", new Point(0, 34), 25));
            pnlTopClientes.Controls.Add(CriarLabelHeader("Cliente", new Point(30, 34), 250));
            pnlTopClientes.Controls.Add(CriarLabelHeader("Pedidos", new Point(285, 34), 100, ContentAlignment.MiddleRight));
            pnlTopClientes.Controls.Add(CriarLabelHeader("Valor Pago", new Point(390, 34), 130, ContentAlignment.MiddleRight));

            this.Controls.Add(pnlTopClientes);
        }

        private Label CriarLabelHeader(string texto, Point loc, int width,
            ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            return new Label
            {
                Text = texto,
                Location = loc,
                Size = new Size(width, 18),
                Font = new Font("Arial", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 80),
                TextAlign = align
            };
        }

        // ════════════════════════════════════════════════════════════
        // CARD CADASTRO DE CLIENTES
        // ════════════════════════════════════════════════════════════
        private void CriarCardCadastroClientes()
        {
            pnlCadastroClientes = new Panel
            {
                Location = new Point(10, Y_CADASTRO),
                Size = new Size(1070, 100),
                BackColor = Color.White
            };

            pnlCadastroClientes.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1070, 4),
                BackColor = Color.FromArgb(230, 81, 0)
            });

            pnlCadastroClientes.Controls.Add(new Label
            {
                Text = "Crescimento de Clientes no Período",
                Location = new Point(10, 10),
                Size = new Size(500, 20),
                Font = new Font("Arial", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });

            pnlCadastroClientes.Controls.Add(new Label
            {
                Text = "Início do período",
                Location = new Point(10, 35),
                Size = new Size(200, 16),
                Font = new Font("Arial", 8f),
                ForeColor = Color.FromArgb(120, 120, 120)
            });

            pnlCadastroClientes.Controls.Add(new Label
            {
                Text = "—",
                Location = new Point(10, 52),
                Size = new Size(200, 24),
                Font = new Font("Arial", 14f, FontStyle.Bold),
                ForeColor = Color.FromArgb(230, 81, 0),
                Name = "lblClientesInicio"
            });

            pnlCadastroClientes.Controls.Add(new Label
            {
                Text = "Fim do período",
                Location = new Point(220, 35),
                Size = new Size(200, 16),
                Font = new Font("Arial", 8f),
                ForeColor = Color.FromArgb(120, 120, 120)
            });

            pnlCadastroClientes.Controls.Add(new Label
            {
                Text = "—",
                Location = new Point(220, 52),
                Size = new Size(200, 24),
                Font = new Font("Arial", 14f, FontStyle.Bold),
                ForeColor = Color.FromArgb(230, 81, 0),
                Name = "lblClientesFim"
            });

            pnlCadastroClientes.Controls.Add(new Label
            {
                Text = "Cadastro de: — clientes",
                Location = new Point(430, 52),
                Size = new Size(400, 24),
                Font = new Font("Arial", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 125, 50),
                Name = "lblCadastroFrase"
            });

            this.Controls.Add(pnlCadastroClientes);
        }

        // ════════════════════════════════════════════════════════════
        // CARREGAMENTO DE DADOS
        // ════════════════════════════════════════════════════════════
        private void CarregarDados()
        {
            try
            {
                var novosDados = _service.CarregarDados(dtpInicio.Value, dtpFim.Value, _dadosAtuais);
                if (novosDados == null) return;

                _dadosAtuais = novosDados;
                AtualizarKPICards();
                AtualizarGraficosPizza();
                AtualizarGraficoReceita();
                AtualizarListagens();
                AtualizarCardCadastroClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar relatório:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarKPICards()
        {
            var k = _dadosAtuais!.KPIs;
            lblValTotalPedidos.Text = k.TotalPedidos.ToString("N0");
            lblValReceitaRecebida.Text = k.ReceitaRecebida.ToString("C2");
            lblValReceitaTotal.Text = k.ReceitaTotal.ToString("C2");
            lblValClientesAtendidos.Text = k.ClientesAtendidos.ToString("N0");
            lblValCancelados.Text = k.PedidosCancelados.ToString("N0");
            lblValorQuebras.Text = k.TotalValorQuebras.ToString("C2");
        }

        // ════════════════════════════════════════════════════════════
        // ATUALIZAR GRÁFICOS PIZZA
        // ════════════════════════════════════════════════════════════
        private void AtualizarGraficosPizza()
        {
            // ── Pizza produtos (top 10 por recorrência) ───────────────────────
            var serieProd = chartProdutosPizza.Series["Produtos"];
            serieProd.Points.Clear();

            var top10Prod = _dadosAtuais!.TopProdutos.Take(10).ToList();
            double totalRecorrencia = top10Prod.Sum(p => p.PedidosDistintos);
            if (totalRecorrencia == 0) totalRecorrencia = 1;

            foreach (var p in top10Prod)
            {
                double pct = Math.Round(p.PedidosDistintos / totalRecorrencia * 100, 1);
                // Nome encurtado para caber na legenda
                int idx = serieProd.Points.AddXY(p.Nome, pct);
                serieProd.Points[idx].Label = $"{pct:0.0}%";
            }

            // ── Pizza pagamentos ──────────────────────────────────────────────
            var seriePag = chartPagamentosPizza.Series["Pagamentos"];
            seriePag.Points.Clear();

            foreach (var t in _dadosAtuais.TiposPagamento)
            {
                int idx = seriePag.Points.AddXY(t.Forma, t.Porcentagem);
                seriePag.Points[idx].Label = $"{t.Porcentagem:0.0}%";
            }
        }

        // ════════════════════════════════════════════════════════════
        // ATUALIZAR GRÁFICO DE RECEITA (barras diárias)
        // ════════════════════════════════════════════════════════════
        private void AtualizarGraficoReceita()
        {
            var serie = chartReceita.Series["Receita Diária"];
            serie.Points.Clear();

            foreach (var ponto in _dadosAtuais!.ReceitaPorPeriodo)
            {
                int idx = serie.Points.AddXY(ponto.Label, ponto.Valor);
                serie.Points[idx].ToolTip = $"{ponto.Label}: {ponto.Valor:C2}";
            }
        }

        // ════════════════════════════════════════════════════════════
        // ATUALIZAR LISTAGENS
        // ════════════════════════════════════════════════════════════
        private void AtualizarListagens()
        {
            // ── Limpa itens antigos ───────────────────────────────────────────
            RemoverControlesPorNome(pnlTopProdutos, "itemProduto");
            RemoverControlesPorNome(pnlTopClientes, "itemCliente");

            // ── Top 20 Produtos ───────────────────────────────────────────────
            int yItem = 56;   // abaixo do cabeçalho de colunas
            int posicao = 1;
            foreach (var produto in _dadosAtuais!.TopProdutos)
            {
                var corBg = posicao % 2 == 0
                    ? Color.FromArgb(245, 247, 250)
                    : Color.White;

                var linha = new Panel
                {
                    Location = new Point(10, yItem),
                    Size = new Size(510, 26),
                    BackColor = corBg,
                    Name = "itemProduto"
                };

                linha.Controls.Add(new Label
                {
                    Text = $"{posicao}º",
                    Location = new Point(0, 5),
                    Size = new Size(25, 18),
                    Font = new Font("Arial", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(25, 118, 210)
                });

                // Nome encurtado
                string nome = produto.Nome.Length > 35 ? produto.Nome[..35] + "…" : produto.Nome;
                linha.Controls.Add(new Label
                {
                    Text = nome,
                    Location = new Point(28, 5),
                    Size = new Size(255, 18),
                    Font = new Font("Arial", 8.5f),
                    ForeColor = Color.FromArgb(50, 50, 50)
                });

                // Recorrência
                linha.Controls.Add(new Label
                {
                    Text = $"{produto.PedidosDistintos}x",
                    Location = new Point(285, 5),
                    Size = new Size(110, 18),
                    Font = new Font("Arial", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(25, 118, 210),
                    TextAlign = ContentAlignment.MiddleRight
                });

                // Valor total locado
                linha.Controls.Add(new Label
                {
                    Text = produto.ValorTotalLocado.ToString("C2"),
                    Location = new Point(400, 5),
                    Size = new Size(105, 18),
                    Font = new Font("Arial", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(46, 125, 50),
                    TextAlign = ContentAlignment.MiddleRight
                });

                pnlTopProdutos.Controls.Add(linha);
                yItem += 28;
                posicao++;
            }

            // ── Top 20 Clientes ───────────────────────────────────────────────
            yItem = 56;
            posicao = 1;
            foreach (var cliente in _dadosAtuais.TopClientes)
            {
                var corBg = posicao % 2 == 0
                    ? Color.FromArgb(245, 247, 250)
                    : Color.White;

                var linha = new Panel
                {
                    Location = new Point(10, yItem),
                    Size = new Size(510, 26),
                    BackColor = corBg,
                    Name = "itemCliente"
                };

                linha.Controls.Add(new Label
                {
                    Text = $"{posicao}º",
                    Location = new Point(0, 5),
                    Size = new Size(25, 18),
                    Font = new Font("Arial", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(123, 31, 162)
                });

                string nome = cliente.Nome.Length > 35 ? cliente.Nome[..35] + "…" : cliente.Nome;
                linha.Controls.Add(new Label
                {
                    Text = nome,
                    Location = new Point(28, 5),
                    Size = new Size(255, 18),
                    Font = new Font("Arial", 8.5f),
                    ForeColor = Color.FromArgb(50, 50, 50)
                });

                // Número de pedidos
                linha.Controls.Add(new Label
                {
                    Text = $"{cliente.NumeroPedidos} pedidos",
                    Location = new Point(285, 5),
                    Size = new Size(110, 18),
                    Font = new Font("Arial", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(123, 31, 162),
                    TextAlign = ContentAlignment.MiddleRight
                });

                // Valor pago
                linha.Controls.Add(new Label
                {
                    Text = cliente.ValorTotalGasto.ToString("C2"),
                    Location = new Point(400, 5),
                    Size = new Size(105, 18),
                    Font = new Font("Arial", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(46, 125, 50),
                    TextAlign = ContentAlignment.MiddleRight
                });

                pnlTopClientes.Controls.Add(linha);
                yItem += 28;
                posicao++;
            }
        }

        private void RemoverControlesPorNome(Panel painel, string nome)
        {
            var lista = painel.Controls.OfType<Control>()
                .Where(c => c.Name == nome).ToList();
            foreach (var c in lista)
                painel.Controls.Remove(c);
        }

        private void AtualizarCardCadastroClientes()
        {
            var k = _dadosAtuais!.KPIs;

            pnlCadastroClientes.Controls.OfType<Label>()
                .First(l => l.Name == "lblClientesInicio").Text = k.ClientesNoInicio.ToString("N0");

            pnlCadastroClientes.Controls.OfType<Label>()
                .First(l => l.Name == "lblClientesFim").Text = k.ClientesNoFim.ToString("N0");

            int novosClientes = k.ClientesNoFim - k.ClientesNoInicio;
            pnlCadastroClientes.Controls.OfType<Label>()
                .First(l => l.Name == "lblCadastroFrase").Text =
                $"Sua Empresa Atendeu: {novosClientes} Novos Clientes";
        }

        // ════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════
        private void DefinirPeriodo(DateTime inicio, DateTime fim)
        {
            dtpInicio.Value = inicio;
            dtpFim.Value = fim;
            CarregarDados();
        }

        private void DesabilitarPersonalizado()
        {
            dtpInicio.Enabled = false;
            dtpFim.Enabled = false;
            btnAplicar.Visible = false;
        }

        private void HabilitarPersonalizado()
        {
            dtpInicio.Enabled = true;
            dtpFim.Enabled = true;
            btnAplicar.Visible = true;
        }
    }
}