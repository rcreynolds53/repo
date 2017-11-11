using CarDealership.Data.Repositories;
using CarDealership.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.MockRepositoryTests
{
    [TestFixture]
    public class CarModelTests
    {
        [Test]
        public void CanGetAllModels()
        {
            MockCarModelRepository carModels = new MockCarModelRepository();

            var models = carModels.GetAllCarModels();

            Assert.AreEqual(3, models.Count());
        }
        [Test]
        public void CanGetModelsByMake()
        {
            MockCarModelRepository repo = new MockCarModelRepository();

            CarMake make = new CarMake();
            make.CarMakeId = 1;
            var models = repo.GetModelsByMake(make.CarMakeId);

            Assert.AreEqual(1, models.Count());
        }
        
    }
}
