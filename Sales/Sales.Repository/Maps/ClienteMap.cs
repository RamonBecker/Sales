using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository.Maps
{
    public class ClienteMap : BaseDomainMap<Cliente>
    {

        ClienteMap() : base("tb_cliente") { }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

        }
    }
}
