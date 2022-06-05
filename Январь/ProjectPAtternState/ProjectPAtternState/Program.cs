using ProjectPAtternState.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPAtternState
{
    class Program
    {
        static void Main(string[] args)
        {
            var widgets = new List<Widget>
            {
                new Widget(new BehaviorGuardPerimeter(10,4,15,6)),
                new Widget(new BehaviorGuardPerimeter(27,6,15,6, false))
            };

            
          

            while (true)
            {
                foreach (var widget in widgets)
                {
                    widget.Update();
                    widget.Draw();
                }

             

                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
