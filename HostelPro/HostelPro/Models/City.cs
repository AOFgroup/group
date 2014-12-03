namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        public City()
        {
            Hostels = new HashSet<Hostel>();
        }

        [Key]
        public int ZIP { get; set; }

        [Column("CITY")]
        [Required]
        [StringLength(255)]
        public string CITY1 { get; set; }

        public virtual ICollection<Hostel> Hostels { get; set; }
    }
}
