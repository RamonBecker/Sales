


using Sales.Domain.Interfaces;

namespace Sales.Domain.Entities
{
    public class Cidade : BaseDomain, IExibivel
    {
        public string Nome { get; set; }    
        public string Uf { get; set;}
        public bool Ativo { get; set ; }
    }
}
