using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Constructors
{
    class Cow
    {
        public static int numInstances;
        static int whatever;
        int id;
        public Cow()
        {
            id = ++numInstances;
        }
        static Cow()
        {
            // Since you touch cow class this constructor will run (1x)
            numInstances = new Random().Next(20);
            whatever = numInstances + 5;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Goo();
        }
        static void Goo()
        {
            Cow.numInstances = 100;
            Cow betsy = new Cow();
            Cow georg = new Cow();
        }
    }
}
