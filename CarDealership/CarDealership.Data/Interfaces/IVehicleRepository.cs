﻿using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
   public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
        void AddVehicle(Vehicle newVehicle);
        void DeleteVehicle(int id);
        void UpdateVehicle(Vehicle updatedVehicle);
        Vehicle GetVehicle(int id);
        void ConvertVehicleVmToVehicle(VehicleViewModel viewmodel);
        VehicleViewModel ConvertVehicleToVM(int id);
        IEnumerable<VehicleType> GetAllTypes();
        IEnumerable<BodyStyle> GetAllStyles();
        IEnumerable<ExteriorColor> GetAllExColors();
        IEnumerable<InteriorColor> GetAllIntColors();
        IEnumerable<Transmission> GetAllTransmissions();
        IEnumerable<CarModel> GetAllCarModels();
        IEnumerable<CarMake> GetAllCarMakes();
        List<Vehicle> GetFeaturedVehicles();
        List<Promo> GetAllSpecials();
    }
}