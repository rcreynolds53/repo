using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class SalesFilterModel
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<SelectListItem> UserItems { get; set; }

        public SalesFilterModel()
        {
            User = new User();
            UserItems = new List<SelectListItem>();
        }

        public void SetUserItems(IEnumerable<User> users)
        {
            foreach (var u in users)
            {
                UserItems.Add(new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id
                });
            }
        }

    }
}
