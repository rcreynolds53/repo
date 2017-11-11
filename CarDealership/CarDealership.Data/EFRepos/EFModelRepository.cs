using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data.EFRepos
{
    public class EFModelRepository : ICarModelRepository
    {
        CarDealershipDbContext context = new CarDealershipDbContext();

        public void AddCarModel(CarModel newModel)
        {
            context.CarModels.Add(newModel);
            context.SaveChanges();
        }

        public List<CarModel> GetAllCarModels()
        {
            var carModels = context.CarModels.Include("CarMake").ToList();

            return carModels;
        }

        public List<CarModel> GetModelsByMake(int makeId)
        {
            var carModels = context.CarModels.Include("CarMake");

            return carModels.Where(m => m.CarMake.CarMakeId == makeId).ToList();
            throw new NotImplementedException();
            //var carModels = (from m in context.CarModels
            //                 where m.CarMakeId == makeId
            //                 select m).ToList();

            //return carModels;
        }
    }
}
