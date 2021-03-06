﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        //A unique ID string that consists of ReceiptId + Date.ToString + SourceId
        public string ReceiptNumber { get; set; }
        public int SourceId { get; set; }
        public virtual Source Source { get; set; }
        public string ReceiptImagePath { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime ReceiptDate { get; set; }
        public string Description { get; set; }

    }
}