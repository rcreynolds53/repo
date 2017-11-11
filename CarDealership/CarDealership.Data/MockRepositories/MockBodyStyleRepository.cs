using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.MockRepositories
{
    public class MockBodyStyleRepository : IBodyStyleRepository
    {
        static List<BodyStyle> _bodystyles;
        public MockBodyStyleRepository()
        {
            _bodystyles = new List<BodyStyle>()
            
            {
                new BodyStyle {BodyStyleId = 1, BodyStyleName = "Truck" },
                new BodyStyle {BodyStyleId = 2, BodyStyleName = "SUV"},
                new BodyStyle {BodyStyleId = 3, BodyStyleName = "Car"}
            };

        }

        public IEnumerable<BodyStyle> GetAllStyles()
        {
            return _bodystyles;
        }
    }
}
