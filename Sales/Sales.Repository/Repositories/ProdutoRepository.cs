

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
          return DBContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo)
                .OrderBy( x => x.Nome)
                .ToList();
        
        }
        public dynamic Search(string text, int pagina)
        {
            var produtos = DBContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo 
                        && (x.Nome.ToUpper().Contains(text.ToUpper())
                       || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina)
                .OrderBy( x => x.Nome).ToList();

            var qtdProdutos = DBContext.Produtos.Where(x => x.Ativo
                        && (x.Nome.ToUpper().Contains(text.ToUpper())
                       || x.Descricao.ToUpper().Contains(text.ToUpper()))).Count();

            var qtdPaginas = (qtdProdutos / TamanhoPagina);

            if(qtdPaginas < 1)
            {
                qtdPaginas = 1;
            }

            return new { produtos, qtdPaginas};
        }

        public Produto Detail(int id)
        {
            return DBContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id).FirstOrDefault();
                ;
        }
    }
}
