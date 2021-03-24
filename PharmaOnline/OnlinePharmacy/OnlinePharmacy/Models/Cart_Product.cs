using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Cart_Product
    {
        public int cart_product_id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public int units { get; set; }
    }
}