using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Subcategorymaster
    {
        public Subcategorymaster()
        {
            Productmaster = new HashSet<Productmaster>();
        }

        public int Id { get; set; }
        public int Categoryid { get; set; }
        public string Name { get; set; }
        public int? Active { get; set; }

        public virtual Productcategorymaster Category { get; set; }
        public virtual ICollection<Productmaster> Productmaster { get; set; }
    }
}
