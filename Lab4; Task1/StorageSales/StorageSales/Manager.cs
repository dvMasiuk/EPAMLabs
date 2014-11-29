using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSales
{
    public class Manager
    {
        private IList<Tuple<string, string, double>> orders;
        public Manager(string secondName)
        {
            orders = new List<Tuple<string, string, double>>();
            SecondName = secondName;
        }

        public string SecondName { get; private set; }
        public void Sell(string customer, string product, double sum)
        {
            orders.Add(new Tuple<string, string, double>(customer, product, sum));
        }

        public void SaveOrders(string catalogName)
        {
            if (orders.Count > 0)
            {
                DateTime date = DateTime.Now.Date;
                string fileName = string.Format("{0}_{1}.csv", SecondName, date.ToString("ddMMyyyy"));
                string path = System.IO.Path.Combine(catalogName, fileName);
                string contents = string.Join("\r\n", orders.Select(x => string.Format("{0},{1},{2},{3}", date.ToShortDateString(), x.Item1, x.Item2, x.Item3)));
                System.IO.File.WriteAllText(path, contents);
            }
        }
    }
}
