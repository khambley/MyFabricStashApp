using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public string ReceiptImagePath { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReceiptDate { get; set; }
        public string Description { get; set; }

    }
}