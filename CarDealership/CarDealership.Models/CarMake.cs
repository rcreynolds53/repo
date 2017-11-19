using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarMake
    {
        public int CarMakeId { get; set; }
        public string Manufacturer { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateAdded { get; set; }
        [NotMapped]
        public string UserName { get; set; }

        public virtual User User { get; set; }
    }
}
