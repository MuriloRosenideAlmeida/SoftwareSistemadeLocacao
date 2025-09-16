using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using Color = System.Drawing.Color;

namespace EstruturaFesta.Presentation.Forms
{
    public partial class MenuForm : Form
    {

        private IconButton botaoAtual;
        private Panel bordaEsquerdaBotao;
        private Form formularioFilhoAtual;


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

        private void bntPedido_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor1);
            AbrirFormFilho(new TelaPedidoForm());
        }

        private void bntFiltrarPedido_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor2);
            AbrirFormFilho(new FiltroPedidosForm());
        }

        private void bntCadastrarCliente_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor3);
            AbrirFormFilho(new CadastroClientesForm());
        }

        private void bntFiltrarCliente_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor4);
            AbrirFormFilho(new FiltroClienteForm());
        }

        private void bntCadastrarProduto_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor5);
            AbrirFormFilho(new CadastroProdutosForm());
        }

        private void bntFiltrarProduto_Click(object sender, EventArgs e)
        {
            BotaoAtivado(sender, CoresRGB.cor6);
            AbrirFormFilho(new FiltroProdutoForm());
        }

        private void bntLogo_Click(object sender, EventArgs e)
        {
            formularioFilhoAtual.Close();
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
            Application.Exit();
        }
        
        
        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        
    }
}
