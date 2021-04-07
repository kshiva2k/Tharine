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
        public bool AddProduct(ProductDetailViewModel viewModel)
        {
            try
            {
                Purchaseorder PO = new Purchaseorder()
                {
                    Clientid = viewModel.ClientId,
                    Totalamount = viewModel.Amount,
                    Ponumber = "", // Logic for Order Number generation to be discussed
                    Createdby = viewModel.UserId,
                    Createddate = DateTime.Now
                };
                context.Purchaseorder.Add(PO);
                if(viewModel.PurchaseOrderId == 0)
                {
                    // New purchase order
                    context.Purchaseorder.Add(PO);
                }
                else
                {
                    // Update total amount
                    var porder = context.Purchaseorder.Where(x => x.Id == viewModel.PurchaseOrderId).FirstOrDefault();
                    porder.Totalamount += viewModel.Amount;
                    porder.Createddate = DateTime.Now;
                }
                context.Purchaseorderdetail.Add(new Purchaseorderdetail()
                {
                    Purchaseorderid = PO.Id,
                    Productid = viewModel.ProductId,
                    Quantity = viewModel.Quantity,
                    Amount = viewModel.Amount
                });

                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool UpdateProduct(ProductDetailViewModel viewModel)
        {
            try
            {
                var pOrder = context.Purchaseorder.Where(x => x.Id == viewModel.PurchaseOrderId).FirstOrDefault();
                var pOrderDetail = context.Purchaseorderdetail.Where(x => x.Id == viewModel.Id).FirstOrDefault();
                // Adjust totalamount in purchase order
                pOrder.Totalamount += (viewModel.Amount - pOrderDetail.Amount);
                // Update quantity and amount
                pOrderDetail.Quantity = viewModel.Quantity;
                pOrderDetail.Amount = viewModel.Quantity;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteProduct(ProductDetailViewModel viewModel)
        {
            try
            {
                var pOrder = context.Purchaseorder.Where(x => x.Id == viewModel.PurchaseOrderId).FirstOrDefault();
                var pOrderDetail = context.Purchaseorderdetail.Where(x => x.Id == viewModel.Id).FirstOrDefault();
                // Adjust totalamount in purchase order
                pOrder.Totalamount -= viewModel.Amount;
                // Update quantity and amount
                context.Purchaseorderdetail.Remove(pOrderDetail);
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
