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
            BEDs = new HashSet<BED>();
            HostelToRoms = new HashSet<HostelToRom>();
        }

        public int ID { get; set; }

        public int BedNumber { get; set; }
        public virtual ICollection<BED> BEDs { get; set; }
        public virtual ICollection<HostelToRom> HostelToRoms { get; set; }
    }
}
