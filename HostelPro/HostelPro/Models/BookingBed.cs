namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingBed")]
    public partial class BookingBed
    {
        public int ID { get; set; }

        public int BedId { get; set; }

        public int BookingId { get; set; }

        public int? Amount { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual BED Bed { get; set; }
    }
}
