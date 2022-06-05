using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPAtternState
{
    public class Widget //GameObject //1
    {
        private readonly IState _state;

        public int X { get; set; }
        public int Y { get; set; }

        public Widget(IState state)
        {
            _state = state;
        }

        public void Draw()
        {
            char face = _state.GetFace();
            Console.SetCursorPosition(X, Y);
            Console.Write(face);
        }
        public void Update()
        {
            _state.Move(this);
        }



    }
}
