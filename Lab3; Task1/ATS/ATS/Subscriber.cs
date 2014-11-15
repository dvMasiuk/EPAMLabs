using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ATS
{
    public class Subscriber
    {
        public Subscriber()
        {
            Calls = new HashSet<Call>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastTariffPlanChanged { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfLoan { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpiryDateOfLoan { get; set; }

        public int LoanAmount { get; set; }

        public int TerminalId { get; set; }

        public int TariffPlanId { get; set; }

        public virtual TariffPlan TariffPlan { get; set; }

        public virtual ICollection<Call> Calls { get; set; }
    }
}
