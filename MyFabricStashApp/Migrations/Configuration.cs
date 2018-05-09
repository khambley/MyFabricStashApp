namespace MyFabricStashApp.Migrations
{
    using MyFabricStashApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyFabricStashApp.Models.MyFabricStashDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MyFabricStashApp.Models.MyFabricStashDb";
        }

        protected override void Seed(MyFabricStashApp.Models.MyFabricStashDb context)
        {
            context.MainCategories.AddOrUpdate(m => m.Name,
                new MainCategory
                {
                    Name = "Sports",
                    SubCategories1 = new List<SubCategory1>
                    {
                        new SubCategory1{Name = "Baseball"},
                        new SubCategory1{Name = "Football"},
                        new SubCategory1{Name = "Hockey"}
                    }
                },

                new MainCategory
                {
                    Name = "Characters",
                    SubCategories1 = new List<SubCategory1>
                    {
                        new SubCategory1{Name = "Marvel Comics"},
                        new SubCategory1{Name = "DC Comics"},
                        new SubCategory1{Name = "Doctor Who"}
                        
                    }
                },
                new MainCategory
                {
                    Name = "Holidays",
                    SubCategories1 = new List<SubCategory1>
                    {
                        new SubCategory1{Name = "Christmas"},
                        new SubCategory1{Name = "Memorial Day"},
                        new SubCategory1{Name = "Halloween"}
                    }
                }
                );
        }
    }
}
