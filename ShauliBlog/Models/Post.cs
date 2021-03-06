﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
            
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string AuthorSite { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Content { get; set; }

        public String Image { get; set; } // the image should be in the sql server
        
        public String Video { get; set; } // the video should be a link to youtube

        public virtual ICollection<Comment> Comments { get; set; }
    }
}