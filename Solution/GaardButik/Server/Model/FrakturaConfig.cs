using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GaardButik.Server.Model
{
    public class FrakturaConfig : EntityConfig<Fraktura>
    {
        public override void Configure(EntityTypeBuilder<Fraktura> builder)
        {
            builder.Property(x => x.Date).IsRequired();
            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Fraktura)
                .HasForeignKey(x => x.FrakturaId)
                .IsRequired();
        }
    }
}
