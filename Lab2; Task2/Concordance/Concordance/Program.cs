using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Concordance
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = new FileInfo(@"..\..\doc.txt").FullName;
            TextDocument doc = new TextDocument(2);
            doc.ProcessFile(filePath);
            doc.PrintConcordance(Path.Combine(Path.GetDirectoryName(filePath), "index.txt"));
        }
    }
}
