using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield_Statement_Intro
{
    class Program
    {
        static Random rand = new Random();
        static IEnumerable<int> GetRandomNumbers(int count)
        {
            for (int i = 0; i < count; i++)
                yield return rand.Next();
        }

        static IEnumerable<int> GetRandomNumbers2(int count)
        {
            List<int> ints = new List<int>(count);
            for (int i = 0; i < count; i++)
                ints.Add(rand.Next());
            return ints;
        }

        static void Main(string[] args)
        {
            foreach (int num in GetRandomNumbers(10))
            {
                Console.WriteLine(num); // note: the return type has* to be IEnumerable in order to use yield keyword :)
            }
        }
    }
}
