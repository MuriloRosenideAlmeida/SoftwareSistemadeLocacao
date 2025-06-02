using EstruturaFesta.DataBase;
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

namespace EstruturaFesta
{
    public partial class FormBuscaProduto : Form
    {
        public FormBuscaProduto()
        {
            InitializeComponent();
        }
        public ProdutoDTO ProdutoSelecionado { get; private set; }

        private void buttonFiltrar_Click(object sender, EventArgs e)
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
                .Select(p => new ProdutoDTO
                {
                    ProdutoId = p.ID,
                    Nome = p.Nome,
                    Material = p.Material,
                    Modelo = p.Modelo,
                    Especificacao = p.Especificacao,
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
                ProdutoSelecionado = (ProdutoDTO)dataGridViewFiltroProdutos.Rows[e.RowIndex].DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
