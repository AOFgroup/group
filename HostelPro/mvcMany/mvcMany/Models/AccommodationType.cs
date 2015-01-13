using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcMany.Models
{
    public class AccommodationType
    {
        public int ID { get; set; }
        public string Name { get;set;}
        public virtual ICollection<Accommodation> Accommodations { get; set; }
    
    }
}