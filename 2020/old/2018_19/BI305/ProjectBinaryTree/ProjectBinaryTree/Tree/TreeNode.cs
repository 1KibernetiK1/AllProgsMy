using ProjectBinaryTree.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBinaryTree.Tree
{
    public class TreeNode<T>
    {
        /// <summary>
        /// Значение, по которому строим индекс
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// Позиция(номер байта)в файле
        /// </summary>
        public List<long> Indexes { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public override string ToString()
        {
            return Item.ToString();
        }

        public TreeNode()
        {
            Indexes = new List<long>();
            Left = null;
            Right = null;
        }
    }
}
