using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTestPathFinder
{
    public class FastDataGridView : DataGridView
    {
        public FastDataGridView()
        {
            DoubleBuffered = true;
        }
    }
}
