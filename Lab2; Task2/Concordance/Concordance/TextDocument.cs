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
        //private IList<TextPage> _pages;
        private BSTree<Word> _tree;

        private int _linesOnPage;
        public TextDocument(int linesOnPage)
        {
            this._linesOnPage = linesOnPage;
        }

        public void ProcessFile(string filePath)
        {
            string line;
            using (StreamReader sr = new StreamReader(filePath))
            {
                int currLine = 0, currPage = 1;
                this._tree = new BSTree<Word>();
                while ((line = sr.ReadLine()) != null)
                {
                    currLine++;
                    var res = Regex.Matches(line, "\\w+");
                    foreach (Match item in res)
                    {
                        Word word = new Word() { Value = item.Value.ToLower() };
                        TreeNode<Word> node = this._tree.Find(word);
                        if (node != null)
                        {
                            word = node.Data;
                            if (word.ListPages.Last() < currPage)
                                word.ListPages.Add(currPage);
                        }
                        else
                        {
                            word.ListPages = new List<int>() { currPage };
                            this._tree.Insert(word);
                        }
                        word.Frequency++;

                    }
                    if (currLine == this._linesOnPage) { currPage++; currLine = 0; }
                }

            }
            //this._pages = new List<TextPage>();
            //int n = (int)Math.Ceiling((double)lines.Length / this._linesOnPage);// count pages

            //int k = 0;
            //for (int i = 0; i < n - 1; k = ++i * this._linesOnPage)
            //{
            //    this._pages.Add(new TextPage() { Number = i + 1, Text = string.Join(" ", lines, k, this._linesOnPage) });
            //}
            //this._pages.Add(new TextPage() { Number = n, Text = string.Join(" ", lines, k, lines.Length - k) });

        }

        public void PrintConcordance(string filePath)
        {
            if (this._tree != null)
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    char currGroup='\0';
                    this._tree.Traverse(this._tree.Root,
                        x =>
                        {
                            if (!currGroup.Equals(x.Value[0]))
                                sw.WriteLine(char.ToUpper(currGroup = x.Value[0]));
                            string line = string.Format("{0}{1}{2}: {3}", x.Value, new String('.', 20 - x.Value.Length), x.Frequency, string.Join(", ", x.ListPages));
                            sw.WriteLine(line);
                        });
                }
            }
        }
    }
}
