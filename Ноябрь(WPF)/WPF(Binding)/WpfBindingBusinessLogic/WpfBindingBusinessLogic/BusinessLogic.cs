using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingBusinessLogic
{
    public class BusinessLogic
    {
        public static List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                    ImageSource = "images/mers.jpg",
                    Manufacturer = "Mersedes-Benz",
                    Model = "amg gt 63 S",
                    Price = 89000000,
                    Year = 2018
                },
                 new Car()
                {
                    ImageSource = "images/kalina.png",
                    Manufacturer = "Автоваз",
                    Model = "Калина",
                    Price = 650000,
                    Year = 2019
                },

        };
        }
    }
}
