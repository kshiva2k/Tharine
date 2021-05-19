using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Productcategorymaster
    {
        public Productcategorymaster()
        {
            Subcategorymaster = new HashSet<Subcategorymaster>();
        }

        public int Id { get; set; }
        public int Clientid { get; set; }
        public int? Serviceid { get; set; }
        public string Name { get; set; }
        public int? Active { get; set; }

        public virtual Clientmaster Client { get; set; }
        public virtual Servicemaster Service { get; set; }
        public virtual ICollection<Subcategorymaster> Subcategorymaster { get; set; }
    }
}
