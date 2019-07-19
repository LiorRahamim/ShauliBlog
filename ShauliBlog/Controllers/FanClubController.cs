using ShauliBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class FanClubController : Controller
    {
        private FanDBContext db = new FanDBContext();

        public ActionResult FansList()
        {
            return View(db.Fans);
        }
    }
}