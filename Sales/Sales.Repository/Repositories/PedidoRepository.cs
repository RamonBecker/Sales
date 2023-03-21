

using Sales.Domain;
using Sales.Interface;

namespace Sales.Repository
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        private string GetProximoNumero()
        {
            var ret = 1.ToString("00000");

            var ultimoNumero = DBContext.Pedidos.Max(x => x.Numero);

            if (!string.IsNullOrEmpty(ultimoNumero))
            {
                ret = (Convert.ToInt32(ultimoNumero) + 1).ToString("00000");
            }

            return ret;
        }
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

        public string Salvar(PedidoDTO pedido)
        {

            var ret = "";

            try
            {
                // Transação explicita
                using (var transaction = DBContext.Database.BeginTransaction())
                {

                    try
                    {



                        var entity = new Pedido
                        {
                            Numero = GetProximoNumero(),
                            IdCliente = pedido.IdCliente,
                            CriadoEm = DateTime.Now,
                            Produtos = new List<ProdutoPedido>()
                        };

                        var valorTotal = 0m;


                        foreach (var produto in pedido.Produtos)
                        {
                            var preco = DBContext.Produtos.Where(x => x.Id.Equals(produto.IdProduto)).Select(x => x.Preco).FirstOrDefault();

                            if (preco > 0)
                            {
                                valorTotal += produto.Quantidade * preco;
                                entity.Produtos.Add(new ProdutoPedido
                                {
                                    IdProduto = produto.IdProduto,
                                    Quantidade = produto.Quantidade,
                                    Preco = preco
                                });
                            }
                        }

                        entity.ValorTotal = valorTotal;
                        DBContext.Pedidos.Add(entity);
                        DBContext.SaveChanges();
                        transaction.Commit();
                        ret = entity.Numero;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }
    }
}
