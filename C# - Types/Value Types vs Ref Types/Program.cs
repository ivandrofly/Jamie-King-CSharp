using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Types_vs_Ref_Types
{
    struct Fraction
    {
        public int numerator;
        public int denominator;
    }

    class FractionC
    {
        public int numerator;
        public int denominator;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Value Types
            {
                // Example:
                // int a = 239;
                // int b = a;
                // Note: that if be change a will be changes

                Fraction fract1 =
                    new Fraction
                       {
                           denominator = 1,
                           numerator = 2
                       };
                Fraction fract2 = fract1;
                fract2.denominator = 555;

                Console.WriteLine(fract1.denominator);
            }

            // Reference Types
            {
                FractionC fract1 =
                   new FractionC
                   {
                       denominator = 1,
                       numerator = 2
                   };
                FractionC fract2 = fract1;
                fract2.denominator = 555;

                Console.WriteLine(fract1.denominator);
            }
        }
    }
}
