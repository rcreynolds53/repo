using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class VehicleManager
    {
        static IVehicleRepository _vehicleRepo;
        static IUserRepo _userRepo;

        public VehicleManager(IVehicleRepository vehicleRepo, IUserRepo userRepo)
        {
            _vehicleRepo = vehicleRepo;
            _userRepo = userRepo;
        }

        // ****** Vehicle Methods *********

        public List<Vehicle> GetFeaturedVehicles()
        {
            return _vehicleRepo.GetFeaturedVehicles();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepo.GetAllVehicles();
        }

        public IEnumerable<ExteriorColor> GetAllExColors()
        {
            return _vehicleRepo.GetAllExColors();
        }

        public IEnumerable<InteriorColor> GetAllIntColors()
        {
            return _vehicleRepo.GetAllIntColors();
        }

        public IEnumerable<Transmission> GetAllTransmissions()
        {
            return _vehicleRepo.GetAllTransmissions();
        }

        public Vehicle GetVehicle(int id)
        {
            return _vehicleRepo.GetVehicle(id);
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            _vehicleRepo.AddVehicle(newVehicle);
        }

        public void ConvertVehicleVmToVehicle(VehicleViewModel viewModel)
        {
            _vehicleRepo.ConvertVehicleVmToVehicle(viewModel);
        }

        public void UpdateVehicle(Vehicle updatedVehicle)
        {
            _vehicleRepo.UpdateVehicle(updatedVehicle);
        }

        public void DeleteVehicle(int id)
        {
            _vehicleRepo.DeleteVehicle(id);
        }

        public VehicleViewModel ConvertVehicleToVM(int id)
        {
            return _vehicleRepo.ConvertVehicleToVM(id);
        }

        public IEnumerable<VehicleType> GetAllTypes()
        {
            return _vehicleRepo.GetAllTypes();
        }

        public IEnumerable<BodyStyle> GetAllStyles()
        {
            return _vehicleRepo.GetAllStyles();
        }

        // ************* Make Methods ***********

        public IEnumerable<CarMake> GetAllMakes()
        {
            return _vehicleRepo.GetAllCarMakes();
        }

        // ************* Model Methods ***********

        //public List<CarModel> GetModelsFromMake(int makeId)
        //{
        //    return _vehicleRepo.GetModelsByMake(makeId);
        //}
        public IEnumerable<CarModel> GetAllCarModels()
        {
            return _vehicleRepo.GetAllCarModels();
        }

        public List<Promo> GetAllSpecials()
        {
           return _vehicleRepo.GetAllSpecials();
        }

        public List<Vehicle> GetAllUsedVehicles()
        {
            return _vehicleRepo.GetAllUsedVehicles();
        }

        public List<Vehicle> GetAllNewVehicles()
        {
            return _vehicleRepo.GetAllNewVehicles();
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
        public void AddUser(User newUser)
        {
            _userRepo.AddUser(newUser);
        }

        public void EditUser(User updatedUser)
        {
            _userRepo.EditUser(updatedUser);
        }
    }
}
