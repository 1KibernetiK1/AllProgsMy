using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatterIteratorAndLinked
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private MyNode<T> _head;
        private MyNode<T> _tail;

        public MyLinkedList()
        {
            _head = _tail = null;
        }

      

        public void Add(T value)
        {
            MyNode<T> node = new MyNode<T>(value);
            if (_tail == null)
            {
                _head = _tail = node;
            }
            else
            {
                _tail.Next = node;
                //_tail = _tail.Next;
                _tail = node;
            }          
        }

       


        public IEnumerator GetEnumerator()
        {
            // алгоритм перебора элементов
            MyNode<T> node = _head;
            do
            {
                yield return node.Value;
                node = node.Next;
                
            } while (node != null);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            // алгоритм перебора элементов
            MyNode<T> node = _head;
            do
            {
                yield return node.Value;
                node = node.Next;
            } while (node != null);
        }

        /*
         * сдесь был класс myEnumerator
         */
    }

    
}
