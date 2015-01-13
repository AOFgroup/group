

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
    public class BookingController : Controller
    {
        private MasterData db = new MasterData();
        // GET: Booking
        
        public ActionResult Index(AllBeds allbeds,string people,string price)
        {
            int am=1;
            int pr = 0;
            if (allbeds.DateStart==null)
            {
                allbeds.DateStart = DateTime.Now;
               
            }
          
            if (allbeds.DateEnd==null)
            {
                DateTime start = DateTime.Now;
                DateTime end = start.AddDays(1);
                allbeds.DateEnd = end;
            }

            if (people!="" && price!="")
            {
               am = Convert.ToInt32(people);
               pr = Convert.ToInt32(price);
            }
            
           
            HostelView hw = new HostelView();
            hw.room1 = db.Rooms.Where(r => r.ID == allbeds.RoomId).First();
            hw.BookingBed.Amount = am;
            hw.BookingBed.DateStart = allbeds.DateStart;
            hw.bok.TotalSum = (am * pr);
            hw.BookingBed.DateEnd = allbeds.DateEnd;
            return View(hw);
        }
        [HttpPost]
        public ActionResult Index(HostelView hv) {

            if (ModelState.IsValid)
            {
                Customer cus = new Customer();
                //    string CustomerId = hv.CUS.ID.ToString();
                string DateStart = hv.BookingBed.DateStart.ToString();
                string DateEnd = hv.BookingBed.DateEnd.ToString();
                string CustomerId = null;
                string CusName = hv.CUS.Name.ToString();
                string Phone = hv.CUS.Phone.ToString();
                string Email = hv.CUS.Email.ToString();
                cus.Salt=cus.GenerateSalt();
                string Hash = cus.HashPassword(hv.CUS.Hash.ToString());
                string Salt = cus.Salt;
                string BedId = null;
                string RoomId = hv.room1.ID.ToString();
                string TotalSum = hv.bok.TotalSum.ToString();
                string Numberofbeds = hv.BookingBed.Amount.ToString();
               
                try
                {
                    var book = db.Database.ExecuteSqlCommand("createBooking @CustomerId={0}, @CusName={1}, @Phone={2}, @Email={3},@Hash={4},@Salt={5},@BedId={6},@RoomId={7},@DateStart={8},@DateEnd={9},@TotalSum={10},@Numberofbeds={11}", CustomerId, CusName, Phone, Email, Hash, Salt, BedId, RoomId, DateStart, DateEnd, TotalSum, Numberofbeds);
                   return  RedirectToAction ("Thank_You");
                }
                catch
                {
                  return  RedirectToAction("Error");
                }

            }

            return View(hv);
        
        }

        public ActionResult Thank_You()
        {
            return View();
        }

        public ActionResult Error()
        {

            return View();

        }
    }
}