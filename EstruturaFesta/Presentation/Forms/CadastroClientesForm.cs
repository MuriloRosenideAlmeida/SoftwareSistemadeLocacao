using ViaCep;
using EstruturaFesta.Data;
using EstruturaFesta.Data.Entities;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using EstruturaFesta.Utils;

namespace EstruturaFesta
{
    public partial class CadastroClientesForm : Form
    {
        private readonly EstruturaDataBase _db;

        private readonly ViaCepClient _viaCepClient;
        private Cliente _cliente;
        private bool _isEditMode;
        private BindingList<Contato> _contatos;

        public CadastroClientesForm(EstruturaDataBase db, Cliente cliente = null)
        {
            InitializeComponent();
            _db = db;
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
            _viaCepClient = new ViaCepClient(httpClient);

            _cliente = cliente;
            _isEditMode = cliente != null;

            // Inicializa BindingList de contatos
            _contatos = new BindingList<Contato>
            {
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true
            };
            dataGridViewContatos.DataSource = _contatos;

            AtualizarTituloForm();

            if (_isEditMode)
                CarregarCliente();
        }
        private void CadastroClientesForm_Load(object sender, EventArgs e)
        {
            SistemaUpperCase.AplicarMaiusculo(this);
        }

        #region RadioButtons
        private void radioButtonPF_CheckedChanged(object sender, EventArgs e)
        {
            panelCadastroPF.BringToFront();
            panelCadastroPF.Visible = radioButtonPF.Checked;
            panelCadastroPJ.Visible = radioButtonPJ.Checked;
        }

