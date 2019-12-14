using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVitec.Models
{
    public class Abonnoment
    {
        public int AbonnomentId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
