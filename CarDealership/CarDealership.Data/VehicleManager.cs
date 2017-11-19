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

        //public void AddVehicle(Vehicle newVehicle)
        //{
        //    _vehicleRepo.AddVehicle(newVehicle);
        //}

        public void AddCarMake(CarMake newMake)
        {
            _vehicleRepo.AddCarMake(newMake);
        }
        //public void AddCarMake(CarModel newModel)
        //{
        //    _vehicleRepo.AddCarModel(newModel);
        //}

        public void ConvertVehicleVmToVehicle(VehicleViewModel viewModel)
        {
            _vehicleRepo.ConvertVehicleVmToVehicle(viewModel);
        }

        //public void UpdateVehicle(Vehicle updatedVehicle)
        //{
        //    _vehicleRepo.UpdateVehicle(updatedVehicle);
        //}

        //public void DeleteVehicle(int id)
        //{
        //    _vehicleRepo.DeleteVehicle(id);
        //}

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
        public IEnumerable<PurchaseType> GetAllPurchaseTypes()
        {
            return _vehicleRepo.GetAllPurchaseTypes();
        }

        // ************* Make Methods ***********

        public IEnumerable<CarMake> GetAllMakes()
        {
            return _vehicleRepo.GetAllCarMakes();
        }

        public void ConvertUserVMtoUserAdd(UserViewModel userVM)
        {
            _userRepo.ConvertVMtoUserAdd(userVM);
        }

        public void ConvertUserVMtoUserEdit(UserViewModel userVM)
        {
            _userRepo.ConvertVMtoUserEdit(userVM);
        }

        public UserViewModel ConvertUserToVM(User userToEdit)
        {
            return _userRepo.ConvertUserToVM(userToEdit);
        }

        // ************* Model Methods ***********

        public List<CarModel> GetModelsByMake(int makeId)
        {
            return _vehicleRepo.GetModelsByMake(makeId);
        }
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

        public IEnumerable<Role> GetAllRoles()
        {
            return _userRepo.GetAllRoles();
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }
        public void DisableUser(string id)
        {
            _userRepo.DisableUser(id);
        }

        public void ConvertCarModelVMtoCarModel(CarModelViewModel newModel)
        {
            _vehicleRepo.ConvertCarModelVMtoCarModel(newModel);
        }

        public User GetUser(string id)
        {
            return _userRepo.GetUser(id);
        }

        public void AddSpecial(Promo special)
        {
            _vehicleRepo.AddSpecial(special);
        }

        public void AddContactRequest(ContactRequest request)
        {
            _vehicleRepo.AddContactRequest(request);
        }
        public List<Vehicle> GetVehiclesFromNewSearch(SearchViewModel search)
        {
            return _vehicleRepo.GetVehiclesFromNewSearch(search);
        }
        public List<Vehicle> GetVehiclesFromUsedSearch(SearchViewModel search)
        {
            return _vehicleRepo.GetVehiclesFromUsedSearch(search);
        }
        public List<Vehicle> GetAllVehiclesFromSearch(SearchViewModel search)
        {
            return _vehicleRepo.GetAllVehiclesFromSearch(search);
        }
        public List<Vehicle> GetAllVehiclesForSaleSearch(SearchViewModel search)
        {
            return _vehicleRepo.GetAllVehiclesForSaleSearch(search);
        }
        public void ConvertPurchaseToInvoice(InvoiceViewModel invoiceVM)
        {
            _vehicleRepo.ConvertPurchaseToInvoice(invoiceVM);
        }
        public VehicleViewModel ConvertVehicleToPurchase(int id)
        {
            return _vehicleRepo.ConvertVehicleToPurchase(id);
        }

        public List<InventoryViewModel> GetInventoryReport()
        {
            return _vehicleRepo.InventoryReport();
        }
        public List<UserSalesViewModel> SalesReport(SalesFilterModel filters)
        {
            return _vehicleRepo.SalesReport(filters);
        }
    }
}
