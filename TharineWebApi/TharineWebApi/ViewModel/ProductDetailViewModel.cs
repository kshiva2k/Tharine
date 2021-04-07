using System;

namespace TharineWebApi.ViewModel
{
    public class ProductDetailViewModel
    {
        public long Id { get; set; }
        public long PurchaseOrderId { get; set; }
        public string PONumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
    }
}
