namespace CarDealership.Data.Migrations
{
    using CarDealership.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Data.CarDealershipDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Data.CarDealershipDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var userMgr = new UserManager<User>(new UserStore<User>(context));
            var roleMgr = new RoleManager<Role>(new RoleStore<Role>(context));

            // have we loaded roles already?
            if (roleMgr.RoleExists("admin"))
                return;

            // create the admin role
            roleMgr.Create(new Role() { Name = "admin" });


            // create the default user
            var user = new User()
            {
                UserName = "admin@reynoldsautos.com",
                FirstName = "Rob",
                LastName = "Reynolds",
                Email = "admin@reynoldsautos.com"
            };



            // create the user with the manager class
            userMgr.Create(user, "Testing123");

            // add the user to the admin role
            userMgr.AddToRole(user.Id, "admin");


            if (roleMgr.RoleExists("manager"))
                return;

            roleMgr.Create(new Role() { Name = "sales" });

            var lesserUser = new User()
            {
                UserName = "sales@reynoldsauto.com",
                FirstName = "John",
                LastName = "Doe",
                Email = "sales@reynoldsauto.com",
            };

            userMgr.Create(lesserUser, "Testing456");
            userMgr.AddToRole(lesserUser.Id, "sales");
        }
    }
}
