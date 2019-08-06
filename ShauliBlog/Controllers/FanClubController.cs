using ShauliBlog.DAL;
using ShauliBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class FanClubController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult FanList(string fanGender, string fanName, string clubSeniority)
        {
            // Would be much more complex querying the filtered fans straight from 
            // the DB because the filter parameters can be empty (and we would need query for each case)
            var fans = from fan in db.Fans
                       select fan;

            if (!String.IsNullOrEmpty(fanName))
            {
                fans = fans.Where(fan => (fan.name.Contains(fanName) || fan.sn.Contains(fanName)));
            }
            if (!string.IsNullOrEmpty(fanGender))
            {
                fans = fans.Where(fan => fan.gender == fanGender);
            }
            if (!string.IsNullOrEmpty(clubSeniority))
            {
                fans = fans.Where(fan => fan.clubSeniority.ToString() == clubSeniority);
            }

            return View(fans);
        }

        public ActionResult FanDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db.Fans.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        /**
         * Get method - used to display 'createNewFan' page
         */
        public ActionResult CreateNewFan()
        {
            return View();
        }

        /*
         * Post method - used to actually create the new fan
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewFan([Bind(Include = "ID,name,sn,gender,city,birthday,clubSeniority")] Fan fan)
        {
            db.Fans.Add(fan);
            db.SaveChanges();
            return RedirectToAction("FanList");
        }

        /**
         * Get method - used to display the edit page
         */
        public ActionResult EditFan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db.Fans.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        /**
         * Post method - used when saving the edited fan
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFan([Bind(Include = "ID,name,sn,gender,city,birthday,clubSeniority")] Fan fan)
        {
            db.Entry(fan).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("FanList");
        }

        /**
         * Get method - used to display 'deleteFan' confirmation page
         */
        public ActionResult DeleteFanDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db.Fans.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        /**
         * Post method - used when deleting a fan
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFanDetails(int id)
        {
            Fan fan = db.Fans.Find(id);
            db.Fans.Remove(fan);
            db.SaveChanges();
            return RedirectToAction("FanList");
        }
    }
}