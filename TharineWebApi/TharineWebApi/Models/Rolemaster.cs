using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Rolemaster
    {
        public Rolemaster()
        {
            Usermaster = new HashSet<Usermaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<Usermaster> Usermaster { get; set; }
    }
}
