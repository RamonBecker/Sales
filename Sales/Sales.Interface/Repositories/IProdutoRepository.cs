
using Sales.Domain;

namespace Sales.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> Get();
    }
}