using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSales
{
    class Program
    {
        static void Main(string[] args)
        {
            //CSVFileServer.CSVFileServer serv = new CSVFileServer.CSVFileServer();

            string catalogName = @"C:\Users\Dimi\Source\Repos\EPAMLabs\Lab4; Task1\StorageSales\SCVFileService\bin\Debug\CSVFiles";
            Manager manager = new Manager("Rubinov");
            manager.Sell("Petrov", "Car", 150);
            manager.Sell("Derin", "Book", 20);
            manager.SaveOrders(catalogName);
            manager = new Manager("Ivanov");
            manager.Sell("Sidorov", "Milk", 15);
            manager.Sell("Derin", "Loaf", 10);
            manager.SaveOrders(catalogName);
        }
    }
}
