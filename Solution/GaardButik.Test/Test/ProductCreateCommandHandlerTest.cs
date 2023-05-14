using GaardButik.Server.Handler;
using GaardButik.Server.Model;
using GaardButik.Shared.Command;
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
    public class ProductCreateCommandHandlerTest
    {
        private ProductCreateCommandHandler Handler;
        private TestDatabaseContext Context;

        public ProductCreateCommandHandlerTest()
        {
            Context = new TestDatabaseContext();

            Handler = new ProductCreateCommandHandler(Context);
        }

        [Fact]
        public async Task Handle_AddsNewProductToDatabase()
        {
            var command = new ProductCreateCommand
            {
                Name = "New Product",
                Price = 10,
                KGPrice = 20,
                ExperationDate = DateTime.Now.AddDays(10),
                amount = 1,
                TypeName = "New Type",
                TypeDescription = "New Type Description",
            };

            await Handler.Handle(command);

            var product = await Context.Instance.Set<Product>().SingleOrDefaultAsync(p => p.Name == command.Name);
            Assert.NotNull(product);
            Assert.Equal(command.Name, product.Name);
            Assert.Equal(command.Price, product.Price);
            Assert.Equal(command.KGPrice, product.KGPrice);
            Assert.Equal(command.ExperationDate.ToUniversalTime(), product.ExperationDate);
            Assert.Equal(command.TypeName, product.Type.Name);
            Assert.Equal(command.TypeDescription, product.Type.Description);
        }
    }
}
