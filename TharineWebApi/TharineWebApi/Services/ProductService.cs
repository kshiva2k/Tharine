using System;
using System.Collections.Generic;
using System.Linq;
using TharineWebApi.Models;
using TharineWebApi.Repository;
using TharineWebApi.ViewModel;
namespace TharineWebApi.Services
{
    public class ProductService : IProductService
    {
        tharineContext context { get; }
        public ProductService(tharineContext _tharineContext)
        {
            context = _tharineContext;
        }
        public List<ProductCategoryViewModel> GetProductCategories(int _clientId, int? _serviceId)
        {
            return context.Productcategorymaster.Where(x => x.Clientid == _clientId && x.Serviceid == _serviceId)
                .Where(x => x.Active == 1)
                .Select(x => new ProductCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }
        public List<SubcategoryViewModel> GetSubcategories(int _categoryId)
        {
            return context.Subcategorymaster.Where(x => x.Categoryid == _categoryId)
                .Where(x => x.Active == 1)
                .Select(x => new SubcategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }
        public List<ProductViewModel> GetProducts(int _subcategoryId)
        {
            return context.Productmaster.Where(x => x.Subcategoryid == _subcategoryId)
                .Where(x => x.Active == 1)
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Manufacturer = x.Manufacturer,
                    Marketprice = x.Marketprice,
                    Saleprice = x.Saleprice,
                    Stock = x.Stock,
                    Size = x.Size,
                    Image1 = x.Image1
                }).ToList();
        }
        public List<ProductViewModel> GetProducts(string _keywords)
        {
            return context.Productmaster.Where(x => x.Keywords.Contains(_keywords))
                .Where(x => x.Active == 1)
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Manufacturer = x.Manufacturer,
                    Marketprice = x.Marketprice,
                    Saleprice = x.Saleprice,
                    Stock = x.Stock,
                    Size = x.Size,
                    Image1 = x.Image1
                }).ToList();
        }
        public ProductViewModel GetProductById(int _productId)
        {
            return context.Productmaster.Where(x => x.Id == _productId)
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Manufacturer = x.Manufacturer,
                    Marketprice = x.Marketprice,
                    Saleprice = x.Saleprice,
                    Stock = x.Stock,
                    Size = x.Size,
                    Image1 = x.Image1,
                    Image2 = x.Image2,
                    Image3 = x.Image3,
                    Image4 = x.Image4
                }).FirstOrDefault();
        }
    }
}
