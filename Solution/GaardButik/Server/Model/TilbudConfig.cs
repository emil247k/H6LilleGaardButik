using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Model
{
    public class TilbudConfig : EntityConfig<Tilbud>
    {
        public override void Configure(EntityTypeBuilder<Tilbud> builder)
        {
            builder
                .HasOne(x => x.Type)
                .WithMany()
                .HasForeignKey(x => x.TypeId)
                .IsRequired();
        }
    }
}
