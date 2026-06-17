using RentManager.Data;
using RentManager.Data.Entities;
using RentManager.Migracao.EntidadesAntigas;
using Microsoft.EntityFrameworkCore;

using var sqlContext = new SqlServerContext();

var options = new DbContextOptionsBuilder<RentManagerDataBase>().Options;

using var mysqlContext = new RentManagerDataBase(options);

Console.WriteLine("Lendo clientes do banco antigo...");

// ════════════════════════════════════════════════
// MIGRAÇÃO DE CLIENTES
// ════════════════════════════════════════════════


var clientesAntigos = sqlContext.Clientes.ToList();
var municipios = sqlContext.Municipios.ToList();
var estados = sqlContext.Estados.ToList();
var telefones = sqlContext.COF_TELEFONES.ToList();



Console.WriteLine($"Total encontrados: {clientesAntigos.Count}");

foreach (var clienteAntigo in clientesAntigos)
{
    var enderecoAntigo = sqlContext.Enderecos
        .FirstOrDefault(e => e.CODCLIFOR == clienteAntigo.CODCLIFOR);

    Cliente novoCliente;

    // ===============================
    // PF
    // ===============================
    if (clienteAntigo.TIPOPESSOA == 1)
    {
        novoCliente = new ClientePF
        {
            Nome = clienteAntigo.RAZAOSOCIAL,
            CPF = clienteAntigo.CNPJ_CPF,
            RG = clienteAntigo.RG_NUMERO,
            DataNascimento = clienteAntigo.DATANASCIMENTO,
            NomeMae = clienteAntigo.NOMEMAE,
        };
    }
    // ===============================
    // PJ
    // ===============================
    else
    {
        novoCliente = new ClientePJ
        {
            RazaoSocial = clienteAntigo.RAZAOSOCIAL,
            CNPJ = clienteAntigo.CNPJ_CPF,
            InscricaoMunicipal = clienteAntigo.INSCRMUNICIPAL,
            InscricaoEstadual = clienteAntigo.INSCRESTADUAL
        };
    }

    // ===============================
    // ENDEREÇO (se existir)
    // ===============================
    if (enderecoAntigo != null)
    {
        novoCliente.Rua = enderecoAntigo.ENDERECO;
        novoCliente.Numero = enderecoAntigo.NUMERO;
        novoCliente.Bairro = enderecoAntigo.BAIRRO;
        var municipio = municipios
    .FirstOrDefault(m => m.CODMUNICIPIO == enderecoAntigo.CODMUNICIPIO);

        if (municipio != null)
        {
            novoCliente.Cidade = municipio.NOMEMUNICIPIO;

            var estado = estados
                .FirstOrDefault(e => e.SIGLAESTADO == municipio.SIGLAESTADO);

            if (estado != null)
                novoCliente.Estado = estado.SIGLAESTADO;
        }
        novoCliente.CEP = enderecoAntigo.CEP;
        novoCliente.Complemento = enderecoAntigo.COMPLEMENTO;
    }
    // ===============================
    // TELEFONES
    // ===============================
    var telefonesDoCliente = telefones
        .Where(t => t.CODCLIFOR == clienteAntigo.CODCLIFOR)
        .ToList();

    foreach (var telefone in telefonesDoCliente)
    {
        novoCliente.Contatos.Add(new Contato
        {
            Telefone = telefone.NUMEROFONE,
            NomeContato = telefone.CONTATO
        });
    }
    mysqlContext.Clientes.Add(novoCliente);
}


// Salva tudo no MySQL
mysqlContext.SaveChanges();

Console.WriteLine($"Clientes migrados com sucesso! {clientesAntigos.Count} registros.\n");

// ════════════════════════════════════════════════
// MIGRAÇÃO DE PRODUTOS
// ════════════════════════════════════════════════
Console.WriteLine("Lendo produtos do banco antigo...");

var produtosAntigos = sqlContext.Produtos.ToList();
var materiais = sqlContext.Materiais.ToList();
var modelos = sqlContext.Modelos.ToList();
var especificacoes = sqlContext.Especificacoes.ToList();

Console.WriteLine($"Total de produtos encontrados: {produtosAntigos.Count}");

foreach (var p in produtosAntigos)
{
    string material = materiais
        .FirstOrDefault(m => m.IDMATERIAL == p.IDMATERIAL)?.MATERIAL ?? "";

    string modelo = modelos
        .FirstOrDefault(m => m.IDMODELO == p.IDMODELO)?.MODELO ?? "";

    string especificacao = especificacoes
        .FirstOrDefault(e => e.IDESPEC == p.IDESPEC)?.ESPECIFICACAO ?? "";

    var novoProduto = new Produto
    {
        Nome = p.NOMEPRODUTO ?? "SEM NOME",
        Quantidade = (int)(p.SALDO ?? 0),
        PrecoLocacao = p.PRECOLOCACAO ?? 0,
        PrecoReposicao = p.PRECOREPOSICAO ?? 0,
        PrecoCompra = p.PRECOCUSTO ?? 0,
        Material = material,
        Modelo = modelo,
        Especificacao = especificacao,
        DataCompra = p.DATACRIACAO ?? DateTime.Today,
    };

    mysqlContext.Produtos.Add(novoProduto);
}

mysqlContext.SaveChanges();
Console.WriteLine($"Produtos migrados com sucesso! {produtosAntigos.Count} registros.\n");

Console.WriteLine("══════════════════════════════════════");
Console.WriteLine("Migração completa! Pressione qualquer tecla para sair.");
Console.ReadKey();

