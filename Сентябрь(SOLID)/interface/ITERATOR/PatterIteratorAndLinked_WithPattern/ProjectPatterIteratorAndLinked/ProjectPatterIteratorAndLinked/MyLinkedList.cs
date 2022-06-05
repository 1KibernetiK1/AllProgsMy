using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatterIteratorAndLinked
{
    public class MyLinkedList<T> : IEnumerable
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
            return new MyEnumerator<T>(this);
        }

        private class MyEnumerator<T> : IEnumerator
        {
            private MyLinkedList<T> _list;
            private MyNode<T> _current;

            public MyEnumerator(MyLinkedList<T> list)
            {
                _list = list;
                _current = null;
            }

            public object Current
            {
                get
                {
                    return _current.Value;
                }
            }

            public bool MoveNext()
            {
                if (_current == null)
                {
                    _current = _list._head;
                    return true;
                }
               /* if (_current.Next == null)
                {
                    return false;
                }*/
                _current = _current.Next;

                return _current != null;

                //return true;
            }

            public void Reset()
            {
                _current = _list._head;
            }
        }
    }

    
}
