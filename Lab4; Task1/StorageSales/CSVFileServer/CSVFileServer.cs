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
        object locker = new object();

        private FileSystemWatcher catalogWatcher;
        public CSVFileServer(string workingDirectory)
        {
            catalogWatcher = new FileSystemWatcher(workingDirectory, "*.csv");
            catalogWatcher.Created +=catalogWatcher_Created;
            catalogWatcher.EnableRaisingEvents = true;
        }

        async void catalogWatcher_Created(object sender, FileSystemEventArgs e)
        {
            await Task.Run(() =>
            {
                using (DataLayerContext context = new DataLayerContext())
                {
                    var lines = File.ReadAllLines(e.FullPath);
                    foreach (var item in lines)
                    {
                        var fields = item.Split(',');
                        lock (locker)
                        {
                            string customer=string.Copy(fields[1]), product=string.Copy(fields[2]);
                            context.Orders.Add(
                                new Order()
                                {
                                    Date = DateTime.Parse(fields[0]),
                                    Customer = context.Customers.FirstOrDefault(x => x.Name.Equals(customer)) ?? context.Customers.Add(new Customer() { Name = fields[1] }),
                                    Product = context.Products.FirstOrDefault(x => x.Name.Equals(product)) ?? context.Products.Add(new Product() { Name = fields[2] }),
                                    Sum = double.Parse(fields[3])
                                });
                        }
                    }
                    context.SaveChanges();
                }
            });
        }
        //public string CatalogName { get; private set; }
    }
}
