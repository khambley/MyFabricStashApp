using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class SubCategory1
    {
        public int SubCategory1Id { get; set; }
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
        public virtual MainCategory MainCategory { get; set; }



    }
}