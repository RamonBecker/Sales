using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository.Maps
{
    public class ProdutoPedidoMap : BaseDomainMap<ProdutoPedido>
    {

        ProdutoPedidoMap() : base("tb_produto_pedido") { }

        public override void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            base.Configure(builder);
        }
    }
}
