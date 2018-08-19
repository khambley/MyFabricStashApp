using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class ReceiptsListViewModel
    {
        public int ReceiptId { get; set; }
        public string ReceiptNumber { get; set; }

        public int SourceId { get; set; }
        public string SourceName { get; set; }

        public string ReceiptImagePath { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReceiptDate { get; set; }
        public string Description { get; set; }
    }
}