using CarDealership.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class CarDealershipDbContext : IdentityDbContext<User>
    {
        public CarDealershipDbContext() : base("CarDealership")
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<BodyStyle> BodyStyles { get; set; }
        public DbSet<ExteriorColor> ExteriorColors { get; set; }
        public DbSet<InteriorColor> InteriorColors { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
    }
}
