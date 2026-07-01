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
        // ── Comparações ───────────────────────────────────────────────────────────
        private Panel pnlComparacoes;
        private Panel pnlResultadoComparacoes;
        private readonly List<ComparacaoPeriodo> _comparacoesAtivas = new();
        private readonly List<CheckBox> _checkboxesComparacao = new();
        private readonly Color[] _coresComparacao = new[]
        {
            Color.FromArgb(214, 39, 40),    // vermelho
            Color.FromArgb(255, 127, 14),   // laranja
            Color.FromArgb(148, 103, 189),  // roxo
            Color.FromArgb(23, 190, 207),   // ciano
            Color.FromArgb(188, 189, 34),   // amarelo-verde
        };

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
        private const int Y_TOPS = 725;
        private const int H_TOPS = 610;
        private const int Y_COMPARACOES = 645;
        private const int H_COMPARACOES = 70;
        private const int Y_CADASTRO = 1345;

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
            CriarPainelComparacoes();
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
            area.AxisX.Interval = 1;
            area.AxisX.IsMarginVisible = false;

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
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(120, 46, 125, 50),
                BorderColor = Color.FromArgb(27, 94, 32),
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                IsXValueIndexed = true
            };
            chartReceita.Series.Add(serie);

            this.Controls.Add(chartReceita);
        }
        // ════════════════════════════════════════════════════════════
        // PAINEL DE COMPARAÇÕES (abaixo do gráfico de receita)
        // ════════════════════════════════════════════════════════════
        private void CriarPainelComparacoes()
        {
            // ── Painel esquerdo: checkboxes ───────────────────────────────────────
            pnlComparacoes = new Panel
            {
                Location = new Point(10, Y_COMPARACOES),
                Size = new Size(520, H_COMPARACOES),
                BackColor = Color.White
            };
            pnlComparacoes.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(520, 3),
                BackColor = Color.FromArgb(27, 94, 32)
            });
            pnlComparacoes.Controls.Add(new Label
            {
                Text = "Comparar com períodos anteriores",
                Location = new Point(10, 8),
                Size = new Size(320, 16),
                Font = new Font("Arial", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });

            var btnPersonalizada = new Button
            {
                Text = "+ Personalizada",
                Location = new Point(355, 5),
                Size = new Size(110, 22),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(25, 118, 210),
                ForeColor = Color.White,
                Font = new Font("Arial", 7.5f),
                Cursor = Cursors.Hand
            };
            btnPersonalizada.FlatAppearance.BorderSize = 0;
            btnPersonalizada.Click += BtnComparacaoPersonalizada_Click;
            pnlComparacoes.Controls.Add(btnPersonalizada);

            // Os checkboxes são criados dinamicamente em AtualizarCheckboxesComparacao
            this.Controls.Add(pnlComparacoes);

            // ── Painel direito: resultado percentual ──────────────────────────────
            pnlResultadoComparacoes = new Panel
            {
                Location = new Point(540, Y_COMPARACOES),
                Size = new Size(540, H_COMPARACOES),
                BackColor = Color.White
            };
            pnlResultadoComparacoes.Controls.Add(new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(540, 3),
                BackColor = Color.FromArgb(27, 94, 32)
            });
            pnlResultadoComparacoes.Controls.Add(new Label
            {
                Text = "Crescimento vs períodos selecionados",
                Location = new Point(10, 8),
                Size = new Size(380, 16),
                Font = new Font("Arial", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });
            this.Controls.Add(pnlResultadoComparacoes);
        }

        private void AtualizarCheckboxesComparacao()
        {
            if (_dadosAtuais == null) return;

            // Remove checkboxes antigos (mantém label e botão)
            foreach (var cb in _checkboxesComparacao)
                pnlComparacoes.Controls.Remove(cb);
            _checkboxesComparacao.Clear();

            DateTime inicio = _dadosAtuais.DataInicio;
            DateTime fim = _dadosAtuais.DataFim;

            // Gera os 3 anos anteriores com o mesmo intervalo
            var candidatos = new List<(string Nome, DateTime Ini, DateTime Fi)>();
            for (int anosAtras = 1; anosAtras <= 3; anosAtras++)
            {
                var ini = inicio.AddYears(-anosAtras);
                var fi = fim.AddYears(-anosAtras);
                // Label: se for o mesmo mês/ano, usa "Mês/Ano", senão usa datas
                string nome;
                if (inicio.Month == fim.Month && inicio.Year == fim.Year)
                    nome = ini.ToString("MMMM/yyyy",
                        System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                else
                    nome = $"{ini:dd/MM/yy} – {fi:dd/MM/yy}";
                candidatos.Add((nome, ini, fi));
            }

            int x = 10;
            int y = 28;
            int corIdx = 0;

            foreach (var (nome, ini, fi) in candidatos)
            {
                var cor = _coresComparacao[corIdx % _coresComparacao.Length];
                var cb = new CheckBox
                {
                    Text = nome,
                    Location = new Point(x, y),
                    Size = new Size(160, 20),
                    Font = new Font("Arial", 8f),
                    ForeColor = cor,
                    Cursor = Cursors.Hand,
                    Tag = (ini, fi, nome, corIdx)   // guarda metadados
                };
                cb.CheckedChanged += CheckboxComparacao_Changed;
                pnlComparacoes.Controls.Add(cb);
                _checkboxesComparacao.Add(cb);
                x += 165;
                corIdx++;
            }

            // Adiciona checkboxes personalizados (que sobrevivem à troca de período)
            foreach (var comp in _comparacoesAtivas.Where(c => c.EhPersonalizada))
            {
                var cor = _coresComparacao[corIdx % _coresComparacao.Length];
                var cb = new CheckBox
                {
                    Text = comp.Nome,
                    Location = new Point(x, y),
                    Size = new Size(155, 20),
                    Font = new Font("Arial", 8f),
                    ForeColor = cor,
                    Cursor = Cursors.Hand,
                    Checked = true,   // já estava ativa
                    Tag = (comp.Inicio, comp.Fim, comp.Nome, corIdx)
                };
                cb.CheckedChanged += CheckboxComparacao_Changed;
                pnlComparacoes.Controls.Add(cb);
                _checkboxesComparacao.Add(cb);
                x += 160;
                corIdx++;
            }
        }

        private void CheckboxComparacao_Changed(object sender, EventArgs e)
        {
            if (sender is not CheckBox cb) return;
            var (ini, fi, nome, corIdx) = ((DateTime, DateTime, string, int))cb.Tag;

            if (cb.Checked)
            {
                // Carrega e adiciona se não existe ainda
                if (!_comparacoesAtivas.Any(c => c.Nome == nome))
                {
                    var comp = _service.CarregarComparacao(
                        _dadosAtuais!.DataInicio, _dadosAtuais.DataFim,
                        ini, fi, nome);
                    comp.EhPersonalizada = false;
                    _comparacoesAtivas.Add(comp);
                }
            }
            else
            {
                _comparacoesAtivas.RemoveAll(c => c.Nome == nome && !c.EhPersonalizada);
            }

            AtualizarGraficoReceita();
            AtualizarResultadoComparacoes();
        }

        private void BtnComparacaoPersonalizada_Click(object sender, EventArgs e)
        {
            using var form = new Form
            {
                Text = "Nova Comparação Personalizada",
                Size = new Size(360, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            form.Controls.Add(new Label { Text = "Nome:", Location = new Point(15, 18), AutoSize = true });
            var txtNome = new TextBox { Location = new Point(80, 15), Size = new Size(255, 22) };
            form.Controls.Add(txtNome);

            form.Controls.Add(new Label { Text = "De:", Location = new Point(15, 55), AutoSize = true });
            var dtpDe = new DateTimePicker { Location = new Point(80, 52), Size = new Size(130, 22), Format = DateTimePickerFormat.Short };
            form.Controls.Add(dtpDe);

            form.Controls.Add(new Label { Text = "Até:", Location = new Point(15, 90), AutoSize = true });
            var dtpAte = new DateTimePicker { Location = new Point(80, 87), Size = new Size(130, 22), Format = DateTimePickerFormat.Short };
            form.Controls.Add(dtpAte);

            var btnOk = new Button
            {
                Text = "Adicionar",
                Location = new Point(190, 130),
                Size = new Size(90, 28),
                BackColor = Color.FromArgb(46, 125, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;
            form.Controls.Add(btnOk);
            form.AcceptButton = btnOk;

            if (form.ShowDialog(this) != DialogResult.OK) return;

            string nome = txtNome.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome)) nome = $"{dtpDe.Value:dd/MM/yy}–{dtpAte.Value:dd/MM/yy}";

            var comp = _service.CarregarComparacao(
                _dadosAtuais!.DataInicio, _dadosAtuais.DataFim,
                dtpDe.Value.Date, dtpAte.Value.Date, nome);
            comp.EhPersonalizada = true;
            _comparacoesAtivas.Add(comp);

            AtualizarCheckboxesComparacao();
            AtualizarGraficoReceita();
            AtualizarResultadoComparacoes();
        }

        private void AtualizarResultadoComparacoes()
        {
            // Remove labels antigos (mantém apenas os 2 primeiros controles: barra + título)
            var paraRemover = pnlResultadoComparacoes.Controls
                .OfType<Label>()
                .Where(l => l.Name == "lblComp")
                .ToList();
            foreach (var l in paraRemover)
                pnlResultadoComparacoes.Controls.Remove(l);

            if (!_comparacoesAtivas.Any()) return;

            decimal receitaAtual = _dadosAtuais!.KPIs.ReceitaRecebida;
            int x = 10;
            int y = 28;
            int corIdx = 0;

            foreach (var comp in _comparacoesAtivas)
            {
                decimal varPct = comp.ReceitaTotal == 0
                    ? (receitaAtual > 0 ? 100m : 0m)
                    : Math.Round((receitaAtual - comp.ReceitaTotal) / comp.ReceitaTotal * 100, 2);

                string seta = varPct >= 0 ? "▲" : "▼";
                string sinal = varPct >= 0 ? "+" : "";
                Color cor = varPct >= 0
                    ? Color.FromArgb(46, 125, 50)
                    : Color.FromArgb(198, 40, 40);

                var lbl = new Label
                {
                    Text = $"{seta} {sinal}{varPct:N2}% vs {comp.Nome}",
                    Location = new Point(x, y),
                    Size = new Size(260, 20),
                    Font = new Font("Arial", 9f, FontStyle.Bold),
                    ForeColor = cor,
                    Name = "lblComp",
                    AutoSize = false
                };
                pnlResultadoComparacoes.Controls.Add(lbl);
                y += 22;
                corIdx++;
            }
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

                // Limpa comparações não-personalizadas ao trocar o período
                _comparacoesAtivas.RemoveAll(c => !c.EhPersonalizada);

                AtualizarKPICards();
                AtualizarGraficosPizza();
                AtualizarGraficoReceita();
                AtualizarCheckboxesComparacao();
                AtualizarResultadoComparacoes();
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
            // Remove todas as séries exceto a principal
            var seriesParaRemover = chartReceita.Series
                .Cast<Series>()
                .Where(s => s.Name != "Receita Diária")
                .ToList();
            foreach (var s in seriesParaRemover)
                chartReceita.Series.Remove(s);

            // Atualiza série principal
            var serie = chartReceita.Series["Receita Diária"];
            serie.Points.Clear();
            foreach (var ponto in _dadosAtuais!.ReceitaPorPeriodo)
            {
                int idx = serie.Points.AddXY(ponto.Label, ponto.Valor);
                serie.Points[idx].ToolTip = $"{ponto.Label}: {ponto.Valor:C2}";
            }

            // Adiciona séries de comparação
            int corIdx = 0;
            foreach (var comp in _comparacoesAtivas)
            {
                var cor = _coresComparacao[corIdx % _coresComparacao.Length];
                var serieComp = new Series(comp.Nome)
                {
                    ChartType = SeriesChartType.Spline,
                    Color = cor,
                    BorderColor = cor,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    MarkerStyle = MarkerStyle.Diamond,
                    MarkerSize = 5,
                    IsXValueIndexed = true,
                    LegendText = comp.Nome
                };

                foreach (var ponto in comp.ReceitaPorDia)
                {
                    int idx = serieComp.Points.AddXY(ponto.Label, ponto.Valor);
                    serieComp.Points[idx].ToolTip = $"{comp.Nome} – {ponto.Label}: {ponto.Valor:C2}";
                }

                chartReceita.Series.Add(serieComp);
                corIdx++;
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