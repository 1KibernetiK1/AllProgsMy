using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStrategyClassic
{
    public abstract class UniversalDriverDevice
    {
        // обязательные методы
        public abstract void Description();
        public abstract void Plug(); // plug&play

        // необязательные 
        public virtual void Print()
        {
            throw new NotImplementedException();
        }
        public virtual void Scan()
        {
            throw new NotImplementedException();
        }
        public virtual void Email()
        {
            throw new NotImplementedException();
        }
        public virtual void Fax()
        {
            throw new NotImplementedException();
        }
        public virtual void Copy()
        {
            throw new NotImplementedException();
        }
        public virtual void ErasePaper()
        {
            throw new NotImplementedException();
        }
    }
}
