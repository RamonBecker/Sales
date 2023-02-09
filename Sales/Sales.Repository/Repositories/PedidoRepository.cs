

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
                  .Max(x => (decimal?) x.ValorTotal) ?? 0;
        }
    }
}
