using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure
        (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder){
              // throw new System.NotImplementedException();
              builder.Property(p =>p.Id).IsRequired();
              builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
              builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
              builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
              builder.Property(p=>p.PictureUrl).IsRequired();
              builder.HasOne(b => b.productBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);
              builder.HasOne(t=>t.ProductType).WithMany().HasForeignKey(p=>p.ProductBrandId);
        }
    }
}