using ProjectWpf_MVVM.Core;
using ProjectWpf_MVVM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWpf_MVVM.ViewModels
{
    public class StudentViewModel
        : EntityViewModel<Student>
    {
        public bool HasChanges { get; set; }

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
                HasChanges = true;
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
                HasChanges = true;
                OnPropertyChanged("Age");
            }
        }
    }
}
