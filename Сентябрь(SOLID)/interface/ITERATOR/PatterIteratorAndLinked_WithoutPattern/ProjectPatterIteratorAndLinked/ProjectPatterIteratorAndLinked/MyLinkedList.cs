using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatterIteratorAndLinked
{
    public class MyLinkedList<T>
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
                _tail.next = node;
            }          
        }
    }
}
