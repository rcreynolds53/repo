using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class State
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
    }
}
