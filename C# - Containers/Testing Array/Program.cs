using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            JaggedArray();
            MultiDim();
        }

        private static void MultiDim()
        {
            int[,] MultiDim = new int[3, 10]
            { 
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0,},
                { 10, 11, 12, 13, 14, 15, 16, 19 ,28, 20},
                {100, 200, 300, 102, 223, 2328, 239, 10, 26, 129} 
            };

            for (int i = 0; i < MultiDim.GetLength(0); i += 1)
            {
                Console.WriteLine("==== #{0} =====", i);
                Console.WriteLine();
                for (int j = 0; j < MultiDim.GetLength(1); j++)
                    Console.WriteLine(MultiDim[i, j]);
            }
            Console.ReadKey();
        }

        private static void JaggedArray()
        {
            // this will story the referrence of 3 arrays
            int[][] multiDim = new int[3][] 
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
                new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                new int[] { 100, 200, 300 }
            };
            //multiDim[0] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            //multiDim[1] = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            //multiDim[2] = new int[] { 100, 200, 300 };

            for (int i = 0; i < multiDim.Length; i++)
            {
                Console.WriteLine("==== #{0} =====", i);
                Console.WriteLine();
                for (int j = 0; j < multiDim[i].Length; j++)
                    Console.WriteLine(multiDim[i][j]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
