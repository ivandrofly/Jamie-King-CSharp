using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deferred_Execution___Assembly_Line
{
    static class Program
    {
        // this has fun execution :)
        static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> gaunlet)
        {
            foreach (T item in items)
                if (gaunlet(item))
                    yield return item;
        }

        static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform)
        {
            Console.WriteLine("Select");
            foreach (T item in items)
                yield return transform(item);
        }

        static void Main(string[] args)
        {
            int[] stuff = { 4, 13, 8, 1, 9 };
            IEnumerable<string> result = stuff
                .Where(i => i < 10)
                .Where(i => 4 < i).Select(i => i * 3)
                .Where(i => i % 2 == 0).Select(i => i + "Ivandro");
            IEnumerator<string> rator = result.GetEnumerator();
            while (rator.MoveNext())
            {
                Console.WriteLine(rator.Current);
            }
            Console.ReadLine();
        }
    }
}
