using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class MainCategory
    {
        public int MainCategoryId { get; set; }
        public string Name { get; set; }
        public List<SubCategory1> SubCategories1 { get; set; }
        
    }
}