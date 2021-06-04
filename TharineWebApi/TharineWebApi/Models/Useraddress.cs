using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Useraddress
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Contactnumber { get; set; }

        public virtual Usermaster User { get; set; }
    }
}