        private void radioButtonPJ_CheckedChanged(object sender, EventArgs e)
        {
            panelCadastroPJ.BringToFront();
            panelCadastroPJ.Visible = radioButtonPJ.Checked;
            panelCadastroPF.Visible = radioButtonPF.Checked;
        }
        #endregion
        #region CEP e CPF
        private void textBoxCEP_Leave(object sender, EventArgs e) => LocalizarCEP();
        private void textBoxCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarCEP();
                e.SuppressKeyPress = true;
            }
        }

        private async void LocalizarCEP()
        {
            if (string.IsNullOrWhiteSpace(textBoxCEP.Text))
            {
                MessageBox.Show("Informe um CEP válido");
                return;
            }

            try
            {
                var endereco = await _viaCepClient.SearchAsync(textBoxCEP.Text, CancellationToken.None);
                if (endereco != null)
                {
                    if (string.IsNullOrWhiteSpace(textBoxRua.Text)) textBoxRua.Text = endereco.Street;
                    if (string.IsNullOrWhiteSpace(textBoxBairro.Text)) textBoxBairro.Text = endereco.Neighborhood;
                    if (string.IsNullOrWhiteSpace(textBoxCidade.Text)) textBoxCidade.Text = endereco.City;
                    if (string.IsNullOrWhiteSpace(textBoxEstado.Text)) textBoxEstado.Text = endereco.StateInitials;
                }
                else
                    MessageBox.Show("CEP não localizado...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar CEP: {ex.Message}");
            }
        }
        private void textBoxNumero_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNumero.Text))
            {
                MessageBox.Show("O número não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNumero.Focus();
            }
        }
        private void maskedTextBoxNascimento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBoxNascimento.Text))
            {
                MessageBox.Show("Digite apenas números para a data de nascimento.",
                    "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        #endregion

        #region Título e Load
        private void AtualizarTituloForm()
        {
            this.Text = _isEditMode ? "Editar Cliente" : "Cadastrar Cliente";
            buttonAdicionarCliente.Text = _isEditMode ? "Salvar Alterações" : "Adicionar Cliente";
        }

        private void CarregarCliente()
        {
            if (_cliente == null) return;


            _cliente = _db.Clientes
                .Include(c => c.Contatos)
                .FirstOrDefault(c => c.ID == _cliente.ID);

            if (_cliente == null) return;

            // Preenche dados comuns
            textBoxRua.Text = _cliente.Rua ?? string.Empty;
            textBoxBairro.Text = _cliente.Bairro ?? string.Empty;
            textBoxNumero.Text = _cliente.Numero.ToString();
            textBoxCEP.Text = _cliente.CEP ?? string.Empty;
            textBoxCidade.Text = _cliente.Cidade ?? string.Empty;
            textBoxEstado.Text = _cliente.Estado ?? string.Empty;
            textBoxComplemento.Text = _cliente.Complemento ?? string.Empty;

            // Tipo específico
            if (_cliente is ClientePF pf)
            {
                radioButtonPF.Checked = true;
                textBoxNomeCliente.Text = pf.Nome;
                textBoxCPF.Text = pf.CPF;
                textBoxRG.Text = pf.RG;
                if (pf.DataNascimento.HasValue)
                    maskedTextBoxNascimento.Text = pf.DataNascimento.Value.ToString("dd/MM/yyyy");
                else
                    maskedTextBoxNascimento.Text = "";
            }
            else if (_cliente is ClientePJ pj)
            {
                radioButtonPJ.Checked = true;
                textBoxNomeFantasia.Text = pj.NomeFantasia;
                textBoxCNPJ.Text = pj.CNPJ;
                textBoxRazaoSocial.Text = pj.RazaoSocial;
                textBoxInscricaoEstadual.Text = pj.InscricaoEstadual;
                textBoxInscricaoMunicipal.Text = pj.InscricaoMunicipal;
            }

            // Preenche contatos
            _contatos.Clear();
            foreach (var contato in _cliente.Contatos.OrderBy(c => c.ID))
            {
                _contatos.Add(new Contato
                {
                    ID = contato.ID,
                    NomeContato = contato.NomeContato,
                    Telefone = contato.Telefone
                });
            }
        }
        #endregion

        #region Validação
        private bool ValidarCampos()
        {
            if (radioButtonPF.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxNomeCliente.Text) ||
                    string.IsNullOrWhiteSpace(textBoxCPF.Text))
                {
                    MessageBox.Show("Nome e CPF são obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (radioButtonPJ.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxNomeFantasia.Text) ||
                    string.IsNullOrWhiteSpace(textBoxCNPJ.Text))
                {
                    MessageBox.Show("Nome Fantasia e CNPJ são obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!int.TryParse(textBoxNumero.Text, out _))
            {
                MessageBox.Show("Número inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region Preencher Cliente
        private void PreencherCliente(Cliente cliente)
        {
            // Dados comuns
            cliente.Rua = textBoxRua.Text?.Trim();
            cliente.Bairro = textBoxBairro.Text?.Trim();
            cliente.Numero = textBoxNumero.Text;
            cliente.CEP = textBoxCEP.Text?.Trim();
            cliente.Cidade = textBoxCidade.Text?.Trim();
            cliente.Estado = textBoxEstado.Text?.Trim();
            cliente.Complemento = textBoxComplemento.Text?.Trim();

            // Campos específicos
            if (cliente is ClientePF pf)
            {
                pf.Nome = textBoxNomeCliente.Text?.Trim();
                pf.CPF = textBoxCPF.Text?.Trim();
                pf.RG = textBoxRG.Text?.Trim();
                if (DateTime.TryParse(maskedTextBoxNascimento.Text, out DateTime dt))
                    pf.DataNascimento = dt;
            }
            else if (cliente is ClientePJ pj)
            {
                pj.NomeFantasia = textBoxNomeFantasia.Text?.Trim();
                pj.CNPJ = textBoxCNPJ.Text?.Trim();
                pj.RazaoSocial = textBoxRazaoSocial.Text?.Trim();
                pj.InscricaoEstadual = textBoxInscricaoEstadual.Text?.Trim();
                pj.InscricaoMunicipal = textBoxInscricaoMunicipal.Text?.Trim();
            }
        }
        #endregion

        #region Salvamento
        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;



            if (!_isEditMode)
            {
                _cliente = radioButtonPF.Checked ? (Cliente)new ClientePF() : new ClientePJ();
                _db.Clientes.Add(_cliente);
            }
            else
            {
                _db.Clientes.Attach(_cliente);
                _db.Entry(_cliente).State = EntityState.Modified;
            }

            PreencherCliente(_cliente);

            // Adiciona novos contatos
            foreach (var contato in _contatos)
            {
                if (contato.ID == 0)
                {
                    // Novo contato
                    _cliente.Contatos.Add(contato);
                }
                else
                {
                    // Contato existente: EF já está rastreando pelo Attach se necessário
                    var contatoExistente = _cliente.Contatos.FirstOrDefault(c => c.ID == contato.ID);
                    if (contatoExistente != null)
                    {
                        contatoExistente.NomeContato = contato.NomeContato;
                        contatoExistente.Telefone = contato.Telefone;
                    }
                }
            }

            // Remove contatos excluídos
            var idsAtuais = _contatos.Select(c => c.ID).ToList();
            foreach (var c in _cliente.Contatos.Where(c => c.ID != 0 && !idsAtuais.Contains(c.ID)).ToList())
                _db.Contatos.Remove(c);

            _db.SaveChanges();

            MessageBox.Show(_isEditMode ? "Cliente atualizado com sucesso!" : "Cliente adicionado com sucesso!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion


    }
}