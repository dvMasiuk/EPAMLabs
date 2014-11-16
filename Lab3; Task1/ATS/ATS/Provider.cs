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
                    if (subscriber.PortId.HasValue)
                        context.Ports.Find(subscriber.PortId).PortState = PortState.Disconnected;
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
                Port port = context.Ports.FirstOrDefault(x => x.PortState == PortState.Disconnected);
                if (port != null)
                    port.PortStateChanged += port_PortStateChanged;
                return port;
            }
        }

        void port_PortStateChanged(object sender, PortStateChangedEventArgs e)
        {
            using (var context = new ATSEntitiesContext())
            {
                Port port = context.Ports.Attach((Port)sender);
                context.Entry(port).State = System.Data.Entity.EntityState.Modified;
                switch (port.PortState)
                {
                    case PortState.Connected:
                        if (e.Data is int)
                        {
                            Subscriber subscriber = context.Subscribers.FirstOrDefault(x => x.TerminalId == (int)e.Data);
                            if (subscriber != null)
                                subscriber.PortId = port.Id;
                        }
                        break;
                    case PortState.Disconnected:
                        context.Subscribers.First(x => x.PortId == port.Id).PortId = null;
                        port.PortStateChanged -= port_PortStateChanged;
                        break;
                    case PortState.Calling:
                        if (e.Data is string)
                        {
                            Subscriber subscriber = context.Subscribers.First(x => x.PortId == port.Id);
                            if (DateTime.Now < subscriber.ExpiryDateOfLoan)
                            {
                                TelephoneNumber telNum = context.TelephoneNumbers.FirstOrDefault(x => x.Number.Equals((string)e.Data));
                                if (telNum != null)
                                {
                                    Subscriber targetSubs = context.Subscribers.FirstOrDefault(x => x.TelephoneNumberId == telNum.Id);
                                    if (targetSubs!=null && targetSubs.PortId.HasValue)
                                    {
                                        Port targetSubsPort = context.Ports.Find(targetSubs.PortId.Value);
                                        if (targetSubsPort.PortState != PortState.Calling)
                                        {
                                            context.Calls.Add(new Call()
                                            {
                                                Date = DateTime.Now,
                                                Subscriber = subscriber,
                                                Ended = false
                                            });
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case PortState.Ending:
                        DateTime dt = DateTime.Now;
                        Call call = context.Subscribers.First(y => y.PortId == port.Id).Calls.FirstOrDefault(x => !x.Ended);
                        if (call != null)
                        {
                            call.Duration = dt - call.Date;
                            call.Cost = Math.Ceiling(call.Duration.Value.TotalMinutes) * call.Subscriber.TariffPlan.Cost;
                            call.Subscriber.LoanAmount += call.Cost.Value;
                            call.Ended = true;
                        }
                        break;
                }
                context.SaveChanges();
            }
        }

    }
}
