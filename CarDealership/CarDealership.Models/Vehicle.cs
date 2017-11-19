using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Vin { get; set; }
        //public int CarModelId { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Msrp { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        [DisplayName("Check to feature this vehicle.")]
        public bool IsFeatured { get; set; }
        [DisplayName("Check to take this vehicle off the market.")]
        public bool IsVehicleSold { get; set; }
        //public int TransmissionId { get; set; }
        //public int InteriorColorId { get; set; }
        //public int ExteriorColorId { get; set; }
        //public int BodyStyleId { get; set; }
        //public int VehicleTypeId { get; set; }
        //public int PromoId { get; set; }

        public virtual CarModel CarModel { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual InteriorColor InteriorColor { get; set; }
        public virtual ExteriorColor ExteriorColor { get; set; }
        public virtual BodyStyle BodyStyle { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual Promo Promo { get; set; }
    }
}
