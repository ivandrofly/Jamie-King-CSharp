using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Example_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[] { 2, 4, 9, 4, 2, 6, 10, 20 };
            var result =
                from n in numbers
                where n < 5
                select n;
            foreach (var item in result)
                Console.WriteLine(item);

            Console.WriteLine("==================================");
            var result2 = numbers.Where(n => n < 5).Select(n => n);
            foreach (var item in result2)
                Console.WriteLine("Result #2: " + item);

            Console.WriteLine("===================================");

            var result3 = Enumerable.Select(Enumerable.Where(numbers, n => n < 5), n => n);

            foreach (var item in result3)
                Console.WriteLine(item);
        }
    }
}
