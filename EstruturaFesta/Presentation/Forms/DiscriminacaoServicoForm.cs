using EstruturaFesta.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstruturaFesta.Presentation.Forms
{
    public partial class DiscriminacaoServicoForm : Form
    {
        private TextBox txtDescricao;
        private DesignButton btnConfirmar;
        private DesignButton btnCancelar;
        private Label lblInstrucao;

        public string Descricao => txtDescricao.Text;

        public DiscriminacaoServicoForm(string descricaoPadrao)
        {
            InitializeComponents();
            txtDescricao.Text = descricaoPadrao;
            txtDescricao.SelectAll(); // seleciona tudo para facilitar edição
        }

        private void InitializeComponents()
        {
            this.Text = "Discriminação do Serviço";
            this.Size = new Size(520, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblInstrucao = new Label
            {
                Text = "Edite a descrição do serviço que aparecerá na nota fiscal:",
                Location = new Point(12, 12),
                Size = new Size(480, 20),
                Font = new Font("Arial", 9f, FontStyle.Bold)
            };

            txtDescricao = new TextBox
            {
                Location = new Point(12, 38),
                Size = new Size(480, 180),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Arial", 9f),
                MaxLength = 1000
            };

            btnConfirmar = new DesignButton
            {
                Text = "Confirmar e Gerar Nota",
                Location = new Point(290, 235),
                Size = new Size(170, 35),
                BackgroundColor = Color.FromArgb(46, 125, 50),
                TextColor = Color.White,
                BorderRadius = 15,
                BorderSize = 0,
                Font = new Font("Arial", 9f, FontStyle.Bold),
                DialogResult = DialogResult.OK
            };

            btnCancelar = new DesignButton
            {
                Text = "Cancelar",
                Location = new Point(200, 235),
                Size = new Size(82, 35),
                BackgroundColor = Color.FromArgb(198, 40, 40),
                TextColor = Color.White,
                BorderRadius = 15,
                BorderSize = 0,
                Font = new Font("Arial", 9f),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.Add(lblInstrucao);
            this.Controls.Add(txtDescricao);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);

            this.AcceptButton = btnConfirmar;
            this.CancelButton = btnCancelar;
        }
    }
}
