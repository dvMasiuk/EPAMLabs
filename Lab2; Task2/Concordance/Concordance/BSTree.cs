using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class BSTree<T> : IBSTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; set; }


        public void Insert(TreeNode<Word> item)
        {
            throw new NotImplementedException();
        }
        public TreeNode<T> Find(T item)
        {
            TreeNode<T> node = Root;
            while (node != null)
            {
                int res = node.Data.CompareTo(item);
                if (res == 0) break;
                else
                    node = res < 0 ? node.Left : node.Right;
            }
            return node;
        }
    }
}
