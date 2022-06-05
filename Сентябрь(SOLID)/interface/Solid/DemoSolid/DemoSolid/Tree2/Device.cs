using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSolid.Tree2
{
    public abstract class Device
    {
        protected string _model;
        protected string _manufacture;
        protected int _price;

        public abstract void Connect();
    }
}
