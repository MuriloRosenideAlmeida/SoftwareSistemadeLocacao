using EstruturaFesta.Clientes;

namespace EstruturaFesta
{
    public class Contrato
    {
        public Cliente Cliente { get; set; }
        public DateTime Entrega { get; set; }
        public DateTime Evento { get; set; }
        public DateTime Devolucao { get; set; }
        public List<Produto> Produto { get; set; }

        public Contrato(Cliente cliente, DateTime entrega, DateTime evento, DateTime devolucao, List<Produto> produto)
        {
            Cliente = cliente;
            Entrega = entrega;
            Evento = evento;
            Devolucao = devolucao;
            Produto = produto;
        }
    }
}
