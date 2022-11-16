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
    public class ProvidersConfiguration : IEntityTypeConfiguration<Providers>
    {
        public void Configure(EntityTypeBuilder<Providers> builder)
        {
            builder.ToTable("Proveedor");
            builder.HasKey(e => e.Provedor_Id);
            builder.Property(e => e.Provedor_Id)
                    .HasColumnName("Codigo_Proveedor");

            builder.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion");

            builder.Property(e => e.Telefono)
                    .HasColumnName("Telefono")
                    .IsRequired();

        }
    }
}
