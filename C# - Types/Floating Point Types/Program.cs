using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floating_Point_Types
{
    class Program
    {
        static void Main()
        {
            float meFloat = .7f;
            //meFloat += .0000001f; false
            //meFloat += .00000001f; return true
            Console.WriteLine(meFloat == .7f);
        }
    }
}
