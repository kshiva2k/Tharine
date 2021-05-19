namespace TharineWebApi.Models
{
    public partial class Purchaseorderdetail
    {
        public long Id { get; set; }
        public long Purchaseorderid { get; set; }
        public int? Productid { get; set; }
        public int? Quantity { get; set; }
        public decimal? Cgsttotal { get; set; }
        public decimal? Sgsttotal { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }
    }
}
