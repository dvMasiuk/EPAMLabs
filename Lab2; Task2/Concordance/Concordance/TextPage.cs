using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class TextPage
    {
        private IList<string> _lines;

        public TextPage()
        {
            this._lines = new List<string>();
        }

        public string GetText(TextOptions options)
        {
            string separator = "";
            switch (options)
            {
                case TextOptions.Singleline:
                    separator = " ";
                    break;
                case TextOptions.Multiline:
                    separator = "\r\n";
                    break;
            }
            return string.Join(separator, this._lines);
        }

        public void AddLine(string line)
        {
            this._lines.Add(line);
        }

        public void AddLines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                this.AddLine(line);
            }
        }

        public void RemoveAllLines()
        {
            this._lines.Clear();
        }

        public string LineAt(int numberLine)
        {
            return numberLine > 0 && numberLine <= this._lines.Count ? this._lines[numberLine - 1] : null;
        }
    }
}
