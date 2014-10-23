using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Concordance
{
    public class TextDocument
    {
        private IList<TextPage> _pages;
        private BSTree<Word> _tree;

        public TextDocument()
        {
            this._pages = new List<TextPage>();
        }

        public void ReadFromFile(string filePath, int linesOnPage)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    TextPage page = new TextPage();
                    for (int i = 0; i < linesOnPage; i++)
                    {
                        string line = sr.ReadLine();
                        if (line == null) break;
                        page.AddLine(line);
                    }
                    this.AddPage(page);
                }
            }
        }

        private void ProcessText(out int lengthLongestWord)
        {
            this._tree = new BSTree<Word>();
            lengthLongestWord = 0;
            int pageNo = 0;
            foreach (TextPage page in this._pages)
            {
                pageNo++;
                var res = Regex.Matches(page.GetText(TextOptions.Singleline), "\\w+");
                foreach (Match item in res)
                {
                    if (lengthLongestWord < item.Value.Length)
                        lengthLongestWord = item.Value.Length;
                    Word word = new Word() { Value = item.Value.ToLower() };
                    TreeNode<Word> node = this._tree.Find(word);
                    if (node != null)
                    {
                        word = node.Data;
                        if (word.ListPages.Last() < pageNo)
                            word.ListPages.Add(pageNo);
                    }
                    else
                    {
                        word.ListPages = new List<int>() { pageNo };
                        this._tree.Insert(word);
                    }
                    word.Frequency++;
                }
            }
        }

        public string GetConcordance()
        {
            int lengthLongestWord;
            this.ProcessText(out lengthLongestWord);
            char currGroup = '\0';
            StringBuilder sb = new StringBuilder();
            this._tree.Traverse(this._tree.Root,
                x =>
                {
                    if (!currGroup.Equals(x.Value[0]))
                        sb.AppendLine(char.ToUpper(currGroup = x.Value[0]).ToString());
                    string line = string.Format("{0}{1}{2}: {3}", x.Value, new String('.',
                        (lengthLongestWord + 5) - (x.Value.Length + ((int)Math.Log10(x.Frequency) + 1))),
                        x.Frequency, string.Join(", ", x.ListPages));
                    sb.AppendLine(line);
                });
            return sb.ToString();
        }

        public void AddPage(TextPage page)
        {
            this._pages.Add(page);
        }

        public void AddPages(IEnumerable<TextPage> pages)
        {
            foreach (var page in pages)
            {
                this.AddPage(page);
            }
        }

        public void RemoveAllPages()
        {
            this._pages.Clear();
        }
    }
}
