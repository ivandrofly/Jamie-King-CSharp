using System;

namespace Struct_Caveats
{
    class Program
    {
        struct Cow
        {
            int numSteaks;
            float onceOfMilk;
            float onceOfMilk1;
            float onceOfMilk2;
            float onceOfMilk3;
            float onceOfMilk4;
            string[] array;
            public Cow(int numSteaks)
                : this() // this will automatically initialize all the float value above
            {
                //this = new Cow(); // same as the : this()
                // NOTE: structors constructor always take parameter which will initilize unnitilized members
                this.numSteaks = numSteaks;
            }
        }

        static void Main()
        {
#if false
            int i = 5;
            Console.WriteLine(i.GetType().BaseType); // this will return if the value is ref or value types
            Console.WriteLine(i.GetType().BaseType.BaseType); // the return types of this will be the Object type
            Console.WriteLine(i.GetType().BaseType.BaseType.BaseType); // this will return null;
            try
            {
                Console.WriteLine(i.GetType().BaseType.BaseType.BaseType.BaseType); // the will return null expepriont;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); } 
#endif
            // Note: Class are automatically iherited from System.Object
            // structs are inherited from System.Valuetype which inheried from System.Object
            Cow c = new Cow(10);
            Console.WriteLine(c.GetType());
            Console.WriteLine(c.GetType().BaseType);
            Console.WriteLine(c.GetType().BaseType.BaseType);
        }
    }
}
