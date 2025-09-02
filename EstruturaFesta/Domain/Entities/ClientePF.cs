namespace EstruturaFesta.Domain.Entities
{
    public class ClientePF : Cliente
    {
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public override string ObterDocumento()
        {
            return CPF;
        }
    }
}
