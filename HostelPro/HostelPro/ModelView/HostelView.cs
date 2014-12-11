using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostelPro.Models;

namespace HostelPro.ModelView
{
    public class HostelView
    {
        public List<Customer> customer { get; set; }
        public List<Hostel> hostel { get; set; }
        public List<Booking> booking { get; set; }
        public List<City> city { get; set; }
        public List<Room> room { get; set; }
        public List<BED> bed { get; set; }
        public Customer CUS { get; set; }
        public Booking bok { get; set; }
        public BookingBed BookingBed { get; set; }
        public BED bed1 { get; set; }
        public Room room1 { get; set; }
        public HostelView()
        {
            customer = new List<Customer>();
            hostel = new List<Hostel>();
            booking = new List<Booking>();
            city = new List<City>();
            room = new List<Room>();
            bed = new List<BED>();
            CUS = new Customer();
            bok = new Booking();
            BookingBed = new BookingBed();
         
        }


        
    }
}