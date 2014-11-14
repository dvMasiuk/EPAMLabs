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
            //Contract contract= provider.SignContract();
            //XmlSerialize(contract, fileName);
            Contract contract = XmlDeserialize<Contract>(fileName);
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
