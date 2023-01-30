using Microsoft.AspNetCore.Mvc;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : AppBaseController
    {
        public OrderController(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

    }
}