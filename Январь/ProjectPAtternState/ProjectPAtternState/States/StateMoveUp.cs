using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPAtternState
{
    public class StateMoveUp: IState
    {
        public char GetFace() => '▲';

        public void Move(Widget widget)
        {
            widget.Y--;
        }
    }
}
