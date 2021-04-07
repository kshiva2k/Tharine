using System;
using System.Collections.Generic;
using TharineWebApi.ViewModel;

namespace TharineWebApi.Repository
{
    public interface IPOService
    {
        bool AddProduct(ProductDetailViewModel viewModel);
        bool UpdateProduct(ProductDetailViewModel viewModel);
        bool DeleteProduct(ProductDetailViewModel viewModel);
    }
}
