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
        public string DateEnd { get; set; }
        public string DateStart { get; set; }
        public string Hostel { get; set; }
        public int HostelId { get;set; }  
        
    }
}