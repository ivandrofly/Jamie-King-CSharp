using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Defined_Types
{
    class Cow
    {
        int numSteaks; // 32bits
        int mooCount; // 32bits
        double pounds; // 64bits
        public void Moo()
        {
            "Moo".P();
            mooCount++;
        }
    }

    class MainClass
    {
        static void Main()
        {
            Cow bets = new Cow();
            Cow gerogy = new Cow();
            bets.Moo(); bets.Moo();

            gerogy.Moo(); gerogy.Moo();
            gerogy.Moo(); gerogy.Moo();
            gerogy.Moo(); gerogy.Moo();

        }
    }
}
