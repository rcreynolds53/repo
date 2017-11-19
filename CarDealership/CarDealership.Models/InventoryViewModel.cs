using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class InventoryViewModel
    {
        public Vehicle Vehicle { get; set; }
        public int Year { get; set; }
        public CarModel CarModel { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }

        public InventoryViewModel()
        {
            Vehicle = new Vehicle();
            CarModel = new CarModel();
        }

    }
}
