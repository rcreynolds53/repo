using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public List<SelectListItem> RoleItems { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public UserViewModel()
        {
            RoleItems = new List<SelectListItem>();
        }

        public void SetRoleItems(IEnumerable<Role> roles)
        {
            foreach(var r in roles)
            {
                RoleItems.Add(new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id
                });
            }
        }

    }
}
