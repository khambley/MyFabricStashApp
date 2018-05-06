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
            context.Fabrics.AddOrUpdate(f => f.Name,
                new Fabric {
                    MainCategory = "Test Main Category 1",
                    SubCategory1 = "Test SubCategory1",
                    SubCategory2 = "Test SubCategory2",
                    Name = "Test Fabric 1",
                    ImagePath = "https://placeholdit.co//i/150x150?&bg=ccc&fc=000&text=150px X 150px",
                    Location = "Shelf #1",
                    Type = "Woven",
                    Weight = "Medium",
                    Content = "100% Cotton",
                    Design = "",
                    Brand = "Test Brand 1",
                    Quantity = 1.0,
                    Width = 54,
                    Source = "Test Source 1",
                    ItemsSold = 3,
                    Purchases = 
                        new List<Purchase>
                        {
                            new Purchase
                            {
                                PurchaseDate = Convert.ToDateTime("April 16, 2018"),
                                PurchaseQuantity = 1,
                                PurchasePrice = 7.99
                            }
                        }
                },
                new Fabric
                {
                    MainCategory = "Test Main Category 2",
                    SubCategory1 = "Test SubCategory1",
                    SubCategory2 = "Test SubCategory2",
                    Name = "Test Fabric 2",
                    ImagePath = "https://placeholdit.co//i/150x150?&bg=ccc&fc=000&text=150px X 150px",
                    Location = "Test Shelf #2",
                    Type = "Woven",
                    Weight = "Medium",
                    Content = "100% Cotton",
                    Design = "",
                    Brand = "Test Brand 2",
                    Quantity = 1,
                    Source = "Test Source 2",
                    ItemsSold = 2,
                    Purchases =
                        new List<Purchase>
                        {
                            new Purchase
                            {
                                PurchaseDate = Convert.ToDateTime("April 16, 2018"),
                                PurchaseQuantity = 1,
                                PurchasePrice = 7.99
                            }
                        }
                },
                new Fabric
                {
                    MainCategory = "Test Main Category 3",
                    SubCategory1 = "Test SubCategory1 2",
                    SubCategory2 = "Test SubCategory2 2",
                    Name = "Test Fabric 3",
                    ImagePath = "https://placeholdit.co//i/150x150?&bg=ccc&fc=000&text=150px X 150px",
                    Location = "Test Shelf #3",
                    Type = "Woven",
                    Weight = "Medium",
                    Content = "100% Cotton",
                    Design = "",
                    Brand = "Test Brand 3",
                    Quantity = .5,
                    Source = "Test Source 3",
                    ItemsSold = 1,
                    Purchases =
                        new List<Purchase>
                        {
                            new Purchase
                            {
                                PurchaseDate = Convert.ToDateTime("April 16, 2018"),
                                PurchaseQuantity = 1,
                                PurchasePrice = 7.99
                            }
                        }
                }
                );
        }
    }
}
