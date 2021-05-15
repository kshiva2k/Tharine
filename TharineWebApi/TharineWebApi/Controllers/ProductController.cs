using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public bool ConfirmOrder(int userId)
        {
            return POService.ConfirmOrder(userId);
        }
    }
}
