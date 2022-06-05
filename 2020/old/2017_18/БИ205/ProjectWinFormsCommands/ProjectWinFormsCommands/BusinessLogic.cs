using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWinFormsCommands
{
    /// <summary>
    /// Класс, инкапсулирует 
    /// бизнес логику приложения
    /// (переносимый/ платформы).
    /// (СИМУЛЯЦИЯ работы с файлом)
    /// </summary>
    public class BusinessLogic
    {
        private bool _isPresentFile;
        private bool _isModified;

        public bool CanCreateOrLoad()
        {
            return ! _isModified;
        }

        public bool CanEdit()
        {
            return _isPresentFile;
        }

        public bool CanClose()
        {
            return 
                _isPresentFile &&
                ! _isModified;
        }

        public bool CanSave()
        {
            return _isModified;
        }
        public void EditFile()
        {
            _isModified = true;
        }
        public void SaveFile()
        {
            _isModified = false;
        }

        public void CreateFile()
        {
            _isPresentFile = true;
            _isModified = false;
        }

        public void CloseFile()
        {
            _isPresentFile = false;
            _isModified = false;
        }

        public void LoadFile()
        {
            _isPresentFile = true;
            _isModified = false;
        }
    }
}
