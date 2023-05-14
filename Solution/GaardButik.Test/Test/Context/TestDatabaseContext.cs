using GaardButik.Server.Context;
using GaardButik.Server.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaardButik.Test.Test.Context
{
    public class TestDatabaseContext : DbContext, IDatabaseContext
    {

        public DbContext Instance => this;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("gaardbutikTestDB");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EntityConfig<Entity>).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
