using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collection
{
    class IntWrapper
    {
        public int wrappedInt;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var wrapped1 = new IntWrapper();
            var wrapped2 = new IntWrapper();
            var wrapped3 = new IntWrapper();
            wrapped1.wrappedInt = 1;
            wrapped2.wrappedInt = 2;
            wrapped3.wrappedInt = 3;
            GC.Collect(); // Garbage Collector
            wrapped2 = null;
            GC.Collect();
            // TODO: TO SEE WHAT REALLY HAPPEEN USE THE MEMORY VIEW
            // MOre info in video 38 - C# Garbage Collection
        }
    }
}
