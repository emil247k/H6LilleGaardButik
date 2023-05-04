using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Model
{
    public class FrakturaProductConfig : EntityConfig<FrakturaProduct>
    {
        public override void Configure(EntityTypeBuilder<FrakturaProduct> builder)
        {
            builder
                .HasOne(x => x.Fraktura)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.FrakturaId)
                .IsRequired();
            builder
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .IsRequired();
        }
    }
}
