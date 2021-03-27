using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Servicemaster
    {
        public Servicemaster()
        {
            Clientsubscriptions = new HashSet<Clientsubscriptions>();
            Productcategorymaster = new HashSet<Productcategorymaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Clientsubscriptions> Clientsubscriptions { get; set; }
        public virtual ICollection<Productcategorymaster> Productcategorymaster { get; set; }
    }
}
