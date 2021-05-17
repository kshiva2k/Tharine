using System;

namespace TharineWebApi.ViewModel
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
    }
}
