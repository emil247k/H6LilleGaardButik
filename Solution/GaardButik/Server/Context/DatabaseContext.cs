namespace GaardButik.Server.Context
{
    using GaardButik.Server.Model;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DatabaseContext Instance => this;

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
