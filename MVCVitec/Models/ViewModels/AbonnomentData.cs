using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVitec.Models.ViewModels
{
    public class AbonnomentData
    {
        public IEnumerable<User> GetUsers { get; set; }
        public IEnumerable<Product> GetProducts { get; set; }
    }
}
