using Microsoft.AspNetCore.Mvc;
using Sales.Interface;

namespace Sales.API
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : AppBaseController
    {
        public PedidoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        [Route("ticket-max")]
        public decimal TicketMax()
        {
            return GetService<IPedidoRepository>().TicketMax();
        }

        [HttpGet]
        [Route("por-cliente")]
        public dynamic PedidosClientes()
        {
            return GetService<IPedidoRepository>().PedidosClientes();
        }

    }
}