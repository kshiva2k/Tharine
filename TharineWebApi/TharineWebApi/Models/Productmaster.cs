using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Productmaster
    {
        public Productmaster()
        {
            Purchaseorderdetail = new HashSet<Purchaseorderdetail>();
        }

        public int Id { get; set; }
        public int Subcategoryid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int? Stock { get; set; }
        public string Size { get; set; }
        public decimal? Marketprice { get; set; }
        public decimal? Saleprice { get; set; }
        public decimal? Cgstpercent { get; set; }
        public decimal? Sgstpercent { get; set; }
        public DateTime? Expirydate { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Keywords { get; set; }
        public int? Active { get; set; }

        public virtual Subcategorymaster Subcategory { get; set; }
        public virtual ICollection<Purchaseorderdetail> Purchaseorderdetail { get; set; }
    }
}
