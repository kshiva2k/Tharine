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
            var product = context.Productmaster.Where(p => p.Id == model.ProductId).FirstOrDefault();
            if (draft == null)
            {
                Purchaseorderdraft poDraft = new Purchaseorderdraft()
                {
                    Productid = model.ProductId,
                    Amount = model.Amount * model.Quantity,
                    Quantity = model.Quantity,
                    Sgsttotal = ((model.Amount * product.Sgstpercent) / 100) * model.Quantity,
                    Cgsttotal = ((model.Amount * product.Cgstpercent) / 100) * model.Quantity,
                    Userid = model.UserId
                };
                context.Purchaseorderdraft.Add(poDraft);
            }
            else
            {
                draft.Quantity += model.Quantity;
                draft.Amount += (model.Amount * model.Quantity);
                draft.Sgsttotal += ((model.Amount * product.Sgstpercent) / 100) * model.Quantity;
                draft.Cgsttotal += ((model.Amount * product.Cgstpercent) / 100) * model.Quantity;
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
                    Quantity = p.Quantity.Value,
                    SGST = p.Sgsttotal.Value,
                    CGST = p.Cgsttotal.Value,
                    Total = p.Amount.Value + p.Sgsttotal.Value + p.Cgsttotal.Value
                }).ToList();
            foreach (var item in list)
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
        public bool ConfirmOrder(List<int> Ids, int _userId)
        {
            try
            {
                List<Purchaseorderdraft> draftlist = new List<Purchaseorderdraft>();
                decimal total = 0;
                foreach (int id in Ids)
                {
                    var draft = context.Purchaseorderdraft.Where(p => p.Id == id).FirstOrDefault();
                    draftlist.Add(draft);
                    total += draft.Amount.Value + draft.Cgsttotal.Value + draft.Sgsttotal.Value;
                }
                Purchaseorder PO = new Purchaseorder()
                {
                    Clientid = 1,
                    Totalamount = total,
                    Ponumber = "", // Logic for Order Number generation to be discussed
                    Createdby = _userId,
                    Createddate = DateTime.Now
                };
                context.Purchaseorder.Add(PO);
                foreach (var item in draftlist)
                {
                    context.Purchaseorderdetail.Add(new Purchaseorderdetail()
                    {
                        Purchaseorderid = PO.Id,
                        Productid = item.Productid,
                        Quantity = item.Quantity,
                        Amount = item.Amount,
                        Sgsttotal = item.Sgsttotal,
                        Cgsttotal = item.Cgsttotal
                    });
                    var product = context.Productmaster.Where(p => p.Id == item.Productid.Value).FirstOrDefault();
                    product.Stock -= item.Quantity.Value;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
