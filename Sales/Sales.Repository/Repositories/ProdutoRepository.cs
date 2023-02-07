

using Sales.Domain;
using Sales.Interface;

namespace Sales.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDBContext dBContext): base(dBContext)
        {
        }
        public List<Produto> Get()
        {
          return _dBContext.Produtos.
                Where(x => x.Ativo).
                OrderBy( x => x.Nome).
                ToList();
        
        }
        public List<Produto> Search(string text)
        {
            return _dBContext.Produtos
                .Where(x => x.Ativo 
                        && (x.Nome.ToUpper().Contains(text.ToUpper())
                       || x.Descricao.ToUpper().Contains(text.ToUpper()))).OrderBy( x => x.Nome).ToList();
        }
    }
}
