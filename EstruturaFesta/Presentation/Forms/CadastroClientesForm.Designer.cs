namespace EstruturaFesta
{
    partial class CadastroClientesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            radioButtonPF = new RadioButton();
            groupBoxTipoCliente = new GroupBox();
            radioButtonPJ = new RadioButton();
            panelCadastroPJ = new Panel();
            InscricaoMunicipal = new Label();
            designTextBoxInscricaoMunicipal = new Design.DesignTextBox();
            designTextBoxInscricaoEstadual = new Design.DesignTextBox();
            designTextBoxNomeFantasia = new Design.DesignTextBox();
            designTextBoxRazaoSocial = new Design.DesignTextBox();
            designTextBoxCNPJ = new Design.DesignTextBox();
            labelInscricaoEstadual = new Label();
            labelNomeFantasia = new Label();
            labelCNPJ = new Label();
            RazaoSocial = new Label();
            panelCadastroPF = new Panel();
            designTextBoxNascimento = new Design.DesignTextBox();
            designTextBoxRG = new Design.DesignTextBox();
            designTextBoxCPF = new Design.DesignTextBox();
            designTextBoxNomeMae = new Design.DesignTextBox();
            designTextBoxNomeCliente = new Design.DesignTextBox();
            labelNomeMae = new Label();
            label1 = new Label();
            rg = new Label();
            cpf = new Label();
            nomeCliente = new Label();
            dataGridViewContatos = new DataGridView();
            TelefoneContato = new DataGridViewTextBoxColumn();
            NomeContato = new DataGridViewTextBoxColumn();
            telefone = new Label();
            designTextBoxEstado = new Design.DesignTextBox();
            designTextBoxComplemento = new Design.DesignTextBox();
            designTextBoxCidade = new Design.DesignTextBox();
            designTextBoxNumero = new Design.DesignTextBox();
            designTextBoxBairro = new Design.DesignTextBox();
            designTextBoxCEP = new Design.DesignTextBox();
            designTextBoxRua = new Design.DesignTextBox();
            Complemento = new Label();
            Rua = new Label();
            Cidade = new Label();
            Numero = new Label();
            Estado = new Label();
            Bairro = new Label();
            CEP = new Label();
            designButtonAdicionarCliente = new Design.DesignButton();
            designButtonExcluirCliente = new Design.DesignButton();
            groupBoxTipoCliente.SuspendLayout();
            panelCadastroPJ.SuspendLayout();
            panelCadastroPF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContatos).BeginInit();
            SuspendLayout();
            // 
            // radioButtonPF
            // 
            radioButtonPF.AutoSize = true;
            radioButtonPF.Checked = true;
            radioButtonPF.Location = new Point(6, 22);
            radioButtonPF.Name = "radioButtonPF";
            radioButtonPF.Size = new Size(93, 19);
            radioButtonPF.TabIndex = 0;
            radioButtonPF.TabStop = true;
            radioButtonPF.Text = "Pessoa Física";
            radioButtonPF.UseVisualStyleBackColor = true;
            radioButtonPF.CheckedChanged += radioButtonPF_CheckedChanged;
            // 
            // groupBoxTipoCliente
            // 
            groupBoxTipoCliente.Controls.Add(radioButtonPJ);
            groupBoxTipoCliente.Controls.Add(radioButtonPF);
            groupBoxTipoCliente.Location = new Point(24, 50);
            groupBoxTipoCliente.Name = "groupBoxTipoCliente";
            groupBoxTipoCliente.Size = new Size(112, 90);
            groupBoxTipoCliente.TabIndex = 0;
            groupBoxTipoCliente.TabStop = false;
            groupBoxTipoCliente.Text = "Tipo do Cliente";
            // 
            // radioButtonPJ
            // 
            radioButtonPJ.AutoSize = true;
            radioButtonPJ.Location = new Point(6, 51);
            radioButtonPJ.Name = "radioButtonPJ";
            radioButtonPJ.Size = new Size(104, 19);
            radioButtonPJ.TabIndex = 0;
            radioButtonPJ.Text = "Pessoa Jurídica";
            radioButtonPJ.UseVisualStyleBackColor = true;
            radioButtonPJ.CheckedChanged += radioButtonPJ_CheckedChanged;
            // 
            // panelCadastroPJ
            // 
            panelCadastroPJ.Controls.Add(InscricaoMunicipal);
            panelCadastroPJ.Controls.Add(designTextBoxInscricaoMunicipal);
            panelCadastroPJ.Controls.Add(designTextBoxInscricaoEstadual);
            panelCadastroPJ.Controls.Add(designTextBoxNomeFantasia);
            panelCadastroPJ.Controls.Add(designTextBoxRazaoSocial);
            panelCadastroPJ.Controls.Add(designTextBoxCNPJ);
            panelCadastroPJ.Controls.Add(labelInscricaoEstadual);
            panelCadastroPJ.Controls.Add(labelNomeFantasia);
            panelCadastroPJ.Controls.Add(labelCNPJ);
            panelCadastroPJ.Controls.Add(RazaoSocial);
            panelCadastroPJ.Location = new Point(189, 12);
            panelCadastroPJ.Name = "panelCadastroPJ";
            panelCadastroPJ.Size = new Size(849, 186);
            panelCadastroPJ.TabIndex = 27;
            panelCadastroPJ.Visible = false;
            // 
            // InscricaoMunicipal
            // 
            InscricaoMunicipal.AutoSize = true;
            InscricaoMunicipal.Location = new Point(416, 67);
            InscricaoMunicipal.Name = "InscricaoMunicipal";
            InscricaoMunicipal.Size = new Size(110, 15);
            InscricaoMunicipal.TabIndex = 0;
            InscricaoMunicipal.Text = "Inscrição Municipal";
            // 
            // designTextBoxInscricaoMunicipal
            // 
            designTextBoxInscricaoMunicipal.BackColor = SystemColors.Window;
            designTextBoxInscricaoMunicipal.BorderColor = Color.MediumSlateBlue;
            designTextBoxInscricaoMunicipal.BorderFocusColor = Color.HotPink;
            designTextBoxInscricaoMunicipal.BorderRadius = 15;
            designTextBoxInscricaoMunicipal.BorderSize = 1;
            designTextBoxInscricaoMunicipal.CharacterCasing = CharacterCasing.Normal;
            designTextBoxInscricaoMunicipal.Font = new Font("Segoe UI", 9.5F);
            designTextBoxInscricaoMunicipal.ForceUpperCase = false;
            designTextBoxInscricaoMunicipal.ForeColor = SystemColors.WindowText;
            designTextBoxInscricaoMunicipal.Location = new Point(532, 59);
            designTextBoxInscricaoMunicipal.Multiline = false;
            designTextBoxInscricaoMunicipal.Name = "designTextBoxInscricaoMunicipal";
            designTextBoxInscricaoMunicipal.Padding = new Padding(10, 7, 10, 7);
            designTextBoxInscricaoMunicipal.PasswordChar = false;
            designTextBoxInscricaoMunicipal.PlaceholderColor = Color.DarkGray;
            designTextBoxInscricaoMunicipal.PlaceholderText = "Nome do Cliente";
            designTextBoxInscricaoMunicipal.ReadOnly = false;
            designTextBoxInscricaoMunicipal.SelectionLength = 0;
            designTextBoxInscricaoMunicipal.SelectionStart = 0;
            designTextBoxInscricaoMunicipal.Size = new Size(170, 32);
            designTextBoxInscricaoMunicipal.TabIndex = 1;
            designTextBoxInscricaoMunicipal.UnderlinedStyle = false;
            // 
            // designTextBoxInscricaoEstadual
            // 
            designTextBoxInscricaoEstadual.BackColor = SystemColors.Window;
            designTextBoxInscricaoEstadual.BorderColor = Color.MediumSlateBlue;
            designTextBoxInscricaoEstadual.BorderFocusColor = Color.HotPink;
            designTextBoxInscricaoEstadual.BorderRadius = 15;
            designTextBoxInscricaoEstadual.BorderSize = 1;
            designTextBoxInscricaoEstadual.CharacterCasing = CharacterCasing.Normal;
            designTextBoxInscricaoEstadual.Font = new Font("Segoe UI", 9.5F);
            designTextBoxInscricaoEstadual.ForceUpperCase = false;
            designTextBoxInscricaoEstadual.ForeColor = SystemColors.WindowText;
            designTextBoxInscricaoEstadual.Location = new Point(532, 21);
            designTextBoxInscricaoEstadual.Multiline = false;
            designTextBoxInscricaoEstadual.Name = "designTextBoxInscricaoEstadual";
            designTextBoxInscricaoEstadual.Padding = new Padding(10, 7, 10, 7);
            designTextBoxInscricaoEstadual.PasswordChar = false;
            designTextBoxInscricaoEstadual.PlaceholderColor = Color.DarkGray;
            designTextBoxInscricaoEstadual.PlaceholderText = "Nome do Cliente";
            designTextBoxInscricaoEstadual.ReadOnly = false;
            designTextBoxInscricaoEstadual.SelectionLength = 0;
            designTextBoxInscricaoEstadual.SelectionStart = 0;
            designTextBoxInscricaoEstadual.Size = new Size(170, 32);
            designTextBoxInscricaoEstadual.TabIndex = 1;
            designTextBoxInscricaoEstadual.UnderlinedStyle = false;
            designTextBoxInscricaoEstadual._TextChanged += designTextBoxInscricaoEstadual__TextChanged;
            // 
            // designTextBoxNomeFantasia
            // 
            designTextBoxNomeFantasia.BackColor = SystemColors.Window;
            designTextBoxNomeFantasia.BorderColor = Color.MediumSlateBlue;
            designTextBoxNomeFantasia.BorderFocusColor = Color.HotPink;
            designTextBoxNomeFantasia.BorderRadius = 15;
            designTextBoxNomeFantasia.BorderSize = 1;
            designTextBoxNomeFantasia.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNomeFantasia.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNomeFantasia.ForceUpperCase = true;
            designTextBoxNomeFantasia.ForeColor = SystemColors.WindowText;
            designTextBoxNomeFantasia.Location = new Point(108, 102);
            designTextBoxNomeFantasia.Multiline = false;
            designTextBoxNomeFantasia.Name = "designTextBoxNomeFantasia";
            designTextBoxNomeFantasia.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNomeFantasia.PasswordChar = false;
            designTextBoxNomeFantasia.PlaceholderColor = Color.DarkGray;
            designTextBoxNomeFantasia.PlaceholderText = "Nome Fantasia da Empresa";
            designTextBoxNomeFantasia.ReadOnly = false;
            designTextBoxNomeFantasia.SelectionLength = 0;
            designTextBoxNomeFantasia.SelectionStart = 0;
            designTextBoxNomeFantasia.Size = new Size(265, 32);
            designTextBoxNomeFantasia.TabIndex = 1;
            designTextBoxNomeFantasia.UnderlinedStyle = false;
            // 
            // designTextBoxRazaoSocial
            // 
            designTextBoxRazaoSocial.BackColor = SystemColors.Window;
            designTextBoxRazaoSocial.BorderColor = Color.MediumSlateBlue;
            designTextBoxRazaoSocial.BorderFocusColor = Color.HotPink;
            designTextBoxRazaoSocial.BorderRadius = 15;
            designTextBoxRazaoSocial.BorderSize = 1;
            designTextBoxRazaoSocial.CharacterCasing = CharacterCasing.Normal;
            designTextBoxRazaoSocial.Font = new Font("Segoe UI", 9.5F);
            designTextBoxRazaoSocial.ForceUpperCase = true;
            designTextBoxRazaoSocial.ForeColor = SystemColors.WindowText;
            designTextBoxRazaoSocial.Location = new Point(108, 59);
            designTextBoxRazaoSocial.Multiline = false;
            designTextBoxRazaoSocial.Name = "designTextBoxRazaoSocial";
            designTextBoxRazaoSocial.Padding = new Padding(10, 7, 10, 7);
            designTextBoxRazaoSocial.PasswordChar = false;
            designTextBoxRazaoSocial.PlaceholderColor = Color.DarkGray;
            designTextBoxRazaoSocial.PlaceholderText = "Razão Social";
            designTextBoxRazaoSocial.ReadOnly = false;
            designTextBoxRazaoSocial.SelectionLength = 0;
            designTextBoxRazaoSocial.SelectionStart = 0;
            designTextBoxRazaoSocial.Size = new Size(265, 32);
            designTextBoxRazaoSocial.TabIndex = 1;
            designTextBoxRazaoSocial.UnderlinedStyle = false;
            // 
            // designTextBoxCNPJ
            // 
            designTextBoxCNPJ.BackColor = SystemColors.Window;
            designTextBoxCNPJ.BorderColor = Color.MediumSlateBlue;
            designTextBoxCNPJ.BorderFocusColor = Color.HotPink;
            designTextBoxCNPJ.BorderRadius = 15;
            designTextBoxCNPJ.BorderSize = 1;
            designTextBoxCNPJ.CharacterCasing = CharacterCasing.Normal;
            designTextBoxCNPJ.Font = new Font("Segoe UI", 9.5F);
            designTextBoxCNPJ.ForceUpperCase = false;
            designTextBoxCNPJ.ForeColor = SystemColors.WindowText;
            designTextBoxCNPJ.Location = new Point(108, 21);
            designTextBoxCNPJ.Multiline = false;
            designTextBoxCNPJ.Name = "designTextBoxCNPJ";
            designTextBoxCNPJ.Padding = new Padding(10, 7, 10, 7);
            designTextBoxCNPJ.PasswordChar = false;
            designTextBoxCNPJ.PlaceholderColor = Color.DarkGray;
            designTextBoxCNPJ.PlaceholderText = "CNPJ da empresa";
            designTextBoxCNPJ.ReadOnly = false;
            designTextBoxCNPJ.SelectionLength = 0;
            designTextBoxCNPJ.SelectionStart = 0;
            designTextBoxCNPJ.Size = new Size(158, 32);
            designTextBoxCNPJ.TabIndex = 1;
            designTextBoxCNPJ.UnderlinedStyle = false;
            designTextBoxCNPJ._TextChanged += designTextBoxCNPJ__TextChanged;
            // 
            // labelInscricaoEstadual
            // 
            labelInscricaoEstadual.AutoSize = true;
            labelInscricaoEstadual.Location = new Point(425, 28);
            labelInscricaoEstadual.Name = "labelInscricaoEstadual";
            labelInscricaoEstadual.Size = new Size(101, 15);
            labelInscricaoEstadual.TabIndex = 0;
            labelInscricaoEstadual.Text = "Inscrição Estadual";
            // 
            // labelNomeFantasia
            // 
            labelNomeFantasia.AutoSize = true;
            labelNomeFantasia.Location = new Point(17, 111);
            labelNomeFantasia.Name = "labelNomeFantasia";
            labelNomeFantasia.Size = new Size(86, 15);
            labelNomeFantasia.TabIndex = 0;
            labelNomeFantasia.Text = "Nome Fantasia";
            // 
            // labelCNPJ
            // 
            labelCNPJ.AutoSize = true;
            labelCNPJ.Location = new Point(70, 28);
            labelCNPJ.Name = "labelCNPJ";
            labelCNPJ.Size = new Size(34, 15);
            labelCNPJ.TabIndex = 2;
            labelCNPJ.Text = "CNPJ";
            // 
            // RazaoSocial
            // 
            RazaoSocial.AutoSize = true;
            RazaoSocial.Location = new Point(31, 67);
            RazaoSocial.Name = "RazaoSocial";
            RazaoSocial.Size = new Size(72, 15);
            RazaoSocial.TabIndex = 0;
            RazaoSocial.Text = "Razão Social";
            // 
            // panelCadastroPF
            // 
            panelCadastroPF.Controls.Add(designTextBoxNascimento);
            panelCadastroPF.Controls.Add(designTextBoxRG);
            panelCadastroPF.Controls.Add(designTextBoxCPF);
            panelCadastroPF.Controls.Add(designTextBoxNomeMae);
            panelCadastroPF.Controls.Add(designTextBoxNomeCliente);
            panelCadastroPF.Controls.Add(labelNomeMae);
            panelCadastroPF.Controls.Add(label1);
            panelCadastroPF.Controls.Add(rg);
            panelCadastroPF.Controls.Add(cpf);
            panelCadastroPF.Controls.Add(nomeCliente);
            panelCadastroPF.Location = new Point(189, 12);
            panelCadastroPF.Name = "panelCadastroPF";
            panelCadastroPF.Size = new Size(849, 186);
            panelCadastroPF.TabIndex = 28;
            // 
            // designTextBoxNascimento
            // 
            designTextBoxNascimento.BackColor = SystemColors.Window;
            designTextBoxNascimento.BorderColor = Color.MediumSlateBlue;
            designTextBoxNascimento.BorderFocusColor = Color.HotPink;
            designTextBoxNascimento.BorderRadius = 15;
            designTextBoxNascimento.BorderSize = 1;
            designTextBoxNascimento.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNascimento.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNascimento.ForceUpperCase = false;
            designTextBoxNascimento.ForeColor = SystemColors.WindowText;
            designTextBoxNascimento.Location = new Point(604, 32);
            designTextBoxNascimento.Multiline = false;
            designTextBoxNascimento.Name = "designTextBoxNascimento";
            designTextBoxNascimento.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNascimento.PasswordChar = false;
            designTextBoxNascimento.PlaceholderColor = Color.DarkGray;
            designTextBoxNascimento.PlaceholderText = "Data";
            designTextBoxNascimento.ReadOnly = false;
            designTextBoxNascimento.SelectionLength = 0;
            designTextBoxNascimento.SelectionStart = 0;
            designTextBoxNascimento.Size = new Size(98, 32);
            designTextBoxNascimento.TabIndex = 51;
            designTextBoxNascimento.UnderlinedStyle = false;
            designTextBoxNascimento._TextChanged += designTextBoxNascimento__TextChanged;
            // 
            // designTextBoxRG
            // 
            designTextBoxRG.BackColor = SystemColors.Window;
            designTextBoxRG.BorderColor = Color.MediumSlateBlue;
            designTextBoxRG.BorderFocusColor = Color.HotPink;
            designTextBoxRG.BorderRadius = 15;
            designTextBoxRG.BorderSize = 1;
            designTextBoxRG.CharacterCasing = CharacterCasing.Normal;
            designTextBoxRG.Font = new Font("Segoe UI", 9.5F);
            designTextBoxRG.ForceUpperCase = false;
            designTextBoxRG.ForeColor = SystemColors.WindowText;
            designTextBoxRG.Location = new Point(302, 76);
            designTextBoxRG.Multiline = false;
            designTextBoxRG.Name = "designTextBoxRG";
            designTextBoxRG.Padding = new Padding(10, 7, 10, 7);
            designTextBoxRG.PasswordChar = false;
            designTextBoxRG.PlaceholderColor = Color.DarkGray;
            designTextBoxRG.PlaceholderText = "RG do Cliente";
            designTextBoxRG.ReadOnly = false;
            designTextBoxRG.SelectionLength = 0;
            designTextBoxRG.SelectionStart = 0;
            designTextBoxRG.Size = new Size(168, 32);
            designTextBoxRG.TabIndex = 3;
            designTextBoxRG.UnderlinedStyle = false;
            designTextBoxRG._TextChanged += designTextBoxRG__TextChanged;
            // 
            // designTextBoxCPF
            // 
            designTextBoxCPF.BackColor = SystemColors.Window;
            designTextBoxCPF.BorderColor = Color.MediumSlateBlue;
            designTextBoxCPF.BorderFocusColor = Color.HotPink;
            designTextBoxCPF.BorderRadius = 15;
            designTextBoxCPF.BorderSize = 1;
            designTextBoxCPF.CharacterCasing = CharacterCasing.Normal;
            designTextBoxCPF.Font = new Font("Segoe UI", 9.5F);
            designTextBoxCPF.ForceUpperCase = false;
            designTextBoxCPF.ForeColor = SystemColors.WindowText;
            designTextBoxCPF.Location = new Point(75, 76);
            designTextBoxCPF.Multiline = false;
            designTextBoxCPF.Name = "designTextBoxCPF";
            designTextBoxCPF.Padding = new Padding(10, 7, 10, 7);
            designTextBoxCPF.PasswordChar = false;
            designTextBoxCPF.PlaceholderColor = Color.DarkGray;
            designTextBoxCPF.PlaceholderText = "CPF do Cliente";
            designTextBoxCPF.ReadOnly = false;
            designTextBoxCPF.SelectionLength = 0;
            designTextBoxCPF.SelectionStart = 0;
            designTextBoxCPF.Size = new Size(175, 32);
            designTextBoxCPF.TabIndex = 2;
            designTextBoxCPF.UnderlinedStyle = false;
            designTextBoxCPF._TextChanged += designTextBoxCPF__TextChanged;
            designTextBoxCPF.Leave += designTextBoxCPF_Leave;
            // 
            // designTextBoxNomeMae
            // 
            designTextBoxNomeMae.BackColor = SystemColors.Window;
            designTextBoxNomeMae.BorderColor = Color.MediumSlateBlue;
            designTextBoxNomeMae.BorderFocusColor = Color.HotPink;
            designTextBoxNomeMae.BorderRadius = 15;
            designTextBoxNomeMae.BorderSize = 1;
            designTextBoxNomeMae.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNomeMae.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNomeMae.ForceUpperCase = true;
            designTextBoxNomeMae.ForeColor = SystemColors.WindowText;
            designTextBoxNomeMae.Location = new Point(75, 137);
            designTextBoxNomeMae.Multiline = false;
            designTextBoxNomeMae.Name = "designTextBoxNomeMae";
            designTextBoxNomeMae.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNomeMae.PasswordChar = false;
            designTextBoxNomeMae.PlaceholderColor = Color.DarkGray;
            designTextBoxNomeMae.PlaceholderText = "Nome da Mãe do Cliente";
            designTextBoxNomeMae.ReadOnly = false;
            designTextBoxNomeMae.SelectionLength = 0;
            designTextBoxNomeMae.SelectionStart = 0;
            designTextBoxNomeMae.Size = new Size(395, 32);
            designTextBoxNomeMae.TabIndex = 4;
            designTextBoxNomeMae.UnderlinedStyle = false;
            // 
            // designTextBoxNomeCliente
            // 
            designTextBoxNomeCliente.BackColor = SystemColors.Window;
            designTextBoxNomeCliente.BorderColor = Color.MediumSlateBlue;
            designTextBoxNomeCliente.BorderFocusColor = Color.HotPink;
            designTextBoxNomeCliente.BorderRadius = 15;
            designTextBoxNomeCliente.BorderSize = 1;
            designTextBoxNomeCliente.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNomeCliente.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNomeCliente.ForceUpperCase = true;
            designTextBoxNomeCliente.ForeColor = SystemColors.WindowText;
            designTextBoxNomeCliente.Location = new Point(75, 32);
            designTextBoxNomeCliente.Multiline = false;
            designTextBoxNomeCliente.Name = "designTextBoxNomeCliente";
            designTextBoxNomeCliente.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNomeCliente.PasswordChar = false;
            designTextBoxNomeCliente.PlaceholderColor = Color.DarkGray;
            designTextBoxNomeCliente.PlaceholderText = "Nome do Cliente";
            designTextBoxNomeCliente.ReadOnly = false;
            designTextBoxNomeCliente.SelectionLength = 0;
            designTextBoxNomeCliente.SelectionStart = 0;
            designTextBoxNomeCliente.Size = new Size(395, 32);
            designTextBoxNomeCliente.TabIndex = 1;
            designTextBoxNomeCliente.UnderlinedStyle = false;
            // 
            // labelNomeMae
            // 
            labelNomeMae.AutoSize = true;
            labelNomeMae.Location = new Point(80, 119);
            labelNomeMae.Name = "labelNomeMae";
            labelNomeMae.Size = new Size(82, 15);
            labelNomeMae.TabIndex = 50;
            labelNomeMae.Text = "Nome da Mãe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 86);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 0;
            label1.Text = "CPF";
            // 
            // rg
            // 
            rg.AutoSize = true;
            rg.Location = new Point(274, 82);
            rg.Name = "rg";
            rg.Size = new Size(22, 15);
            rg.TabIndex = 42;
            rg.Text = "RG";
            // 
            // cpf
            // 
            cpf.AutoSize = true;
            cpf.Location = new Point(486, 38);
            cpf.Name = "cpf";
            cpf.Size = new Size(114, 15);
            cpf.TabIndex = 0;
            cpf.Text = "Data de Nascimento";
            // 
            // nomeCliente
            // 
            nomeCliente.AutoSize = true;
            nomeCliente.Location = new Point(19, 38);
            nomeCliente.Name = "nomeCliente";
            nomeCliente.Size = new Size(40, 15);
            nomeCliente.TabIndex = 0;
            nomeCliente.Text = "Nome";
            // 
            // dataGridViewContatos
            // 
            dataGridViewContatos.BackgroundColor = SystemColors.Control;
            dataGridViewContatos.BorderStyle = BorderStyle.None;
            dataGridViewContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewContatos.Columns.AddRange(new DataGridViewColumn[] { TelefoneContato, NomeContato });
            dataGridViewContatos.Location = new Point(189, 204);
            dataGridViewContatos.Name = "dataGridViewContatos";
            dataGridViewContatos.ScrollBars = ScrollBars.Vertical;
            dataGridViewContatos.Size = new Size(327, 79);
            dataGridViewContatos.TabIndex = 6;
            // 
            // TelefoneContato
            // 
            TelefoneContato.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TelefoneContato.DataPropertyName = "Telefone";
            TelefoneContato.HeaderText = "Telefone";
            TelefoneContato.Name = "TelefoneContato";
            // 
            // NomeContato
            // 
            NomeContato.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomeContato.DataPropertyName = "NomeContato";
            NomeContato.HeaderText = "Nome";
            NomeContato.Name = "NomeContato";
            // 
            // telefone
            // 
            telefone.AutoSize = true;
            telefone.Location = new Point(132, 214);
            telefone.Name = "telefone";
            telefone.Size = new Size(51, 15);
            telefone.TabIndex = 0;
            telefone.Text = "Telefone";
            // 
            // designTextBoxEstado
            // 
            designTextBoxEstado.BackColor = SystemColors.Window;
            designTextBoxEstado.BorderColor = Color.MediumSlateBlue;
            designTextBoxEstado.BorderFocusColor = Color.HotPink;
            designTextBoxEstado.BorderRadius = 15;
            designTextBoxEstado.BorderSize = 1;
            designTextBoxEstado.CharacterCasing = CharacterCasing.Normal;
            designTextBoxEstado.Font = new Font("Segoe UI", 9.5F);
            designTextBoxEstado.ForceUpperCase = false;
            designTextBoxEstado.ForeColor = SystemColors.WindowText;
            designTextBoxEstado.Location = new Point(260, 407);
            designTextBoxEstado.Multiline = false;
            designTextBoxEstado.Name = "designTextBoxEstado";
            designTextBoxEstado.Padding = new Padding(10, 7, 10, 7);
            designTextBoxEstado.PasswordChar = false;
            designTextBoxEstado.PlaceholderColor = Color.DarkGray;
            designTextBoxEstado.PlaceholderText = "Estado";
            designTextBoxEstado.ReadOnly = false;
            designTextBoxEstado.SelectionLength = 0;
            designTextBoxEstado.SelectionStart = 0;
            designTextBoxEstado.Size = new Size(106, 32);
            designTextBoxEstado.TabIndex = 10;
            designTextBoxEstado.UnderlinedStyle = false;
            // 
            // designTextBoxComplemento
            // 
            designTextBoxComplemento.BackColor = SystemColors.Window;
            designTextBoxComplemento.BorderColor = Color.MediumSlateBlue;
            designTextBoxComplemento.BorderFocusColor = Color.HotPink;
            designTextBoxComplemento.BorderRadius = 15;
            designTextBoxComplemento.BorderSize = 1;
            designTextBoxComplemento.CharacterCasing = CharacterCasing.Normal;
            designTextBoxComplemento.Font = new Font("Segoe UI", 9.5F);
            designTextBoxComplemento.ForceUpperCase = false;
            designTextBoxComplemento.ForeColor = SystemColors.WindowText;
            designTextBoxComplemento.Location = new Point(461, 407);
            designTextBoxComplemento.Multiline = false;
            designTextBoxComplemento.Name = "designTextBoxComplemento";
            designTextBoxComplemento.Padding = new Padding(10, 7, 10, 7);
            designTextBoxComplemento.PasswordChar = false;
            designTextBoxComplemento.PlaceholderColor = Color.DarkGray;
            designTextBoxComplemento.PlaceholderText = "Complemento";
            designTextBoxComplemento.ReadOnly = false;
            designTextBoxComplemento.SelectionLength = 0;
            designTextBoxComplemento.SelectionStart = 0;
            designTextBoxComplemento.Size = new Size(242, 32);
            designTextBoxComplemento.TabIndex = 13;
            designTextBoxComplemento.UnderlinedStyle = false;
            // 
            // designTextBoxCidade
            // 
            designTextBoxCidade.BackColor = SystemColors.Window;
            designTextBoxCidade.BorderColor = Color.MediumSlateBlue;
            designTextBoxCidade.BorderFocusColor = Color.HotPink;
            designTextBoxCidade.BorderRadius = 15;
            designTextBoxCidade.BorderSize = 1;
            designTextBoxCidade.CharacterCasing = CharacterCasing.Normal;
            designTextBoxCidade.Font = new Font("Segoe UI", 9.5F);
            designTextBoxCidade.ForceUpperCase = false;
            designTextBoxCidade.ForeColor = SystemColors.WindowText;
            designTextBoxCidade.Location = new Point(577, 364);
            designTextBoxCidade.Multiline = false;
            designTextBoxCidade.Name = "designTextBoxCidade";
            designTextBoxCidade.Padding = new Padding(10, 7, 10, 7);
            designTextBoxCidade.PasswordChar = false;
            designTextBoxCidade.PlaceholderColor = Color.DarkGray;
            designTextBoxCidade.PlaceholderText = "Cidade";
            designTextBoxCidade.ReadOnly = false;
            designTextBoxCidade.SelectionLength = 0;
            designTextBoxCidade.SelectionStart = 0;
            designTextBoxCidade.Size = new Size(126, 32);
            designTextBoxCidade.TabIndex = 12;
            designTextBoxCidade.UnderlinedStyle = false;
            // 
            // designTextBoxNumero
            // 
            designTextBoxNumero.BackColor = SystemColors.Window;
            designTextBoxNumero.BorderColor = Color.MediumSlateBlue;
            designTextBoxNumero.BorderFocusColor = Color.HotPink;
            designTextBoxNumero.BorderRadius = 15;
            designTextBoxNumero.BorderSize = 1;
            designTextBoxNumero.CharacterCasing = CharacterCasing.Normal;
            designTextBoxNumero.Font = new Font("Segoe UI", 9.5F);
            designTextBoxNumero.ForceUpperCase = false;
            designTextBoxNumero.ForeColor = SystemColors.WindowText;
            designTextBoxNumero.Location = new Point(616, 326);
            designTextBoxNumero.Multiline = false;
            designTextBoxNumero.Name = "designTextBoxNumero";
            designTextBoxNumero.Padding = new Padding(10, 7, 10, 7);
            designTextBoxNumero.PasswordChar = false;
            designTextBoxNumero.PlaceholderColor = Color.DarkGray;
            designTextBoxNumero.PlaceholderText = "Numero";
            designTextBoxNumero.ReadOnly = false;
            designTextBoxNumero.SelectionLength = 0;
            designTextBoxNumero.SelectionStart = 0;
            designTextBoxNumero.Size = new Size(87, 32);
            designTextBoxNumero.TabIndex = 11;
            designTextBoxNumero.UnderlinedStyle = false;
            designTextBoxNumero._TextChanged += designTextBoxNumero__TextChanged;
            // 
            // designTextBoxBairro
            // 
            designTextBoxBairro.BackColor = SystemColors.Window;
            designTextBoxBairro.BorderColor = Color.MediumSlateBlue;
            designTextBoxBairro.BorderFocusColor = Color.HotPink;
            designTextBoxBairro.BorderRadius = 15;
            designTextBoxBairro.BorderSize = 1;
            designTextBoxBairro.CharacterCasing = CharacterCasing.Normal;
            designTextBoxBairro.Font = new Font("Segoe UI", 9.5F);
            designTextBoxBairro.ForceUpperCase = false;
            designTextBoxBairro.ForeColor = SystemColors.WindowText;
            designTextBoxBairro.Location = new Point(261, 364);
            designTextBoxBairro.Multiline = false;
            designTextBoxBairro.Name = "designTextBoxBairro";
            designTextBoxBairro.Padding = new Padding(10, 7, 10, 7);
            designTextBoxBairro.PasswordChar = false;
            designTextBoxBairro.PlaceholderColor = Color.DarkGray;
            designTextBoxBairro.PlaceholderText = "Nome do Bairro";
            designTextBoxBairro.ReadOnly = false;
            designTextBoxBairro.SelectionLength = 0;
            designTextBoxBairro.SelectionStart = 0;
            designTextBoxBairro.Size = new Size(226, 32);
            designTextBoxBairro.TabIndex = 9;
            designTextBoxBairro.UnderlinedStyle = false;
            // 
            // designTextBoxCEP
            // 
            designTextBoxCEP.BackColor = SystemColors.Window;
            designTextBoxCEP.BorderColor = Color.MediumSlateBlue;
            designTextBoxCEP.BorderFocusColor = Color.HotPink;
            designTextBoxCEP.BorderRadius = 15;
            designTextBoxCEP.BorderSize = 1;
            designTextBoxCEP.CharacterCasing = CharacterCasing.Normal;
            designTextBoxCEP.Font = new Font("Segoe UI", 9.5F);
            designTextBoxCEP.ForceUpperCase = false;
            designTextBoxCEP.ForeColor = SystemColors.WindowText;
            designTextBoxCEP.Location = new Point(83, 324);
            designTextBoxCEP.Multiline = false;
            designTextBoxCEP.Name = "designTextBoxCEP";
            designTextBoxCEP.Padding = new Padding(10, 7, 10, 7);
            designTextBoxCEP.PasswordChar = false;
            designTextBoxCEP.PlaceholderColor = Color.DarkGray;
            designTextBoxCEP.PlaceholderText = "CEP";
            designTextBoxCEP.ReadOnly = false;
            designTextBoxCEP.SelectionLength = 0;
            designTextBoxCEP.SelectionStart = 0;
            designTextBoxCEP.Size = new Size(109, 32);
            designTextBoxCEP.TabIndex = 7;
            designTextBoxCEP.UnderlinedStyle = false;
            designTextBoxCEP.KeyDown += designTextBoxCEP_KeyDown;
            designTextBoxCEP.Leave += designTextBoxCEP_Leave;
            // 
            // designTextBoxRua
            // 
            designTextBoxRua.BackColor = SystemColors.Window;
            designTextBoxRua.BorderColor = Color.MediumSlateBlue;
            designTextBoxRua.BorderFocusColor = Color.HotPink;
            designTextBoxRua.BorderRadius = 15;
            designTextBoxRua.BorderSize = 1;
            designTextBoxRua.CharacterCasing = CharacterCasing.Normal;
            designTextBoxRua.Font = new Font("Segoe UI", 9.5F);
            designTextBoxRua.ForceUpperCase = false;
            designTextBoxRua.ForeColor = SystemColors.WindowText;
            designTextBoxRua.Location = new Point(264, 324);
            designTextBoxRua.Multiline = false;
            designTextBoxRua.Name = "designTextBoxRua";
            designTextBoxRua.Padding = new Padding(10, 7, 10, 7);
            designTextBoxRua.PasswordChar = false;
            designTextBoxRua.PlaceholderColor = Color.DarkGray;
            designTextBoxRua.PlaceholderText = "Nome da Rua";
            designTextBoxRua.ReadOnly = false;
            designTextBoxRua.SelectionLength = 0;
            designTextBoxRua.SelectionStart = 0;
            designTextBoxRua.Size = new Size(272, 32);
            designTextBoxRua.TabIndex = 8;
            designTextBoxRua.UnderlinedStyle = false;
            // 
            // Complemento
            // 
            Complemento.AutoSize = true;
            Complemento.Location = new Point(371, 416);
            Complemento.Name = "Complemento";
            Complemento.Size = new Size(84, 15);
            Complemento.TabIndex = 0;
            Complemento.Text = "Complemento";
            // 
            // Rua
            // 
            Rua.AutoSize = true;
            Rua.Location = new Point(224, 333);
            Rua.Name = "Rua";
            Rua.Size = new Size(27, 15);
            Rua.TabIndex = 0;
            Rua.Text = "Rua";
            // 
            // Cidade
            // 
            Cidade.AutoSize = true;
            Cidade.Location = new Point(525, 372);
            Cidade.Name = "Cidade";
            Cidade.Size = new Size(44, 15);
            Cidade.TabIndex = 0;
            Cidade.Text = "Cidade";
            // 
            // Numero
            // 
            Numero.AutoSize = true;
            Numero.Location = new Point(563, 333);
            Numero.Name = "Numero";
            Numero.Size = new Size(51, 15);
            Numero.TabIndex = 0;
            Numero.Text = "Numero";
            // 
            // Estado
            // 
            Estado.AutoSize = true;
            Estado.Location = new Point(211, 416);
            Estado.Name = "Estado";
            Estado.Size = new Size(42, 15);
            Estado.TabIndex = 0;
            Estado.Text = "Estado";
            // 
            // Bairro
            // 
            Bairro.AutoSize = true;
            Bairro.Location = new Point(215, 372);
            Bairro.Name = "Bairro";
            Bairro.Size = new Size(38, 15);
            Bairro.TabIndex = 0;
            Bairro.Text = "Bairro";
            // 
            // CEP
            // 
            CEP.AutoSize = true;
            CEP.Location = new Point(55, 333);
            CEP.Name = "CEP";
            CEP.Size = new Size(28, 15);
            CEP.TabIndex = 0;
            CEP.Text = "CEP";
            // 
            // designButtonAdicionarCliente
            // 
            designButtonAdicionarCliente.BackColor = Color.LimeGreen;
            designButtonAdicionarCliente.BackgroundColor = Color.LimeGreen;
            designButtonAdicionarCliente.BorderColor = Color.LightGreen;
            designButtonAdicionarCliente.BorderRadius = 29;
            designButtonAdicionarCliente.BorderSize = 0;
            designButtonAdicionarCliente.FlatAppearance.BorderSize = 0;
            designButtonAdicionarCliente.FlatStyle = FlatStyle.Flat;
            designButtonAdicionarCliente.ForeColor = Color.White;
            designButtonAdicionarCliente.Location = new Point(774, 395);
            designButtonAdicionarCliente.Name = "designButtonAdicionarCliente";
            designButtonAdicionarCliente.Size = new Size(169, 55);
            designButtonAdicionarCliente.TabIndex = 14;
            designButtonAdicionarCliente.Text = "Adicionar Cliente";
            designButtonAdicionarCliente.TextColor = Color.White;
            designButtonAdicionarCliente.UseVisualStyleBackColor = false;
            designButtonAdicionarCliente.Click += designButtonAdicionarCliente_Click;
            // 
            // designButtonExcluirCliente
            // 
            designButtonExcluirCliente.BackColor = Color.Red;
            designButtonExcluirCliente.BackgroundColor = Color.Red;
            designButtonExcluirCliente.BorderColor = Color.Red;
            designButtonExcluirCliente.BorderRadius = 29;
            designButtonExcluirCliente.BorderSize = 0;
            designButtonExcluirCliente.FlatAppearance.BorderSize = 0;
            designButtonExcluirCliente.FlatStyle = FlatStyle.Flat;
            designButtonExcluirCliente.ForeColor = Color.White;
            designButtonExcluirCliente.Location = new Point(774, 324);
            designButtonExcluirCliente.Name = "designButtonExcluirCliente";
            designButtonExcluirCliente.Size = new Size(169, 55);
            designButtonExcluirCliente.TabIndex = 0;
            designButtonExcluirCliente.Text = "Excluir Cliente";
            designButtonExcluirCliente.TextColor = Color.White;
            designButtonExcluirCliente.UseVisualStyleBackColor = false;
            designButtonExcluirCliente.Click += designButtonExcluirCliente_Click;
            // 
            // CadastroClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 523);
            Controls.Add(designButtonExcluirCliente);
            Controls.Add(designButtonAdicionarCliente);
            Controls.Add(groupBoxTipoCliente);
            Controls.Add(CEP);
            Controls.Add(Bairro);
            Controls.Add(dataGridViewContatos);
            Controls.Add(Estado);
            Controls.Add(telefone);
            Controls.Add(Numero);
            Controls.Add(Cidade);
            Controls.Add(Rua);
            Controls.Add(designTextBoxCidade);
            Controls.Add(Complemento);
            Controls.Add(designTextBoxEstado);
            Controls.Add(designTextBoxRua);
            Controls.Add(designTextBoxComplemento);
            Controls.Add(designTextBoxCEP);
            Controls.Add(designTextBoxNumero);
            Controls.Add(designTextBoxBairro);
            Controls.Add(panelCadastroPJ);
            Controls.Add(panelCadastroPF);
            Name = "CadastroClientesForm";
            Text = "Cadastro de Clientes";
            Load += CadastroClientesForm_Load;
            groupBoxTipoCliente.ResumeLayout(false);
            groupBoxTipoCliente.PerformLayout();
            panelCadastroPJ.ResumeLayout(false);
            panelCadastroPJ.PerformLayout();
            panelCadastroPF.ResumeLayout(false);
            panelCadastroPF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton radioButtonPF;
        private GroupBox groupBoxTipoCliente;
        private RadioButton radioButtonPJ;
        private Panel panelCadastroPF;
        private DataGridView dataGridViewContatos;
        private Label label1;
        private Label telefone;
        private Label rg;
        private Label cpf;
        private Label nomeCliente;
        private Panel panelCadastroPJ;
        private Label RazaoSocial;
        private Label labelNomeFantasia;
        private Label labelCNPJ;
        private Label InscricaoMunicipal;
        private Label labelInscricaoEstadual;
        private Label AdicionarCliente;
        private Label labelNomeMae;
        private DataGridViewTextBoxColumn TelefoneContato;
        private DataGridViewTextBoxColumn NomeContato;
        private Design.DesignTextBox designTextBoxNomeCliente;
        private Design.DesignTextBox designTextBoxCPF;
        private Design.DesignTextBox designTextBoxRG;
        private Design.DesignTextBox designTextBoxNomeMae;
        private Design.DesignTextBox designTextBoxEstado;
        private Design.DesignTextBox designTextBoxComplemento;
        private Design.DesignTextBox designTextBoxCidade;
        private Design.DesignTextBox designTextBoxNumero;
        private Design.DesignTextBox designTextBoxBairro;
        private Design.DesignTextBox designTextBoxCEP;
        private Design.DesignTextBox designTextBoxRua;
        private Label Complemento;
        private Label Rua;
        private Label Cidade;
        private Label Numero;
        private Label Estado;
        private Label Bairro;
        private Label CEP;
        private Design.DesignButton designButtonAdicionarCliente;
        private Design.DesignButton designButtonExcluirCliente;
        private Design.DesignTextBox designTextBoxInscricaoMunicipal;
        private Design.DesignTextBox designTextBoxInscricaoEstadual;
        private Design.DesignTextBox designTextBoxNomeFantasia;
        private Design.DesignTextBox designTextBoxRazaoSocial;
        private Design.DesignTextBox designTextBoxCNPJ;
        private Design.DesignTextBox designTextBoxNascimento;
    }
}