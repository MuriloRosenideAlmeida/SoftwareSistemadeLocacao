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
        private ClientePF DocumentoJaExiste(string cpfNumeros)
        {
            return _db.Clientes
                .OfType<ClientePF>()
                .FirstOrDefault(c => c.CPF == cpfNumeros);
        }

        public CadastroClientesForm(EstruturaDataBase db, Cliente cliente = null)
        {
            InitializeComponent();
            _db = db;
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
            _viaCepClient = new ViaCepClient(httpClient);
            dataGridViewContatos.AutoGenerateColumns = false;

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
        public bool ValidarCpf(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], 11) == cpf)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
        private void designTextBoxCPF__TextChanged(object sender, EventArgs e)
        {

            string texto = new string(designTextBoxCPF.Text
        .Where(char.IsDigit)
        .ToArray());

            if (texto.Length > 11)
                texto = texto.Substring(0, 11);

            if (texto.Length >= 4)
                texto = texto.Insert(3, ".");
            if (texto.Length >= 8)
                texto = texto.Insert(7, ".");
            if (texto.Length >= 12)
                texto = texto.Insert(11, "-");

            designTextBoxCPF.TextChanged -= designTextBoxCPF__TextChanged;
            designTextBoxCPF.Text = texto;
            designTextBoxCPF.SelectionStart = designTextBoxCPF.Text.Length;
            designTextBoxCPF.TextChanged += designTextBoxCPF__TextChanged;
        }
        private void designTextBoxCPF_Leave(object sender, EventArgs e)
        {
            string cpf = designTextBoxCPF.Text;

            if (!string.IsNullOrWhiteSpace(cpf) && !ValidarCpf(cpf))
            {
                MessageBox.Show("CPF inválido!");
                designTextBoxCPF.Focus();
            }
            if (!_isEditMode)
            {
                var clienteExistente = DocumentoJaExiste(cpf);
                if (clienteExistente != null)
                {
                    MessageBox.Show(
                     $"Já existe um cliente cadastrado com esse CPF.\n\nNúmero do cadastro: {clienteExistente.ID}",
                     "Documento duplicado",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);

                }
            }

        }

        private void designTextBoxCEP_Leave(object sender, EventArgs e) => LocalizarCEP();

        private void designTextBoxCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizarCEP();
                e.SuppressKeyPress = true;
            }
        }

        private async void LocalizarCEP()
        {
            if (string.IsNullOrWhiteSpace(designTextBoxCEP.Text))
            {
                MessageBox.Show("Informe um CEP válido");
                return;
            }

            try
            {
                var endereco = await _viaCepClient.SearchAsync(designTextBoxCEP.Text, CancellationToken.None);
                if (endereco != null)
                {
                    if (string.IsNullOrWhiteSpace(designTextBoxRua.Text)) designTextBoxRua.Text = endereco.Street;
                    if (string.IsNullOrWhiteSpace(designTextBoxBairro.Text)) designTextBoxBairro.Text = endereco.Neighborhood;
                    if (string.IsNullOrWhiteSpace(designTextBoxCidade.Text)) designTextBoxCidade.Text = endereco.City;
                    if (string.IsNullOrWhiteSpace(designTextBoxEstado.Text)) designTextBoxEstado.Text = endereco.StateInitials;
                }
                else
                    MessageBox.Show("CEP não localizado...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar CEP: {ex.Message}");
            }
        }
        private void designTextBoxNumero_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(designTextBoxNumero.Text))
            {
                MessageBox.Show("O número não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                designTextBoxNumero.Focus();
            }
        }
        private void designTextBoxNumero__TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(designTextBoxNumero.Text))
            {
                MessageBox.Show("O número não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                designTextBoxNumero.Focus();
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

        private void designTextBoxCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        #endregion

        #region Título e Load
        private void AtualizarTituloForm()
        {
            this.Text = _isEditMode ? "Editar Cliente" : "Cadastrar Cliente";
            designButtonAdicionarCliente.Text = _isEditMode ? "Salvar Alterações" : "Adicionar Cliente";
            designButtonExcluirCliente.Visible = _isEditMode;
        }

        private void CarregarCliente()
        {
            if (_cliente == null) return;

            _cliente = _db.Clientes
                .Include(c => c.Contatos)
                .FirstOrDefault(c => c.ID == _cliente.ID);


            if (_cliente == null) return;

            // Preenche dados comuns
            designTextBoxRua.Text = _cliente.Rua ?? string.Empty;
            designTextBoxBairro.Text = _cliente.Bairro ?? string.Empty;
            designTextBoxNumero.Text = _cliente.Numero.ToString();
            designTextBoxCEP.Text = _cliente.CEP ?? string.Empty;
            designTextBoxCidade.Text = _cliente.Cidade ?? string.Empty;
            designTextBoxEstado.Text = _cliente.Estado ?? string.Empty;
            designTextBoxComplemento.Text = _cliente.Complemento ?? string.Empty;

            // Tipo específico
            if (_cliente is ClientePF pf)
            {
                radioButtonPF.Checked = true;
                designTextBoxNomeCliente.Text = pf.Nome;
                designTextBoxCPF.Text = pf.CPF;
                designTextBoxRG.Text = pf.RG;
                designTextBoxNomeMae.Text = pf.NomeMae;
                if (pf.DataNascimento.HasValue)
                    maskedTextBoxNascimento.Text = pf.DataNascimento.Value.ToString("dd/MM/yyyy");
                else
                    maskedTextBoxNascimento.Text = "";
            }
            else if (_cliente is ClientePJ pj)
            {
                radioButtonPJ.Checked = true;
                designTextBoxNomeFantasia.Text = pj.NomeFantasia;
                designTextBoxCNPJ.Text = pj.CNPJ;
                designTextBoxRazaoSocial.Text = pj.RazaoSocial;
                designTextBoxInscricaoEstadual.Text = pj.InscricaoEstadual;
                designTextBoxInscricaoMunicipal.Text = pj.InscricaoMunicipal;
            }

            // Preenche contatos
            _contatos.Clear();
            foreach (var contato in _cliente.Contatos.OrderBy(c => c.ID))
            {
                _contatos.Add(new Contato
                {
                    ID = contato.ID,
                    ClienteID = contato.ClienteID,
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
                if (string.IsNullOrWhiteSpace(designTextBoxNomeCliente.Text) ||
                    string.IsNullOrWhiteSpace(designTextBoxCPF.Text))
                {
                    MessageBox.Show("Nome e CPF são obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (radioButtonPJ.Checked)
            {
                if (string.IsNullOrWhiteSpace(designTextBoxRazaoSocial.Text) ||
                    string.IsNullOrWhiteSpace(designTextBoxCNPJ.Text))
                {
                    MessageBox.Show("Nome Fantasia e CNPJ são obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!int.TryParse(designTextBoxNumero.Text, out _))
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
            cliente.Rua = designTextBoxRua.Text?.Trim();
            cliente.Bairro = designTextBoxBairro.Text?.Trim();
            cliente.Numero = designTextBoxNumero.Text;
            cliente.CEP = designTextBoxCEP.Text?.Trim();
            cliente.Cidade = designTextBoxCidade.Text?.Trim();
            cliente.Estado = designTextBoxEstado.Text?.Trim();
            cliente.Complemento = designTextBoxComplemento.Text?.Trim();

            // Campos específicos
            if (cliente is ClientePF pf)
            {
                pf.Nome = designTextBoxNomeCliente.Text?.Trim();
                pf.CPF = designTextBoxCPF.Text?.Trim();
                pf.RG = designTextBoxRG.Text?.Trim();
                pf.NomeMae = designTextBoxNomeMae.Text?.Trim();
                if (DateTime.TryParse(maskedTextBoxNascimento.Text, out DateTime dt))
                    pf.DataNascimento = dt;
            }
            else if (cliente is ClientePJ pj)
            {
                pj.NomeFantasia = designTextBoxNomeFantasia.Text?.Trim();
                pj.CNPJ = designTextBoxCNPJ.Text?.Trim();
                pj.RazaoSocial = designTextBoxRazaoSocial.Text?.Trim();
                pj.InscricaoEstadual = designTextBoxInscricaoEstadual.Text?.Trim();
                pj.InscricaoMunicipal = designTextBoxInscricaoMunicipal.Text?.Trim();
            }
        }
        #endregion

        #region Salvamento
        private void designButtonAdicionarCliente_Click(object sender, EventArgs e)
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
        private void designButtonExcluirCliente_Click(object sender, EventArgs e)
        {
            if (_cliente == null) return;

            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir este cliente?\n\nEssa ação não poderá ser desfeita.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                // Carrega cliente com contatos
                var cliente = _db.Clientes
                    .Include(c => c.Contatos)
                    .FirstOrDefault(c => c.ID == _cliente.ID);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado.");
                    return;
                }

                _db.Contatos.RemoveRange(cliente.Contatos);

                _db.Clientes.Remove(cliente);

                _db.SaveChanges();

                MessageBox.Show("Cliente excluído com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}");
            }

        }
        #endregion


    }
}