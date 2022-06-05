using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWpf_MVVM.Core
{
    public class EntityViewModel<T> : BaseViewModel
        where T : class, new()
    {
        protected T _model;

        public EntityViewModel(T model)
        {
            _model = model;
        }
    }
}
