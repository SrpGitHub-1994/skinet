using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProdConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(p => p.ProductName).IsRequired().HasMaxLength(400);
           builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);
           builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
           builder.Property(p => p.ProdTypeId).IsRequired();
           builder.Property(p => p.ProdBrandid).IsRequired();
           builder.Property(p => p.PictureUrl).IsRequired().HasMaxLength(200);

        }
    }
}