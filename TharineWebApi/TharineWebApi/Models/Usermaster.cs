using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Usermaster
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Roleid { get; set; }
        public int? Clientid { get; set; }
        public int? Customerid { get; set; }
        public int? Status { get; set; }

        public virtual Clientmaster Client { get; set; }
        public virtual Customermaster Customer { get; set; }
        public virtual Rolemaster Role { get; set; }
    }
}
