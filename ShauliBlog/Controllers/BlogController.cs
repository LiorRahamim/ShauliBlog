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

        public ActionResult Blog(String authorField, String blogTitleField, String commentsAuthorField)
        {
            List<Post> posts = db.Posts.ToList();

            if (!String.IsNullOrEmpty(authorField))
            {
                posts = posts.Where(post => post.Author.Equals(authorField)).ToList();
            }
            if (!String.IsNullOrEmpty(blogTitleField))
            {
                posts = posts.Where(post => post.Title.Equals(blogTitleField)).ToList();
            }
            if (!String.IsNullOrEmpty(commentsAuthorField))
            {
                List<Post> postsCopy = posts.ToList();

                foreach (Post post in postsCopy)
                {
                    if (!IsCommentAuthorExists(post, commentsAuthorField))
                    {
                        posts.Remove(post);
                    }
                }
            }
            
            return View(posts);
        }  
        
        private bool IsCommentAuthorExists(Post post, String commentsAuthorField)
        {
            bool isCommentAuthorExists = true;

            foreach (Comment comment in post.Comments)
            {
                isCommentAuthorExists = comment.Author.Equals(commentsAuthorField);
            }

            return isCommentAuthorExists;
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