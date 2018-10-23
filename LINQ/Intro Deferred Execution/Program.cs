using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_Deferred_Execution
{
    static class Program
    {
        static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> gaunlet)
        {
            // this methods will only run when the move next is called
            Console.WriteLine("Where");
            foreach (T item in items)
                if (gaunlet(item))
                    yield return item;
        }

        static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform)
        {
            // this methods will only run when the move next is called
            Console.WriteLine("Select");
            foreach (T item in items)
                yield return transform(item);
        }

        static void Main(string[] args)
        {
            // this methods will only run when the move next is called
            int[] stuff = { 4, 8, 1, 9 };

            // this will only indicate proccess the process will be executed when the var result is called
            var result1 =
                from i in stuff
                where i < 5
                select i + 6;

            { // this is called scope
                // Translation
                var result2 =
                    //from i in stuff
                    stuff.Where(x => x < 5)
                    .Select(i => i + 6);

                var result3 =
                    Select(Where(stuff, i => i < 5), i => i + 6); // this lambda expression o (i=> i+6) is Func<T, R> transform)

                IEnumerator<int> ratro2 = result2.GetEnumerator();
                while (ratro2.MoveNext())
                    Console.WriteLine(ratro2.Current);
            }

            IEnumerator<int> ratro = result1.GetEnumerator();
            while (ratro.MoveNext())
                Console.WriteLine(ratro.Current);
        }
    }
}
