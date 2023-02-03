using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository.Maps
{
    public class EnderecoMap : BaseDomainMap<Endereco>
    {

        EnderecoMap() : base("tb_endereco") { }

        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);

        }
    }
}
