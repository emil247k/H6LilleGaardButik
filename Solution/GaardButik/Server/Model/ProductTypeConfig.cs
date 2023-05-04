using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Model
{
    public class ProductTypeConfig : EntityConfig<ProductType>
    {
        public override void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
