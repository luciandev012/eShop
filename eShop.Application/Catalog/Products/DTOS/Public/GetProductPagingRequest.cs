using eShop.Application.Catalog.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Application.Catalog.Products.DTOS.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
