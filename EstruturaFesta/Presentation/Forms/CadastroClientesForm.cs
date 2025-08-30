using ViaCep;
using EstruturaFesta.Infrastructure.Data;
using EstruturaFesta.Domain.Entities;

namespace EstruturaFesta
{
    public partial class CadastroClientesForm : Form
    {
        private readonly ViaCepClient _viaCepClient;
        public CadastroClientesForm()
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
            _viaCepClient = new ViaCepClient(httpClient);
        }
        //CPF
        private void textBoxCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //CEP
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
                MessageBox.Show("O numero não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNumero.Focus(); // Redefine o foco para a TextBox
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
        //Adicionar Clientes
        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            using (var context = new EstruturaDataBase())
            {
                if (radioButtonPF.Checked)
                {
                    var cliente = new ClientePF
                    {
                        Nome = textBoxNomeCliente.Text,
                        CPF = textBoxCPF.Text,
                        RG = textBoxRG.Text,
                        DataNascimento = DateTime.Parse(maskedTextBoxNascimento.Text),
                        Contatos = new List<Contato>(),
                        Rua = textBoxRua.Text,
                        Bairro = textBoxBairro.Text,
                        Numero = int.Parse(textBoxNumero.Text),
                        CEP = textBoxCEP.Text,
                        Estado = textBoxEstado.Text,
                        Cidade = textBoxCidade.Text,
                        Complemento = textBoxComplemento.Text,

                    };
                    context.Clientes.Add(cliente);

                    foreach (DataGridViewRow row in dataGridViewContatos.Rows)
                    {
                        if (row.Cells["NomeContato"].Value != null && row.Cells["TelefoneContato"].Value != null)
                        {
                            var contato = new Contato
                            {
                                NomeContato = row.Cells["NomeContato"].Value.ToString(),
                                Telefone = row.Cells["TelefoneContato"].Value.ToString()
                            };
                            cliente.Contatos.Add(contato);
                        }
                    }
                }
                if (radioButtonPJ.Checked)
                {
                    // Criar uma instância do cliente PJ
                    var clientePJ = new ClientePJ
                    {
                        NomeFantasia = textBoxNomeFantasia.Text,
                        CNPJ = textBoxCNPJ.Text,
                        RazaoSocial = textBoxRazaoSocial.Text,
                        InscricaoEstadual = textBoxInscricaoEstadual.Text,
                        InscricaoMunicipal = textBoxInscricaoMunicipal.Text,
                        Contatos = new List<Contato>(), // Inicializar a lista de contatos
                        Rua = textBoxRua.Text,
                        Bairro = textBoxBairro.Text,
                        Numero = int.Parse(textBoxNumero.Text),
                        CEP = textBoxCEP.Text,
                        Estado = textBoxEstado.Text,
                        Cidade = textBoxCidade.Text,
                        Complemento = textBoxComplemento.Text,
                    };

                    context.Clientes.Add(clientePJ);

                    foreach (DataGridViewRow row in dataGridViewContatosPJ.Rows)
                    {
                        if (row.Cells["NomePJ"].Value != null && row.Cells["Contato"].Value != null)
                        {
                            var contato = new Contato
                            {
                                NomeContato = row.Cells["NomePJ"].Value.ToString(),
                                Telefone = row.Cells["Contato"].Value.ToString()
                            };
                            clientePJ.Contatos.Add(contato); // Adicionar o contato à lista
                        }
                    }

                }
                context.SaveChanges();
                MessageBox.Show("Cliente adicionado com sucesso!");
            }
        }

        
    }
}
