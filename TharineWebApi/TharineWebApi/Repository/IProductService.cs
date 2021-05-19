using System.Collections.Generic;
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
        void AddProductCategory(ProductCategoryViewModel viewModel);
        void UpdateProductCategory(ProductCategoryViewModel viewModel);
        void DeleteProductCategory(int id);
        void AddSubcategory(SubcategoryViewModel viewModel);
        void UpdateSubCategory(SubcategoryViewModel viewModel);
        void DeleteSubCategory(int id);
        void AddProduct(ProductViewModel viewModel);
        void UpdateProduct(ProductViewModel viewModel);
        void DeleteProduct(int id);
        void AddProductStock(int id, int stock);
    }
}
