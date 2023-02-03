using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain;


namespace Sales.Repository
{
    public class CategoriaProdutoMap : BaseDomainMap<CategoriaProduto>
    {

        public  CategoriaProdutoMap() : base("tb_categoria_produto") { }

        public override void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}
