using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class singleton
    {
        //public string Name;

        private static singleton _instance;

        private singleton()
        { }

        public static singleton GetInstance()
        {
            if (_instance == null) _instance = new singleton();
            return _instance;
        }
    }
}
