using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_the_Inheritace_Hierarchy
{
    class MeBase { }
    class MeMind : MeBase { }
    class MeDerived : MeMind { }
    class MeMoreDerived : MeDerived { }
    class MeMegaDerived : MeMoreDerived { }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MeMegaDerived);
            while (type != null)
            {
                Console.WriteLine(type.Name);
                type = type.BaseType;
            }
        }
    }
}
