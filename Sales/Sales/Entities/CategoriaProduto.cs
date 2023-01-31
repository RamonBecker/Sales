using Sales.Domain.Interfaces;


namespace Sales.Domain.Entities
{
    public class CategoriaProduto: BaseDomain, IExibivel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
