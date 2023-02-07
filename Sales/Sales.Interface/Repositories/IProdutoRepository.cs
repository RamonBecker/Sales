
using Sales.Domain;

namespace Sales.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> Get();

        List<Produto> Search(string text);

        Produto Detail(int id);

    }
}