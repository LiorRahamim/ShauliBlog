using System;
using System.Web;
using System.Data.Entity;


namespace ShauliBlog.Models
{
    public class Fan
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sn { get; set; }
        public string gender { get; set; }
        public DateTime birthday { get; set; }
        public int clubSeniority { get; set; }
    }
}