namespace EstruturaFesta
{
    partial class CadastroClientes
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
            CEP = new Label();
            textBoxCEP = new TextBox();
            Rua = new Label();
            textBoxRua = new TextBox();
            Numero = new Label();
            textBoxNumero = new TextBox();
            Bairro = new Label();
            textBoxBairro = new TextBox();
            Complemento = new Label();
            textBoxComplemento = new TextBox();
            Cidade = new Label();
            textBoxCidade = new TextBox();
            Estado = new Label();
            textBoxEstado = new TextBox();
            groupBox2 = new GroupBox();
            buttonAdicionarCliente = new Button();
            AdicionarCliente = new Label();
            panelCadastroPJ = new Panel();
            dataGridViewContatosPJ = new DataGridView();
            Contato = new DataGridViewTextBoxColumn();
            NomePJ = new DataGridViewTextBoxColumn();
            labelTelefone = new Label();
            textBoxInscricaoMunicipal = new TextBox();
            InscricaoMunicipal = new Label();
            textBoxInscricaoEstadual = new TextBox();
            labelInscricaoEstadual = new Label();
            textBoxNomeFantasia = new TextBox();
            labelNomeFantasia = new Label();
            textBoxCNPJ = new TextBox();
            labelCNPJ = new Label();
            textBoxRazaoSocial = new TextBox();
            RazaoSocial = new Label();
            panelCadastroPF = new Panel();
            dataGridViewContatos = new DataGridView();
            TelefoneContato = new DataGridViewTextBoxColumn();
            NomeContato = new DataGridViewTextBoxColumn();
            textBoxCPF = new TextBox();
            label1 = new Label();
            telefone = new Label();
            textBoxRG = new TextBox();
            rg = new Label();
            textBoxDataNascimento = new TextBox();
            cpf = new Label();
            textBoxNomeCliente = new TextBox();
            nomeCliente = new Label();
            groupBoxTipoCliente.SuspendLayout();
            groupBox2.SuspendLayout();
            panelCadastroPJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContatosPJ).BeginInit();
            panelCadastroPF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContatos).BeginInit();
            SuspendLayout();
            // 
            // radioButtonPF
            // 
            radioButtonPF.AutoSize = true;
            radioButtonPF.Location = new Point(6, 22);
            radioButtonPF.Name = "radioButtonPF";
            radioButtonPF.Size = new Size(93, 19);
            radioButtonPF.TabIndex = 8;
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
            groupBoxTipoCliente.TabIndex = 9;
            groupBoxTipoCliente.TabStop = false;
            groupBoxTipoCliente.Text = "Tipo do Cliente";
            // 
            // radioButtonPJ
            // 
            radioButtonPJ.AutoSize = true;
            radioButtonPJ.Location = new Point(6, 51);
            radioButtonPJ.Name = "radioButtonPJ";
            radioButtonPJ.Size = new Size(104, 19);
            radioButtonPJ.TabIndex = 10;
            radioButtonPJ.TabStop = true;
            radioButtonPJ.Text = "Pessoa Jurídica";
            radioButtonPJ.UseVisualStyleBackColor = true;
            radioButtonPJ.CheckedChanged += radioButtonPJ_CheckedChanged;
            // 
            // CEP
            // 
            CEP.AutoSize = true;
            CEP.Location = new Point(26, 27);
            CEP.Name = "CEP";
            CEP.Size = new Size(28, 15);
            CEP.TabIndex = 13;
            CEP.Text = "CEP";
            // 
            // textBoxCEP
            // 
            textBoxCEP.Location = new Point(60, 22);
            textBoxCEP.Name = "textBoxCEP";
            textBoxCEP.Size = new Size(100, 23);
            textBoxCEP.TabIndex = 14;
            textBoxCEP.Leave += textBoxCEP_Leave;
            // 
            // Rua
            // 
            Rua.AutoSize = true;
            Rua.Location = new Point(197, 27);
            Rua.Name = "Rua";
            Rua.Size = new Size(27, 15);
            Rua.TabIndex = 15;
            Rua.Text = "Rua";
            // 
            // textBoxRua
            // 
            textBoxRua.Location = new Point(236, 22);
            textBoxRua.Name = "textBoxRua";
            textBoxRua.Size = new Size(271, 23);
            textBoxRua.TabIndex = 16;
            // 
            // Numero
            // 
            Numero.AutoSize = true;
            Numero.Location = new Point(534, 27);
            Numero.Name = "Numero";
            Numero.Size = new Size(51, 15);
            Numero.TabIndex = 17;
            Numero.Text = "Numero";
            // 
            // textBoxNumero
            // 
            textBoxNumero.Location = new Point(591, 24);
            textBoxNumero.Name = "textBoxNumero";
            textBoxNumero.Size = new Size(55, 23);
            textBoxNumero.TabIndex = 18;
            textBoxNumero.TextChanged += textBoxNumero_TextChanged;
            // 
            // Bairro
            // 
            Bairro.AutoSize = true;
            Bairro.Location = new Point(186, 66);
            Bairro.Name = "Bairro";
            Bairro.Size = new Size(38, 15);
            Bairro.TabIndex = 19;
            Bairro.Text = "Bairro";
            // 
            // textBoxBairro
            // 
            textBoxBairro.Location = new Point(236, 63);
            textBoxBairro.Name = "textBoxBairro";
            textBoxBairro.Size = new Size(203, 23);
            textBoxBairro.TabIndex = 20;
            // 
            // Complemento
            // 
            Complemento.AutoSize = true;
            Complemento.Location = new Point(342, 110);
            Complemento.Name = "Complemento";
            Complemento.Size = new Size(84, 15);
            Complemento.TabIndex = 21;
            Complemento.Text = "Complemento";
            // 
            // textBoxComplemento
            // 
            textBoxComplemento.Location = new Point(432, 107);
            textBoxComplemento.Multiline = true;
            textBoxComplemento.Name = "textBoxComplemento";
            textBoxComplemento.Size = new Size(214, 23);
            textBoxComplemento.TabIndex = 22;
            // 
            // Cidade
            // 
            Cidade.AutoSize = true;
            Cidade.Location = new Point(496, 66);
            Cidade.Name = "Cidade";
            Cidade.Size = new Size(44, 15);
            Cidade.TabIndex = 23;
            Cidade.Text = "Cidade";
            // 
            // textBoxCidade
            // 
            textBoxCidade.Location = new Point(546, 63);
            textBoxCidade.Name = "textBoxCidade";
            textBoxCidade.Size = new Size(100, 23);
            textBoxCidade.TabIndex = 24;
            // 
            // Estado
            // 
            Estado.AutoSize = true;
            Estado.Location = new Point(182, 110);
            Estado.Name = "Estado";
            Estado.Size = new Size(42, 15);
            Estado.TabIndex = 25;
            Estado.Text = "Estado";
            // 
            // textBoxEstado
            // 
            textBoxEstado.Location = new Point(236, 107);
            textBoxEstado.Name = "textBoxEstado";
            textBoxEstado.Size = new Size(100, 23);
            textBoxEstado.TabIndex = 26;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonAdicionarCliente);
            groupBox2.Controls.Add(AdicionarCliente);
            groupBox2.Controls.Add(textBoxCEP);
            groupBox2.Controls.Add(textBoxEstado);
            groupBox2.Controls.Add(CEP);
            groupBox2.Controls.Add(textBoxBairro);
            groupBox2.Controls.Add(textBoxCidade);
            groupBox2.Controls.Add(Bairro);
            groupBox2.Controls.Add(Estado);
            groupBox2.Controls.Add(Numero);
            groupBox2.Controls.Add(textBoxNumero);
            groupBox2.Controls.Add(Cidade);
            groupBox2.Controls.Add(textBoxRua);
            groupBox2.Controls.Add(Rua);
            groupBox2.Controls.Add(Complemento);
            groupBox2.Controls.Add(textBoxComplemento);
            groupBox2.Location = new Point(24, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(969, 178);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "Endereço";
            // 
            // buttonAdicionarCliente
            // 
            buttonAdicionarCliente.Location = new Point(757, 91);
            buttonAdicionarCliente.Name = "buttonAdicionarCliente";
            buttonAdicionarCliente.Size = new Size(126, 53);
            buttonAdicionarCliente.TabIndex = 28;
            buttonAdicionarCliente.Text = "Adicionar";
            buttonAdicionarCliente.UseVisualStyleBackColor = true;
            buttonAdicionarCliente.Click += buttonAdicionarCliente_Click;
            // 
            // AdicionarCliente
            // 
            AdicionarCliente.AutoSize = true;
            AdicionarCliente.Location = new Point(771, 71);
            AdicionarCliente.Name = "AdicionarCliente";
            AdicionarCliente.Size = new Size(98, 15);
            AdicionarCliente.TabIndex = 27;
            AdicionarCliente.Text = "Adicionar Cliente";
            // 
            // panelCadastroPJ
            // 
            panelCadastroPJ.Controls.Add(dataGridViewContatosPJ);
            panelCadastroPJ.Controls.Add(labelTelefone);
            panelCadastroPJ.Controls.Add(textBoxInscricaoMunicipal);
            panelCadastroPJ.Controls.Add(InscricaoMunicipal);
            panelCadastroPJ.Controls.Add(textBoxInscricaoEstadual);
            panelCadastroPJ.Controls.Add(labelInscricaoEstadual);
            panelCadastroPJ.Controls.Add(textBoxNomeFantasia);
            panelCadastroPJ.Controls.Add(labelNomeFantasia);
            panelCadastroPJ.Controls.Add(textBoxCNPJ);
            panelCadastroPJ.Controls.Add(labelCNPJ);
            panelCadastroPJ.Controls.Add(textBoxRazaoSocial);
            panelCadastroPJ.Controls.Add(RazaoSocial);
            panelCadastroPJ.Location = new Point(189, 12);
            panelCadastroPJ.Name = "panelCadastroPJ";
            panelCadastroPJ.Size = new Size(804, 160);
            panelCadastroPJ.TabIndex = 27;
            // 
            // dataGridViewContatosPJ
            // 
            dataGridViewContatosPJ.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewContatosPJ.Columns.AddRange(new DataGridViewColumn[] { Contato, NomePJ });
            dataGridViewContatosPJ.Location = new Point(530, 98);
            dataGridViewContatosPJ.Name = "dataGridViewContatosPJ";
            dataGridViewContatosPJ.ScrollBars = ScrollBars.Vertical;
            dataGridViewContatosPJ.Size = new Size(230, 50);
            dataGridViewContatosPJ.TabIndex = 48;
            // 
            // Contato
            // 
            Contato.HeaderText = "Telefone";
            Contato.Name = "Contato";
            // 
            // NomePJ
            // 
            NomePJ.HeaderText = "Nome";
            NomePJ.Name = "NomePJ";
            // 
            // labelTelefone
            // 
            labelTelefone.AutoSize = true;
            labelTelefone.Location = new Point(473, 111);
            labelTelefone.Name = "labelTelefone";
            labelTelefone.Size = new Size(51, 15);
            labelTelefone.TabIndex = 5;
            labelTelefone.Text = "Telefone";
            // 
            // textBoxInscricaoMunicipal
            // 
            textBoxInscricaoMunicipal.Location = new Point(532, 64);
            textBoxInscricaoMunicipal.Name = "textBoxInscricaoMunicipal";
            textBoxInscricaoMunicipal.Size = new Size(160, 23);
            textBoxInscricaoMunicipal.TabIndex = 4;
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
            // textBoxInscricaoEstadual
            // 
            textBoxInscricaoEstadual.Location = new Point(532, 25);
            textBoxInscricaoEstadual.Name = "textBoxInscricaoEstadual";
            textBoxInscricaoEstadual.Size = new Size(160, 23);
            textBoxInscricaoEstadual.TabIndex = 3;
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
            // textBoxNomeFantasia
            // 
            textBoxNomeFantasia.Location = new Point(109, 108);
            textBoxNomeFantasia.Name = "textBoxNomeFantasia";
            textBoxNomeFantasia.Size = new Size(264, 23);
            textBoxNomeFantasia.TabIndex = 2;
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
            // textBoxCNPJ
            // 
            textBoxCNPJ.Location = new Point(110, 25);
            textBoxCNPJ.Name = "textBoxCNPJ";
            textBoxCNPJ.Size = new Size(129, 23);
            textBoxCNPJ.TabIndex = 0;
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
            // textBoxRazaoSocial
            // 
            textBoxRazaoSocial.Location = new Point(108, 64);
            textBoxRazaoSocial.Name = "textBoxRazaoSocial";
            textBoxRazaoSocial.Size = new Size(265, 23);
            textBoxRazaoSocial.TabIndex = 1;
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
            panelCadastroPF.Controls.Add(dataGridViewContatos);
            panelCadastroPF.Controls.Add(textBoxCPF);
            panelCadastroPF.Controls.Add(label1);
            panelCadastroPF.Controls.Add(telefone);
            panelCadastroPF.Controls.Add(textBoxRG);
            panelCadastroPF.Controls.Add(rg);
            panelCadastroPF.Controls.Add(textBoxDataNascimento);
            panelCadastroPF.Controls.Add(cpf);
            panelCadastroPF.Controls.Add(textBoxNomeCliente);
            panelCadastroPF.Controls.Add(nomeCliente);
            panelCadastroPF.Location = new Point(189, 12);
            panelCadastroPF.Name = "panelCadastroPF";
            panelCadastroPF.Size = new Size(804, 160);
            panelCadastroPF.TabIndex = 28;
            panelCadastroPF.Visible = false;
            // 
            // dataGridViewContatos
            // 
            dataGridViewContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewContatos.Columns.AddRange(new DataGridViewColumn[] { TelefoneContato, NomeContato });
            dataGridViewContatos.Location = new Point(543, 75);
            dataGridViewContatos.Name = "dataGridViewContatos";
            dataGridViewContatos.ScrollBars = ScrollBars.Vertical;
            dataGridViewContatos.Size = new Size(230, 50);
            dataGridViewContatos.TabIndex = 47;
            // 
            // TelefoneContato
            // 
            TelefoneContato.HeaderText = "Telefone";
            TelefoneContato.Name = "TelefoneContato";
            // 
            // NomeContato
            // 
            NomeContato.HeaderText = "Nome";
            NomeContato.Name = "NomeContato";
            // 
            // textBoxCPF
            // 
            textBoxCPF.Location = new Point(75, 82);
            textBoxCPF.Name = "textBoxCPF";
            textBoxCPF.Size = new Size(100, 23);
            textBoxCPF.TabIndex = 46;
            textBoxCPF.KeyPress += textBoxCPF_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 86);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 45;
            label1.Text = "CPF";
            // 
            // telefone
            // 
            telefone.AutoSize = true;
            telefone.Location = new Point(486, 85);
            telefone.Name = "telefone";
            telefone.Size = new Size(51, 15);
            telefone.TabIndex = 44;
            telefone.Text = "Telefone";
            // 
            // textBoxRG
            // 
            textBoxRG.Location = new Point(216, 83);
            textBoxRG.Name = "textBoxRG";
            textBoxRG.Size = new Size(143, 23);
            textBoxRG.TabIndex = 43;
            // 
            // rg
            // 
            rg.AutoSize = true;
            rg.Location = new Point(188, 86);
            rg.Name = "rg";
            rg.Size = new Size(22, 15);
            rg.TabIndex = 42;
            rg.Text = "RG";
            // 
            // textBoxDataNascimento
            // 
            textBoxDataNascimento.Location = new Point(606, 35);
            textBoxDataNascimento.Name = "textBoxDataNascimento";
            textBoxDataNascimento.Size = new Size(143, 23);
            textBoxDataNascimento.TabIndex = 41;
            textBoxDataNascimento.TextChanged += textBoxDataNascimento_TextChanged;
            // 
            // cpf
            // 
            cpf.AutoSize = true;
            cpf.Location = new Point(486, 38);
            cpf.Name = "cpf";
            cpf.Size = new Size(114, 15);
            cpf.TabIndex = 40;
            cpf.Text = "Data de Nascimento";
            // 
            // textBoxNomeCliente
            // 
            textBoxNomeCliente.Location = new Point(75, 35);
            textBoxNomeCliente.Name = "textBoxNomeCliente";
            textBoxNomeCliente.Size = new Size(395, 23);
            textBoxNomeCliente.TabIndex = 39;
            // 
            // nomeCliente
            // 
            nomeCliente.AutoSize = true;
            nomeCliente.Location = new Point(19, 38);
            nomeCliente.Name = "nomeCliente";
            nomeCliente.Size = new Size(40, 15);
            nomeCliente.TabIndex = 38;
            nomeCliente.Text = "Nome";
            // 
            // CadastroClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 378);
            Controls.Add(panelCadastroPJ);
            Controls.Add(panelCadastroPF);
            Controls.Add(groupBox2);
            Controls.Add(groupBoxTipoCliente);
            Name = "CadastroClientes";
            Text = "CadastroClientes";
            groupBoxTipoCliente.ResumeLayout(false);
            groupBoxTipoCliente.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panelCadastroPJ.ResumeLayout(false);
            panelCadastroPJ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContatosPJ).EndInit();
            panelCadastroPF.ResumeLayout(false);
            panelCadastroPF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContatos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private RadioButton radioButtonPF;
        private GroupBox groupBoxTipoCliente;
        private RadioButton radioButtonPJ;
        private Label CEP;
        private TextBox textBoxCEP;
        private Label Rua;
        private TextBox textBoxRua;
        private Label Numero;
        private TextBox textBoxNumero;
        private Label Bairro;
        private TextBox textBoxBairro;
        private Label Complemento;
        private TextBox textBoxComplemento;
        private Label Cidade;
        private TextBox textBoxCidade;
        private Label Estado;
        private TextBox textBoxEstado;
        private GroupBox groupBox2;
        private Panel panelCadastroPF;
        private DataGridView dataGridViewContatos;
        private TextBox textBoxCPF;
        private Label label1;
        private Label telefone;
        private TextBox textBoxRG;
        private Label rg;
        private TextBox textBoxDataNascimento;
        private Label cpf;
        private TextBox textBoxNomeCliente;
        private Label nomeCliente;
        private Panel panelCadastroPJ;
        private Label RazaoSocial;
        private TextBox textBoxRazaoSocial;
        private TextBox textBoxNomeFantasia;
        private Label labelNomeFantasia;
        private TextBox textBoxCNPJ;
        private Label labelCNPJ;
        private TextBox textBoxInscricaoMunicipal;
        private Label InscricaoMunicipal;
        private TextBox textBoxInscricaoEstadual;
        private Label labelInscricaoEstadual;
        private Label labelTelefone;
        private Button buttonAdicionarCliente;
        private Label AdicionarCliente;
        private DataGridViewTextBoxColumn TelefoneContato;
        private DataGridViewTextBoxColumn NomeContato;
        private DataGridView dataGridViewContatosPJ;
        private DataGridViewTextBoxColumn Contato;
        private DataGridViewTextBoxColumn NomePJ;
    }
}