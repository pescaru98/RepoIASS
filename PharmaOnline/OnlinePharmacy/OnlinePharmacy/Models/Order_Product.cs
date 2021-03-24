using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Order_Product
    {
        public int order_product_id { get; set; }
        public int product_id { get; set; }
        public int order_set_id { get; set; }
        public int units { get; set; }
        public int current_price_per_unit { get; set; }
    }
}