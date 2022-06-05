using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLinq_DZ
{

    public enum Covers {IsAvailable, NotAvailable }

    public class HardDrive
    {
        public string Name { get; set; }

        public int Volume { get; set; }

        public int Guarantee { get; set; }

        public bool AvailabilityInStores { get; set; }

        public int Rating { get; set; }

        public string Categories { get; set; }

        public string Manufacturer { get; set; }

        public int Price { get; set; }

        public Covers Covers { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} гб, {2} месяца, Доступен: {3}, рейтинг: {4}, {5}, производитель: {6}, {7} рублей, Чехол: {8}", 
                Name, Volume, Guarantee, AvailabilityInStores, Rating, Categories, Manufacturer, Price, Covers);
        }
    }
}
