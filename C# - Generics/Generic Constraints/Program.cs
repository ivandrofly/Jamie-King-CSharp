using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Constraints
{
    class ClassOne
    {
        public ClassOne() { }

        // these method will be accesible in ProduceA<T>()
        public void Foo() { }
        public void Bar() { }
    }

    class ClassTwo : ClassOne { public ClassTwo() { } }
    class ClassThree { public ClassThree() { } }

    class MainClass
    {
        // Note you can't use more then one class in here
        static T ProduceA<T>() where T : ClassOne, new() // this mean most be class one or inherits class one
        {
            T returnVal = new T();
            returnVal.Bar();
            return returnVal;
        }
        static void Main()
        {
            ProduceA<ClassOne>();
            ProduceA<ClassTwo>();
            //ProduceA<ClassThree>(); // this is not working cause there is nothing to do with classone
        }
    }
}
// Note: C# doesn't support multiple inherit type (C++)