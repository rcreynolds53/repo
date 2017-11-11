using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data.EFRepos
{
    public class EFMakeRepository : ICarMakeRepository
    {
        CarDealershipDbContext context = new CarDealershipDbContext();
        public void AddCarMake(CarMake newMake)
        {
            context.CarMakes.Add(newMake);
            context.SaveChanges();
        }

        public List<CarMake> GetAllMakes()
        {
            var carMakes = (from m in context.CarMakes
                            select m).ToList();
            return carMakes;
        }

        List<CarMake> ICarMakeRepository.GetAllMakes()
        {
            throw new NotImplementedException();
        }
    }
}
