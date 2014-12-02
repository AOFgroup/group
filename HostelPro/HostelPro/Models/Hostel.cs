namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hostel")]
    public partial class Hostel
    {
        public Hostel()
        {
            Rooms = new HashSet<Room>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public Guid CityId { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Information { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
