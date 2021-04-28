using eShop.Application.Catalog.DTOS;
using eShop.Application.Catalog.Products.DTOS;
using eShop.Application.Catalog.Products.DTOS.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PagedViewModel<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
