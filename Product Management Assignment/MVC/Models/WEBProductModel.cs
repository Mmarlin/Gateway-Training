using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class WEBProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Short_Description { get; set; }
        public string Long_Description { get; set; }
        public string Small_Img { get; set; }
        public string Large_Img { get; set; }

    }
}