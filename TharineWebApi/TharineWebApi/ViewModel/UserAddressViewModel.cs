using System;
namespace TharineWebApi.ViewModel
{
    public class UserAddressViewModel
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Contactnumber { get; set; }
    }
}
