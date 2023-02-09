

using Microsoft.EntityFrameworkCore;
using Sales.Domain;
using Sales.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Sales.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
        public dynamic Get()
        {
            return DBContext.Produtos
                  .Include(x => x.Categoria)
                  .Where(x => x.Ativo)
                  .Select(x => new
                  {
                      x.Nome,
                      x.Preco,
                      Categoria = x.Categoria.Nome,
                      Imagens = x.Imagens.Select(x => new
                      {
                          x.Id,
                          x.Nome,
                          x.NomeArquivo
                      })
                  })
                  .OrderBy(x => x.Nome)
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
                                .Select(x => new
                                {
                                    x.Nome,
                                    x.Preco,
                                    Categoria = x.Categoria.Nome,
                                    Imagens = x.Imagens.Select(x => new
                                    {
                                        x.Id,
                                        x.Nome,
                                        x.NomeArquivo
                                    })
                                })
                .Take(TamanhoPagina)
                .OrderBy(x => x.Nome).ToList();

            var qtdProdutos = DBContext.Produtos.Where(x => x.Ativo
                        && (x.Nome.ToUpper().Contains(text.ToUpper())
                       || x.Descricao.ToUpper().Contains(text.ToUpper()))).Count();

            var qtdPaginas = (qtdProdutos / TamanhoPagina);

            if (qtdPaginas < 1)
            {
                qtdPaginas = 1;
            }

            return new { produtos, qtdPaginas };
        }

        public dynamic Detail(int id)
        {
            return DBContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Codigo,
                    x.Descricao,
                    x.Preco,
                    Categoria = new
                    {
                        x.Categoria.Id,
                        x.Categoria.Nome
                    },
                    Imagens = x.Imagens.Select(x => new
                    {
                        x.Id,
                        x.Nome,
                        x.NomeArquivo
                    })
                })
                .FirstOrDefault();
            ;
        }

        public dynamic Imagens(int id)
        {
            return DBContext.Produtos
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .SelectMany(x => x.Imagens, (produto, imagem) => new
                    {
                    IdProduto = produto.Id,
                    imagem.Id,
                    imagem.Nome,
                    imagem.NomeArquivo
                })
                .FirstOrDefault();
            ;
        }

    }
}
