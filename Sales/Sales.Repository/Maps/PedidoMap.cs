using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository
{
    public class PedidoMap : BaseDomainMap<Pedido>
    {

        PedidoMap() : base("tb_pedido") { }

        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);


            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("valor_total").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Entrega).HasColumnName("entrega").IsRequired();


            builder.Property(x => x.IdCliente).HasColumnName("id_cliente").IsRequired();
            builder.HasOne(x => x.Cliente).WithMany(x => x.Pedidos).HasForeignKey(x => x.IdCliente);


        }
    }
}
