using eShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Data.Configurations
{
    class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });
            builder.ToTable("ProductCategories");
            builder.HasOne(p => p.Product).WithMany(pc => pc.ProductCategories).HasForeignKey(pc => pc.ProductId);
            builder.HasOne(p => p.Category).WithMany(pc => pc.ProductCategories).HasForeignKey(pc => pc.CategoryId);
        }
    }
}
