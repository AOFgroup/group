using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HostelPro.Models;

namespace HostelPro.Controllers
{
    public class HostelRolesController : Controller
    {
        private MasterData db = new MasterData();

        // GET: HostelRoles
        public ActionResult Index()
        {
            return View(db.HostelRoles.ToList());
        }

        // GET: HostelRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostelRole hostelRole = db.HostelRoles.Find(id);
            if (hostelRole == null)
            {
                return HttpNotFound();
            }
            return View(hostelRole);
        }

        // GET: HostelRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostelRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] HostelRole hostelRole)
        {
            if (ModelState.IsValid)
            {
                db.HostelRoles.Add(hostelRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hostelRole);
        }

        // GET: HostelRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostelRole hostelRole = db.HostelRoles.Find(id);
            if (hostelRole == null)
            {
                return HttpNotFound();
            }
            return View(hostelRole);
        }

        // POST: HostelRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] HostelRole hostelRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostelRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hostelRole);
        }

        // GET: HostelRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostelRole hostelRole = db.HostelRoles.Find(id);
            if (hostelRole == null)
            {
                return HttpNotFound();
            }
            return View(hostelRole);
        }

        // POST: HostelRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HostelRole hostelRole = db.HostelRoles.Find(id);
            db.HostelRoles.Remove(hostelRole);
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
