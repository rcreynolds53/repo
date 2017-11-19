using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class CarModelViewModel
    {
        public CarModel CarModel { get; set; }
        public List<SelectListItem> CarMakeItems { get; set; }
        public string UserName { get; set; }

        public CarModelViewModel()
        {
            CarMakeItems = new List<SelectListItem>();
        }

        public void SetCarMakeItems(IEnumerable<CarMake> carMakes)
        {
            foreach(var m in carMakes)
            {
                CarMakeItems.Add(new SelectListItem
                {
                    Text = m.Manufacturer,
                    Value = m.CarMakeId.ToString()
                });
            }
        }
    }
}
