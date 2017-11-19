using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string StateAb { get; set; }
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public int PurchasePrice { get; set; }

        
        public virtual Vehicle Vehicle { get; set; }
    }        

}
