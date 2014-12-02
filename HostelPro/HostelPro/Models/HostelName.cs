namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostelName")]
    public partial class HostelName
    {
        public HostelName()
        {
            HostelNameToCities = new HashSet<HostelNameToCity>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<HostelNameToCity> HostelNameToCities { get; set; }
    }
}
