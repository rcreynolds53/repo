using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        //public int PurchaseTypeId { get; set; }
        //public int CustomerId { get; set; }
        //public string Vin { get; set; }
        //public string UserId { get; set; }

        public virtual PurchaseType PurchaseType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual User User { get; set; }
    }
}
