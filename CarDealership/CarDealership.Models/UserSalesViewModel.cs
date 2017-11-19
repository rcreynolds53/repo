using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class UserSalesViewModel
    {
        public Invoice Invoice { get; set; }
        public User User { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        //    public List<SelectListItem> UserItems { get; set; }

        public UserSalesViewModel()
        {
            Invoice = new Invoice();
            User = new User();

        }

        //    public void SetUserItems(IEnumerable<User> users)
        //    {
        //        foreach(var u in users)
        //        {
        //            UserItems.Add(new SelectListItem
        //            {
        //                Text = u.FullName,
        //                Value = u.Id
        //            });
        //        }
        //    }
        //}
    }
}
