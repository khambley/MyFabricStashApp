using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public string ReceiptImagePath { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string Description { get; set; }

    }
}