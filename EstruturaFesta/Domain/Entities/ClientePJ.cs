﻿namespace EstruturaFesta.Domain.Entities
{
    public class ClientePJ : Cliente
    {
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
    }
}
