using eShop.ViewModels.Catalog.Products;
using eShop.ViewModels.Common;
using System.Threading.Tasks;

namespace eShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedViewModel<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request); 
    }
}
