using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class PurchasesListViewModel
    {
        public int PurchaseId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public int PurchaseQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public double PurchaseTotal { get; set; }

        public int FabricId { get; set; }
        public string FabricName { get; set; }
        public string FabricImagePath { get; set; }

        public int ReceiptId { get; set; }
        public string ReceiptName { get; set; }

        public int SourceId { get; set; }
        public string SourceName { get; set; }

        public string Notes { get; set; }

    }
}