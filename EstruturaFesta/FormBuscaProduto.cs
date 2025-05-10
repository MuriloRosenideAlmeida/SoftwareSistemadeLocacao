using System;
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
    public partial class FormBuscaProduto : Form
    {
        public FormBuscaProduto()
        {
            InitializeComponent();
        }
        public Produto ProdutoSelecionado { get; private set; }

    }
}
