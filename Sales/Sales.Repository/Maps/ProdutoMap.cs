using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Repository.Maps
{
    public class ProdutoMap : BaseDomainMap<Produto>
    {

        ProdutoMap() : base("tb_produto") { }

        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);
        }
    }
}
