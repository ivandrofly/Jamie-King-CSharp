using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    struct CountingClass
    {
        static short counter = 0;
        short id;
        char c;

        public CountingClass(int hack)
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
            var c1 = new CountingClass(1);
            var c2 = new CountingClass(1);
            var c3 = new CountingClass(1);
            var c4 = new CountingClass(1);
            var c5 = new CountingClass(1);
            GC.Collect();
            // Note: Garbage collection as generation level l1, l2, l3, when a object is not being used there are moved to second generation l2; l3 is the last  generation
            // they are called when the object is about to be distroied
            //c3 = null; // this can't be done cause its like signing a reference to value-type
        }
    }
}
