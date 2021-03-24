using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class VW_Feedback
    {
        public int feedback_id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; }
        public int rating { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
    }
}