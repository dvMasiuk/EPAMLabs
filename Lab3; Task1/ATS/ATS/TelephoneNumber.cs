namespace ATS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TelephoneNumber
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Number { get; set; }

        public bool Assigned { get; set; }
    }
}
