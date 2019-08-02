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
    public class AccountsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.LoginModels.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginModel loginModel = db.LoginModels.Find(id);
            if (loginModel == null)
            {
                return HttpNotFound();
            }
            return View(loginModel);
        }

        // GET: Accounts/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailAddress,Password")] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                db.LoginModels.Add(loginModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginModel);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginModel loginModel = db.LoginModels.Find(id);
            if (loginModel == null)
            {
                return HttpNotFound();
            }
            return View(loginModel);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailAddress,Password")] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginModel);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginModel loginModel = db.LoginModels.Find(id);
            if (loginModel == null)
            {
                return HttpNotFound();
            }
            return View(loginModel);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoginModel loginModel = db.LoginModels.Find(id);
            db.LoginModels.Remove(loginModel);
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
