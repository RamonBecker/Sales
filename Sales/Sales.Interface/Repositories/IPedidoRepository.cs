
using Sales.Domain;

namespace Sales.Interface
{
    public interface IPedidoRepository
    {
        decimal TicketMax();
        dynamic PedidosClientes();

        string Salvar(PedidoDTO pedido);
    }
}
