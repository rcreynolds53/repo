using CarDealership.Data.Interfaces;
using CarDealership.Data.MockRepositories;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public class MockVehicleRepository : IVehicleRepository
    {
         static List<Vehicle> _vehicles;
         static List<ExteriorColor> _exColors;
         static List<InteriorColor> _intColors;
         static List<Transmission> _transmissions;
         static List<BodyStyle> _bodyStyles;
         static List<VehicleType> _types;
        static List<CarMake> _carMakes;
        static List<CarModel> _carModels;
        static List<Promo> _specials;

        static MockVehicleRepository()
        {
            _carMakes = new List<CarMake>()
            {
                new CarMake{ CarMakeId =1, Manufacturer = "Ford" },
                new CarMake { CarMakeId=2, Manufacturer = "Chevy" },
                new CarMake { CarMakeId = 3, Manufacturer = "Dodge"}
            };

            _carModels = new List<CarModel>()
            {
                new CarModel { CarModelId = 1, CarModelName = "F250", DateAdded = DateTime.Parse("10/01/2017"), CarMake = _carMakes[0]},
                new CarModel { CarModelId = 2, CarModelName = "Silverado 1500", DateAdded = DateTime.Parse("10/02/2017"),CarMake = _carMakes[1]},
                new CarModel { CarModelId = 3, CarModelName = "Ram 1500", DateAdded = DateTime.Parse("10/03/2017"),CarMake = _carMakes[2]},
                new CarModel { CarModelId = 4, CarModelName = "F150", DateAdded = DateTime.Parse("10/04/2017"),CarMake = _carMakes[0]}

            };
            _specials = new List<Promo>()
            {
                new Promo { PromoId = 1, StartDate = DateTime.Parse("11/01/2017"), EndDate = DateTime.Parse("12/01/2017"), Description = "Truck month is back on here at Reynolds Automovite! Check out our wide range of trucks, both new and used, on sale!"}
            };

            _exColors = new List<ExteriorColor>()
            {
                new ExteriorColor {ExteriorColorId = 1, ExteriorColorName = "Red" },
                new ExteriorColor {ExteriorColorId = 2, ExteriorColorName = "Blue"},
                new ExteriorColor {ExteriorColorId = 3, ExteriorColorName = "Black"},
                new ExteriorColor {ExteriorColorId = 4, ExteriorColorName = "Silver"}
            };
            _intColors = new List<InteriorColor>()
            {
                new InteriorColor {InteriorColorId = 1, InteriorColorName = "Grey"},
                new InteriorColor {InteriorColorId = 2, InteriorColorName = "Red"},
                new InteriorColor {InteriorColorId = 3, InteriorColorName = "Cream"}
            };
            _transmissions = new List<Transmission>()
            {
                new Transmission {TransmissionId = 1, TransmissionType = "Automatic" },
                new Transmission {TransmissionId = 2, TransmissionType = "Manual"}
            };
            _bodyStyles = new List<BodyStyle>()
            {
                new BodyStyle {BodyStyleId = 1, BodyStyleName = "Truck" },
                new BodyStyle {BodyStyleId = 2, BodyStyleName = "SUV"},
                new BodyStyle {BodyStyleId = 3, BodyStyleName = "Car"}
            };
            _types = new List<VehicleType>()
            {
                new VehicleType { VehicleTypeId = 1, VehicleTypeName = "New"},
                new VehicleType { VehicleTypeId = 2, VehicleTypeName = "Used"}
            };
            _vehicles = new List<Vehicle>()
            {
                new Vehicle {
                    VehicleId =1,
                    Vin = "11111111111111111",
                    CarModel = _carModels[0],
                    Year = 1999,
                    Mileage = 205800,
                    BodyStyle = _bodyStyles[0],
                    ExteriorColor = _exColors[0],
                    InteriorColor = _intColors[1],
                    Transmission = _transmissions[0],
                    VehicleType = _types[0],
                    Msrp = 2500,
                    SalePrice = 2200,
                    Description = "Rusty but trusty.",
                    IsFeatured = true,
                },            
                new Vehicle {
                    VehicleId =2,
                    Vin = "22222222222222222",
                    CarModel = _carModels[1],
                    Year = 2002,
                    Mileage = 130067,
                    BodyStyle = _bodyStyles[0],
                    ExteriorColor = _exColors[2],
                    InteriorColor = _intColors[1],
                    Transmission = _transmissions[1],
                    VehicleType = _types[1],
                    Msrp = 7500,
                    SalePrice = 5000,
                    Description = "Florida truck, no rust!",
                    IsFeatured = false,
                },
                new Vehicle {
                    VehicleId = 3,
                    Vin = "33333333333333333",
                    CarModel = _carModels[3],
                    Year = 2017,
                    Mileage = 510,
                    BodyStyle = _bodyStyles[0],
                    ExteriorColor = _exColors[3],
                    InteriorColor = _intColors[2],
                    Transmission = _transmissions[0],
                    VehicleType =_types[0],
                     Msrp = 50000,
                    SalePrice = 45000,
                    Description = "Solid",
                   IsFeatured = true,
                }

            };
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            if(_vehicles.Any())
            {
                newVehicle.VehicleId = _vehicles.Max(v => v.VehicleId) + 1;
            }
            else
            {
                newVehicle.VehicleId = 1;
            }
            _vehicles.Add(newVehicle);
        }

        public VehicleViewModel ConvertVehicleToVM(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.VehicleId == id);
            var vehicleVM = new VehicleViewModel();
            vehicleVM.Vehicle = vehicle;
            vehicleVM.SetCarMakeItems(_carMakes);
            vehicleVM.SetBodyStyleItems(_bodyStyles);
            vehicleVM.SetVehicleTypeItems(_types);
            vehicleVM.SetCarModelItems(_carModels);
            vehicleVM.SetExColorItems(_exColors);
            vehicleVM.SetIntColorItems(_intColors);
            vehicleVM.SetTransmissionItems(_transmissions);

            return vehicleVM;
        }

        public void ConvertVehicleVmToVehicle(VehicleViewModel viewmodel)
        {
            Vehicle vehicle = new Vehicle();
            if(viewmodel.Vehicle.VehicleId == 0)
            {
                viewmodel.Vehicle.VehicleId = _vehicles.Max(v => v.VehicleId) + 1;
                vehicle = viewmodel.Vehicle;
                vehicle.VehicleId = viewmodel.Vehicle.VehicleId;
                vehicle.CarModel = _carModels.FirstOrDefault(m => m.CarModelId == viewmodel.Vehicle.CarModel.CarModelId);
                vehicle.BodyStyle = _bodyStyles.FirstOrDefault(b => b.BodyStyleId == viewmodel.Vehicle.BodyStyle.BodyStyleId);
                vehicle.ExteriorColor = _exColors.FirstOrDefault(c => c.ExteriorColorId == viewmodel.Vehicle.ExteriorColor.ExteriorColorId);
                vehicle.InteriorColor = _intColors.FirstOrDefault(c => c.InteriorColorId == viewmodel.Vehicle.InteriorColor.InteriorColorId);
                vehicle.Transmission = _transmissions.FirstOrDefault(t => t.TransmissionId == viewmodel.Vehicle.Transmission.TransmissionId);
                vehicle.VehicleType = _types.FirstOrDefault(t => t.VehicleTypeId == viewmodel.Vehicle.VehicleType.VehicleTypeId);
                _vehicles.Add(vehicle);
            }
            else
            {
                vehicle = viewmodel.Vehicle;
                vehicle.VehicleId = viewmodel.Vehicle.VehicleId;
                vehicle.CarModel = _carModels.FirstOrDefault(m => m.CarModelId == viewmodel.Vehicle.CarModel.CarModelId);
                vehicle.BodyStyle = _bodyStyles.FirstOrDefault(b => b.BodyStyleId == viewmodel.Vehicle.BodyStyle.BodyStyleId);
                vehicle.ExteriorColor = _exColors.FirstOrDefault(c=>c.ExteriorColorId == viewmodel.Vehicle.ExteriorColor.ExteriorColorId);
                vehicle.InteriorColor =_intColors.FirstOrDefault(c=>c.InteriorColorId == viewmodel.Vehicle.InteriorColor.InteriorColorId);
                vehicle.Transmission = _transmissions.FirstOrDefault(t=>t.TransmissionId == viewmodel.Vehicle.Transmission.TransmissionId);
                vehicle.VehicleType = _types.FirstOrDefault(t=>t.VehicleTypeId == viewmodel.Vehicle.VehicleType.VehicleTypeId);
                
                _vehicles.RemoveAll(v => v.VehicleId == viewmodel.Vehicle.VehicleId);
                _vehicles.Add(vehicle);
            }            
        }

        public void DeleteVehicle(int id)
        {
            _vehicles.RemoveAll(v => v.VehicleId == id);
        }

        public IEnumerable<ExteriorColor> GetAllExColors()
        {
            return _exColors;
        }

        public IEnumerable<InteriorColor> GetAllIntColors()
        {
            return _intColors;
        }

        public IEnumerable<BodyStyle> GetAllStyles()
        {
            return _bodyStyles;
        }

        public IEnumerable<Transmission> GetAllTransmissions()
        {
            return _transmissions;
        }

        public IEnumerable<VehicleType> GetAllTypes()
        {
            return _types;
        }


        public IEnumerable<CarMake> GetAllCarMakes()
        {
            return _carMakes;
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            return _carModels;
        }


        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public Vehicle GetVehicle(int id)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleId == id);
        }

        public void UpdateVehicle(Vehicle updatedVehicle)
        {
            _vehicles.RemoveAll(v => v.Vin == updatedVehicle.Vin);
            _vehicles.Add(updatedVehicle);
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return _vehicles.Where(v => v.IsFeatured == true).ToList();
        }

        public List<Promo> GetAllSpecials()
        {
            return _specials;
        }
    }
}
