using Domain.Entity;
using Infraestructure.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class App_Context : DbContext
    {
        
        public App_Context(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<LivroEntity> Livro { get; set; }

    }
}
