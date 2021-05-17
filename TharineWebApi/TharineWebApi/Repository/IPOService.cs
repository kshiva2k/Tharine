using System;
using System.Collections.Generic;
using TharineWebApi.ViewModel;

namespace TharineWebApi.Repository
{
    public interface IPOService
    {
        //bool AddProduct(ProductViewModel viewModel);
        //bool UpdateProduct(ProductViewModel viewModel);
        //bool DeleteProduct(ProductViewModel viewModel);
        void AddToCart(CartViewModel model);
        void DeleteFromCart(int _productId, int _userId);
        bool ConfirmOrder(List<int> Ids, int _userId);
        List<CartViewModel> GetProductInDraft(int userId);
    }
}
