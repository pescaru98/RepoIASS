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

        public VW_Order_Product(int order_product_id, int product_id, int order_set_id, int bought_units, int bought_price_per_unit, int user_id, DateTime issue_date, string product_name, string name, string surname, string email)
        {
            this.order_product_id = order_product_id;
            this.product_id = product_id;
            this.order_set_id = order_set_id;
            this.bought_units = bought_units;
            this.bought_price_per_unit = bought_price_per_unit;
            this.user_id = user_id;
            this.issue_date = issue_date;
            this.product_name = product_name;
            this.name = name;
            this.surname = surname;
            this.email = email;
        }


        public static VW_Order_Product convertFromSqlReader(object order_product_id, object order_set_id, object product_id, object bought_units, object bought_price_per_unit, object user_id, object issue_date, object product_name, object name, object surname, object email)
        {
            return new VW_Order_Product((int)order_product_id, (int)product_id, (int)order_set_id, (int)bought_units, (int)bought_price_per_unit, (int)user_id, (DateTime)issue_date, (string)product_name, (string)name, (string)surname, (string)email);
        }
    }
}