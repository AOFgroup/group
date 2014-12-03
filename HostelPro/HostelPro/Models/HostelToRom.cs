namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostelToRom")]
    public partial class HostelToRom
    {
        public int ID { get; set; }

        public int RoomID { get; set; }

        public int HostelId { get; set; }

        public virtual Hostel Hostel { get; set; }

        public virtual Room Room { get; set; }
    }
}
