using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository.Maps
{
    public class ImagemMap : BaseDomainMap<Imagem>
    {

        ImagemMap() : base("tb_imagem") { }

        public override void Configure(EntityTypeBuilder<Imagem> builder)
        {
            base.Configure(builder);

        }
    }
}
