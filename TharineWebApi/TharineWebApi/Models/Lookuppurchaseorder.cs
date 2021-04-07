using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Lookuppurchaseorder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Active { get; set; }
    }
}
