﻿using Sales.Domain.Interfaces;


namespace Sales.Domain.Entities
{
    public class Cliente : BaseDomain, IExibivel
    { 
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }

    }
}