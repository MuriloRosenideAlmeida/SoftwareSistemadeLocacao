using EstruturaFesta.Data;
using EstruturaFesta.Data.Entities;
using EstruturaFesta.Migracao.EntidadesAntigas;
using Microsoft.EntityFrameworkCore;

using var sqlContext = new SqlServerContext();

var options = new DbContextOptionsBuilder<EstruturaDataBase>().Options;

using var mysqlContext = new EstruturaDataBase(options);

Console.WriteLine("Lendo clientes do banco antigo...");

// 🔹 TESTE PRIMEIRO COM TAKE(10)
var clientesAntigos = sqlContext.Clientes.ToList();

Console.WriteLine($"Total encontrados: {clientesAntigos.Count}");

var municipios = sqlContext.Municipios.ToList();
var estados = sqlContext.Estados.ToList();

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
        };
    }
    // ===============================
    // PJ
    // ===============================
    else
    {
        novoCliente = new ClientePJ
        {
            Nome = clienteAntigo.RAZAOSOCIAL,
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

    mysqlContext.Clientes.Add(novoCliente);
}

// Salva tudo no MySQL
mysqlContext.SaveChanges();

Console.WriteLine("Migração concluída com sucesso!");