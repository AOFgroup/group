namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Hash { get; set; }

        [Required]
        [StringLength(255)]
        public string Salt { get; set; }

        public Guid? HostelRoleId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual HostelRole HostelRole { get; set; }
    }
}
