using System;

namespace Anonymous_Vs_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> func = i => i > 5;
            Func<int, int, bool> func2 = (a, b) => a == b ? true : false;

            Console.WriteLine(func(3));
            Console.WriteLine(func.Invoke(7));

            // #2 
            Console.WriteLine(func2(20, 20));
            Console.WriteLine(func2(20, 21));
        }
    }
}
