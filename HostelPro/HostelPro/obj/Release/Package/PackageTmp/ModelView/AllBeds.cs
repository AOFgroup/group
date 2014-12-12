using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelPro.ModelView
{
    public class AllBeds
    {
        public int RoomId { get; set; }
        public int  BedId { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateStart { get; set; }
        public string Hostel { get; set; }
        public int HostelId { get;set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public int CountBed { get; set; }
        public int NumberOfBeds { get; set; }
        
    }
}