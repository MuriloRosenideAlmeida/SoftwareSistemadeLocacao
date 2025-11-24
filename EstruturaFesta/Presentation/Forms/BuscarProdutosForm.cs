using EstruturaFesta.AppServices.DTOs;
using EstruturaFesta.Data;
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
    public partial class BuscarProdutosForm : Form
    {
        private readonly EstruturaDataBase _db;
        public BuscarProdutosForm(EstruturaDataBase db)
        {
            _db = db;
            InitializeComponent();
            dataGridViewFiltroProdutos.AutoGenerateColumns = false;
        }
        public ProdutoDTO ProdutoSelecionado { get; private set; }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            
            
                var query = _db.Produtos.AsQueryable();

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
                dataGridViewFiltroProdutos.DataSource = resultado;
            
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
