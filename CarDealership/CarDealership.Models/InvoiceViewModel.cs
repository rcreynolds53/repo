using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class InvoiceViewModel : VehicleViewModel
    {
        public Invoice Invoice { get; set; }
        public string UserName { get; set; }
        public List<SelectListItem> PurchaseTypeItems { get; set; }

        public InvoiceViewModel()
        {
            PurchaseTypeItems = new List<SelectListItem>();           
            Invoice = new Invoice();
        }

        public void SetPurchaseTypeItems(IEnumerable<PurchaseType> types)
        {
            foreach (var t in types)
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
