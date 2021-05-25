using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Clientmaster
    {
        public Clientmaster()
        {
            Clientsubscriptions = new HashSet<Clientsubscriptions>();
            Productcategorymaster = new HashSet<Productcategorymaster>();
            Purchaseorder = new HashSet<Purchaseorder>();
            Usermaster = new HashSet<Usermaster>();
        }

        public int  Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Contactno { get; set; }
        public string Emailid { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Gstinnumber { get; set; }
        public int? Minimumorderamount { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Clientsubscriptions> Clientsubscriptions { get; set; }
        public virtual ICollection<Productcategorymaster> Productcategorymaster { get; set; }
        public virtual ICollection<Purchaseorder> Purchaseorder { get; set; }
        public virtual ICollection<Usermaster> Usermaster { get; set; }
    }
}
