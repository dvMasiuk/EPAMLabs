#undef START_CONTRACT
#undef END_CONTRACT

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATS
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"..\..\AppObjs.xml";

            Provider provider = new Provider();
#if START_CONTRACT
            TelephoneNumber telNum = provider.GetTelephoneNumbers().First();
            TariffPlan tPlan = provider.GetTariffPlans().OrderBy(x => x.Cost).First();
            Contract contract = new Contract()
            {
                TelephoneNumber = telNum,
                TariffPlan = tPlan
            };
            Terminal terminal = provider.SignContract(contract);
            if (terminal == null) return;
            XmlSerialize(terminal, fileName);
#else
            Terminal terminal = XmlDeserialize<Terminal>(fileName);
#endif
            //provider.ChangeTariffPlan(terminal,provider.GetTariffPlans().First());
            terminal.Connect(provider.GetPort());
            Console.WriteLine("Port is connected.");
            Console.WriteLine("Calling...");
            terminal.Call("32-21-65");
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 5));
            terminal.EndCall();
            Console.WriteLine("Call is ended.");

            Console.WriteLine("Report (No Filter):");
            Console.WriteLine(provider.GetReport(terminal));
            Console.WriteLine("Report (Filter is Cost and TelephoneNumber):");
            Console.WriteLine(provider.GetReport(terminal, 20, "32-21-65"));
            Console.WriteLine("Report (Filter is Date):");
            Console.WriteLine(provider.GetReport(terminal, DateTime.Now));
            terminal.Disconnect();
            Console.ReadKey();
#if END_CONTRACT
            bool freed = provider.FreeTerminal(terminal);
#endif
        }

        public static void XmlSerialize(object obj, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, obj);
            }
        }

        public static T XmlDeserialize<T>(string fileName) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
