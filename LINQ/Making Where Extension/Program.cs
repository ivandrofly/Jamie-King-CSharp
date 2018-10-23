using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Where_Extension
{
    static class Program
    {
        // Note: Predicate is a Func which's return type is a bool
        // read more here: http://stackoverflow.com/questions/4317479/func-vs-action-vs-predicate
        public static IEnumerable<int> Where(this int[] ints, Predicate<int> gauntlet)
        {
            Console.WriteLine("My Where");
            foreach (int i in ints)
                if (gauntlet(i))
                    yield return i;
        }

        static void Main(string[] args)
        {
            int[] numbers = new[] { 2, 4, 9, 4, 2, 6, 10, 20 };
            var result =
                from n in numbers
                where n < 5
                select n;

            //Implicity 'Where'
            var result2 = numbers.Where(n => n < 5)
                .Select(n => n);

            var result3 = Enumerable.Select(
                Enumerable.Where(numbers, n => n < 5), n => n);

            // this won't show our where methods cause its implement explicity 
            //foreach (int worthyInt in result3)
            //    Console.WriteLine(worthyInt);

            foreach (int worthyInt in result2)
                Console.WriteLine(worthyInt);
        }
    }
}
