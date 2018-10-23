using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Value_Type_or_Reference
{
    class Program
    {
        // Value Type "Stack-LIFO"
        struct MeClassS
        {
            public int MeField;
        }
        
        // Reference Type "Heap"
        class MeClassC
        {
            public int MeField;
        }

        static void Main(string[] args)
        {
            // Struct
            int[] meInts = new int[] { 1, 3, 5, 6 };
            MeClassS[] meClasses = new MeClassS[3];
            meClasses[1].MeField = 5;
            Console.WriteLine(meClasses[1].MeField);

            // Classe
            int[] meInts1 = new int[] { 1, 3, 5, 6 };
            MeClassC[] meClasses1 = new MeClassC[3];
            meClasses1[1] = new MeClassC();
            meClasses1[1].MeField = 5;
            Console.WriteLine(meClasses[1].MeField);
        }
    }
}
