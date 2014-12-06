using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HostelPro.Models;
using HostelPro.ModelView;
namespace HostelPro.Controllers
{
    public class HomeController : Controller
    {
        MasterData db = new MasterData();
        public ActionResult Index()
        {
            HostelView data = new HostelView();
            data.customer = db.Customers.ToList();
            data.booking = db.Bookings.ToList();
          

            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}