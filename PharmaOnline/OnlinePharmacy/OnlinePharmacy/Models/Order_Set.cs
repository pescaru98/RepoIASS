using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Order_Set
    {
        public int order_set_id { get; set; }
        public int user_id { get; set; }
        public DateTime issue_date { get; set; }

    }
}