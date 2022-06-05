using ProjectWpf_MVVM.Core;
using ProjectWpf_MVVM.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectWpf_MVVM.ViewModels
{
    public class MainViewModel 
        : BaseViewModel
    {
        protected DelegateCommand _cmdSaveStudents;

        public DelegateCommand CmdSaveStudents =>
            _cmdSaveStudents == null ?
            new DelegateCommand("Сохранить", CmdSaveExecute, CmdSaveCanExecute) 
            : _cmdSaveStudents;

        private bool CmdSaveCanExecute()
        {
            return ActiveStudent == null ? 
                false : 
                ActiveStudent.HasChanges;
        }

        private void CmdSaveExecute()
        {
            MessageBox.Show("Всё сохранили");
            ActiveStudent.HasChanges = false;
        }

        public MainViewModel()
        {
            AllStudents = new FakeRepositoryStudents()
                .GetItems()
                .Select(m => new StudentViewModel(m));
        }

        public IEnumerable<StudentViewModel> AllStudents { get; set; }

        protected StudentViewModel _student;

        public StudentViewModel ActiveStudent
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged("ActiveStudent");
            }
        }
    }

}
