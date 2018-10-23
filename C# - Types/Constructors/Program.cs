using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Farm
    {
        Cow cow1 = new Cow("Betsy");
        Cow cow2 = new Cow("Georgy");
        public Farm()
        {
            // The IL will translate this like:
            // cow1 = new Cow("Betsy"); Note: The Cow Value will be created and the constructor will make the instance of Cow();
            Console.WriteLine("Farm()");
        }
    }

    class Ivandro : Farm
    {
        Cow IvandrosCow = new Cow("Bessie"); // this is will run first
        public Ivandro()
        {
            Console.WriteLine("Ivandro's farm()");
        }
    }
    class Cow
    {
        public Cow(string name)
        {
            Console.WriteLine("Cow (" + name + ")");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Farm();
        }
    }
}
