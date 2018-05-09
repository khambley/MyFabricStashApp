using MyFabricStashApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFabricStashApp.Controllers
{
    public class HomeController : Controller
    {
        MyFabricStashDb _db = new MyFabricStashDb();

        public ActionResult Index(string searchTerm = null)
        {
            //var model =
            //    from f in _db.Fabrics
            //    orderby f.ItemsSold descending
            //    select new FabricListViewModel
            //    {
            //        FabricId = f.FabricId,
            //        Name = f.Name,
            //        MainCategory = f.MainCategory,
            //        SubCategory1 = f.SubCategory1,
            //        SubCategory2 = f.SubCategory2,
            //        ImagePath = f.ImagePath,
            //        Location = f.Location,
            //        Type = f.Type,
            //        Weight = f.Weight,
            //        Content = f.Content,
            //        Design = f.Design,
            //        CurrentAmount = f.CurrentAmount,
            //        Source = f.Source,
            //        Notes = f.Notes,
            //        ItemsSold = f.ItemsSold,
            //        PurchaseCount = f.Purchases.Count()
            //    };

            var model = _db.Fabrics
                .OrderByDescending(f => f.ItemsSold)
                .Select(f => new FabricListViewModel
                {
                    FabricId = f.FabricId,
                    Name = f.Name,
                    MainCategoryId = f.MainCategoryId,
                    SubCategory1Id = f.SubCategory1Id,
                    ImagePath = f.ImagePath,
                    Location = f.Location,
                    Type = f.Type,
                    Weight = f.Weight,
                    Content = f.Content,
                    Design = f.Design,
                    Brand = f.Brand,
                    Quantity = f.Quantity,
                    Width = f.Width,
                    Source = f.Source,
                    Notes = f.Notes,
                    ItemsSold = f.ItemsSold,
                    PurchaseCount = f.Purchases.Count()
                });

            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}