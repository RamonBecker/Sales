

using Microsoft.EntityFrameworkCore;
using Sales.Domain;
using Sales.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Sales.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDBContext dBContext): base(dBContext)
        {
        }
        public List<Produto> Get()
        {
          return _dBContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo)
                .OrderBy( x => x.Nome)
                .ToList();
        
        }
        public List<Produto> Search(string text, int pagina)
        {
            return _dBContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo 
                        && (x.Nome.ToUpper().Contains(text.ToUpper())
                       || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina)
                .OrderBy( x => x.Nome).ToList();
        }

        public Produto Detail(int id)
        {
            return _dBContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id).FirstOrDefault();
                ;
        }
    }
}
