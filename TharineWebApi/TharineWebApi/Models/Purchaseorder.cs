using System;

namespace TharineWebApi.Models
{
    public partial class Purchaseorder
    {
        public long Id { get; set; }
        public string Ponumber { get; set; }
        public int? Clientid { get; set; }
        public int? Userid { get; set; }
        public decimal? Totalamount { get; set; }
        public short? Ispaid { get; set; }
        public DateTime? Deliverydate { get; set; }
        public string Deliveredby { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createddate { get; set; }
        public int? Status { get; set; }

        public virtual Clientmaster Client { get; set; }
        public virtual Usermaster User { get; set; }
    }
}
