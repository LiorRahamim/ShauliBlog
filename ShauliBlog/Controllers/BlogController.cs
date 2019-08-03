using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShauliBlog.DAL;
using ShauliBlog.Models;

namespace ShauliBlog.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult Blog()
        {
            List<Post> posts = db.Posts.ToList();

            return View(db.Posts.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchPosts(String publisherField, String blogTitleField, Boolean commentsCheckBox)
        {
            List<Post> posts = db.Posts.ToList();       

            if (!String.IsNullOrEmpty(publisherField))
            {
                posts = posts.Where(post => post.Author.Equals(publisherField)).ToList();                              
            }
            if (!String.IsNullOrEmpty(blogTitleField))
            {              
                posts = posts.Where(post => post.Title.Equals(blogTitleField)).ToList();
            }
            if (commentsCheckBox)
            {
                posts = posts.Where(post => post.Comments.ToList().Count > 0).ToList();
            }
            else
            {
                posts = posts.Where(post => post.Comments.ToList().Count == 0).ToList();
            }
            
            return View(posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "Id,PostId,Title,Author,AuthorSite,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Blog");
            }

            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        } 
    }
}