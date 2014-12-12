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

        public ActionResult FindBeds()
        {
            BedFilter BD = new BedFilter();
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(2);
            List<AllBeds> getBeds = getAllBeds(start.ToShortDateString(), end.ToShortDateString());
          

            return View(getBeds);

        }
        public ActionResult Date()
        {
            BedFilter bed = new BedFilter();
            return PartialView("_Date", bed);
        }

        public ActionResult City()
        {

            var city = db.Cities;

            return PartialView("_City", city);
        }
        public ActionResult People()
        {



            return PartialView("_people");
        }


        public List<AllBeds> getAllBeds(string DateStart, string DateEnd)
        {
            List<AllBeds> allBeds = new List<AllBeds>();
            //codeFirst
            try
            {
                var evailibleBeds = db.Database.SqlQuery<AllBeds>("AvailibleBeds @DateStart={0},@DateEnd={1}", DateStart, DateEnd).ToList();


                foreach (var bed in evailibleBeds)
                {
                    AllBeds b = new AllBeds();
                    b.Hostel = bed.Hostel;
                    b.RoomId = bed.RoomId;
                    b.DateStart = bed.DateStart;
                    b.DateEnd = bed.DateEnd;
                    b.BedId = bed.BedId;
                    b.HostelId = bed.HostelId;
                    b.Price = bed.Price;
                    b.City = bed.City;
                    allBeds.Add(b);
                }

                DateTime start = Convert.ToDateTime(DateStart);
                DateTime end = Convert.ToDateTime(DateEnd);

                //var evailibleBeds = db.Database.SqlQuery<AllBeds>("AvailibleBeds @DateStart={0},@DateEnd={1}",DateStart,DateEnd).ToList();
                BedFilter filter = new BedFilter();
                //  var booking = db.Database.ExecuteSqlCommand("createBooking @DateStart={0}, @DateEnd={1}", HostelView.BookingBed.DateStart, HostelView.BookingBed.DateEnd);

                foreach (var item in evailibleBeds)
                {
                    filter.hostel = db.Hostels.Where(h => h.ID == item.HostelId).ToList();
                    filter.bed = db.BEDs.Where(b => b.ID == item.BedId).ToList();
                    filter.room = db.Rooms.Where(r => r.ID == item.RoomId).ToList();




                }
            }
            catch
            {
                //var bed = from x in db.BookingBeds.Where(s => s.DateEnd <= date && (s.DateStart >= t2)) group x by x.BedId;

                //allbeds =bed;

            }

            return allBeds;

        }




        public ActionResult DateFilter(string DateStart, string DateEnd)
        {
            List<AllBeds> getBeds = getAllBeds(DateStart, DateEnd);


            return PartialView("_filteredDates", getBeds);
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
            ViewBag.ZIP = db.Cities; 
            return View(hostel);
        }

        // POST: Hostels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(HotelRoomBed HotelRoomBed, FormCollection collection)
        {
                 var zip = HotelRoomBed.City.ZIP;
                 HotelRoomBed.Hostel.ZIP = zip;
                //HotelRoomBed.Hostel.City.ZIP = HotelRoomBed.City.ZIP;
                Room room;
                BED b;
                var bedNumber = collection["bedInput"];
                var pricePrBed = collection["Price"];
                int[] rooms = null;
                int[] price = null;
                try
                {
                    rooms = bedNumber.Split(',').Select(c => Convert.ToInt32(c)).ToArray();
                    price = pricePrBed.Split(',').Select(c => Convert.ToInt32(c)).ToArray();
                }
                catch
                {

                }
                if (rooms != null)
                {
                    db.Hostels.Add(HotelRoomBed.Hostel);
                    int index = 0;
                    foreach (int roomNumber in rooms)
                    {
                        ++index;

                        room = new Room();
                        int bedPrice = 0;
                        if (price != null)
                        {
                            bedPrice = price[index - 1];

                        }
                        for (int i = 0; i < roomNumber; i++)
                        {

                            b = new BED();
                            b.Room = room;
                            b.Price = bedPrice;
                            room.BEDs.Add(b);
                            db.BEDs.Add(b);
                        }
                       
                        room.Hostel = HotelRoomBed.Hostel;
                        db.Rooms.Add(room);

                    }


                }

                else
                {
                    db.Hostels.Add(HotelRoomBed.Hostel);


                }

                db.SaveChanges();
                return RedirectToAction("Index", "Admin");

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
        public JsonResult City(HotelRoomBed CityView)
        {

            if (this.Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Cities.Add(CityView.City);

                        db.SaveChanges();
                   
                    }
                   
                   catch
                    {



                    }
                    


                    return Json(CityView.City, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(db.Cities, JsonRequestBehavior.AllowGet);
        }
        

    }




}
