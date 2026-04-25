using EstruturaFesta.Data;
using EstruturaFesta.Data.Entities;
using EstruturaFesta.Models;
using EstruturaFesta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EstruturaFesta.Presentation.Forms
{
    public partial class FiltroRecibosForm : Form
    {
        private readonly EstruturaDataBase _db;

        public FiltroRecibosForm(EstruturaDataBase db)
        {
            InitializeComponent();
            _db = db;

            ConfigurarDataGrid();

            designButtonFiltrar.Click += DesignButtonFiltrar_Click;
            dataGridViewFiltroRecibos.CellDoubleClick += DataGridViewFiltrar_CellDoubleClick;
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
                var dados = ConverterParaDados(recibo);
                NotaFiscalServicoService.VisualizarPDF(dados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o recibo:\n{ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Converte ReciboGerado → DadosNotaFiscalServico ──────────
        // Espelha exatamente o que NotaFiscalServicoService.MontarDados faz.
        private static DadosNotaFiscalServico ConverterParaDados(ReciboGerado r)
        {
            return new DadosNotaFiscalServico
            {
                // Emissora
                EmpresaNome = "ESTRUTURA FESTA LTDA",
                EmpresaCNPJ = "10.427.554/0001-23",
                EmpresaRua = "Rua Jucelino Kubitschek de Oliveira",
                EmpresaNumero = "22",
                EmpresaBairro = "Jd. Europa",
                EmpresaCidade = "Nova Odessa",
                EmpresaUF = "SP",
                EmpresaCEP = "13460-000",
                EmpresaTelefone = "(19) 3476-5005",
                EmpresaEmail = "estruturafesta@hotmail.com.br",
                LogoPath = @"Resources\logo_estrutura.png",

                // Identificação
                NumeroNota = r.Id,
                DataEmissao = r.DataEmissao,
                NumeroPedido = r.NumeroPedido,
                DataServico = r.DataEntrega,
                DataRetirada = r.DataRetirada,

                // Tomador
                ClienteNome = r.ClienteNome,
                ClienteDocumento = r.ClienteDocumento,
                ClienteRua = r.EnderecoRua,
                ClienteNumero = r.EnderecoNumero,
                ClienteBairro = r.Bairro,
                ClienteCidade = r.Cidade,
                ClienteUF = r.UF,
                ClienteCEP = r.CEP,
                ClienteTelefone = r.ClienteTelefone,

                // Serviço
                DescricaoServico = r.DescricaoServico,
                ValorServico = r.SubTotal,
                Desconto = r.Desconto,
                Acrescimo = r.Acrescimo,
                ValorTotal = r.ValorTotal,

                // Pagamentos não ficam gravados na entidade → lista vazia
                Pagamentos = new List<PagamentoImpressao>()
            };
        }

    }
}