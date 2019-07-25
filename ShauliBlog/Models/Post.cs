using System;
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
        public string AuthorSite { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Content { get; set; }

        public string Image { get; set; } // the image should be a link
        
        public string Video { get; set; } // the video should be a link to youtube

        public List<Comment> Comments { get; set; }
    }
}