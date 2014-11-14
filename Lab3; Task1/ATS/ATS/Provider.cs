using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Provider
    {
        public Contract SignContract()
        {
            Contract contract = null;
            using (var context = new ATSEntitiesContext())
            {
                var port = context.Ports.FirstOrDefault(x => !x.Assigned);
                if (port != null)
                {
                    var number = context.TelephoneNumbers.FirstOrDefault(x => !x.Assigned);
                    if (number != null)
                    {
                        Terminal terminal = new Terminal()
                        {
                            PortId = port.Id,
                            TelephoneNumberId = number.Id
                        };
                        port.Assigned = true;
                        number.Assigned = true;
                        context.Terminals.Add(terminal);
                        context.SaveChanges();

                        contract = new Contract()
                        {
                            TariffPlanId = context.TariffPlans.First().Id,
                            TerminalId = terminal.Id,
                        };
                        context.Contracts.Add(contract);
                        context.SaveChanges();

                        DateTime dt = DateTime.Now;
                        Subscriber subscriber = new Subscriber()
                        {
                            ContractId = contract.Id,
                            LastTariffPlanChanged = dt,
                            DateOfLoan = dt,
                            LoanAmount = 0,
                            ExpiryDateOfLoan = dt.AddMonths(1),

                        };
                        context.Subscribers.Add(subscriber);
                        context.SaveChanges();
                    }
                }
            }
            return contract;
        }

        public void CancelContract(Contract contract)
        { }

        public Terminal GetTerminal(int terminalId)
        {
            using (var context = new ATSEntitiesContext())
            {
                return context.Terminals.Find(terminalId);
            }
        }
    }
}
