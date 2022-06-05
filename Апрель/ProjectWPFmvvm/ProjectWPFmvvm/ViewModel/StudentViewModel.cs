using ProjectWPFmvvm.Core;
using ProjectWPFmvvm.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFmvvm.ViewModel
{
    public class StudentViewModel : BaseViewModel<Student>
    {
        public StudentViewModel(Student model) 
            : base(model)
        {

        }

        public string Name
        {
            get => _model.Name;
            set
            {
                if (value == _model.Name)
                    return;
                _model.Name = value;

                OnPropertyChanged("Name");
            }
        }

        public int Age
        {
            get => _model.Age;
            set
            {
                if (value == _model.Age)
                    return;
                _model.Age = value;

                OnPropertyChanged("Age");
            }
        }
    }
}
