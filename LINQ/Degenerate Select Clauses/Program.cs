using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degenerate_Select_Clauses
{
    static class Program
    {
        public static IEnumerable<int> Where(this int[] ints, Func<int, int> transformation)
        {
            Console.WriteLine("My Where");
            foreach (int i in ints)
                yield return transformation(i);
        }

        static void Main(string[] args)
        {
            int[] numbers = new[] { 2, 4, 9, 4, 2, 6, 10, 20 };
            var result =
                from n in numbers
                where n < 5
                select n;

            var result2 = numbers.Where(n => n < 5);

            //foreach (int worthyInt in result)
            //    Console.WriteLine(worthyInt);

            foreach (int worthyInt in result2)
                Console.WriteLine(worthyInt);
        }
    }
}
