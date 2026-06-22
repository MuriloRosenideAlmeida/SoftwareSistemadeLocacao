using RentManager.Data;
using RentManager.Data.Entities;
using RentManager.Models;
using RentManager.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentManager.Services
{
    public class ReciboGeradoService
    {
        private readonly RentManagerDataBase _db;

        public ReciboGeradoService(RentManagerDataBase db)
        {
            _db = db;
        }

        /// <summary>Busca recibo já gerado para o pedido.</summary>
        public async Task<ReciboGerado?> BuscarPorPedidoAsync(int numeroPedido)
            => await _db.ReciboGerados
                .FirstOrDefaultAsync(r => r.NumeroPedido == numeroPedido);

        /// <summary>Salva o recibo e retorna o Id gerado (= número da nota).</summary>
        public async Task<int> SalvarAsync(ReciboGerado recibo)
        {
            _db.ReciboGerados.Add(recibo);
            await _db.SaveChangesAsync();
            return recibo.Id; // ← ID gerado pelo banco = número da nota
        }

        /// <summary>Monta ReciboGerado para persistir no banco.</summary>
        public static ReciboGerado MontarParaSalvar(
            DadosPedidoImpressao pedido,
            string descricao)
        {
            return new ReciboGerado
            {
                // Id será gerado pelo banco
                NumeroPedido = pedido.NumeroPedido,
                DataEmissao = DateTime.Now,

                DataPedido = pedido.DataPedido,
                DataEntrega = pedido.DataEntrega,
                DataRetirada = pedido.DataRetirada,
                Observacoes = pedido.Observacoes ?? string.Empty,

                ClienteId = pedido.ClienteId,
                ClienteNome = pedido.NomeCliente,
                ClienteDocumento = pedido.DocumentoCliente,
                ClienteTelefone = pedido.OutrosContatos.FirstOrDefault()?.Telefone
                                     ?? pedido.ContatoNumero
                                     ?? string.Empty,

                EnderecoRua = pedido.EnderecoRua ?? string.Empty,
                EnderecoNumero = pedido.EnderecoNumero ?? string.Empty,
                Bairro = pedido.Bairro ?? string.Empty,
                Complemento = pedido.Complemento ?? string.Empty,
                CEP = pedido.CEP ?? string.Empty,
                Cidade = pedido.Cidade ?? string.Empty,
                UF = pedido.UF ?? string.Empty,

                DescricaoServico = descricao,

                SubTotal = pedido.SubTotal,
                Desconto = pedido.Desconto,
                Acrescimo = pedido.Acrescimo,
                ValorQuebra = pedido.ValorQuebra,
                ValorTotal = pedido.ValorTotal,
            };
        }

        /// <summary>Reconstrói DadosNotaFiscalServico a partir do banco para reimprimir.</summary>
        public static DadosNotaFiscalServico ConverterParaDadosNota(ReciboGerado r)
        {
            return new DadosNotaFiscalServico
            {
                // Empresa (fixo)
                EmpresaNome = DadosEmpresa.RazaoSocial,
                EmpresaCNPJ = DadosEmpresa.CNPJ,
                EmpresaRua = DadosEmpresa.Rua,
                EmpresaNumero = DadosEmpresa.Numero,
                EmpresaBairro = DadosEmpresa.Bairro,
                EmpresaCidade = DadosEmpresa.Cidade,
                EmpresaUF = DadosEmpresa.UF,
                EmpresaCEP = DadosEmpresa.CEP,
                EmpresaTelefone = DadosEmpresa.Telefone,
                EmpresaEmail = DadosEmpresa.EmpresaEmail,
                LogoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ToqueDeClasseLogo.PNG"),

                // Identificação — Id do banco = número da nota
                NumeroNota = r.Id,
                DataEmissao = r.DataEmissao,
                NumeroPedido = r.NumeroPedido,
                DataServico = r.DataEntrega,
                DataRetirada = r.DataRetirada,

                // Cliente
                ClienteNome = r.ClienteNome,
                ClienteDocumento = r.ClienteDocumento,
                ClienteRua = r.EnderecoRua,
                ClienteNumero = r.EnderecoNumero,
                ClienteBairro = r.Bairro,
                ClienteCidade = r.Cidade,
                ClienteUF = r.UF,
                ClienteCEP = r.CEP,
                ClienteTelefone = r.ClienteTelefone,

                // Serviço
                DescricaoServico = r.DescricaoServico,
                ValorServico = r.SubTotal,
                Desconto = r.Desconto,
                Acrescimo = r.Acrescimo,
                ValorTotal = r.ValorTotal,
            };
        }
    }
}
