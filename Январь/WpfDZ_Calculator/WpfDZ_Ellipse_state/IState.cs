using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfDZ_Ellipse_state
{
    public interface IState
    {
        void Add();

        void Subtract();

        void Multiply();

        void Divide();

        void Clear();

        void ClearLastLetter();

        Grid UI();
    }
}
