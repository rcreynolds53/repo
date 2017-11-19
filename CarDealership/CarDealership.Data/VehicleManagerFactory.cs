using CarDealership.Data.EFRepos;
using CarDealership.Data.Interfaces;
using CarDealership.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public static class VehicleManagerFactory
    {
        public static VehicleManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "Mock":
                    return new VehicleManager(new MockVehicleRepository(), new MockUserRepository());
                case "EF":
                    return new VehicleManager(new EFVehicleRepository(), new EFUserRepository());
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
