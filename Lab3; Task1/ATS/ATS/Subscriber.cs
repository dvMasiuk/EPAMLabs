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

        public DateTime LastTariffPlanChanged { get; set; }

        public DateTime DateOfLoan { get; set; }

        public DateTime ExpiryDateOfLoan { get; set; }

        public double LoanAmount { get; set; }

        public int TerminalId { get; set; }

        public int TelephoneNumberId { get; set; }

        public int TariffPlanId { get; set; }

        public int? PortId { get; set; }

        public virtual TariffPlan TariffPlan { get; set; }

        public virtual ICollection<Call> Calls { get; set; }
    }
}
