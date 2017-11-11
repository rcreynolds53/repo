using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
   public class MockCarMakeRepository : ICarMakeRepository
    {
         static List<CarMake> _carMakes;

        public MockCarMakeRepository()
        {
            _carMakes = new List<CarMake>()
            {
                new CarMake{ CarMakeId =1, Manufacturer = "Ford" },
                new CarMake { CarMakeId=2, Manufacturer = "Chevy" },
                new CarMake { CarMakeId = 3, Manufacturer = "Dodge"}
            };
        }

        public List<CarMake> GetAllMakes()
        {
            return _carMakes.ToList();
        }

        public void AddCarMake(CarMake newMake)
        {
            if (_carMakes.Any())
            {
                newMake.CarMakeId = _carMakes.Max(m => m.CarMakeId) + 1;
            }
            else
            {
                newMake.CarMakeId = 1;
            }
            _carMakes.Add(newMake);
        }
    }
}
