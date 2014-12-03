namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public Booking()
        {
            BookingBeds = new HashSet<BookingBed>();
        }

        public int ID { get; set; }

        public int CustomerId { get; set; }

        public decimal TotalSum { get; set; }

        public DateTime? BookingDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<BookingBed> BookingBeds { get; set; }
    }
}
