using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MVCVitec.Models;
using System.Collections.Generic;
using MVCVitec.Models.ViewModels;

namespace MVCVitec.Data
{
    public class FillThatDb
    {
        public static void PushProducts(ApplicationDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            if (context.Users.Any())
            {
                return;
            }
            if (context.Abonnoments.Any())
            {
                return;
            }
            List<Product> products = new List<Product>();
            products.Add(new Product
            {
                Name = "CD Ord",
                Price = 299.95,
                ProductKey = "HG31-BVT5-45KK-K984-D2BN",
                Description = "Et program som hjælper dig, som er ordblind.",
                ProductType = "ikke angivet"
            });
            products.Add(new Product {
                Name = "CD Ord - Premium",
                Price = 599.95,
                ProductKey = "HG31-BVT5-45KK-K984-D2BN",
                Description = "Et produkt som hjælper dig, der har brug for hjælp.",
                ProductType = "ikke angivet"
            });
            products.Add(new Product
            {
                Name = "Into Words",
                Price = 99.95,
                ProductKey = "HG31-BVT5-45KK-K984-D2BN",
                Description = "Frihed til at læse, skrive og søge viden. For alle.",
                ProductType = "ikke angivet"
            });

            List<User> users = new List<User>();
            users.Add(new User {
                FirstMidName = "Bob",
                LastName = "Bobsen"
            });
            users.Add(new User
            {
                FirstMidName = "Bob",
                LastName = "Bobsen"
            });
            users.Add(new User
            {
                FirstMidName = "Bob",
                LastName = "Bobsen"
            });
            users.Add(new User
            {
                FirstMidName = "Bob",
                LastName = "Bobsen"
            });

            var abonnoments = new Abonnoment[]
            {
                new Abonnoment {
                    ProductId = products.Single(c => c.Name == "CD Ord" ).ProductID,
                    UserId = users.Single(i => i.FirstMidName == "Bob").UserID
                    },
                new Abonnoment {
                    ProductId = products.Single(c => c.Name == "CD Ord" ).ProductID,
                    UserId = users.Single(i => i.FirstMidName == "Bob").UserID
                    },
                new Abonnoment {
                    ProductId = products.Single(c => c.Name == "CD Ord" ).ProductID,
                    UserId = users.Single(i => i.FirstMidName == "Bob").UserID
                    },
                new Abonnoment {
                    ProductId = products.Single(c => c.Name == "CD Ord" ).ProductID,
                    UserId = users.Single(i => i.FirstMidName == "Bob").UserID
                    }
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            foreach (Abonnoment a in abonnoments)
            {
                context.Abonnoments.Add(a);
            }

            context.SaveChanges();
        }
    }
}
