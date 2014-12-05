using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostelPro.Models;
namespace HostelPro.ModelView
{
    public class HotelRoomBed
    {
        public Hostel Hostel { get; set; }
        public Room Room { get; set; }
        public BED Bed { get; set; }
        public City City { get; set; }

       public HotelRoomBed()
       {    
           Hostel = new Hostel();
           Room = new Room();
           Bed = new BED();
           City = new City();
       }


    }
}