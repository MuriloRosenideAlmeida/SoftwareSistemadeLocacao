using ViaCep;
using EstruturaFesta.Infrastructure.Data;
using EstruturaFesta.Domain.Entities;
using System.ComponentModel;

namespace EstruturaFesta
{
    public partial class CadastroClientesForm : Form
    {
        private readonly ViaCepClient _viaCepClient;
        private Cliente _cliente;
        private bool _isEditMode;
        private BindingList<Contato> _contatosPF;
        private BindingList<Contato> _contatosPJ;

        public CadastroClientesForm(Cliente cliente = null)
        {
            InitializeComponent();

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
            _viaCepClient = new ViaCepClient(httpClient);

            _cliente = cliente;
            _isEditMode = cliente != null;

            // Inicializar BindingLists
            _contatosPF = new BindingList<Contato>();
            _contatosPJ = new BindingList<Contato>();

            // Vincular DataGridViews às BindingLists
            dataGridViewContatos.DataSource = _contatosPF;
            dataGridViewContatosPJ.DataSource = _contatosPJ;

            AtualizarTituloForm();

            if (_isEditMode)
                CarregarCliente();
        }

        // CPF
        private void textBoxCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // CEP
        private void textBoxCEP_Leave(object sender, EventArgs e)
        {
            LocalizarCEP();
        }

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
            if (!string.IsNullOrWhiteSpace(textBoxCEP.Text))
            {
                try
                {
                    var endereco = await _viaCepClient.SearchAsync(textBoxCEP.Text, CancellationToken.None);
                    if (endereco != null)
                    {
                        if (string.IsNullOrWhiteSpace(textBoxRua.Text))
                            textBoxRua.Text = endereco.Street;
                        if (string.IsNullOrWhiteSpace(textBoxBairro.Text))
                            textBoxBairro.Text = endereco.Neighborhood;
                        if (string.IsNullOrWhiteSpace(textBoxCidade.Text))
                            textBoxCidade.Text = endereco.City;
                        if (string.IsNullOrWhiteSpace(textBoxEstado.Text))
                            textBoxEstado.Text = endereco.StateInitials;
                    }
                    else
                    {
                        MessageBox.Show("Cep não localizado...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao consultar CEP: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido");
            }
        }

        private void radioButtonPF_CheckedChanged(object sender, EventArgs e)
        {
            panelCadastroPF.Visible = radioButtonPF.Checked;
            panelCadastroPJ.Visible = radioButtonPJ.Checked;
        }

        private void radioButtonPJ_CheckedChanged(object sender, EventArgs e)
        {
            panelCadastroPJ.Visible = radioButtonPJ.Checked;
            panelCadastroPF.Visible = radioButtonPF.Checked;
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

        private void AtualizarTituloForm()
        {
            this.Text = _isEditMode ? "Editar Cliente" : "Cadastrar Cliente";
            buttonAdicionarCliente.Text = _isEditMode ? "Salvar Alterações" : "Adicionar Cliente";
        }

        private void CarregarCliente()
        {
            if (_cliente == null) return;

            if (_cliente is ClientePF pf)
            {
                radioButtonPF.Checked = true;
                textBoxNomeCliente.Text = pf.Nome;
                textBoxCPF.Text = pf.CPF;
                textBoxRG.Text = pf.RG;
                maskedTextBoxNascimento.Text = pf.DataNascimento.ToString("dd/MM/yyyy");

                _contatosPF.Clear();
                if (pf.Contatos != null)
                {
                    foreach (var contato in pf.Contatos)
                        _contatosPF.Add(contato);
                }
            }
            else if (_cliente is ClientePJ pj)
            {
                radioButtonPJ.Checked = true;
                textBoxNomeFantasia.Text = pj.NomeFantasia;
                textBoxCNPJ.Text = pj.CNPJ;
                textBoxRazaoSocial.Text = pj.RazaoSocial;
                textBoxInscricaoEstadual.Text = pj.InscricaoEstadual;
                textBoxInscricaoMunicipal.Text = pj.InscricaoMunicipal;

                _contatosPJ.Clear();
                if (pj.Contatos != null)
                {
                    foreach (var contato in pj.Contatos)
                        _contatosPJ.Add(contato);
                }
            }

            // Dados comuns
            textBoxRua.Text = _cliente.Rua ?? string.Empty;
            textBoxBairro.Text = _cliente.Bairro ?? string.Empty;
            textBoxNumero.Text = _cliente.Numero.ToString();
            textBoxCEP.Text = _cliente.CEP ?? string.Empty;
            textBoxCidade.Text = _cliente.Cidade ?? string.Empty;
            textBoxEstado.Text = _cliente.Estado ?? string.Empty;
            textBoxComplemento.Text = _cliente.Complemento ?? string.Empty;
        }

        private bool ValidarCampos()
        {
            if (radioButtonPF.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxNomeCliente.Text) || string.IsNullOrWhiteSpace(textBoxCPF.Text))
                {
                    MessageBox.Show("Nome e CPF são obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (radioButtonPJ.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxNomeFantasia.Text) || string.IsNullOrWhiteSpace(textBoxCNPJ.Text))
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

        private void PreencherCliente(Cliente cliente)
        {
            // Dados comuns
            cliente.Rua = textBoxRua.Text?.Trim();
            cliente.Bairro = textBoxBairro.Text?.Trim();
            cliente.Numero = int.Parse(textBoxNumero.Text);
            cliente.CEP = textBoxCEP.Text?.Trim();
            cliente.Cidade = textBoxCidade.Text?.Trim();
            cliente.Estado = textBoxEstado.Text?.Trim();
            cliente.Complemento = textBoxComplemento.Text?.Trim();

            // Contatos
            var contatos = cliente is ClientePF ? _contatosPF : _contatosPJ;
            cliente.Contatos.Clear();
            foreach (var contato in contatos)
            {
                if (!string.IsNullOrWhiteSpace(contato.NomeContato) &&
                    !string.IsNullOrWhiteSpace(contato.Telefone))
                {
                    cliente.Contatos.Add(new Contato
                    {
                        ID = contato.ID,
                        NomeContato = contato.NomeContato.Trim(),
                        Telefone = contato.Telefone.Trim()
                    });
                }
            }

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

        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            using var context = new EstruturaDataBase();

            if (!_isEditMode)
            {
                _cliente = radioButtonPF.Checked ? (Cliente)new ClientePF() : new ClientePJ();
                context.Clientes.Add(_cliente);
            }
            else
            {
                context.Clientes.Attach(_cliente);
                context.Entry(_cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            PreencherCliente(_cliente);
            context.SaveChanges();

            MessageBox.Show(_isEditMode ? "Cliente atualizado com sucesso!" : "Cliente adicionado com sucesso!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
