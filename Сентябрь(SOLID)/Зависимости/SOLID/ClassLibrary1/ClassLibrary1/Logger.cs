using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
        /// <summary>
        /// Ведение журнала - паттерн Одиночка
        /// </summary>
        public class Logger
        {
            private FileStream _fs;
            private StreamWriter _sw;

            private static Logger _instance;

            private Logger()
            {

                _fs = new FileStream("app.log", FileMode.Create, FileAccess.Write);
                _sw = new StreamWriter(_fs);
                _sw.WriteLine("Start Logger");
                _sw.WriteLine(DateTime.Now);

                AppDomain.CurrentDomain.ProcessExit += ProgramClosed;
            }

            private void ProgramClosed(object sender, EventArgs e)
            {
                Add("Program closed!");
            }

            public static Logger instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }

                    return _instance;
                }
            }

            public void Add(string message)
            {
                DateTime time = DateTime.Now;
                _sw.WriteLine("[{0}] {1}", time.ToLongTimeString(), message);
                _sw.Flush();
            }
        }
}

