

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
        
        public ActionResult Index()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Index(HostelView hv) {
        //    string CustomerId = hv.CUS.ID.ToString();
            string CustomerId = "";
            string CusName = hv.CUS.Name.ToString();
            string Phone = hv.CUS.Phone.ToString();
            string Email = hv.CUS.Email.ToString();
            string Hash = hv.CUS.Hash.ToString();
            string Salt = hv.CUS.Salt.ToString();
            string BedId = hv.BookingBed.BedId.ToString();
            string RoomId = hv.bed1.RoomId.ToString();
            string DateStart = hv.BookingBed.DateStart.ToString();
            string DateEnd = hv.BookingBed.DateEnd.ToString();
            string TotalSum = hv.bok.TotalSum.ToString();
            string Numberofbeds = hv.BookingBed.Amount.ToString();
            try
            {
                var book = db.Database.ExecuteSqlCommand("createBooking @CustomerId={0}, @CusName={1}, @Phone={2}, @Email={3},@Hash={4},@Salt={5},@BedId={6},@RoomId={7},@DateStart={8},@DateEnd={9},@TotalSum={10},@Numberofbeds={11}", CustomerId, CusName, Phone, Email, Hash, Salt, BedId, RoomId, DateStart, DateEnd, TotalSum, Numberofbeds);
                return View("Thank_You");
            }
            catch {
                return View("Error");
            }
        }
    }
}