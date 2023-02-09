

using Sales.Interface;

namespace Sales.Repository
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
        public decimal TicketMax()
        {

            var dataAtual = DateTime.Now;

            return DBContext
                   .Pedidos
                   .Where(x => x.CriadoEm.Date == dataAtual)
                   .Max(x => (decimal?)x.ValorTotal) ?? 0;
        }

        public dynamic PedidosClientes()
        {
            var dataAtual = DateTime.Today.Date;
            var inicioMes = new DateTime(dataAtual.Year, dataAtual.Month, 1);
            var finalMes = new DateTime(dataAtual.Year, dataAtual.Month, DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month));

            return DBContext
                   .Pedidos
                   .Where(x => x.CriadoEm.Date >= inicioMes && x.CriadoEm.Date <= finalMes)
                   .GroupBy(
                    pedido => new { pedido.IdCliente, pedido.Cliente.Nome },
                    (chave, pedidos) => new
                   {
                       Cliente = chave.Nome,
                       QtdPedidos = pedidos.Count(),
                       Total = pedidos.Sum(p => p.ValorTotal)

                   })
                   .ToList()
                   ;
        }
    }
}
