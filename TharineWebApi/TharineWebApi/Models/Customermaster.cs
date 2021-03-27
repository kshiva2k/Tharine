using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Customermaster
    {
        public Customermaster()
        {
            Usermaster = new HashSet<Usermaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobileno { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Usermaster> Usermaster { get; set; }
    }
}
