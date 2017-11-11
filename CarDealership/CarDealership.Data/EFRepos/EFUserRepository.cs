using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealership.Data.EFRepos
{
    public class EFUserRepository : IUserRepo
    {
        CarDealershipDbContext context = new CarDealershipDbContext();
        public void AddUser(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public void EditUser(User updatedUser)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            var users = context.Users.ToList();
            var roles = context.Roles.ToList();

            foreach(var u in users)
            {
                foreach(var r in u.Roles)
                {
                    if(u.Roles.Any(ur=>ur.RoleId == r.RoleId))
                    {
                        var roleMatch = roles.FirstOrDefault(ur => ur.Id == r.RoleId);

                        u.RoleName = roleMatch.Name;
                    }
                }
            }

            return users;
        }

        public User GetUser(string id)
        {
            var user = (from u in context.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            return user;
        }
    }
}
