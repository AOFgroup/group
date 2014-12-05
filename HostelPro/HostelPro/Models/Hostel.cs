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
            HostelToRoms = new HashSet<HostelToRom>();
            Images = new HashSet<Image>();
           
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public int? ZIP { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Information { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<HostelToRom> HostelToRoms { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        
    }
}
