namespace ATS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Port
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool Assigned { get; set; }
    }
}
