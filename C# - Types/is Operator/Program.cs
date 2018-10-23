using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_Operator
{
    class Base
    {

    }
    class Derived : Base
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Base b = new Derived(); // this is called polymorphyim

            var rand = new Random();
            bool randomBool = rand.Next() % 2 == 0;
            Base b = randomBool ? new Base() : new Derived();
            Derived d = null;
            
            if (b is Derived)
                d = (Derived)b;

            if (b is Base)
                Console.WriteLine("Oh, well that failed...");
            else
                Console.WriteLine("WE GOT A OBJECT!");
        }
    }
}
