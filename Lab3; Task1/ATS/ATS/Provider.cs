using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Provider
    {
        public Terminal SignContract(Contract contract)
        {
            Terminal terminal = null;
            using (var context = new ATSEntitiesContext())
            {
                var telNumber = context.TelephoneNumbers.Attach(contract.TelephoneNumber);
                var tPlan = context.TariffPlans.Attach(contract.TariffPlan);
                if (telNumber != null)
                {
                    var port = context.Ports.First(x => !x.Assigned);
                    terminal = new Terminal()
                    {
                        Port = port,
                        TelephoneNumber = telNumber
                    };
                    port.Assigned = true;
                    telNumber.Assigned = true;
                    context.Terminals.Add(terminal);
                    context.SaveChanges();

                    DateTime dt = DateTime.Now;
                    Subscriber subscriber = new Subscriber()
                    {
                        TerminalId = terminal.Id,
                        TariffPlan = tPlan,
                        LastTariffPlanChanged = dt,
                        DateOfLoan = dt,
                        LoanAmount = 0,
                        ExpiryDateOfLoan = dt.AddMonths(1),
                    };
                    context.Subscribers.Add(subscriber);
                    context.SaveChanges();
                }
            }
            return terminal;
        }

        public bool FreeTerminal(Terminal terminal)
        {
            bool free = false;
            using (var context = new ATSEntitiesContext())
            {
                Subscriber subscriber = context.Subscribers.FirstOrDefault(x => x.TerminalId == terminal.Id);
                if (subscriber != null)
                {
                    if (subscriber.LoanAmount > 0) return free;
                    context.TelephoneNumbers.Attach(terminal.TelephoneNumber).Assigned = false;
                    context.Ports.Attach(terminal.Port).Assigned = false;
                    context.Terminals.Attach(terminal);
                    context.Terminals.Remove(terminal);
                    context.Subscribers.Remove(subscriber);
                    context.SaveChanges();
                    free = true;
                }
            }
            return free;
        }

        public IEnumerable<TariffPlan> GetTariffPlans()
        {
            using (var context = new ATSEntitiesContext())
            {
                return context.TariffPlans.ToList();
            }
        }

        public IEnumerable<TelephoneNumber> GetTelephoneNumbers()
        {
            using (var context = new ATSEntitiesContext())
            {
                return (from number in context.TelephoneNumbers
                        where !number.Assigned
                        select number).ToList();
            }
        }
    }
}
