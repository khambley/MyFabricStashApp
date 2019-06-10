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

            var model = _db.Fabrics
                .Take(3)
                .Select(f => new FabricListViewModel
                {
                    FabricId = f.FabricId,
                    Name = f.Name,
                    MainCategoryId = f.MainCategoryId,
                    ImagePath = f.ImagePath,
                    Location = f.Location,
                    Type = f.Type,
                    Weight = f.Weight,
                    Content = f.Content,
                    Design = f.Design,
                    Brand = f.Brand,
                    TotalInches = f.TotalInches,
                    Width = f.Width,
                    Notes = f.Notes,
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