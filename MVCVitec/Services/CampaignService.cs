﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MVCVitec.Data;
using MVCVitec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVitec.Services
{
    public class CampaignService
    {
        private readonly ProductConnection connect = new ProductConnection();
        public List<Product> GetProducts()
        {
            List<Product> products = connect.GetData();
            return products;
        }

        public double OldPriceIs()
        {
            double price = 1;
            List<Product> products = connect.GetData();
            products.ForEach(x => price = x.Price);

            return price;
        }

        public IEnumerable<SelectListItem> GetProductItems()
        {
            Campaign c = new Campaign();
            foreach (Product p in c.Products)
            {
                yield return new SelectListItem { Text = "Produkt", Value = p.Name.ToString() };
            }
        }
    }
}
