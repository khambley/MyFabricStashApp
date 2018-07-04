using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFabricStashApp.Models
{
    public class Source
    {
        public int SourceId { get; set; }
        public string SourceName { get; set; }
        public string SourceAddress { get; set; }
        public string SourceCity { get; set; }
        public string SourceState { get; set; }
        public string SourceZipCode { get; set; }
        public string SourcePhone { get; set; }
        public string SourceUrl { get; set; }
        public string Notes { get; set; }
    }
}