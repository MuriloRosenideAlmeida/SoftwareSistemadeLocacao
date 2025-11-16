namespace EstruturaFesta.Domain.Entities
{
    public abstract class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public ICollection<Contato> Contatos { get; set; } = new List<Contato>();
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
  
        public abstract string ObterDocumento();
        
        


    }

}
