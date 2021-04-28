using eShop.Application.Catalog.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Application.Catalog.Products.DTOS.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
