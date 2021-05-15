using System;
using System.Collections.Generic;
using System.Linq;
using TharineWebApi.Models;
using TharineWebApi.Repository;
using TharineWebApi.ViewModel;
namespace TharineWebApi.Services
{
    public class POService : IPOService
    {
        tharineContext context { get; }
        public POService(tharineContext _tharineContext)
        {
            context = _tharineContext;
        }
        //public bool AddProduct(ProductViewModel viewModel)
        //{
        //    try
        //    {
        //        Purchaseorder PO = new Purchaseorder()
        //        {
        //            Clientid = viewModel.ClientId,
        //            Totalamount = viewModel.Amount,
        //            Ponumber = "", // Logic for Order Number generation to be discussed
        //            Createdby = viewModel.UserId,
        //            Createddate = DateTime.Now
        //        };
        //        context.Purchaseorder.Add(PO);
        //        if(viewModel.PurchaseOrderId == 0)
        //        {
        //            // New purchase order
        //            context.Purchaseorder.Add(PO);
        //        }
        //        else
        //        {
        //            // Update total amount
        //            var porder = context.Purchaseorder.Where(x => x.Id == viewModel.PurchaseOrderId).FirstOrDefault();
        //            porder.Totalamount += viewModel.Amount;
        //            porder.Createddate = DateTime.Now;
        //        }
        //        context.Purchaseorderdetail.Add(new Purchaseorderdetail()
        //        {
        //            Purchaseorderid = PO.Id,
        //            Productid = viewModel.ProductId,
        //            Quantity = viewModel.Quantity,
        //            Amount = viewModel.Amount
        //        });

        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }
        //}
        //public bool UpdateProduct(ProductViewModel viewModel)
        //{
        //    try
        //    {
        //        var pOrder = context.Purchaseorder.Where(x => x.Id == viewModel.PurchaseOrderId).FirstOrDefault();
        //        var pOrderDetail = context.Purchaseorderdetail.Where(x => x.Id == viewModel.Id).FirstOrDefault();
        //        // Adjust totalamount in purchase order
        //        pOrder.Totalamount += (viewModel.Amount - pOrderDetail.Amount);
        //        // Update quantity and amount
        //        pOrderDetail.Quantity = viewModel.Quantity;
        //        pOrderDetail.Amount = viewModel.Quantity;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        //public bool DeleteProduct(ProductViewModel viewModel)
        //{
        //    try
        //    {
        //        var pOrder = context.Purchaseorder.Where(x => x.Id == viewModel.PurchaseOrderId).FirstOrDefault();
        //        var pOrderDetail = context.Purchaseorderdetail.Where(x => x.Id == viewModel.Id).FirstOrDefault();
        //        // Adjust totalamount in purchase order
        //        pOrder.Totalamount -= viewModel.Amount;
        //        // Update quantity and amount
        //        context.Purchaseorderdetail.Remove(pOrderDetail);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public void AddToCart(CartViewModel model)
        {
            var list = context.Purchaseorderdraft.Where(p => p.Userid == model.UserId).ToList();
            var draft = context.Purchaseorderdraft.Where(li => li.Productid == model.ProductId).FirstOrDefault();
            if(draft == null)
            {
                Purchaseorderdraft poDraft = new Purchaseorderdraft()
                {
                    Productid = model.ProductId,
                    Amount = model.Amount,
                    Quantity = model.Quantity,
                    Userid = model.UserId
                };
                context.Purchaseorderdraft.Add(poDraft);                
            }
            else
            {
                draft.Quantity += model.Quantity;
                draft.Amount += model.Amount;
            }
            context.SaveChanges();
        }
        public List<CartViewModel> GetProductInDraft(int userId)
        {
            var list = context.Purchaseorderdraft.Where(p => p.Userid == userId)
                .Select(p => new CartViewModel()
                {
                    Id = p.Id,
                    ProductId = p.Productid.Value,
                    Amount = p.Amount.Value,
                    Quantity = p.Quantity.Value
                }).ToList();
            foreach(var item in list)
            {
                Productmaster pro = context.Productmaster.Where(p => p.Id == item.ProductId).FirstOrDefault();
                item.Name = pro.Name;
                item.Description = pro.Description;
                item.Image1 = pro.Image1;
            }
            return list;
        }
        public void DeleteFromCart(int _productId, int _userId)
        {
            var record = context.Purchaseorderdraft.Where(po => po.Productid == _productId && po.Userid == _userId).FirstOrDefault();
            context.Purchaseorderdraft.Remove(record);
            context.SaveChanges();
        }
        public bool ConfirmOrder(int _userId)
        {
            try
            {
                var draft = context.Purchaseorderdraft.Where(p => p.Userid == _userId).ToList();
                Purchaseorder PO = new Purchaseorder()
                {
                    Clientid = 1,
                    Totalamount = draft.Sum(p => p.Amount).Value,
                    Ponumber = "", // Logic for Order Number generation to be discussed
                    Createdby = _userId,
                    Createddate = DateTime.Now
                };
                context.Purchaseorder.Add(PO);
                foreach(var item in draft)
                {
                    context.Purchaseorderdetail.Add(new Purchaseorderdetail()
                    {
                        Purchaseorderid = PO.Id,
                        Productid = item.Productid,
                        Quantity = item.Quantity,
                        Amount = item.Amount
                    });
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
