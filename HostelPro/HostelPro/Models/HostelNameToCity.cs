namespace HostelPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostelNameToCity")]
    public partial class HostelNameToCity
    {
        public int ID { get; set; }

        public int HostelNameId { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual HostelName HostelName { get; set; }
    }
}
