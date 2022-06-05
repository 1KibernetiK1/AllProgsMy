using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPAtternState
{
    public interface IState //2
    {
        void Move(Widget widget);

        char GetFace();

    }
}
