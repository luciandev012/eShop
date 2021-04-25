using eShop.Data.Entities;
using eShop.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AppConfig>().HasData(
            //    new AppConfig() { Key = "HomeTitle", Value = "This is homepage of eShop" },
            //    new AppConfig() { Key = "Homekeyword", Value = "This is keyword of eShop" },
            //    new AppConfig() { Key = "HomeDescription", Value = "This is Description of eShop" }
            //    );

            //modelBuilder.Entity<Language>().HasData(
            //    new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
            //    new Language() { Id = "en-US", Name = "English", IsDefault = false }
            //    );

            //modelBuilder.Entity<Category>().HasData(
            //    new Category()
            //    {
            //        Id = 1,
            //        IsShowOnHome = true,
            //        ParentId = null,
            //        SortOrder = 1,
            //        Status = Status.Active,
            //        CategoryTranslations = new List<CategoryTranslation>() {
            //            new CategoryTranslation(){ Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam"},
            //            new CategoryTranslation(){ Name = "Men shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "Shirts for men", SeoTitle = "Shirts for men"}
            //        }
            //    },
            //    new Category()
            //    {
            //        Id = 1,
            //        IsShowOnHome = true,
            //        ParentId = null,
            //        SortOrder = 2,
            //        Status = Status.Active,
            //        CategoryTranslations = new List<CategoryTranslation>() {
            //            new CategoryTranslation(){ Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang nữ"},
            //            new CategoryTranslation(){ Name = "Women shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "Shirts for women", SeoTitle = "Shirts for women"}
            //        }
            //    });
            //modelBuilder.Entity<Product>().HasData(
            //    new Product()
            //    {
            //        Id = 1,
            //        DateCreated = DateTime.Now,
            //        OriginalPrice = 100000,
            //        Price = 200000,
            //        ProductTranslations = new List<ProductTranslation>()
            //        {
            //            new ProductTranslation(){ Name = "Áo nam xám Uniqolo", LanguageId = "vi-VN", SeoAlias = "ao-nam-xam-Uniqolo", SeoDescription = "Sản phẩm áo nam xám của Uniqolo", SeoTitle = "Sản phẩm áo nam xám của Uniqolo", Details = "Mô tả sản phẩm"},
            //            new ProductTranslation(){ Name = "Uniqolo Gray Men shirt", LanguageId = "en-US", SeoAlias = "uniqolo-gray-men-shirt", SeoDescription = "Shirts for men", SeoTitle = "Shirts for men", Details = "Description of product"}
            //        },
            //        ProductCategories = new List<ProductCategory>()
            //        {
            //            new ProductCategory() {CategoryId = 1}
            //        }
            //    }
            //    );
            var roleId = new Guid("E9178863-0CD8-49DF-8A93-648DDB740DB5");
            var adminId = new Guid("0AD41D50-0CF6-4AC0-9523-72A68B12E9A9");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                });
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "thanguk04@gmail.com",
                    NormalizedEmail = "thanguk04@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abc13579"),
                    SecurityStamp = string.Empty,
                    FirstName = "Thang",
                    LastName = "Duong",
                    Dob = new DateTime(1998,12,02)
                });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
