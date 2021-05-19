using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TharineWebApi.Repository;
using TharineWebApi.ViewModel;
namespace TharineWebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        IProductService productService { get; set; }
        IPOService POService { get; set; }
        public ProductController(IProductService _productService, IPOService _POService)
        {
            productService = _productService;
            POService = _POService;
        }
        [HttpGet("GetProductCategories")]
        public List<ProductCategoryViewModel> GetProductCategories(int clientId, int serviceId)
        {
            return productService.GetProductCategories(clientId, serviceId);
        }
        [HttpGet("GetSubcategories")]
        public List<SubcategoryViewModel> GetSubcategories(int categoryId)
        {
            return productService.GetSubcategories(categoryId);
        }
        [HttpGet("GetProducts")]
        public List<ProductViewModel> GetProducts(int subcategoryId)
        {
            return productService.GetProducts(subcategoryId);
        }
        [HttpGet("GetProductsBySearch")]
        public List<ProductViewModel> GetProductsBySearch(string keywords)
        {
            return productService.GetProducts(keywords);
        }
        [HttpGet("GetProductById")]
        public ProductViewModel GetProductById(int productId)
        {
            return productService.GetProductById(productId);
        }
        [HttpGet("GetCartCount")]
        public int GetCartCount(int userId)
        {
            var list = POService.GetProductInDraft(userId);
            return list.Count;
        }
        [HttpGet("GetCartDetails")]
        public List<CartViewModel> GetCartDetails(int userId)
        {
            return POService.GetProductInDraft(userId);
        }
        [HttpPost("AddToCart")]
        public bool AddToCart([FromBody] CartViewModel model)
        {
            POService.AddToCart(model);
            return true;
        }
        [HttpPost("DeleteFromCart")]
        public bool DeleteFromCart([FromBody] CartViewModel model)
        {
            POService.DeleteFromCart(model.ProductId, model.UserId);
            return true;
        }
        [HttpPost("ConfirmOrder")]
        public bool ConfirmOrder(List<int> Ids, int userId)
        {
            return POService.ConfirmOrder(Ids, userId);
        }
        [HttpPost("AddProductCategory")]
        public bool AddProductCategory([FromBody] ProductCategoryViewModel viewModel)
        {
            productService.AddProductCategory(viewModel);
            return true;
        }
        [HttpPost("UpdateProductCategory")]
        public bool UpdateProductCategory([FromBody] ProductCategoryViewModel viewModel)
        {
            productService.UpdateProductCategory(viewModel);
            return true;
        }
        [HttpGet("DeleteProductCategory")]
        public bool DeleteProductCategory(int id)
        {
            productService.DeleteProductCategory(id);
            return true;
        }
        [HttpPost("AddSubCategory")]
        public bool AddSubCategory([FromBody] SubcategoryViewModel viewModel)
        {
            productService.AddSubcategory(viewModel);
            return true;
        }
        [HttpPost("UpdateSubCategory")]
        public bool UpdateSubCategory([FromBody] SubcategoryViewModel viewModel)
        {
            productService.UpdateSubCategory(viewModel);
            return true;
        }
        [HttpGet("DeleteSubCategory")]
        public bool DeleteSubCategory(int id)
        {
            productService.DeleteSubCategory(id);
            return true;
        }
        [HttpPost("AddProduct")]
        public bool AddProduct([FromBody] ProductViewModel viewModel)
        {
            // Setting up the images

            // Saving the data
            productService.AddProduct(viewModel);
            return true;
        }
        [HttpPost("UpdateSubCategory")]
        public bool UpdateProduct([FromBody] ProductViewModel viewModel)
        {
            productService.UpdateProduct(viewModel);
            return true;
        }
        [HttpGet("DeleteProduct")]
        public bool DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
            return true;
        }
    }
}
