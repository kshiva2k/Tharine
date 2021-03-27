using System;
using System.Collections.Generic;

namespace TharineWebApi.Models
{
    public partial class Clientsubscriptions
    {
        public int Id { get; set; }
        public int? Clientid { get; set; }
        public int? Serviceid { get; set; }
        public DateTime? Fromdate { get; set; }
        public DateTime? Todate { get; set; }
        public int? Active { get; set; }

        public virtual Clientmaster Client { get; set; }
        public virtual Servicemaster Service { get; set; }
    }
}
