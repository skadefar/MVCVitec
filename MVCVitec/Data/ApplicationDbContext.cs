using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UCLVitecMV.Models;
using UCLVitecMV.Model;

namespace MVCVitec.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UCLVitecMV.Models.Admin> Admin { get; set; }
        public DbSet<UCLVitecMV.Models.Payment> Payment { get; set; }
        public DbSet<UCLVitecMV.Model.Product> Product { get; set; }
    }
}
