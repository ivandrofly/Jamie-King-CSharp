using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Type_Inference
{
    class MyClass<T>
    {
        public MyClass(T arg)
        {

        }
    }
    class Program
    {
        static void P<T>(T item) { Console.WriteLine(item); }

        static void Main(string[] args)
        {

            MyClass<int> m = new MyClass<int>(5); // here you have to de explicit
            P(5);
            P("Ivandro Isamael");
        }
    }
}
