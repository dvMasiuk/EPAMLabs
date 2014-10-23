using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public class BSTree<T> : IBSTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }

        public void Insert(T item)
        {
            TreeNode<T> node = Root, parent = null;
            while (node != null)
            {
                parent = node;
                node = item.CompareTo(node.Data) < 0 ? node.Left : node.Right;
            }
            node = new TreeNode<T>() { Data = item };
            if (parent == null)
                Root = node;
            else if (item.CompareTo(parent.Data) < 0)
                parent.Left = node;
            else
                parent.Right = node;
        }
        public TreeNode<T> Find(T item)
        {
            TreeNode<T> node = Root;
            while (node != null)
            {
                int res = item.CompareTo(node.Data);
                if (res == 0) break;
                else
                    node = res < 0 ? node.Left : node.Right;
            }
            return node;
        }

        public void Traverse(TreeNode<T> node, Action<T> callback)
        {
            if (node != null)
            {
                Traverse(node.Left, callback);
                callback(node.Data);
                Traverse(node.Right, callback);
            }
        }
    }
}
