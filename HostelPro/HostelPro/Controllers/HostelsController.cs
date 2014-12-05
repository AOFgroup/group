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
    public class HostelsController : Controller
    {
        private MasterData db = new MasterData();

        // GET: Hostels
        public ActionResult Index()
        {
            var hostels = db.Hostels.Include(h => h.City);
            return View(hostels.ToList());
        }

        // GET: Hostels/Details/5
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

        // GET: Hostels/Create
        public ActionResult Create()
        {
            HotelRoomBed hostel = new HotelRoomBed();
         
            ViewBag.ZIP = new SelectList(db.Cities, "ZIP", "CITY1");
            return View(hostel);
        }

        // POST: Hostels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( )
        {
            if (ModelState.IsValid)
            {
                //db.Hostels.Add(hostel.Hostel);
                //db.BEDs.Add(hostel.Bed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ZIP = new SelectList(db.Cities, "ZIP", "CITY1", hostel.Hostel.ZIP);
            return View(hostel);
        }

        // GET: Hostels/Edit/5
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

        // POST: Hostels/Edit/5
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

        // GET: Hostels/Delete/5
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

        // POST: Hostels/Delete/5
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
                [HttpPost]
        public JsonResult City(HotelRoomBed  CityView)
        {
                   
            if (this.Request.IsAjaxRequest())
            {
             if (ModelState.IsValid)
             {
                 db.Cities.Add(CityView.City);
                 db.SaveChanges();
                 MasterData newDb=new MasterData();
                 return Json(newDb.Cities,JsonRequestBehavior.AllowGet);
             }
              
            }
                return Json(db.Cities, JsonRequestBehavior.AllowGet);
        }
        
          
        }



    
}
