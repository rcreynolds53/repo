﻿using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ICarModelRepository
    {
        List<CarModel> GetAllCarModels();
        void AddCarModel(CarModel newModel);
        List<CarModel> GetModelsByMake(int makeId);
    }
}
