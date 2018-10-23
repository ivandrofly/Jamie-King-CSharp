using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Let_Clauses_Even_Deeper_Transparent_ID
{
    // Formula found here => http://www.purplemath.com/modules/quadform.htm
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new[]
            {
                new {a = 2, b = 2, c = 3},
                new {a = 2, b = 9, c = 4},
                new {a = 7, b = 3, c = 6},
            };

            var result =
                from coef in inputs
                let negB = -coef.b
                let discriminant = coef.b * coef.b - 4 * coef.a * coef.c // 2 * 2 which is = 4 then 4 - (4 * 2 * 3 )= 16+8
                let TwoA = 2 * coef.a
                select new
                {
                    FirstRoot = (negB + discriminant) / TwoA, // first run (-2 + -8) / 2 = -5 (negative)
                    SecondRoot = (negB - discriminant) / TwoA // first run (-2 - -8) /2 = 3 (possitive)
                };
        //http://www.quickmath.com/webMathematica3/quickmath/algebra/simplify/basic.jsp#c=simplify_stepssimplify&v1=2+*+2+-+4+*+1+*+3
            foreach (var r in result)
            {
                Console.WriteLine("Firstroot : {0}", r.FirstRoot);
                Console.WriteLine("SecondRoot : {0}", r.SecondRoot);
            }

            // Compile Method Translation
            var result2 =
                //from coef in inputs
                 inputs
                 .Select(coef => new { coef, negB = -coef.b })
                 .Select(tp1 => new { tp1, discriminant = tp1.coef.b * tp1.coef.b - 4 * tp1.coef.a * tp1.coef.c })
                 .Select(tp2 => new { tp2, twoA = 2 * tp2.tp1.coef.a })
                 .Select(tp3 => new
                 {
                     FirstRoot = (tp3.tp2.tp1.negB + tp3.tp2.discriminant) / tp3.twoA,
                     SecondRoot = (tp3.tp2.tp1.negB - tp3.tp2.discriminant) / tp3.twoA
                 });
        }
    }
}
