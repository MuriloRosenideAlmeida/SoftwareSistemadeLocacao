using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using Color = System.Drawing.Color;

namespace RentManager.Presentation.Forms
{
    public partial class MenuForm : Form
    {

        private IconButton botaoAtual;
        private Panel bordaEsquerdaBotao;
        private Form formularioFilhoAtual;
        private bool _backupRealizado = false;

        private const string ChaveCliente = "ESTRUTURA_FESTA_001";
        // ↑ Troque pelo identificador único deste cliente
        //   Ex: "CLIENTE_JOAO_001", "CLIENTE_MARIA_002"
        //   Cada instalador entregue a um cliente diferente terá uma chave diferente

        public MenuForm()
        {
            InitializeComponent();

            bordaEsquerdaBotao = new Panel();
            bordaEsquerdaBotao.Size = new Size(7, 60);
            panelMenu.Controls.Add(bordaEsquerdaBotao);
            //Personalização do Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private struct CoresRGB
        {
            public static Color cor1 = Color.FromArgb(172, 126, 241);
            public static Color cor2 = Color.FromArgb(249, 118, 176);
            public static Color cor3 = Color.FromArgb(253, 138, 114);
            public static Color cor4 = Color.FromArgb(95, 77, 221);
            public static Color cor5 = Color.FromArgb(249, 88, 155);
            public static Color cor6 = Color.FromArgb(24, 161, 251);
            public static Color cor7 = Color.FromArgb(50, 156, 59);
        }
        private void BotaoAtivado(object senderBtn, Color color)
        {
            if (botaoAtual != null)
            {
                BotaoDesativado();
            }
            //Botao
            botaoAtual = (IconButton)senderBtn;
            botaoAtual.BackColor = Color.FromArgb(37, 36, 81);
            botaoAtual.ForeColor = color;
            botaoAtual.TextAlign = ContentAlignment.MiddleCenter;
            botaoAtual.IconColor = color;
            botaoAtual.TextImageRelation = TextImageRelation.TextBeforeImage;
            botaoAtual.ImageAlign = ContentAlignment.MiddleRight;

            //Borda Esquerda do Botao
            bordaEsquerdaBotao.BackColor = color;
            bordaEsquerdaBotao.Location = new Point(0, botaoAtual.Location.Y);
            bordaEsquerdaBotao.Visible = true;
            bordaEsquerdaBotao.BringToFront();

            formatoAtualIcone.IconChar = botaoAtual.IconChar;
            formatoAtualIcone.IconColor = color;


        }
        private void BotaoDesativado()
        {
            if (botaoAtual != null)
            {
                botaoAtual.BackColor = Color.FromArgb(31, 30, 68);
                botaoAtual.ForeColor = Color.Gainsboro;
                botaoAtual.TextAlign = ContentAlignment.MiddleLeft;
                botaoAtual.IconColor = Color.Gainsboro;
                botaoAtual.TextImageRelation = TextImageRelation.ImageBeforeText;
                botaoAtual.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        //Isso serve para abrir o pedido ja existente
        private void AbrirPedidoDoFiltro(int pedidoId)
        {
            // ativa visualmente o botão Pedido
            BotaoAtivado(bntPedido, CoresRGB.cor1);

            // abre o pedido no panel
            var telaPedido = ServiceLocator.Provider.GetRequiredService<TelaPedidoForm>();
            telaPedido.CarregarPedidoPorId(pedidoId);

            AbrirFormFilho(telaPedido);
        }

        private void bntPedido_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor1);
            AbrirFormFilho(ServiceLocator.Provider.GetRequiredService<TelaPedidoForm>());
        }

        private void bntFiltrarPedido_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor2);
            var filtro = ServiceLocator.Provider.GetRequiredService<FiltroPedidosForm>();

            // escuta o evento do filtro
            filtro.PedidoSelecionado += AbrirPedidoDoFiltro;

            AbrirFormFilho(filtro);
        }

        private void bntCadastrarCliente_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor3);
            AbrirFormFilho(ServiceLocator.Provider.GetRequiredService<CadastroClientesForm>());
        }

        private void bntFiltrarCliente_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor4);
            AbrirFormFilho(ServiceLocator.Provider.GetRequiredService<FiltroClienteForm>());
        }

        private void bntCadastrarProduto_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor5);
            AbrirFormFilho(ServiceLocator.Provider.GetRequiredService<CadastroProdutosForm>());
        }

        private void bntFiltrarProduto_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor6);
            AbrirFormFilho(ServiceLocator.Provider.GetRequiredService<FiltroProdutoForm>());
        }
        private void bntFiltrarRecibo_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor7);   // escolha a cor que preferir
            AbrirFormFilho(ServiceLocator.Provider.GetRequiredService<FiltroRecibosForm>());
        }

        private void bntLogo_Click(object sender, EventArgs e)
        {
            if (formularioFilhoAtual != null && !formularioFilhoAtual.IsDisposed)
            {
                formularioFilhoAtual.Close();
                formularioFilhoAtual = null;
            }

            Reset();
        }

        private void AbrirFormFilho(Form childForm)
        {
            //open only form
            if (formularioFilhoAtual != null)
            {
                formularioFilhoAtual.Close();
            }
            formularioFilhoAtual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTituloForm.Text = childForm.Text;
        }
        private void Reset()
        {
            BotaoDesativado();
            bordaEsquerdaBotao.Visible = false;
            formatoAtualIcone.IconChar = IconChar.Home;
            formatoAtualIcone.IconColor = Color.MediumPurple;
            labelTituloForm.Text = "Inicio";

        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void barraDeTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Close-Maximize-Minimize
        private void bntMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void bntMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                bntMaximize.IconChar = IconChar.Clone;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                bntMaximize.IconChar = IconChar.SquareFull;
            }

        }
        private void bntExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private static string PastaLogs =>
           Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
               "RentManager", "Logs");

        private void GravarLogFechamento(string mensagem)
        {
            try
            {
                Directory.CreateDirectory(PastaLogs);
                File.AppendAllText(
                    Path.Combine(PastaLogs, "log_fechamento.txt"),
                    $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} — {mensagem}\n",
                    System.Text.Encoding.UTF8);
            }
            catch { }
        }

        // ── BACKUP AO FECHAR ─────────────────────────────────────────
        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            if (_backupRealizado)
            {
                base.OnFormClosing(e);
                return;
            }

            e.Cancel = true;

            GravarLogFechamento("OnFormClosing chamado — iniciando backup...");

            try
            {
                await RentManager.Services.BackupService.RealizarBackupAsync(ChaveCliente);
                GravarLogFechamento("Backup concluído com sucesso.");
            }
            catch (Exception ex)
            {
                GravarLogFechamento($"ERRO no backup: {ex.Message}\n{ex.StackTrace}");
            }

            _backupRealizado = true;
            e.Cancel = false;
            base.OnFormClosing(e);
        }
    }
}
