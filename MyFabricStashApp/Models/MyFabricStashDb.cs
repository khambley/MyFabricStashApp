using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyFabricStashApp.Models
{
    public class MyFabricStashDb : DbContext
    {
        public MyFabricStashDb() : base("DefaultConnection")
        {

        }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory1> SubCategories1 { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
}