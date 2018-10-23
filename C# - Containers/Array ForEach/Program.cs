using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_ForEach
{
    static class Program
    {
        // NOTE: THIS CLASSE HAS TO BE STATIC IN ORDER
        static void ForEach(this int[] ints, Action<int> action)
        {
            foreach (int i in ints)
                action(i);
        }

        static void Main(string[] args)
        {
            int[] ints = new int[] { 5, 23, 5, 52, };
            //goto _ismael;
            Array.ForEach(ints, Console.WriteLine); // Note: we can't use WriteLine(With paramt) 'cause this is called the extension method
            Array.ForEach(ints, (int i) => Console.Write(i));
            //_ismael:
            ints.ForEach(Console.WriteLine);
        }
    }
}
