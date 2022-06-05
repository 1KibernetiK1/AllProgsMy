using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingBusinessLogic
{
    public class Car
    {
        public string Model { get; set; } = "МодельМашины";

        public string Manufacturer { get; set; } = "Автоваз";

        public int Price { get; set; } = 1000000;

        public int Year { get; set; } = 2000;

        public string ImageSource { get; set; } = "images/mers.jpg";
    }
}
