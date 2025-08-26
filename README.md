
Sistema de locação de materiais para festas, desenvolvido em **C# WinForms** com **Entity Framework Core + MySQL**.

---

## Funcionalidades

- Cadastro de clientes (Pessoa Física e Jurídica)
- Controle dinamico de estoque por data
- Criação de contratos e reservas
- Relatórios e consultas com filtro por data
- Gerenciamento financeiro com retorno de: clientes atendidos, produtos mais alugados, balanço mensal (Em desenvolvimento futuro)

---

### CadastroCliente
**Descrição:**  
Tela para cadastro de clientes, alterando os dados de cadastro de pessoa fisica para pessoa juridica atravez de RadioButton

**Print do Form:**  
![Cadastro de Clientes](EstruturaFesta/Images/TelaClientesPF.PNG)
![Cadastro de Clientes](EstruturaFesta/Images/TelaClientesPJ.PNG)

---

### FormPedido
**Descrição:**  
Tela para criação de contratos de locação com as informações do cliente pré-cadastrado que está locando os itens
Data da locação para controle dinamico de estoque com verificação de disponibilidade baseado na data da locação


**Print do Form:**  
![Tela de Criação de Contratos](EstruturaFesta/Images/TelaPedidoPreenchida.PNG)

---

### Cadastro de Produtos
**Descrição:**  
Tela para cadastro de produtos com informações uteis para controle financeiro e logistico


**Prints:**  
![Tela de Cadastro de Produtos](EstruturaFesta/Images/TelaCadastroProdutos.PNG)

---

## 🛠️ Tecnologias Utilizadas
- C# (.NET 8 / WinForms)
- Entity Framework Core
- MySQL
- GitHub

---


