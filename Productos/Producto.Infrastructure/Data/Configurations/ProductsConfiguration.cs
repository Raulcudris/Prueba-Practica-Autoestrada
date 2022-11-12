using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Producto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Data.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(e => e.Codigo_Producto);
            builder.Property(e => e.Codigo_Producto)
                    .HasColumnName("Codigo_Producto");
            builder.Property(e => e.Descripcion)
                    .HasColumnName("Descripcion")
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            builder.Property(e => e.Estado_Producto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Estado_Producto");
            builder.Property(e => e.Fecha_Fabricacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Fabricacion");
            builder.Property(e => e.Fecha_Validez)
                    .HasColumnType("date")
                     .HasColumnName("Fecha_Fabricacion");
            builder.Property(e => e.Codigo_Proveedor)
                    .IsRequired()
                    .HasColumnName("Codigo_Proveedor");
          
        }
    
    }
}
