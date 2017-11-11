using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealership.Data.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User GetUser(string id);
        void AddUser(User newUser);
    }
}
