namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostelRole")]
    public partial class HostelRole
    {
        public HostelRole()
        {
            Customers = new HashSet<Customer>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
