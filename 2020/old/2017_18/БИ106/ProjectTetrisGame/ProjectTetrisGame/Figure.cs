using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTetrisGame
{
    public class Figure : GameObject
    {
        protected GameField _mainField;

        public Figure(int x, int y, int w, int h) 
            : base(x, y, w, h)
        {
        }

        public void SetShape(string[] shape)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                string s = shape[i];
                for (int j = 0; j < s.Length; j++)
                {
                    _body[i, j] = s[j] == '1' ? 1 : 0;
                }
            }
        }

        public void Fall()
        {
            _y++;
        }

        public void MoveLeft()
        {
            _x--;
            if (_x < _mainField.Left)
            {
                _x = _mainField.Left;
            }
        }

        public void MoveRight()
        {
            _x++;
            if (_x > _mainField.Right)
            {
                _x = _mainField.Right;
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < _body.GetLength(0); i++)
            {
                for (int j = 0; j < _body.GetLength(1); j++)
                {
                    if (_body[i, j] == 1)
                    {
                        Console.SetCursorPosition(_x + j, _y + i);
                        Console.Write("█"); //219
                    }
                }
            }
        }
    }
}
