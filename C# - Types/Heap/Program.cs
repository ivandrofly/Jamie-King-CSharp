using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class CountingClass
    {
        static short counter = 0;
        short id;
        char c;

        public CountingClass()
        {
            id = counter;
            c = (char)(((short)'a') + counter);
            counter++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GC.Collect();
            var c1 = new CountingClass();
            var c2 = new CountingClass();
            var c3 = new CountingClass();
            var c4 = new CountingClass();
            var c5 = new CountingClass();
            GC.Collect();
        }
    }
}
