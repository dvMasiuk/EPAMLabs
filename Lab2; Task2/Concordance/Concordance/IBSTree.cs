using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    public interface IBSTree<T> where T : IComparable<T>
    {
        void Insert(T item);
        TreeNode<T> Find(T item);
        void Traverse(TreeNode<T> node, Action<T> callback);
    }
}
