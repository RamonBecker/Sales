

using Sales.Domain;
using Sales.Interface;

namespace Sales.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public ProdutoRepository(ApplicationDBContext dBContext): base(dBContext)
        {
        }
        public List<Produto> Get()
        {
          return _dBContext.Produtos.ToList();
        }
    }
}
