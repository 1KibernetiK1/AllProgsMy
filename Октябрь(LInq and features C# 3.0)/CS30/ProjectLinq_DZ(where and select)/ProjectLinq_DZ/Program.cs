using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLinq_DZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DZ");
            var harddrive = HardDriveStorage.GetHardDrives();

            Console.WriteLine("Фильтр:");
            Console.WriteLine("\r\nС рейтингом 5");
            var ratingFive = harddrive.Where(h => h.Rating == 5).ToList();
            ratingFive.ForEach(h => Console.WriteLine(h));

            Console.WriteLine("\r\nС рейтингом 3");
            var ratingThree = harddrive.Where(h => h.Rating == 3).ToList();
            ratingThree.ForEach(h => Console.WriteLine(h));

            Console.WriteLine("\r\nпо гарантии");
            var guarantee = harddrive.Where(h => h.Guarantee == 24).ToList();
            guarantee.ForEach(Console.WriteLine);

            Console.WriteLine("\r\nс Чехлами и с ценой");
            var covers = harddrive.Where(h => h.Covers == Covers.IsAvailable && h.Price >=3000 && h.Price <=4000).ToList();
            covers.ForEach(Console.WriteLine);

            Console.WriteLine("\r\nПроекция:");
            Console.WriteLine("фильтрация по наличию в магазине и проекция по имени");
            List<string> nameOfAvailabilityInStores = harddrive.Where(h => h.AvailabilityInStores).Select(h => h.Name).ToList();
            Console.WriteLine(string.Join(", ", nameOfAvailabilityInStores));

            Console.WriteLine("\r\nфильтрация по цене и проекция по имени и вместимости");
            var nameAndVolumeofPrice = harddrive.Where(h => h.Price <= 4000).Select(h => new { nameOfharddrive = h.Name, harddriveVolume = h.Volume })/*.SelectMany(h => h.nameOfharddrive)*/.ToList();
            nameAndVolumeofPrice.ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
