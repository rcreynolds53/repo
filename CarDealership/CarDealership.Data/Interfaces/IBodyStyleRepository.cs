using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarDealership.Data.MockRepositories
{
    public interface IBodyStyleRepository
    {
        IEnumerable<BodyStyle> GetAllStyles();
    }
}