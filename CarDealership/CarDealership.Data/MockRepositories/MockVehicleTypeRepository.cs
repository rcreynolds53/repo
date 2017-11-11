using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.MockRepositories
{
    public class MockVehicleTypeRepository
    {
        static List<VehicleType> _types;
        public MockVehicleTypeRepository()
        {
            _types = new List<VehicleType>()
            {
                new VehicleType { VehicleTypeId = 1, VehicleTypeName = "New" },
                new VehicleType { VehicleTypeId = 2, VehicleTypeName = "Used"}
            };
        }

        public IEnumerable<VehicleType> GetAllTypes()
        {
            return _types;
        }
    }
}
