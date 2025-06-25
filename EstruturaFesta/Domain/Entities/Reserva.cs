namespace EstruturaFesta.Domain.Entities
{
    public class Reserva
    {
        public int ID { get; set; }
        public DateTime Entrega { get; set; }
        public DateTime Devolucao { get; set; }
        public int Quantidade { get; set; }
        public void CriarReserva(Produto produto, int quantidade, DateTime dataEntrega, DateTime dataDevolucao)
        {
            // Verifica se o produto tem a quantidade disponível
            if (produto.Quantidade >= quantidade)
            {
                // Verifica se já existem reservas que conflitam com as datas solicitadas
                foreach (var reserva in produto.Reserva)
                {
                    if (dataEntrega < reserva.Devolucao && dataDevolucao > reserva.Entrega)
                    {
                        throw new Exception("Produto não disponível nas datas solicitadas.");
                    }
                }
                // Se tudo estiver ok, cria a reserva
                produto.Reserva.Add(new Reserva { Quantidade = quantidade, Entrega = dataEntrega, Devolucao = dataDevolucao });
                produto.Quantidade -= quantidade; // Retira a quantidade do estoque
            }
            else
            {
                throw new Exception("Quantidade solicitada não disponível.");
            }
        }
    }
}
