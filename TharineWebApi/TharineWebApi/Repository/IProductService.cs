using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TharineWebApi.ViewModel;
namespace TharineWebApi.Repository
{
    public interface IProductService
    {
        List<ProductCategoryViewModel> GetProductCategories(int _clientId, int? _serviceId);
        List<SubcategoryViewModel> GetSubcategories(int _categoryId);
        List<ProductViewModel> GetProducts(int _subcategoryId);
        List<ProductViewModel> GetProducts(string _keywords);
        ProductViewModel GetProductById(int _productId);
    }
}
