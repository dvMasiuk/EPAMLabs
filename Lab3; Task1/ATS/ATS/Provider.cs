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
                var telNumber = contract.TelephoneNumber;
                var tPlan = context.TariffPlans.Attach(contract.TariffPlan);
                context.Terminals.Add(terminal = new Terminal());
                context.SaveChanges();

                DateTime dt = DateTime.Now;
                Subscriber subscriber = new Subscriber()
                {
                    TerminalId = terminal.Id,
                    TelephoneNumberId = telNumber.Id,
                    TariffPlan = tPlan,
                    LastTariffPlanChanged = dt,
                    DateOfLoan = dt,
                    LoanAmount = 0,
                    ExpiryDateOfLoan = dt.AddMonths(1),
                };
                context.Subscribers.Add(subscriber);
                context.SaveChanges();
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
                return context.TelephoneNumbers.Except(
                    from number in context.TelephoneNumbers
                    join subscriber in context.Subscribers on number.Id equals subscriber.TelephoneNumberId
                    select number).ToList();
            }
        }

        public Port GetPort()
        {
            using (var context = new ATSEntitiesContext())
            {
                Port port = context.Ports.FirstOrDefault(x => !x.Assigned);
                if (port != null)
                    port.PropertyChanged += port_PropertyChanged;
                return port;
            }
        }

        void port_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            using (var context = new ATSEntitiesContext())
            {
                Port port = context.Ports.Attach((Port)sender);
                switch (port.PortState)
                {
                    case PortState.Connected:
                        port.Assigned = true;
                        break;
                    case PortState.Disconnected:
                        port.Assigned = false;
                        port.PropertyChanged -= port_PropertyChanged;
                        break;
                    case PortState.Calling:
                        break;
                    case PortState.Ending:
                        break;
                }
                context.SaveChanges();
            }
        }
    }
}
