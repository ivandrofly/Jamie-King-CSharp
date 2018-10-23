using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Constructors_and_Exceptions
{
    class Cow
    {
        static Cow()
        {
            Console.WriteLine("static Cow()");
            throw new Exception();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Cow();
            }
            catch { }
            new Cow(); // Note since the exception is throw in try{} this will return the same error
        }
    }
}
