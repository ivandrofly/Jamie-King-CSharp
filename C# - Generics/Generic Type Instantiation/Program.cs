using System;

namespace Generic_Type_Instantiation
{
    class MyClass<T>
    {
        // Since this is static field we can access it without createing instance of it
        public static int _value;
        static MyClass()
        {
            Console.WriteLine(typeof(MyClass<T>));
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            // Note: everyone will create its own object
            // To figureout how this will work run it with F11
            MyClass<string>._value = 10;
            MyClass<char>._value = 20;
            MyClass<MainClass>._value = 53;

            Console.WriteLine(MyClass<string>._value);
            Console.WriteLine(MyClass<char>._value);
            Console.WriteLine(MyClass<MainClass>._value);
        }
    }
}
