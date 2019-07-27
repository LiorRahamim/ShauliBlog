using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShauliBlog.DAL;

namespace ShauliBlog.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult Blog()
        {
            return View(db.Posts);
        }
    }
}