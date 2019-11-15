using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MVCVitec.Models;

namespace MVCVitec.Data
{
    public class FillThatDb
    {
        public static void PushProducts(ApplicationDbContext context)
        {
            if (context.Product.Any())
            {
                return;
            }

            Array products = new Product[3]
            {
                new Product
                    {
                        Name = "CD Ord",
                        Price = 299.95,
                        ProductKey = "HG31-BVT5-45KK-K984-D2BN",
                        Description = "Et program som hjælper dig, som er ordblind.",
                        ProductType = "ikke angivet"
                    },
                new Product
                    {
                        Name = "CD Ord - Premium",
                        Price = 599.95,
                        ProductKey = "HG31-BVT5-45KK-K984-D2BN",
                        Description = "Et produkt som hjælper dig, der har brug for hjælp.",
                        ProductType = "ikke angivet"
                    },
                new Product
                    {
                        Name = "Into Words",
                        Price = 99.95,
                        ProductKey = "HG31-BVT5-45KK-K984-D2BN",
                        Description = "Frihed til at læse, skrive og søge viden. For alle.",
                        ProductType = "ikke angivet"
                    }
            };

            foreach (Product p in products)
            {
                context.Product.Add(p);
            }

            context.SaveChanges();
        }
    }
}
