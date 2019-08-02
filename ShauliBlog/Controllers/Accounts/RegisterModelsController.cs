using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShauliBlog.DAL;
using ShauliBlog.Models;

namespace ShauliBlog.Controllers
{
    public class RegisterModelsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: RegisterModels
        public ActionResult IndexRegister()
        {
            return View(db.RegisterModels.ToList());
        }

        // GET: RegisterModels/Details/5
        public ActionResult DetailsRegister(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterModel registerModel = db.RegisterModels.Find(id);
            if (registerModel == null)
            {
                return HttpNotFound();
            }
            return View(registerModel);
        }

        // GET: Register new user
        public ActionResult Register()
        {
            return View();
        }

        // POST: RegisterModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "EmailAddress,Password,ConfirmPassword,AutenticationQuestion,AutenticationAnswer")] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                db.RegisterModels.Add(registerModel);
                db.SaveChanges();
                return RedirectToAction("Login", "Accounts");
            }

            return View(registerModel);
        }

        // GET: RegisterModels/Edit/5
        public ActionResult EditRegister(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterModel registerModel = db.RegisterModels.Find(id);
            if (registerModel == null)
            {
                return HttpNotFound();
            }
            return View(registerModel);
        }

        // POST: RegisterModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRegister([Bind(Include = "EmailAddress,Password,ConfirmPassword,AutenticationQuestion,AutenticationAnswer")] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerModel);
        }

        // GET: RegisterModels/Delete/5
        public ActionResult DeleteRegister(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterModel registerModel = db.RegisterModels.Find(id);
            if (registerModel == null)
            {
                return HttpNotFound();
            }
            return View(registerModel);
        }

        // POST: RegisterModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedRegister(string id)
        {
            RegisterModel registerModel = db.RegisterModels.Find(id);
            db.RegisterModels.Remove(registerModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
