using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace as_Operator
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
            
            //Derived d = (Derived)b; // if fails throw exception
            Derived d = b as Derived; // if fails return null
            if (d == null)
                Console.WriteLine("Oh, well that failed...");
            else
                Console.WriteLine("WE GOT A OBJECT!");
        }
    }
}
