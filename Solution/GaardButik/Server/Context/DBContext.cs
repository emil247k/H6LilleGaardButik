namespace GaardButik.Server.Context
{
    using GaardButik.Server.Model;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("GaardbutikDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EntityConfig<Entity>).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
