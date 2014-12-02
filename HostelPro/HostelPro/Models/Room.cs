namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ID { get; set; }

        public int BedNumber { get; set; }

        public int HostelId { get; set; }

        public decimal Price { get; set; }

        public bool PetAllow { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Hostel Hostel { get; set; }
    }
}
