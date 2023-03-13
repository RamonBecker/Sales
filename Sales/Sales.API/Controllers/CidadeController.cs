using Microsoft.AspNetCore.Mvc;
using Sales.Interface;
using Microsoft.Extensions.DependencyInjection;
using Sales.Domain;

namespace Sales.API
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : AppBaseController
    {
        public CidadeController(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

   

        [HttpGet]
        public dynamic Get()
        {
            return GetService<ICidadeRepository>().Get();
        }

        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Criar(model);
        }


        [HttpPut]
        public int Atualizar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Atualizar(model);
        }
    }
}