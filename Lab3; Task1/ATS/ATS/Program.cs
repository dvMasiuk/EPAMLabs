#undef START_CONTRACT

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
            //bool freed = provider.FreeTerminal(terminal);

            terminal.Connect(provider.GetPort());



            terminal.Disconnect();
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
