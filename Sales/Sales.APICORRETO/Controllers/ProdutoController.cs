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

            //return  repo.Get();
        

        //    throw new NotImplementedException();
         }

        [HttpGet]
        [Route("search/{text}")]
        public IEnumerable<Produto>  GetSearch(string text)
        {
            var repo = (IProdutoRepository) ServiceProvider.GetService(typeof(IProdutoRepository));
            return repo.Search(text);
        }

        [HttpGet]
        [Route("{text}")]
        public Produto Detail(int? id)
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