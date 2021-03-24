using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class VW_Cart_Product
    {
        public int cart_product_id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public int cart_units { get; set; }
        public string name { get; set; }
        public int price_per_unit { get; set; }
        public int product_units { get; set; }
        public string tag { get; set; }
        //add image type
    }
}