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

        public void AddSpecial(Promo special)
        {
            throw new NotImplementedException();
        }

        public List<CarModel> GetModelsByMake(int makeId)
        {
            throw new NotImplementedException();
        }

        public void AddContactRequest(ContactRequest request)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehiclesFromNewSearch(SearchViewModel search)
        {
            var vehicles = context.Vehicles.Where(v => v.VehicleType.VehicleTypeName.ToUpper() == "NEW"
                                                    && v.IsForSale == true).ToList();

            if (string.IsNullOrWhiteSpace(search.MakeModelYear))
            {
                vehicles = vehicles.Where(v => v.CarModel.CarMake.Manufacturer.Contains(search.MakeModelYear) ||
                                                           v.CarModel.CarModelName.Contains(search.MakeModelYear) ||
                                                          v.Year.ToString().Contains(search.MakeModelYear)).ToList();
            }
            if (search.MinPrice.HasValue)
            {
                vehicles = vehicles.Where(v => v.Msrp > search.MinPrice).ToList();
            }
            if (search.MaxPrice.HasValue)
            {
                vehicles = vehicles.Where(v => v.Msrp < search.MaxPrice).ToList();
            }
            if (search.MinYear.HasValue)
            {
                vehicles = vehicles.Where(v => v.Year > search.MinYear).ToList();
            }
            if (search.MaxYear.HasValue)
            {
                vehicles = vehicles.Where(v => v.Year < search.MaxYear).ToList();

            }
            return vehicles;
        }

        public List<Vehicle> GetVehiclesFromUsedSearch(SearchViewModel search)
        {
            var vehicles = context.Vehicles.Where(v => v.VehicleType.VehicleTypeName.ToUpper() == "USED"
                                                     && v.IsForSale == true).ToList();

            if (string.IsNullOrWhiteSpace(search.MakeModelYear))
            {
                vehicles = vehicles.Where(v => v.CarModel.CarMake.Manufacturer.Contains(search.MakeModelYear) ||
                                                           v.CarModel.CarModelName.Contains(search.MakeModelYear) ||
                                                          v.Year.ToString().Contains(search.MakeModelYear)).ToList();
            }
            if (search.MinPrice.HasValue)
            {
                vehicles = vehicles.Where(v => v.Msrp > search.MinPrice).ToList();
            }
            if (search.MaxPrice.HasValue)
            {
                vehicles = vehicles.Where(v => v.Msrp < search.MaxPrice).ToList();
            }
            if (search.MinYear.HasValue)
            {
                vehicles = vehicles.Where(v => v.Year > search.MinYear).ToList();
            }
            if (search.MaxYear.HasValue)
            {
                vehicles = vehicles.Where(v => v.Year < search.MaxYear).ToList();

            }
            return vehicles;
        }

        public List<Vehicle> GetAllVehiclesFromSearch(SearchViewModel search)
        {
            {
                var vehicles = context.Vehicles.ToList();

                if (string.IsNullOrWhiteSpace(search.MakeModelYear))
                {
                    vehicles = vehicles.Where(v => v.CarModel.CarMake.Manufacturer.Contains(search.MakeModelYear) ||
                                                               v.CarModel.CarModelName.Contains(search.MakeModelYear) ||
                                                              v.Year.ToString().Contains(search.MakeModelYear)).ToList();
                }
                if (search.MinPrice.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Msrp > search.MinPrice).ToList();
                }
                if (search.MaxPrice.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Msrp < search.MaxPrice).ToList();
                }
                if (search.MinYear.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Year > search.MinYear).ToList();
                }
                if (search.MaxYear.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Year < search.MaxYear).ToList();

                }
                return vehicles;
            }
        }

        public List<Vehicle> GetAllVehiclesForSaleSearch(SearchViewModel search)
        {
            {
                var vehicles = context.Vehicles.Where(v => v.IsForSale == true).ToList();

                if (string.IsNullOrWhiteSpace(search.MakeModelYear))
                {
                    vehicles = vehicles.Where(v => v.CarModel.CarMake.Manufacturer.Contains(search.MakeModelYear) ||
                                                               v.CarModel.CarModelName.Contains(search.MakeModelYear) ||
                                                              v.Year.ToString().Contains(search.MakeModelYear)).ToList();
                }
                if (search.MinPrice.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Msrp > search.MinPrice).ToList();
                }
                if (search.MaxPrice.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Msrp < search.MaxPrice).ToList();
                }
                if (search.MinYear.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Year > search.MinYear).ToList();
                }
                if (search.MaxYear.HasValue)
                {
                    vehicles = vehicles.Where(v => v.Year < search.MaxYear).ToList();

                }
                return vehicles;
            }
        }
    }
}
