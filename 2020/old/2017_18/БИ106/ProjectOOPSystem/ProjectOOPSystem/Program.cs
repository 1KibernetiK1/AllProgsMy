using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOPSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowMessage area = new WindowMessage();
            area.Left = 10;
            area.Width = 20;
            area.Draw();
            
            Console.ReadLine();
        }
    }
}
