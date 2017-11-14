using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class VehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        public List<SelectListItem> CarMakeItems { get; set; }
        public List<SelectListItem> CarModelItems { get; set; }
        public List<SelectListItem> TransmissionItems { get; set; }
        public List<SelectListItem> InteriorColorItems { get; set; }
        public List<SelectListItem> ExteriorColorItems { get; set; }
        public List<SelectListItem> BodyStyleItems { get; set; }
        public List<SelectListItem> VehicleTypeItems { get; set; }
        public List<SelectListItem> PurchaseTypeItems { get; set; }
        public VehicleViewModel()
        {
            CarMakeItems = new List<SelectListItem>();
            CarModelItems = new List<SelectListItem>();
            TransmissionItems = new List<SelectListItem>();
            InteriorColorItems = new List<SelectListItem>();
            ExteriorColorItems = new List<SelectListItem>();
            BodyStyleItems = new List<SelectListItem>();
            VehicleTypeItems = new List<SelectListItem>();
            Vehicle = new Vehicle();
        }

        public void SetCarMakeItems(IEnumerable<CarMake> makes)
        {
            foreach(var m in makes)
            {
                CarMakeItems.Add(new SelectListItem()
                {
                    Value = m.CarMakeId.ToString(),
                    Text = m.Manufacturer
                });
            }
        }

        public void SetCarModelItems(IEnumerable<CarModel> models)
        {
           foreach(var m in models)
            {
                CarModelItems.Add(new SelectListItem()
                {
                    Value = m.CarModelId.ToString(),
                    Text = m.CarModelName
                });
            }
        }

        public void SetTransmissionItems(IEnumerable<Transmission> trans)
        {
            foreach (var t in trans)
            {
                TransmissionItems.Add(new SelectListItem()
                {
                    Value = t.TransmissionId.ToString(),
                    Text = t.TransmissionType
                });
            }
        }

        public void SetIntColorItems(IEnumerable<InteriorColor> colors)
        {
            foreach (var c in colors)
            {
                InteriorColorItems.Add(new SelectListItem()
                {
                    Value = c.InteriorColorId.ToString(),
                    Text = c.InteriorColorName
                });
            }
        }

        public void SetExColorItems(IEnumerable<ExteriorColor> colors)
        {
            foreach (var c in colors)
            {
                ExteriorColorItems.Add(new SelectListItem()
                {
                    Value = c.ExteriorColorId.ToString(),
                    Text = c.ExteriorColorName
                });
            }
        }

        public void SetBodyStyleItems(IEnumerable<BodyStyle> bodies)
        {
            foreach (var b in bodies)
            {
                BodyStyleItems.Add(new SelectListItem()
                {
                    Value = b.BodyStyleId.ToString(),
                    Text = b.BodyStyleName
                });
            }
        }

        public void SetVehicleTypeItems(IEnumerable<VehicleType> types)
        {
            foreach (var t in types)
            {
                VehicleTypeItems.Add(new SelectListItem()
                {
                    Value = t.VehicleTypeId.ToString(),
                    Text = t.VehicleTypeName
                });
            }
        }

        public void SetPurchaseTypeItems(IEnumerable<PurchaseType> types)
        {
            foreach(var t in types)
            {
                PurchaseTypeItems.Add(new SelectListItem()
                {
                    Value = t.PurchaseTypeId.ToString(),
                    Text = t.PurchaseTypeName
                });
            }
        }
    }
}
