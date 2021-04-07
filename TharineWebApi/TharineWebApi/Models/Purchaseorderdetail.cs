using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Purchaseorderdetail
    {
        public long Id { get; set; }
        public long Purchaseorderid { get; set; }
        public int? Productid { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }

        public virtual Productmaster Product { get; set; }
        public virtual Purchaseorder Purchaseorder { get; set; }
    }
}
