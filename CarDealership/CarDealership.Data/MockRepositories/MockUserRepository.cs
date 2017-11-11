using System.Collections.Generic;
using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System.Linq;

namespace CarDealership.Data
{
    public class MockUserRepository : IUserRepo
    {
        private static List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>()
            {
                new User{ Id="1", FirstName = "John", LastName = "Doe", Email = "jd@car.com", RoleName = "Sales"},
                new User{Id="2",FirstName = "Tommy", LastName = "Gunn", Email="tg@car.com", RoleName = "Admin"}
            };
        }
        public void AddUser(User newUser)
        {     
            _users.Add(newUser);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUser(string id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}