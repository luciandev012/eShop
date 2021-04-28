using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Application.Catalog.DTOS
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
