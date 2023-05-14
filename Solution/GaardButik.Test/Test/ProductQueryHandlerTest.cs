using GaardButik.Server.Handler;
using GaardButik.Server.Model;
using GaardButik.Shared.Query;
using GaardButik.Test.Test.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaardButik.Test.Test
{
    public class ProductQueryHandlerTest
    {
        private ProductQueryHandler Handler;
        public ProductQueryHandlerTest()
        {
            var context = new TestDatabaseContext();

            Handler = new ProductQueryHandler(context);

            var products = new List<Product>
        {
            new Product { IsSold = false, IsDeleted = false, Name = "Product1", Price = 10, KGPrice = 20, ExperationDate = DateTime.Now.AddDays(10), Id = 1, Type = new ProductType { Description = "Type1", Name = "Type1" }},
            new Product { IsSold = true, IsDeleted = false, Name = "Product2", Price = 20, KGPrice = 40, ExperationDate = DateTime.Now.AddDays(20), Id = 2, Type = new ProductType { Description = "Type2", Name = "Type2" }},
            new Product { IsSold = false, IsDeleted = true, Name = "Product3", Price = 30, KGPrice = 60, ExperationDate = DateTime.Now.AddDays(30), Id = 3, Type = new ProductType { Description = "Type3", Name = "Type3" }},
        };

            context.AddRange(products);
            context.SaveChanges();
        }

        [Fact]
        public async Task Handle_ReturnsOnlyProductsThatAreNotSoldAndNotDeleted()
        {
            // Act
            var result = await Handler.Handle(new ProductQuery());

            // Assert
            Assert.Single(result);
            Assert.Equal("Product1", result.First().Name);
        }
    }
}
