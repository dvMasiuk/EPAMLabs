using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ATS
{
    public class Contract
    {
        public TariffPlan TariffPlan { get; set; }
        public TelephoneNumber TelephoneNumber { get; set; }
    }
}
