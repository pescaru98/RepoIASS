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
        public byte[] picture { get; set; }

        public Product(int product_id, string name, int price_per_unit, int units, string tag, byte[] picture)
        {
            this.product_id = product_id;
            this.name = name;
            this.price_per_unit = price_per_unit;
            this.units = units;
            this.tag = tag;
            this.picture = picture;
        }

        public Product(string name, int price_per_unit, int units, string tag, byte[] picture)
        {
            this.name = name;
            this.price_per_unit = price_per_unit;
            this.units = units;
            this.tag = tag;
            this.picture = picture;
        }

       
        public static Product convertFromSqlReader(object product_id, object name, object price_per_unit, object picture, object units, object tag)
        {
            return new Product((int)product_id, (string)name, (int)price_per_unit, (int)units, (string)tag, (byte[])picture);
        }

        public Product()
        {
        }
    }
}