
namespace Casts_vs_Type_Conversions
{
    class Base
    {
        public int baseInt;
    }
    class Derived : Base
    {
        public float derivedFloat;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            Base b = d;
            //d = (Derived)b;
            int i = 5;
            float f = i;
            i = (int)f;
        }
    }
}
