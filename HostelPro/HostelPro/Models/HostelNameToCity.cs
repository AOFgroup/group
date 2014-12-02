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
        public Guid ID { get; set; }

        public Guid HostelNameId { get; set; }

        public Guid CityId { get; set; }

        public virtual City City { get; set; }

        public virtual HostelName HostelName { get; set; }
    }
}
