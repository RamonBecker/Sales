using Microsoft.AspNetCore.Mvc;
using Sales.Domain;
using Sales.Interface;
using Sales.Repository;
using System;


namespace Sales.API
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : AppBaseController
    {
        public ProdutoController(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {

            var repo = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

            return repo.Get();
         }

        [HttpGet]
        [Route("search/{text}/{pagina?}")]
        public IEnumerable<Produto>  GetSearch(string text, int pagina = 1)
        {
            var repo = (IProdutoRepository) ServiceProvider.GetService(typeof(IProdutoRepository));
            return repo.Search(text, pagina);
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic Detail(int? id)
        {

            if ((id ?? 0) > 0)
            {
                var repo = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
                return repo.Detail(id.Value);
            }

            return null;
        }
    }
}