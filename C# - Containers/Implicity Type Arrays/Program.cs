using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implicity_Type_Arrays
{
    class Program
    {
        class Base { }
        class Derived1 : Base { }
        class Derived2 : Base { }

        class Cow
        {
            public static implicit operator Derived1(Cow cow)
            {
                return null;
            }
        }

        static void Main(string[] args)
        {
            // Note: the base classe has to included other wise it will not work...
            var myArrayRef = new[] { new Derived1(), new Derived2(), new Base(), new Cow() };
            // This will return the type of array whici is Base(): 'cause all are implicitly inherited from Base class
            Console.WriteLine(myArrayRef.GetType());



            var myInstance = new { FirstName = "Ivandro Ismael", LastName = "Gomes Jao" };
            var yourInstance = new { FirstName = "Gomes Jao", LastName = "Ismael Ivandro" };
            var myInts = new[] { 1, 2, 3, 'a', 5 }; // this is a int arrays 'cause char are implicitly converted to ints

            // Compiler will figured out will type is the best to put after new[]
            var myArray = new[] { myInstance, yourInstance };

            int[] myints = new[] { 1, 2, 3, 4, 5 };
        }
    }
}
