using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInversion.Abstract
{
    /// <summary>
    /// 1) шаг = выделена абстракция 
    /// (несуществующая физически пока)
    /// </summary>
    public interface IStateSwitchable
    {
        void SwitchOn();

        void SwitchOff();
    }
}
