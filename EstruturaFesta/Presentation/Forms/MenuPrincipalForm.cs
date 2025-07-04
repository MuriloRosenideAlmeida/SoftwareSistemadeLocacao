﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstruturaFesta
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

        }
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CadastroClientesForm();
            form.MdiParent = this; // Opcional: se quiser como janela interna
            form.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CadastroProdutosForm();
            form.MdiParent = this;
            form.Show();
        }

        private void novoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TelaPedidoForm();
            form.MdiParent = this;
            form.Show();
        }

        private void InitializeComponent()
        {

        }

        private void filtroDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FiltroPedidosForm();
            form.MdiParent = this;
            form.Show();
        }


    }
}
