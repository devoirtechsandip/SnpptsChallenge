using System;
using System.Collections.Generic;
using System.Text;

namespace learn.Models
{
    public class tbl_NewsMaster
    {
        public string pk { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
        public string content { get; set; }
        public string categoryId { get; set; }
        public string sourceName { get; set; }

    }
}
