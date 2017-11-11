using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        public string CarModelName { get; set; }
        //public int CarMakeId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }
        //public string UserId { get; set; }

        public virtual CarMake CarMake { get; set; }
        public virtual User User { get; set; }
    }
}
