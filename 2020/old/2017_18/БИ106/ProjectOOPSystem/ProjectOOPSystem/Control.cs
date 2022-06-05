using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOPSystem
{
    public class Control:
        DrawableArea
    {
        protected Control _parent;

        public Control Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }


        protected string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }


        protected ConsoleColor _textColor;

        public ConsoleColor TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }

        protected string CutText(string str)
        {
            int diff = (_w - (_text.Length + 3));
            if (diff < 0)
            {
                str = str.Substring(0, _text.Length 
                    + diff);
            }
            return str;
        }

    }
}
