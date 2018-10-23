using System;

namespace Why_Start_From_0
{
    class Program
    {
        static void Main(string[] args)
        {
            // note: the allow unsafe needs to be checked in Properties/Build/
            int[] myArray = new int[] { 5, 3, 5, 5, 6, 6 };
            unsafe
            {
                // this is pointer 
                fixed (int* p = myArray)
                {
                    Console.WriteLine(*(p + 1));
                }
            }
        }
    }
}
