using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFmvvm.Core
{
    public class BaseViewModel<T> : INotifyPropertyChanged where T : class, new()
    {
        protected T _model;

        public BaseViewModel(T model)
        {
            _model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
