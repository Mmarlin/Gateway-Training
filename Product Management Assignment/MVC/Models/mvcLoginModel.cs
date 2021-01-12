using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcLoginModel
    {
        public int ID { get; set; }

        public string EMAIL { get; set; }

        public string PASSWORD { get; set; }

    }
}