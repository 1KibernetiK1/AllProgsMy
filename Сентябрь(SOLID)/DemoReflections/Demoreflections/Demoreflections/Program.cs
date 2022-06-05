using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Demoreflections
{
    class Program
    {
        static void Inspector(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("Название типа = {0}", t.Name);
            Console.WriteLine("Откуда тип = {0}", t.Namespace);
            Console.WriteLine("----Список свойств----");
            PropertyInfo[] props =  t.GetProperties();
            foreach (var p in props)
            {
                Console.WriteLine("{0} {1}", p.PropertyType.Name, p.Name);
            }

            Console.WriteLine("----Список методов----");
            MethodInfo[] methods= t.GetMethods();

            foreach (var m in methods)
            {
                string strReturn =  m.ReturnParameter.ParameterType.Name;
                ParameterInfo[] pars = m.GetParameters();
                string strParams = "";

                foreach (var p in pars)
                {
                    strParams += p.ParameterType.Name + ", ";
                }

                if (strParams.Length>2)
                {
                    strParams = strParams.Remove(strParams.Length - 2, 2);
                }             
                Console.WriteLine("{2} .{0}({1});",m.Name, strParams, strReturn);
            }

            Console.WriteLine();
        }

        static void executeViaReflection(object subject, string methodName)
        {
            Type t = subject.GetType();
            try
            {
                t.InvokeMember(methodName, BindingFlags.InvokeMethod, null, subject, null);
                Console.WriteLine("invoke succes");
            }
            catch (Exception EX)
            {
                Console.WriteLine("invoke {0} failed, reason = {1}", methodName, EX.InnerException.Message);
            }
           
            
        }

        static void Main(string[] args)
        {
            int a = 125;
            string message = "Hello";
            FileInfo fi = new FileInfo("D:\\1.txt");
            Inspector(a);
            Inspector(message);
            Inspector(fi);

            executeViaReflection(fi, "Encrypt");

            Console.ReadLine();
        }
    }
}
