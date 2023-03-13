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
        public dynamic Get([FromQuery] string ordem="" )
        {
            return GetService<IProdutoRepository>().Get(ordem);
         }

        [HttpGet]
        [Route("search/{text}/{pagina?}")]
        public dynamic GetSearch(string text, int pagina = 1, [FromQuery] string ordem = "")
        {
            return GetService<IProdutoRepository>().Search(text, pagina, ordem);
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic Detail(int? id)
        {

            if ((id ?? 0) > 0)
            {
                return GetService<IProdutoRepository>().Detail(id.Value);
            }

            return null;
        }

        [HttpGet]
        [Route("{id}/imagens")]
        public dynamic Imagens(int? id)
        {

            if ((id ?? 0) > 0)
            {
                return GetService<IProdutoRepository>().Imagens(id.Value);
            }

            return null;
        }
    }
}