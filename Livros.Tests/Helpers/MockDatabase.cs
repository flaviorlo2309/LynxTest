using Domain.Entity;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros.Tests.Helpers
{
    public class MockDatabase : IDbContextFactory<App_Context>
    {
        public App_Context CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<App_Context>()
                .UseInMemoryDatabase($"TestDbMemory-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

            return new App_Context(options);
        }
    }
}
