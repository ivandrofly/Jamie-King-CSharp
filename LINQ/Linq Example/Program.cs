using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[] { 2, 3, 4, 0, 10, 38, 20 };
            var result = from n in numbers
                         where n > 4
                         select n;
            foreach (var item in result)
            { Console.WriteLine(item); }

            char[] chars = new char[] { 'a', 'b', 'h', 'p', 'z', 'y', 'u' };

            var vowels = from n in chars
                         where n == 'a' || n == 'e' || n == 'i' || n == 'u'
                         select n;
            foreach (var v in vowels)
            { Console.WriteLine("Vowels: {0}", v); }
        }
    }
}
