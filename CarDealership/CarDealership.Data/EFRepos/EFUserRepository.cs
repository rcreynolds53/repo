using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace CarDealership.Data.EFRepos
{
    public class EFUserRepository : IUserRepo
    {
        CarDealershipDbContext context = new CarDealershipDbContext();
        //public void AddUser(User newUser)
        //{
           
        //}

        public UserViewModel ConvertUserToVM(User userToEdit)
        {
            UserViewModel userVM = new UserViewModel();
            userVM.User = userToEdit;
            userVM.SetRoleItems(context.IdentityRoles);
            return userVM;
        }

        public void ConvertVMtoUserAdd(UserViewModel userVM)
        {
            userVM.User.UserName = userVM.User.Email;
            var context = new CarDealershipDbContext();
            var userMgr = new UserManager<User>(new UserStore<User>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (userMgr.FindByName(userVM.User.UserName) == null)
            {
                var newuser = new User()
                {
                    FirstName = userVM.User.FirstName,
                    LastName = userVM.User.LastName,
                    UserName = userVM.User.UserName,
                    Email = userVM.User.Email,
                };
                userMgr.Create(newuser, userVM.Password);
            }

            var user = userMgr.FindByName(userVM.User.UserName);
            var role = context.Roles.SingleOrDefault(r => r.Id == userVM.Role.Id);
            userMgr.AddToRole(user.Id, role.Name);
            context.SaveChanges();            
        }

        public void ConvertVMtoUserEdit(UserViewModel userVM)
        {
            userVM.User.UserName = userVM.User.Email;
            var context = new CarDealershipDbContext();
            var userMgr = new UserManager<User>(new UserStore<User>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var user = userMgr.FindByName(userVM.User.UserName);
            var role = context.Roles.SingleOrDefault(r => r.Id == userVM.Role.Id);
            string[] allUserRoles = userMgr.GetRoles(user.Id).ToArray();
            userMgr.RemoveFromRoles(user.Id, allUserRoles);
            userMgr.AddToRole(user.Id, role.Name);
            context.SaveChanges();
        }

        public void DisableUser(string id)
        {
            var context = new CarDealershipDbContext();
            var userMgr = new UserManager<User>(new UserStore<User>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var user = userMgr.FindById(id);
            userMgr.Delete(user);
            context.SaveChanges();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return context.IdentityRoles;
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
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
