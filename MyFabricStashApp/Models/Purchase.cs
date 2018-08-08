using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public int PurchaseQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public double PurchaseTotal { get; set; }
        
        public int FabricId { get; set; }
        public virtual Fabric Fabric { get; set; }

        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }

        public int SourceId { get; set; }
        public virtual Source Source { get; set; }

        public string Notes { get; set; }

    }
}