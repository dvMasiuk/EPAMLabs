using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataLayer;

namespace CSVFileServer
{
    public class CSVFileServer
    {
        private FileSystemWatcher catalogWatcher;
        public CSVFileServer()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["CatalogName"];
            catalogWatcher = new FileSystemWatcher(path, "*.csv");
            catalogWatcher.Created += catalogWatcher_Created;
        }

        void catalogWatcher_Created(object sender, FileSystemEventArgs e)
        {
            using (DataLayerContext context = new DataLayerContext())
            {
                var lines = File.ReadAllLines(e.FullPath);
                foreach (var item in lines)
                {
                    var fields = item.Split(',');
                    context.Orders.Add(
                        new Order()
                        {
                            Date = DateTime.Parse(fields[0]),
                            Customer = context.Customers.First(x => x.Name.Equals(fields[1])),
                            Product = context.Products.First(x => x.Name.Equals(fields[2])),
                            Sum = double.Parse(fields[3])
                        });
                }
                context.SaveChanges();
            }
        }
        //public string CatalogName { get; private set; }
    }
}
