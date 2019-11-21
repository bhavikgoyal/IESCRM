using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMenuItem.Models
{
    public class getcustomerdetails
    {
        public string CustomerName { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Address_3 { get; set; }
        public string City { get; set; }
        public string ProvinceName { get; set; }
        public string Email { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public string website { get; set; }
        public string Fax { get; set; }
        public string CountryName { get; set; }
        public string PostalCode { get; set; }

        public bool IsActive { get; set; }
    }
}
