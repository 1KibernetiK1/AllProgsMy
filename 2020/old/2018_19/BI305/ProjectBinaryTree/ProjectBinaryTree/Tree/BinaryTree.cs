using ProjectBinaryTree.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectBinaryTree.Tree
{
    public class BinaryTree<T>
        where T : IComparable
    {
        public TreeNode<T> Root { get; set; }

        public void AddNode(T value,long index)
        {
            var node = new TreeNode<T>()
            {
                Item = value,
            };
            node.Indexes.Add(index);

            if (Root == null)
            {
                Root = node;
                return;
            }
            var current = Root;
            while(true)
            {
                int cmp = current.Item.CompareTo(value);
                if (cmp == 0)
                {
                    current.Indexes.Add(node.Indexes[0]);
                    break;
                }
                if(cmp < 0)
                {
                    //Вправо
                    if (current.Right == null)
                    {
                        current.Right = node;
                        break;
                    } else
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    // Влево
                    if (current.Left == null)
                    {
                        current.Left = node;
                        break;
                    } else
                    {
                        current = current.Left;
                    } 
                }
            }
        }

        public void Save()
        {
            var fs = new FileStream("TreeIndex.xml", FileMode.Create);
            var xms = new XmlSerializer(typeof(TreeNode<T>));
            xms.Serialize(fs, Root);
            fs.Close();
        }

        public void Load()
        {
            var fi = new FileInfo("TreeIndex.xml");
            if (!fi.Exists) return;
            var fs = fi.OpenRead();
            var xms = new XmlSerializer(typeof(TreeNode<T>));
            Root = (TreeNode<T>) xms.Deserialize(fs);
            fs.Close();
        }

        public List<long> FindIndexes(T value)
        {
            var list = new List<long>();
            var node = Root;
            while(true)
            {
                if (node == null)
                {
                    return list;
                }
                int cmp = node.Item.CompareTo(value);
                if (cmp == 0)
                {
                    return node.Indexes;
                }
                if (cmp < 0)
                {
                    node = node.Right;
                } else
                {
                    node = node.Left;
                }
            }
        }
    }
}
