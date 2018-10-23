using System;

namespace Multidimensional_vs_Jagged
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //int[] ages = new[] { 2, 3, 1, 24, 23, 4, 3, 4, 34 };
            // Take a look in jagged diagram
            // JAGGED ARRAY
            int[][] partiesJagged = new int[3][]; // the 3 array is referencing to other arrays
            partiesJagged[0] = new int[] { 25, 27, 23, 34, 36, 99 };
            partiesJagged[1] = new int[] { 25, 27, 23, 34, 36, 99, 102, 283 };
            partiesJagged[2] = new int[] { 25, 27, 23, 34, 36, 99 };

            // # Jagged Array
            Console.WriteLine("Jagged Array");
            for (int i = 0; i < partiesJagged.Length; i++)
            {
                for (int j = 0; j < partiesJagged[i].Length; j++)
                    Console.WriteLine(partiesJagged[i][j] + " ");
                Console.WriteLine();
            }

            // MULTIDIMENSIONAL
            int[,] partiesMultidimensional = new int[3, 6] // this get length(0) == > 3; length(1) => 6;
            {
                { 25, 27, 23, 34, 36, 99 },
                { 25, 27, 23, 34, 36, 99 },
                { 25, 27, 23, 34, 36, 99 }
            };

            // # MultiDimensional Array
            Console.WriteLine("MultiDimensional Array");
            // GetLength(0) => 3 above in declaration
            // [3, 6] = .GetLength(0) == 3 and .GetLength(1) == 6
            for (int i = 0; i < partiesMultidimensional.GetLength(0); i++) // note if .Length it will be the size of element inside the are which is 18
            {
                // GetLength(1) => 6 above in declaration
                for (int j = 0; j < partiesMultidimensional.GetLength(1); j++)
                    Console.WriteLine(partiesMultidimensional[i, j] + " ");
                Console.WriteLine();
            }

            /// Reading with for ==============
            foreach (int[] thisRow in partiesJagged)
            {
                foreach (var i in thisRow)
                    Console.WriteLine(i + " ");
                Console.WriteLine();
            }
            // Reaing with foreach in multidimentional "isn't possbile"
        }
    }
}

//NOTE: partiesMultidimensional.GetLength(1) which is 6 in [3,6]