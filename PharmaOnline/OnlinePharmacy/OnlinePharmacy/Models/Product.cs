using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public int price_per_unit { get; set; }
        public int units { get; set; }
        public string tag { get; set; }
        //TODO add image type
    }
}