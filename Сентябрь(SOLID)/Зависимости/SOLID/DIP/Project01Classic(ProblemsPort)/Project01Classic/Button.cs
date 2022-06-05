using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01Classic
{
    /// <summary>
    ///2) шаг Класс верхнего уровня (Механика)
    /// </summary>
    public class Button
    {
        // из кнопки обращаться к лампочке(чтобы зажечь)??
        // что и как зажигать - неясно - "нет деталей"
        private Lamp _lamp;

        private bool _isLighting;

        public Button()
        {
            Console.WriteLine("Создается кнопка (особенности: сенсорные,....)");
            _lamp = new Lamp(); // создается лампочка
            _isLighting = false; // на старте она не светит
        }

        public void Click()
        {
            _isLighting = !_isLighting; // проверяет светит она или нет
            if (_isLighting) // если вкл то свет если нет то тьма
            {
                _lamp.Light();
            }
            else
            {
                _lamp.Dark();
            }
        }
    }
}
