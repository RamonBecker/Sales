using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository.Maps
{
    public class CidadeMap : BaseDomainMap<Cidade>
    {

        CidadeMap() : base("tb_cidade") { }

        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);
    
        }
    }
}
