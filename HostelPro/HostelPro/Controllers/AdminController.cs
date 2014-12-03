using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HostelPro.Models;
using HostelPro.ModelView;
namespace HostelPro.Controllers
{
    public class AdminController : Controller
    {
        private MasteData db = new MasteData();

        // GET: Admin
        public ActionResult Index()
        {
            //var hostels = db.Hostels.Include(h => h.City);
        //    return View(hostels.ToList());
            HostelView admin = new HostelView();
            return View(admin);
          
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hostel hostel = db.Hostels.Find(id);
            if (hostel == null)
            {
                return HttpNotFound();
            }
            return View(hostel);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.ZIP = new SelectList(db.Cities, "ZIP", "CITY1");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,ZIP,Phone,Email,Information")] Hostel hostel)
        {
            if (ModelState.IsValid)
            {
                db.Hostels.Add(hostel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZIP = new SelectList(db.Cities, "ZIP", "CITY1", hostel.ZIP);
            return View(hostel);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hostel hostel = db.Hostels.Find(id);
            if (hostel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZIP = new SelectList(db.Cities, "ZIP", "CITY1", hostel.ZIP);
            return View(hostel);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,ZIP,Phone,Email,Information")] Hostel hostel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZIP = new SelectList(db.Cities, "ZIP", "CITY1", hostel.ZIP);
            return View(hostel);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hostel hostel = db.Hostels.Find(id);
            if (hostel == null)
            {
                return HttpNotFound();
            }
            return View(hostel);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hostel hostel = db.Hostels.Find(id);
            db.Hostels.Remove(hostel);
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
