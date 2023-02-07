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

            var repo = ServiceProvider.GetService(typeof(IProdutoRepository));


            return ((IProdutoRepository)repo).Get();

            //return  repo.Get();
        

        //    throw new NotImplementedException();
         }
    }
}