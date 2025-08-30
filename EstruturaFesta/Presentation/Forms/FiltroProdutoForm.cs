using EstruturaFesta.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
    public partial class FiltroProdutoForm : Form
    {
        public FiltroProdutoForm()
        {
            InitializeComponent();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            CarregarProdutos();
        }
        private void CarregarProdutos()
        {
            using (var context = new EstruturaDataBase())
            {
                var query = context.Produtos.AsQueryable();

                if (!string.IsNullOrWhiteSpace(textBoxFiltroNomeProduto.Text))
                {
                    string filtro = $"{textBoxFiltroNomeProduto.Text}%";
                    query = query.Where(p => EF.Functions.Like(p.Nome, filtro));
                }

                if (!string.IsNullOrWhiteSpace(textBoxFiltroMaterial.Text))
                {
                    string filtro = $"{textBoxFiltroMaterial.Text}%";
                    query = query.Where(p => EF.Functions.Like(p.Material, filtro));
                }

                if (!string.IsNullOrWhiteSpace(textBoxFiltroModelo.Text))
                {
                    string filtro = $"{textBoxFiltroModelo.Text}%";
                    query = query.Where(p => EF.Functions.Like(p.Modelo, filtro));
                }

                if (!string.IsNullOrWhiteSpace(textBoxFiltroEspecificacao.Text))
                {
                    string filtro = $"{textBoxFiltroEspecificacao.Text}%";
                    query = query.Where(p => EF.Functions.Like(p.Especificacao, filtro));
                }

                var resultado = query
                    .Select(p => new
                    {
                        p.ID,
                        p.Nome,
                        p.Material,
                        p.Modelo,
                        p.Especificacao,
                        QuantidadeEstoque = p.Quantidade,
                        ValorUnitario = p.PrecoLocacao
                    })
                    .ToList();

                dataGridViewFiltroProdutos.DataSource = resultado;
            }
        }

        private void dataGridViewFiltroProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int produtoId = (int)dataGridViewFiltroProdutos.Rows[e.RowIndex].Cells["ID"].Value;

                using (var context = new EstruturaDataBase())
                {
                    var produto = context.Produtos.FirstOrDefault(p => p.ID == produtoId);

                    if (produto != null)
                    {
                        using (var form = new CadastroProdutosForm(produto))
                        {
                            if (form.ShowDialog() == DialogResult.OK) ;
                            {
                                CarregarProdutos();
                            }
                        }
                    }
                }
            }
        }
    }
}
