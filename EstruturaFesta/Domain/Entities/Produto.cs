namespace EstruturaFesta.Domain.Entities
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoLocacao { get; set; }
        public string Especificacao { get; set; }
        public string Material { get; set; }
        public string Modelo { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoReposicao { get; set; }
        public DateTime DataCompra { get; set; }
        public List<Reserva> Reserva { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, int quantidade, decimal precoLocacao, string especificacao, string material, string modelo)
        {
            Nome = nome;
            Quantidade = quantidade;
            PrecoLocacao = precoLocacao;
            Especificacao = especificacao;
            Material = material;
            Modelo = modelo;
        }

        public Produto(string nome, int quantidade, decimal precoLocacao, string especificacao, string material, string modelo, decimal precoCompra, decimal precoReposicao, DateTime dataCompra)
        {
            Nome = nome;
            Quantidade = quantidade;
            PrecoLocacao = precoLocacao;
            Especificacao = especificacao;
            Material = material;
            Modelo = modelo;
            PrecoCompra = precoCompra;
            PrecoReposicao = precoReposicao;
            DataCompra = dataCompra;
        }
    }
}
