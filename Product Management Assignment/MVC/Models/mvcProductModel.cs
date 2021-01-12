using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcProductModel
    {
        public int ID { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Product Name Should be less than 50.")]
        public string Name { get; set; }
        
        [Required]
        public string Category { get; set; }
        
        [Required]
        public Nullable<int> Price { get; set; }

        [Required]
        public Nullable<int> Quantity { get; set; }

        [DisplayName("Short Description")]
        [Required]
        [MaxLength(200, ErrorMessage = "Product Name Should be less than 200.")]
        public string Short_Description { get; set; }

        [DisplayName("Long Description")]
        [Required]
        [MaxLength(1000, ErrorMessage = "Product Name Should be less than 1000.")]
        public string Long_Description { get; set; }

        [DisplayName("Upload Small Image")]
        public string Small_Img { get; set; }

        [DisplayName("Upload Large Image")]
        public string Large_Img { get; set; }

        [Required]
        public HttpPostedFileBase SmallImgFile { get; set; }

        [Required]
        public HttpPostedFileBase LargeImgFile { get; set; }
    }
}