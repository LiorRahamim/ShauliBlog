using System;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShauliBlog.Models
{
    public class Fan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string sn { get; set; }
        
        [Required]
        public string name { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public DateTime birthday { get; set; }

        [Required]
        public int clubSeniority { get; set; }
    }
}