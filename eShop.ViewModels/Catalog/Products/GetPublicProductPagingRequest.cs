using eShop.ViewModels.Common;
using System.Collections.Generic;

namespace eShop.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        //public string Keyword { get; set; }
        public int? CategoryId { get; set; }
    }
}
