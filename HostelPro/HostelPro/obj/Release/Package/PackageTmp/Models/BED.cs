namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BED")]
    public partial class BED
    {
        public int ID { get; set; }

        public decimal? Price { get; set; }

        public int? RoomId { get; set; }

        public virtual Room Room { get; set; }
       
    }
}
