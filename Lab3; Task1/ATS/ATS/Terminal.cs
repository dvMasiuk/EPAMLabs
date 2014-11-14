namespace ATS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Terminal
    {
        public int Id { get; set; }

        public int TelephoneNumberId { get; set; }

        public int PortId { get; set; }
    }
}
