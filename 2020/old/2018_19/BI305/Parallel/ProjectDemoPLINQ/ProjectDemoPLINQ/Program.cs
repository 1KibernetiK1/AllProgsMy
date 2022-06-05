using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemoPLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var sites = new string[]
            {
                "www.yandex.ru",
                "www.google.com",
                "www.microsoft.com",
                "www.amazon.com",
                "www.ozon2.ru",
                "www.apple.com"
            };
            // 1)-й вариант последовательный
            var sequenceRequest =
            sites.Select(site =>
            {
                var p = new Ping().Send(site);
                return new
                {
                    Site = site,
                    Result = p.Status,
                    Time = p.RoundtripTime
                };
            });

            Console.WriteLine("Нажмите Enter для пинга:");
            var sw = new Stopwatch();

            Console.ReadLine();
            sw.Start();
            var res1 = sequenceRequest.ToArray();
            sw.Stop();
            Console.WriteLine("потратили время ={0}",
                              sw.ElapsedMilliseconds);
            foreach (var r in res1)
            {
                Console.WriteLine($"Site={r.Site}; " +
                                  $"Res={r.Result}; " +
                                  $"Ping={r.Time}");
            }

            Console.WriteLine("\r\nНажмите Enter для повтороного пинга:");
            sw.Reset();
            // 2)-й вариант параллельный
            var parallelRequest =
            sites
            .AsParallel()
            .WithDegreeOfParallelism(sites.Count())
            .Select(site =>
            {
                var p = new Ping().Send(site);
                return new
                {
                    Site = site,
                    Result = p.Status,
                    Time = p.RoundtripTime
                };
            });

            Console.ReadLine();
            sw.Start();
            var res2 = parallelRequest.ToArray();
            sw.Stop();
            Console.WriteLine("потратили время ={0}",
                              sw.ElapsedMilliseconds);
            foreach (var r in res2)
            {
                Console.WriteLine($"Site={r.Site}; " +
                                  $"Res={r.Result}; " +
                                  $"Ping={r.Time}");
            }
            Console.ReadLine();
        }
    }
}
