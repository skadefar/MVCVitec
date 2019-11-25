using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVitec.Models
{
    public class Product
    {

        [Display(Name = "Navn:")]
        public string Name { get; set; }

        [Display(Name = "Pris:")]
        public double Price { get; set; }

        [Display(Name = "Produkt Type:")]
        public string ProductType { get; set; }

        [Display(Name = "Produkt Key:")]
        public string ProductKey { get; set; }

        [Display(Name = "Beskrivelse:")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public int ProductID { get; set; }

    }
}
