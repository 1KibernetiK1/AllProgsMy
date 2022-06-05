using ConsoleClientProductService.ProductServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientProductService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Клиент для сервиса");
            Console.WriteLine("Нажмите любую кнопку для подключения");
            Console.ReadKey();
            // 1) подключаемся к сервису
            ProductServiceClient service = null;
            try
            {
                Console.WriteLine();
                service = new ProductServiceClient();
                Console.WriteLine("Успешно подключились");
            }
            catch(Exception ex)
            {
                Console.WriteLine("ИСКЛЮЧЕНИЕ:");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("загружаем список категорий");
            string[] cats = service.GetCategories();
            Console.WriteLine("Список категорий товаров:");
            foreach (var s in cats)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine("нажмите любую кнопку загрузим инфо про КРЕПЁЖ");
            Console.ReadKey();
            Console.WriteLine("загрузка списка");
            ProductWrapper[] products =
                service
                .ProductsByCategory("Пиломатериал");
            Console.WriteLine("По крепежу:");
            foreach (var p in products)
            {
                Console.WriteLine("{0}, {1}: {2}", 
                                    p.Name,
                                    p.Price,
                                    p.Description);
            }
            Console.ReadLine();
        }
    }
}
