using System;
using System.Runtime.InteropServices;

namespace @sizeof
{
    [StructLayout(LayoutKind.Auto)] // this will organize the TYPES in Memory
    struct MyStruct
    {
        [FieldOffsetAttribute(0)]
        public char mchar1;
        [FieldOffset(12)]
        public int meInt;
        [FieldOffset(2)]
        public char mcchar2;

    }

    class Program
    {
        static void Main(string[] args)
        {
            MyStruct mS = new MyStruct();
            mS.mchar1 = 'j';
            mS.meInt = 25;
            mS.mchar1 = 'k';
            unsafe
            {
                Console.WriteLine(sizeof(MyStruct));
            }
        }
    }
}

// NOTE: MORE IN: /Jamie King/Types/36 - C# sizeof