using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Purchaseorderdraft
    {
        public int Id { get; set; }
        public int? Productid { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Cgsttotal { get; set; }
        public decimal? Sgsttotal { get; set; }
        public int? Userid { get; set; }
    }
}
