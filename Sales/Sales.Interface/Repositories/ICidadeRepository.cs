
using Sales.Domain;

namespace Sales.Interface
{
    public interface ICidadeRepository
    {
        dynamic Get();
        int Criar(CidadeDTO model);

        int Atualizar(CidadeDTO model);
    }
}
