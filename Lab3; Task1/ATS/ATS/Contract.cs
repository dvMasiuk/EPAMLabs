namespace ATS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contract
    {
        public int Id { get; set; }

        public int TerminalId { get; set; }

        public int TariffPlanId { get; set; }
    }
}
