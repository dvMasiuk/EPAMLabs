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
            string inputFilePath = new FileInfo(@"..\..\doc.txt").FullName;
            string outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), "index.txt");
            TextDocument doc = new TextDocument();
            doc.ReadFromFile(inputFilePath, 14);
            File.WriteAllText(outputFilePath, doc.GetConcordance());
        }
    }
}
