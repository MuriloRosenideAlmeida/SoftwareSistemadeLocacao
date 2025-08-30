namespace EstruturaFesta.Domain.Entities
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        private decimal _precoLocacao;
        public decimal PrecoLocacao
        {
            get => Math.Round(_precoLocacao, 2);
            set => _precoLocacao = Math.Round(value, 2); 
        }
        public string Especificacao { get; set; }
        public string Material { get; set; }
        public string Modelo { get; set; }

        private decimal _precoCompra;
        public decimal PrecoCompra
        {
            get => Math.Round(_precoCompra, 2);
            set => _precoCompra = Math.Round(value, 2);
        }

        private decimal _precoReposicao;
        public decimal PrecoReposicao
        {
            get => Math.Round(_precoReposicao,2);
            set => _precoReposicao = Math.Round(value, 2);
        }
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
