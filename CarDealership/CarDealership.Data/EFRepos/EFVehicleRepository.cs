using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data.EFRepos
{
    public class EFVehicleRepository : IVehicleRepository
    {
        CarDealershipDbContext context = new CarDealershipDbContext();

        public void AddVehicle(Vehicle newVehicle)
        {
            context.Vehicles.Add(newVehicle);
            context.SaveChanges();
        }

        public VehicleViewModel ConvertVehicleToVM(string vin)
        {
            throw new NotImplementedException();
        }

        public VehicleViewModel ConvertVehicleToVM(int id)
        {
            throw new NotImplementedException();
        }


        public void DeleteVehicle(string vin)
        {
            var vehicle = (from v in context.Vehicles
                           where v.Vin == vin
                           select v).FirstOrDefault();
            context.Vehicles.Remove(vehicle);
            context.SaveChanges();
        }

        public void DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExteriorColor> GetAllExColors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InteriorColor> GetAllIntColors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BodyStyle> GetAllStyles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transmission> GetAllTransmissions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleType> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehicles()
        {
            var vehicles = (from v in context.Vehicles
                            select v).ToList();
            return vehicles;
        }

        public Vehicle GetVehicle(string vin)
        {
            var vehicle = (from v in context.Vehicles
                           where v.Vin == vin
                           select v).FirstOrDefault();
            return vehicle;
        }

        public Vehicle GetVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(Vehicle updatedVehicle)
        {
            context.Entry(updatedVehicle).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void ConvertVehicleVmToVehicle(VehicleViewModel viewmodel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarMake> GetAllCarMakes()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Promo> GetAllSpecials()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllNewVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllUsedVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
