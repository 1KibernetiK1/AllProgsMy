using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatterIteratorAndLinked
{
    public class MyNode<T>
    {
        private T _value;

        public T Value
        {
            get { return _value; }
            set { _value = value;  }
        }

        private MyNode<T> _next;

        public MyNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public MyNode(T value)
        {
            _value = value;
            _next = null;
        }
    }
}
