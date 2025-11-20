using EstruturaFesta.AppServices.DTOs;
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
            dataGridViewFiltroProdutos.AutoGenerateColumns = false;
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
                    .Select(p => new ProdutoDTO
                    {
                        ProdutoId = p.ID,
                        Nome = p.Nome,
                        Material = p.Material,
                        Modelo = p.Modelo,
                        Especificacao = p.Especificacao,
                        QuantidadeEstoque = p.Quantidade,
                        ValorUnitario = p.PrecoLocacao,
                        ValorReposicao = p.PrecoReposicao,
                    })
                    .ToList();

                dataGridViewFiltroProdutos.AutoGenerateColumns = false;
                dataGridViewFiltroProdutos.DataSource = resultado;
            }
        }

        private void dataGridViewFiltroProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int produtoId = (int)dataGridViewFiltroProdutos.Rows[e.RowIndex].Cells["ProdutoId"].Value;

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

        private void dataGridViewFiltroProdutos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewFiltroProdutos.Columns[e.ColumnIndex].Name;

            // Pega a lista atual do DataSource
            var produtos = dataGridViewFiltroProdutos.DataSource as List<ProdutoDTO>;
            if (produtos == null) return;

            // Alterna entre ascendente e descendente
            bool ascending = dataGridViewFiltroProdutos.SortOrder != SortOrder.Ascending;

            // Usa Reflection para pegar a propriedade correspondente
            var propInfo = typeof(ProdutoDTO).GetProperty(columnName);
            if (propInfo == null) return; // Se não existir a propriedade, sai

            // Ordena dinamicamente pelo valor da propriedade
            produtos = ascending
                ? produtos.OrderBy(p => propInfo.GetValue(p, null)).ToList()
                : produtos.OrderByDescending(p => propInfo.GetValue(p, null)).ToList();

            // Atualiza o DataSource
            dataGridViewFiltroProdutos.DataSource = null;
            dataGridViewFiltroProdutos.DataSource = produtos;

            // Atualiza o ícone de ordenação
            dataGridViewFiltroProdutos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
    }
}
