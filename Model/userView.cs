using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class userView
    {
        public int id { get; set; }
        public string username { get; set; }
        public string truename { get; set; }
        public string rolename { get; set; }
        public DateTime createdate { get; set; } 
    }
}