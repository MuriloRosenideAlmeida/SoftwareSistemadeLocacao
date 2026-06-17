using RentManager.Data;
using RentManager.Data.Entities;
using RentManager.Models;
using RentManager.Services;
using RentManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RentManager.Presentation.Forms
{
    public partial class FiltroRecibosForm : Form
    {
        private readonly RentManagerDataBase _db;

        public FiltroRecibosForm(RentManagerDataBase db)
        {
            InitializeComponent();
            _db = db;

            ConfigurarDataGrid();

            this.Shown += (s, e) => designTextBoxNumeroRecibo.Focus();
            designButtonFiltrar.Click += DesignButtonFiltrar_Click;
            dataGridViewFiltroRecibos.KeyDown += DataGridViewFiltroRecibos_KeyDown;
        }

        // ── Configuração das colunas ─────────────────────────────────
        private void ConfigurarDataGrid()
        {
            dataGridViewFiltroRecibos.AutoGenerateColumns = false;
            dataGridViewFiltroRecibos.ReadOnly = true;
            dataGridViewFiltroRecibos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFiltroRecibos.MultiSelect = false;
            dataGridViewFiltroRecibos.AllowUserToAddRows = false;
            dataGridViewFiltroRecibos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewFiltroRecibos.Columns.Clear();
            dataGridViewFiltroRecibos.Columns.Add(Coluna("Id", "Nº Recibo"));
            dataGridViewFiltroRecibos.Columns.Add(Coluna("NumeroPedido", "Pedido Ref."));
            dataGridViewFiltroRecibos.Columns.Add(Coluna("ClienteNome", "Cliente"));
            dataGridViewFiltroRecibos.Columns.Add(Coluna("ClienteDocumento", "CPF/CNPJ"));
            dataGridViewFiltroRecibos.Columns.Add(Coluna("DataEmissao", "Emissão", "dd/MM/yyyy HH:mm"));
            dataGridViewFiltroRecibos.Columns.Add(Coluna("ValorTotal", "Valor Total", "C2"));
        }

        private static DataGridViewTextBoxColumn Coluna(
            string propriedade, string cabecalho, string formato = "")
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propriedade,
                HeaderText = cabecalho,
                Name = propriedade
            };

            if (!string.IsNullOrEmpty(formato))
                col.DefaultCellStyle.Format = formato;

            return col;
        }

        // ── Filtrar ──────────────────────────────────────────────────
        private void DesignButtonFiltrar_Click(object sender, EventArgs e)
        {
            var texto = designTextBoxNumeroRecibo.Text.Trim();

            // Com número → filtra pelo Id do recibo
            if (!string.IsNullOrWhiteSpace(texto))
            {
                if (!int.TryParse(texto, out int id))
                {
                    MessageBox.Show("Número do recibo inválido.", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var recibo = _db.ReciboGerados
                    .Where(r => r.Id == id)
                    .ToList();

                dataGridViewFiltroRecibos.DataSource = recibo;
                return;
            }

            // Sem número → busca todos
            var todos = _db.ReciboGerados
                .OrderByDescending(r => r.DataEmissao)
                .ToList();

            dataGridViewFiltroRecibos.DataSource = todos;
        }

        // ── Abrir recibo ─────────────────────────────────────────────
        private void DataGridViewFiltrar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AbrirReciboSelecionado();
        }

        private void DataGridViewFiltroRecibos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AbrirReciboSelecionado();
            }
        }

        private void AbrirReciboSelecionado()
        {
            if (dataGridViewFiltroRecibos.CurrentRow?.DataBoundItem is not ReciboGerado recibo)
                return;

            try
            {
                var dados = ReciboGeradoService.ConverterParaDadosNota(recibo);
                NotaFiscalServicoService.VisualizarPDF(dados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o recibo:\n{ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}