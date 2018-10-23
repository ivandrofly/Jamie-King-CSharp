using System;

namespace Nullable_Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            int? i = 5;
            //int? j = i ?? 8;
            int j = i.HasValue ? i.GetValueOrDefault() : 8;
            Console.WriteLine(j);
        }
    }
}
