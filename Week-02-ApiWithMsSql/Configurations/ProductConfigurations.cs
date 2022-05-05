using ApiWithMsSql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApiWithMsSql.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(250);

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Products).HasForeignKey(a => a.CategoryId);

            builder.ToTable("Products");

            builder.HasData(

              new Product { Id = Guid.NewGuid().ToString(), Name = "Product1", Description = "Test" },
              new Product { Id = Guid.NewGuid().ToString(), Name = "Product2", Description = "Test2" }

          );

        }
    }
}
