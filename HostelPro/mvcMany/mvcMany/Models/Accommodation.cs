using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcMany.Models
{
    public class Accommodation
    {
        public int ID { get; set; }
        public string Name {get;set;}
        public virtual ICollection<AccommodationType> AccommodationTypes { get; set; }
    }
}