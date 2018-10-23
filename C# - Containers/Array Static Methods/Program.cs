using System;
using System.Linq;

namespace Array_Static_Methods
{
    internal class Program
    {
        private static void Main()
        {
            var ints = new int[] { 23, 4, 2, 423, 42, 3 };
            //Array.Sort(ints); // remember that Arrays are ref-types
            var sorted = ints.OrderBy(i => i);

            foreach (int i in sorted)
                Console.WriteLine(i);

            // NOTE: TESTING.
            //string names = "Ivandro";
            //bool a = names.Any(s => char.IsUpper(s));
        }
    }
}