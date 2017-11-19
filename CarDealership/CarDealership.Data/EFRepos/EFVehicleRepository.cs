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

        //public void AddVehicle(Vehicle newVehicle)
        //{
        //    context.Vehicles.Add(newVehicle);
        //    context.SaveChanges();
        //}


        public VehicleViewModel ConvertVehicleToVM(int id)
        {
            var vehicle = context.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            var vehicleVM = new VehicleViewModel();
            vehicleVM.Vehicle = vehicle;
            vehicleVM.SetCarMakeItems(context.CarMakes);
            vehicleVM.SetBodyStyleItems(context.BodyStyles);
            vehicleVM.SetVehicleTypeItems(context.VehicleTypes);
            vehicleVM.SetCarModelItems(context.CarModels);
            vehicleVM.SetExColorItems(context.ExteriorColors);
            vehicleVM.SetIntColorItems(context.InteriorColors);
            vehicleVM.SetTransmissionItems(context.Transmissions);

            return vehicleVM;
        }


        //public void DeleteVehicle(string vin)
        //{
        //    var vehicle = (from v in context.Vehicles
        //                   where v.Vin == vin
        //                   select v).FirstOrDefault();
        //    context.Vehicles.Remove(vehicle);
        //    context.SaveChanges();
        //}

        //public void DeleteVehicle(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<ExteriorColor> GetAllExColors()
        {
            return context.ExteriorColors.ToList();
        }

        public IEnumerable<InteriorColor> GetAllIntColors()
        {
            return context.InteriorColors.ToList();
        }

        public IEnumerable<BodyStyle> GetAllStyles()
        {
            return context.BodyStyles.ToList();
        }

        public IEnumerable<Transmission> GetAllTransmissions()
        {
            return context.Transmissions.ToList();
        }

        public IEnumerable<VehicleType> GetAllTypes()
        {
            return context.VehicleTypes.ToList();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return context.Vehicles.ToList();

        }
        public Vehicle GetVehicle(int id)
        {
            return context.Vehicles.SingleOrDefault(v => v.VehicleId == id);
        }

        public void UpdateVehicle(Vehicle updatedVehicle)
        {
            context.Entry(updatedVehicle).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void ConvertVehicleVmToVehicle(VehicleViewModel viewmodel)
        {
            Vehicle vehicle = viewmodel.Vehicle;
            if (viewmodel.Vehicle.VehicleId == 0)
            {
                vehicle = viewmodel.Vehicle;
                vehicle.CarModel = context.CarModels.FirstOrDefault(m => m.CarModelId == viewmodel.Vehicle.CarModel.CarModelId);
                vehicle.BodyStyle = context.BodyStyles.FirstOrDefault(b => b.BodyStyleId == viewmodel.Vehicle.BodyStyle.BodyStyleId);
                vehicle.ExteriorColor = context.ExteriorColors.FirstOrDefault(c => c.ExteriorColorId == viewmodel.Vehicle.ExteriorColor.ExteriorColorId);
                vehicle.InteriorColor = context.InteriorColors.FirstOrDefault(c => c.InteriorColorId == viewmodel.Vehicle.InteriorColor.InteriorColorId);
                vehicle.Transmission = context.Transmissions.FirstOrDefault(t => t.TransmissionId == viewmodel.Vehicle.Transmission.TransmissionId);
                vehicle.VehicleType = context.VehicleTypes.FirstOrDefault(t => t.VehicleTypeId == viewmodel.Vehicle.VehicleType.VehicleTypeId);
                vehicle.IsVehicleSold = false;
                context.Vehicles.Add(vehicle);
                context.SaveChanges();

            }
            else
            {
                vehicle = context.Vehicles.FirstOrDefault(v=>v.VehicleId == viewmodel.Vehicle.VehicleId);
                vehicle.CarModel = context.CarModels.FirstOrDefault(m => m.CarModelId == viewmodel.Vehicle.CarModel.CarModelId);
                vehicle.BodyStyle = context.BodyStyles.FirstOrDefault(b => b.BodyStyleId == viewmodel.Vehicle.BodyStyle.BodyStyleId);
                vehicle.ExteriorColor = context.ExteriorColors.FirstOrDefault(c => c.ExteriorColorId == viewmodel.Vehicle.ExteriorColor.ExteriorColorId);
                vehicle.InteriorColor = context.InteriorColors.FirstOrDefault(c => c.InteriorColorId == viewmodel.Vehicle.InteriorColor.InteriorColorId);
                vehicle.Transmission = context.Transmissions.FirstOrDefault(t => t.TransmissionId == viewmodel.Vehicle.Transmission.TransmissionId);
                vehicle.VehicleType = context.VehicleTypes.FirstOrDefault(t => t.VehicleTypeId == viewmodel.Vehicle.VehicleType.VehicleTypeId);
                vehicle.IsVehicleSold = false;
                context.Entry(vehicle).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            return context.CarModels.ToList();

        }

        public IEnumerable<CarMake> GetAllCarMakes()
        {
            return context.CarMakes.ToList();

        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return context.Vehicles.Where(v => v.IsFeatured == true).ToList();
        }

        public List<Promo> GetAllSpecials()
        {
            return context.Promos.ToList();
        }

        public List<Vehicle> GetAllNewVehicles()
        {
            return context.Vehicles.Where(v => v.VehicleType.VehicleTypeId == 1).ToList();
        }

        public List<Vehicle> GetAllUsedVehicles()
        {
            return context.Vehicles.Where(v => v.VehicleType.VehicleTypeId == 2).ToList();
        }

        public void AddSpecial(Promo special)
        {
            context.Promos.Add(special);
            context.SaveChanges();
        }

        public List<CarModel> GetModelsByMake(int makeId)
        {
            return context.CarModels.Where(m => m.CarMake.CarMakeId == makeId).ToList();
        }

        public void AddContactRequest(ContactRequest request)
        {
            context.ContactRequests.Add(request);
            context.SaveChanges();
        }

        public List<Vehicle> GetVehiclesFromNewSearch(SearchViewModel search)
        {
            var vehicles = context.Vehicles.Where(v => v.VehicleType.VehicleTypeName.ToUpper() == "NEW"
                                                    && v.IsVehicleSold == true).ToList();

            if (!string.IsNullOrWhiteSpace(search.MakeModelYear))
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
                                                     && v.IsVehicleSold == true).ToList();

            if (!string.IsNullOrWhiteSpace(search.MakeModelYear))
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

                if (!string.IsNullOrWhiteSpace(search.MakeModelYear))
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
                var vehicles = context.Vehicles.Where(v => v.IsVehicleSold == false).ToList();

                if (!string.IsNullOrWhiteSpace(search.MakeModelYear))
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

        public IEnumerable<PurchaseType> GetAllPurchaseTypes()
        {
            return context.PurchaseTypes.ToList();
        }

        public InvoiceViewModel ConvertVehicleToPurchase(int id)
        {
            InvoiceViewModel invoiceVM = new InvoiceViewModel();
            invoiceVM.Vehicle = context.Vehicles.SingleOrDefault(v => v.VehicleId == id);
            invoiceVM.Invoice = new Invoice();
            invoiceVM.SetPurchaseTypeItems(context.PurchaseTypes.ToList());
            return invoiceVM;
        }

        public void ConvertPurchaseToInvoice(InvoiceViewModel invoiceVM)
        {
            var invoice = invoiceVM.Invoice;
            invoice.PurchaseDate = DateTime.Now;
            invoice.Vehicle = context.Vehicles.SingleOrDefault(i => i.VehicleId == invoiceVM.Vehicle.VehicleId);
            invoice.User = context.Users.SingleOrDefault(u => u.UserName == invoiceVM.UserName);
            context.Invoices.Add(invoice);
            context.SaveChanges();

            Vehicle vehicletoUpdate = context.Vehicles.SingleOrDefault(v => v.VehicleId == invoiceVM.Vehicle.VehicleId);
            vehicletoUpdate.IsVehicleSold = true;
            context.Entry(vehicletoUpdate).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

        }

        public void AddCarMake(CarMake newMake)
        {
            var user = context.Users.SingleOrDefault(u => u.UserName == newMake.UserName);
            newMake.User = user;
            context.CarMakes.Add(newMake);
            context.SaveChanges();
        }

        public void AddCarModel(CarModel newModel)
        {
            context.CarModels.Add(newModel);
            context.SaveChanges();
        }

        public void ConvertCarModelVMtoCarModel(CarModelViewModel newModel)
        {
            CarModel newCarModel = new CarModel();
            newCarModel = newModel.CarModel;
            newCarModel.User = context.Users.Single(u => u.UserName == newModel.UserName);
            newCarModel.CarMake = context.CarMakes.FirstOrDefault(m => m.CarMakeId == newModel.CarModel.CarMake.CarMakeId);
            context.CarModels.Add(newCarModel);
            context.SaveChanges();
        }

        public List<InventoryViewModel> InventoryReport()
        {
            return context.Vehicles.GroupBy(v => new
            {
                v.CarModel,
                v.Year
            })
            .Select(v => new InventoryViewModel
            {
                Year = v.Key.Year,
                CarModel = v.Key.CarModel,
                Count = v.Count(),
                StockValue = v.Sum(c=>c.Msrp)

            }).ToList();
                            
        }

        public List<UserSalesViewModel> SalesReport(SalesFilterModel filters)
        {
            var toDate = Convert.ToDateTime(filters.ToDate);
            var fromDate = Convert.ToDateTime(filters.FromDate);
            var vehiclesSoldByUser = context.Invoices.GroupBy(i => new
            {
                i.User
                //i.PurchaseDate
            }).Select(i => new UserSalesViewModel
            {
                User = i.Key.User,
                TotalSales = i.Sum(p => p.PurchasePrice),
                TotalVehicles = i.Count()
            }).ToList();

            if(!string.IsNullOrWhiteSpace(filters.UserId))
            {
                vehiclesSoldByUser = vehiclesSoldByUser.Where(i => i.User.Id == filters.UserId).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filters.FromDate))
            {
               vehiclesSoldByUser = vehiclesSoldByUser.Where(v => v.Invoice.PurchaseDate.CompareTo(fromDate) >= 0).ToList();
            }
            if(!string.IsNullOrWhiteSpace(filters.ToDate))
            {
                vehiclesSoldByUser = vehiclesSoldByUser.Where(v => v.Invoice.PurchaseDate.CompareTo(toDate) <= -1).ToList();
            }
            return vehiclesSoldByUser;
        }
    }
}
