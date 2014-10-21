using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class Word: IComparable<Word>
    {
        public string Value { get; set; }
        public int Frequency { get; set; }
        public List<int> ListPages { get; set; }

        public int CompareTo(Word other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
