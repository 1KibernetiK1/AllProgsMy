using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectThreadVariableStatic
{
    class Program
    {
        static void Change(object obj)
        {
            int n = (int)obj;
            Console.Write("n={0} ", n);

            Console.WriteLine("Before change: shared {0} loc {1}",
                Data.sharedVar, Data.localVar);
            Data.sharedVar = n;
            Data.localVar = n;
            Console.WriteLine("After change: shared {0} loc {1}",
                Data.sharedVar, Data.localVar);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var th1 = new Thread(Change);
            var th2 = new Thread(Change);
            Data.localVar = 1; Data.sharedVar = 1;
            th1.Start(2); th2.Start(3);

            th1.Join(); th2.Join();

            Console.ReadLine();
            Console.WriteLine("Main");
            Console.WriteLine("Vars: shared {0} loc {1}",
                Data.sharedVar, Data.localVar);
            Console.ReadLine();
        }
    }

    class Data
    {
        // глобальная для всех
        public static int sharedVar;

        // локальная для каждого
        [ThreadStatic]
        public static int localVar;
    }
}
