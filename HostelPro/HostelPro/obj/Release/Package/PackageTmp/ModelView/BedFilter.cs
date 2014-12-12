using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostelPro.Models;

namespace HostelPro.ModelView
{
    public class BedFilter
    {

        //City City { get; set; }
        //Hostel Hostel { get; set; }
        //BED Bed { get; set; }

        public List<Room> room { get; set; }
        public List<BED> bed { get; set; }
        public List<City> city { get; set; }
        public List<Hostel> hostel { get; set; }
        public BookingBed bookingBed { get; set; }
      public  BedFilter()
        {
            bookingBed = new BookingBed();
            room = new List<Room>();
            bed = new List<BED>();
            city = new List<City>();
            hostel = new List<Hostel>();
        }
    }
}