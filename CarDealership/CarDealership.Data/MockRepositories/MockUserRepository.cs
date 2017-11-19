using System.Collections.Generic;
using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System.Linq;

namespace CarDealership.Data
{
    public class MockUserRepository : IUserRepo
    {
        private static List<User> _users;
        private static List<Role> _roles;

        public MockUserRepository()
        {
            _users = new List<User>()
            {
                new User{ Id="1", FirstName = "John", LastName = "Doe", Email = "jd@car.com", RoleName = "Sales"},
                new User{Id="2",FirstName = "Tommy", LastName = "Gunn", Email="tg@car.com", RoleName = "Admin"}
            };
            _roles = new List<Role>()
            {
                new Role { Id = "1", Name = "admin"},
                new Role { Id = "2", Name = "sales"}

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

        public void EditUser(User updatedUser)
        {
            _users.RemoveAll(u => u.Id == updatedUser.Id);
            _users.Add(updatedUser);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roles;
        }

        public void ConvertVMtoUserAdd(UserViewModel userVM)
        {
            var user = userVM.User;
            _users.Add(user);

        }
        public void ConvertVMtoUserEdit(UserViewModel userVM)
        {
            var user = userVM.User;
            _users.RemoveAll(u => u.Id == userVM.User.Id);
            _users.Add(user);
        }

        public UserViewModel ConvertUserToVM(User userToEdit)
        {
            UserViewModel userVM = new UserViewModel();
            userVM.User = userToEdit;
            userVM.SetRoleItems(_roles);
            return userVM;
        }

        public void DisableUser(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}