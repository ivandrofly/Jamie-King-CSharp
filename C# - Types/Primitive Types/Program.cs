using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // we can use the debug write to write in debut windows below

namespace Primitive_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: The explaination is on the videos
            //int i = 5;
            //long l = i;

            byte meByte = 129;
            sbyte smeByte = (sbyte)meByte;
            Console.WriteLine(meByte);
            Console.WriteLine(smeByte);
            Console.ReadLine();

            byte b = 0; // system.byte
            sbyte sb = 0; // system.sbyte

            short s = 0; // system.byte
            ushort us = 0; // system.byte

            int i = 0; // system.int32
            uint ui = 0; // system.uint32

            long l = 0; // system.int64
            ulong ul = 0; // system.uint64

            float f = 0; // system.single
            double d = 0; // system.double

            char c = '\0'; // system.char
            bool bl = false; // system.boolean
            string st = ""; // system.string
            decimal dc = 0; // system.decimal
        }
    }
}
