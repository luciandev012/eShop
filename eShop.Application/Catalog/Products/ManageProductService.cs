using eShop.Application.Catalog.DTOS;
using eShop.Application.Catalog.Products.DTOS;
using eShop.Application.Catalog.Products.DTOS.Manage;
using eShop.Data.EF;
using eShop.Data.Entities;
using eShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eShop.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        public ManageProductService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount++;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                }
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();

        }


        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if(product == null)
            {
                throw new EShopException($"Cannot find a product with id: {productId}");
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //Select join from table
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pc in _context.ProductCategories on p.Id equals pc.ProductId
                        join c in _context.Categories on pc.CategoryId equals c.Id
                        select new { p, pt, pc };
            //Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if(request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pc.CategoryId));
            }
            //Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel() {
                    Id = x.p.Id,
                    Price = x.p.Price,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    DateCreated = x.p.DateCreated,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //Select and project
            var pagedResult = new PagedViewModel<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStock(int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
