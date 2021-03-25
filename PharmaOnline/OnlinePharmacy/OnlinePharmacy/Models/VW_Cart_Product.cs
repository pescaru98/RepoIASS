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
        public byte[] picture { get; set; }

        public VW_Cart_Product(int cart_product_id, int user_id, int product_id, int cart_units, string name, int price_per_unit, int product_units, string tag, byte[] picture)
        {
            this.cart_product_id = cart_product_id;
            this.user_id = user_id;
            this.product_id = product_id;
            this.cart_units = cart_units;
            this.name = name;
            this.price_per_unit = price_per_unit;
            this.product_units = product_units;
            this.tag = tag;
            this.picture = picture;
        }

        public static VW_Cart_Product convertFromSqlReader(object cart_product_id, object user_id, object product_id, object cart_units, object name, object price_per_unit, object picture, object product_units, object tag)
        {
            return new VW_Cart_Product((int)cart_product_id, (int)user_id, (int)product_id, (int)cart_units, (string)name, (int)price_per_unit, (int)product_units, (string)tag, (byte[])picture);
        }

    }
}