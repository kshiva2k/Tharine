using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Productmaster
    {
        public int Id { get; set; }
        public int Categoryid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int? Active { get; set; }

        public virtual Productcategorymaster Category { get; set; }
    }
}
