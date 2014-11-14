namespace ATS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Call
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Cost { get; set; }

        public TimeSpan Duration { get; set; }

        public int SubscriberId { get; set; }

        public virtual Subscriber Subscriber { get; set; }
    }
}
