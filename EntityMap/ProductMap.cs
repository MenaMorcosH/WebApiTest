using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.EntityMap
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("ProductName")
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnName("productPrice")
                .HasColumnType("int")
                .HasDefaultValue(10);
                
        }
    }
}
