using ProjectInversion.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInversion
{   
    /// <summary>
    /// 2) шаг - пишем сразу верхний уровень
    /// (начинаем дом с крыши)
    /// </summary>
    public class Button
    {
        // неопределенное нечто - абстракция
        // (неконкретное - ГИБКАЯ)
        private readonly IStateSwitchable _subject;
        private bool _isActive;

        /// <summary>
        /// Инъекция зависимости через конструктор
        /// </summary>
        /// <param name="subject"></param>
        public Button(IStateSwitchable subject)
        {
            _subject = subject;
            _isActive = false; // изначально выключено
        }

        public void Click()
        {
            _isActive = !_isActive;
            if (_isActive)
            {
                _subject.SwitchOn();
            }
            else
            {
                _subject.SwitchOff();
            }
        }
    }
}
