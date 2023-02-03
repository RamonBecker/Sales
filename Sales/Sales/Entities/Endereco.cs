using Sales.Domain.Interfaces;
using Sales.Domain.Enums;


namespace Sales.Domain.Entities
{
    public class Endereco: BaseDomain, IExibivel
    {
        public TipoEnderecoEnum Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public bool Ativo { get; set; } 
        public int IdCidade { get; set; }
        public virtual Cidade cidade { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
