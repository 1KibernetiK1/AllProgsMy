using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldService
{
    /* Сервис - Бизнес логика в чистом ВИДЕ!!!
     * */
    public class HelloWorldService
        : IHelloWorldService
    {
        public string GetMessage()
        {
            return "Hello world!";
        }

        public string GetTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}
