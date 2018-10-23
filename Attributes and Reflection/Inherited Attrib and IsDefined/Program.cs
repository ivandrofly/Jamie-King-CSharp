using System;

namespace Attribute_Usage
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true)]
    class MeAttribute : Attribute
    {
        public MeAttribute()
        {
            Console.WriteLine("MeAttributes()");
        }
    }

    [Me]
    class Base { }
    class Derived : Base { }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(typeof(Derived).GetCustomAttributes(true));
            //Console.WriteLine(typeof(Derived).IsDefined(typeof(MeAttribute), true).ToString());
            //Console.WriteLine(typeof(Derived).BaseType);
        }
    }
}
