using RentManager.Data;
using RentManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RentManager.Presentation.Forms
{
    public partial class ComponentesProdutoForm : Form
    {
        private readonly RentManagerDataBase _db;
        private readonly Produto _produtoPai;

        private DataGridView dgvComponentes;
        private Button btnAdicionarComponente;
        private Button btnRemoverComponente;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label lblInstrucao;

        public ComponentesProdutoForm(RentManagerDataBase db, Produto produtoPai)
        {
            _db = db;
            _produtoPai = produtoPai;
            InitializeComponents();
            CarregarComponentes();
        }

        private void InitializeComponents()
        {
            this.Text = $"Componentes de: {_produtoPai.Nome}";
            this.Size = new Size(600, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblInstrucao = new Label
            {
                Text = $"Produto: {_produtoPai.Nome} {_produtoPai.Material} {_produtoPai.Modelo}".Trim(),
                Location = new Point(12, 12),
                Size = new Size(560, 20),
                Font = new Font("Arial", 9f, FontStyle.Bold)
            };

            dgvComponentes = new DataGridView
            {
                Location = new Point(12, 40),
                Size = new Size(560, 270),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Coluna ID oculta
            dgvComponentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProdutoFilhoId",
                HeaderText = "ID",
                ReadOnly = true,
                Visible = false
            });

            // Coluna nome do componente
            dgvComponentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeComponente",
                HeaderText = "Componente",
                ReadOnly = true,
                FillWeight = 70
            });

            // Coluna quantidade por unidade (editável)
            dgvComponentes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QuantidadePorUnidade",
                HeaderText = "Qtd. por Unidade do Jogo",
                ReadOnly = false,
                FillWeight = 30
            });

            btnAdicionarComponente = new Button
            {
                Text = "+ Adicionar Componente",
                Location = new Point(12, 320),
                Size = new Size(170, 32),
                BackColor = Color.FromArgb(46, 125, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAdicionarComponente.FlatAppearance.BorderSize = 0;
            btnAdicionarComponente.Click += BtnAdicionarComponente_Click;

            btnRemoverComponente = new Button
            {
                Text = "Remover Selecionado",
                Location = new Point(192, 320),
                Size = new Size(160, 32),
                BackColor = Color.FromArgb(198, 40, 40),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRemoverComponente.FlatAppearance.BorderSize = 0;
            btnRemoverComponente.Click += BtnRemoverComponente_Click;

            btnSalvar = new Button
            {
                Text = "Salvar",
                Location = new Point(420, 320),
                Size = new Size(80, 32),
                BackColor = Color.FromArgb(25, 118, 210),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += BtnSalvar_Click;

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(510, 320),
                Size = new Size(70, 32),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };
            btnCancelar.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[]
            {
                lblInstrucao, dgvComponentes,
                btnAdicionarComponente, btnRemoverComponente,
                btnSalvar, btnCancelar
            });

            this.CancelButton = btnCancelar;
        }

        private void CarregarComponentes()
        {
            dgvComponentes.Rows.Clear();

            var componentes = _db.ProdutosComponentes
                .Include(pc => pc.ProdutoFilho)
                .Where(pc => pc.ProdutoPaiId == _produtoPai.ID)
                .ToList();

            foreach (var comp in componentes)
            {
                string descricao = $"{comp.ProdutoFilho.Nome} {comp.ProdutoFilho.Material} {comp.ProdutoFilho.Modelo} {comp.ProdutoFilho.Especificacao}".Trim();
                dgvComponentes.Rows.Add(comp.ProdutoFilhoId, descricao, comp.QuantidadePorUnidade);
            }
        }

        private void BtnAdicionarComponente_Click(object sender, EventArgs e)
        {
            using var busca = new BuscarProdutosForm(_db);
            if (busca.ShowDialog() != DialogResult.OK) return;

            var produto = busca.ProdutoSelecionado;

            // Não permite adicionar o próprio produto como componente
            if (produto.ProdutoId == _produtoPai.ID)
            {
                MessageBox.Show("Um produto não pode ser componente de si mesmo.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica duplicidade
            foreach (DataGridViewRow row in dgvComponentes.Rows)
            {
                if (row.Cells["ProdutoFilhoId"].Value != null &&
                    Convert.ToInt32(row.Cells["ProdutoFilhoId"].Value) == produto.ProdutoId)
                {
                    MessageBox.Show("Este componente já foi adicionado.",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string descricao = $"{produto.Nome} {produto.Material} {produto.Modelo} {produto.Especificacao}".Trim();
            dgvComponentes.Rows.Add(produto.ProdutoId, descricao, 1);

            // Foca na célula de quantidade para o usuário já editar
            var ultimaLinha = dgvComponentes.Rows[dgvComponentes.Rows.Count - 1];
            dgvComponentes.CurrentCell = ultimaLinha.Cells["QuantidadePorUnidade"];
            dgvComponentes.BeginEdit(true);
        }

        private void BtnRemoverComponente_Click(object sender, EventArgs e)
        {
            if (dgvComponentes.CurrentRow == null) return;

            var confirmar = MessageBox.Show(
                "Remover este componente?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
                dgvComponentes.Rows.Remove(dgvComponentes.CurrentRow);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // Valida quantidades
            foreach (DataGridViewRow row in dgvComponentes.Rows)
            {
                if (!int.TryParse(row.Cells["QuantidadePorUnidade"].Value?.ToString(), out int qtd) || qtd <= 0)
                {
                    MessageBox.Show(
                        $"A quantidade de '{row.Cells["NomeComponente"].Value}' deve ser maior que zero.",
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Remove componentes antigos e insere os da grid
            var existentes = _db.ProdutosComponentes
                .Where(pc => pc.ProdutoPaiId == _produtoPai.ID)
                .ToList();
            _db.ProdutosComponentes.RemoveRange(existentes);

            foreach (DataGridViewRow row in dgvComponentes.Rows)
            {
                _db.ProdutosComponentes.Add(new ProdutoComponente
                {
                    ProdutoPaiId = _produtoPai.ID,
                    ProdutoFilhoId = Convert.ToInt32(row.Cells["ProdutoFilhoId"].Value),
                    QuantidadePorUnidade = Convert.ToInt32(row.Cells["QuantidadePorUnidade"].Value)
                });
            }

            _db.SaveChanges();

            MessageBox.Show("Componentes salvos com sucesso!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

