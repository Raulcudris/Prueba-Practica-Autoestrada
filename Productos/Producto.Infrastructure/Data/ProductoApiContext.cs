using Microsoft.EntityFrameworkCore;
using Producto.Core.Entities;
using Producto.Infrastructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Data
{
    public class ProductoApiContext: DbContext
    {
        public ProductoApiContext()
        {
        }

        public ProductoApiContext(DbContextOptions<ProductoApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidersConfiguration());
        }

    }
}
