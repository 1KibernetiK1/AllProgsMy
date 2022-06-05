using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ProjectFileInfo
{
    class Program
    {
        static long DirectorySize(string path)
        {
            // 1) размер файлов  папке
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            long s = 0;
            for (int i = 0; i < files.Length; i++)
            {
                s += files[i].Length;
            }
            // 2) папки
            DirectoryInfo[] dirs = di.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                string folder = dirs[i].FullName;
                // рекурсивный вызов функции
                s += DirectorySize(folder);
            }
            return s;
        }


        static void Main(string[] args)
        {
            long s = DirectorySize("D:\\Visual Studio 2010");
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
