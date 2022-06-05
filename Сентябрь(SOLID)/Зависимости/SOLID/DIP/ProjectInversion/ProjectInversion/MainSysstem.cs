using ProjectInversion.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInversion
{
    public class MainSysstem
    {
        private Button _btn;

        public MainSysstem(IStateSwitchable subj)
        {
            _btn = new Button(subj);
        }

        public void Run()
        {
            while (true)
            {
                Console.ReadKey();

                _btn.Click();
            }
        }
    }
}
