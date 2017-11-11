using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class ContactRequest
    {
        public int ContactRequestId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }
        //public string Vin { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
