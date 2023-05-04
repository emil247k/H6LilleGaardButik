using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Model
{
    public interface IEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
    }
}
