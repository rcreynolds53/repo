using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
   public interface ICarMakeRepository
    {
        void AddCarMake(CarMake newMake);
        List<CarMake> GetAllMakes();
    }
}
