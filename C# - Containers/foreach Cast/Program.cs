using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreach_Cast
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
            List<Base> myPartyAges = new List<Base>() { new Derived(), new Base() };
            foreach (Derived age in myPartyAges)
            {
                // The foreach uses the (Darived)age
                Console.WriteLine(age);
            }

            Base b = new Base();

            Derived d = (Derived)b; // This will blow up (Note: this is the type cast with foreach does)
            Derived d1 = b as Derived; // this will return null is it fails
            Console.WriteLine(d1 == null); // this will return true
        }
    }
}
