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
            return context.Productmaster.Where(x => x.Keywords.Contains(_keywords) || x.Name.Contains(_keywords))
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
                    Image4 = x.Image4,
                    BigImage = x.Bigimage
                }).FirstOrDefault();
        }
        public void AddProductCategory(ProductCategoryViewModel viewModel)
        {
            context.Productcategorymaster.Add(new Productcategorymaster()
            {
                Clientid = viewModel.Clientid,
                Serviceid = viewModel.Serviceid,
                Name = viewModel.Name
            });
            context.SaveChanges();
        }
        public void UpdateProductCategory(ProductCategoryViewModel viewModel)
        {
            var record = context.Productcategorymaster.Where(p => p.Id == viewModel.Id).FirstOrDefault();
            record.Name = viewModel.Name;
            context.SaveChanges();
        }
        public void DeleteProductCategory(int id)
        {
            var record = context.Productcategorymaster.Where(p => p.Id == id).FirstOrDefault();
            record.Active = 0;
            context.SaveChanges();
        }
        public void AddSubcategory(SubcategoryViewModel viewModel)
        {
            context.Subcategorymaster.Add(new Subcategorymaster()
            {
                Categoryid = viewModel.Categoryid,
                Name = viewModel.Name
            });
        }
        public void UpdateSubCategory(SubcategoryViewModel viewModel)
        {
            var record = context.Subcategorymaster.Where(p => p.Id == viewModel.Id).FirstOrDefault();
            record.Name = viewModel.Name;
            context.SaveChanges();
        }
        public void DeleteSubCategory(int id)
        {
            var record = context.Subcategorymaster.Where(p => p.Id == id).FirstOrDefault();
            record.Active = 0;
            context.SaveChanges();
        }
        public void AddProduct(ProductViewModel viewModel)
        {
            context.Productmaster.Add(new Productmaster()
            {
                Name = viewModel.Name,
                Code = viewModel.Code,
                Description = viewModel.Description,
                Keywords = viewModel.Keywords,
                Size = viewModel.Size,
                Stock = viewModel.Stock,
                Cgstpercent = viewModel.Cgstpercent,
                Sgstpercent = viewModel.Sgstpercent,
                Manufacturer = viewModel.Manufacturer,
                Marketprice = viewModel.Marketprice,
                Saleprice = viewModel.Saleprice,
                Image1 = viewModel.Image1,
                Image2 = viewModel.Image2,
                Image3 = viewModel.Image3,
                Image4 = viewModel.Image4,
                Bigimage = viewModel.BigImage,
                Expirydate = viewModel.Expirydate,
                Subcategoryid = viewModel.Subcategoryid
            });
            context.SaveChanges();
        }
        public void UpdateProduct(ProductViewModel viewModel)
        {
            var record = context.Productmaster.Where(p => p.Id == viewModel.Id).FirstOrDefault();
            record.Name = viewModel.Name;
            record.Code = viewModel.Code;
            record.Description = viewModel.Description;
            record.Keywords = viewModel.Keywords;
            record.Size = viewModel.Size;
            record.Stock = viewModel.Stock;
            record.Cgstpercent = viewModel.Cgstpercent;
            record.Sgstpercent = viewModel.Sgstpercent;
            record.Manufacturer = viewModel.Manufacturer;
            record.Marketprice = viewModel.Marketprice;
            record.Saleprice = viewModel.Saleprice;
            record.Image1 = viewModel.Image1;
            record.Image2 = viewModel.Image2;
            record.Image3 = viewModel.Image3;
            record.Image4 = viewModel.Image4;
            record.Bigimage = viewModel.BigImage;
            record.Expirydate = viewModel.Expirydate;
            record.Subcategoryid = viewModel.Subcategoryid;
            context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var record = context.Productmaster.Where(p => p.Id == id).FirstOrDefault();
            record.Active = 0;
            context.SaveChanges();
        }
        public void AddProductStock(int id, int stock)
        {
            var record = context.Productmaster.Where(p => p.Id == id).FirstOrDefault();
            record.Stock += stock;
            context.SaveChanges();
        }
    }
}
