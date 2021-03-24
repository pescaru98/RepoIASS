using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Feedback
    {
        public int feedback_id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; }
        public int rating { get; set; }
    }
}