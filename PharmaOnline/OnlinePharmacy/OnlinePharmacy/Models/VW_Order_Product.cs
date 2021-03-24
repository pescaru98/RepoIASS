using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class VW_Order_Product
    {
        public int order_product_id { get; set; }
        public int product_id { get; set; }
        public int order_set_id { get; set; }
        public int bought_units { get; set; }
        public int bought_price_per_unit { get; set; }
        public int user_id { get; set; }
        public DateTime issue_date { get; set; }
        public string product_name { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

    }
}