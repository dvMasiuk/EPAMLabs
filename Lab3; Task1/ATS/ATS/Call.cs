using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ATS
{
    public class Call
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double? Cost { get; set; }

        public TimeSpan? Duration { get; set; }

        public bool Ended { get; set; }

        [Required]
        [StringLength(8)]
        public string TargetNumber { get; set; }

        public int SubscriberId { get; set; }

        public virtual Subscriber Subscriber { get; set; }
    }
}
