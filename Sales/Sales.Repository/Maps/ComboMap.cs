using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository.Maps
{
    public class ComboMap : BaseDomainMap<Combo>
    {

        ComboMap() : base("tb_combo") { }

        public override void Configure(EntityTypeBuilder<Combo> builder)
        {
            base.Configure(builder);

        }
    }
}
