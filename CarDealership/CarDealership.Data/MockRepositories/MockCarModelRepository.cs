using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
   public class MockCarModelRepository : ICarModelRepository
    {
        private static List<CarModel> _carModels;

        static MockCarModelRepository()
        {
            List<CarMake> carMakes = new MockCarMakeRepository().GetAllMakes();
            _carModels = new List<CarModel>()
            {
                new CarModel { CarModelId = 1, CarModelName = "F250", DateAdded = DateTime.Parse("10/01/2017"), CarMake = carMakes[0]},
                new CarModel { CarModelId = 2, CarModelName = "Silverado 1500", DateAdded = DateTime.Parse("10/02/2017"),CarMake = carMakes[1]},
                new CarModel { CarModelId = 3, CarModelName = "Ram 1500", DateAdded = DateTime.Parse("10/03/2017"),CarMake = carMakes[2]},
                new CarModel { CarModelId = 4, CarModelName = "F150", DateAdded = DateTime.Parse("10/04/2017"),CarMake = carMakes[0]},

            };
        }

        public List<CarModel> GetAllCarModels()
        {
            return _carModels;
        }

        public List<CarModel> GetModelsByMake(int makeId)
        {
            return _carModels.Where(c => c.CarMake.CarMakeId == makeId).ToList();
        }

        public void AddCarModel(CarModel carModel)
        {
            if(_carModels.Any())
            {
                carModel.CarModelId = _carModels.Max(c => c.CarModelId) + 1;
            }
            carModel.CarModelId = 1;

            _carModels.Add(carModel);
        }
    }
}
