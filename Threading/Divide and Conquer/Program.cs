using System;
using System.Diagnostics;
using System.Threading;

namespace Divide_and_Conquer
{
    class Program
    {
        static byte[] values = new byte[500000000];
        static long[] portionResults;
        static int portionSize;
        static void GenerateInts()
        {
            var rand = new Random(987);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (byte)rand.Next(10);
            }
        }

        // Ivandro
        static void SumYourPortion1(object portionNumber)
        {
            long sum = 0;
            int portionNumberAsInt = (int)portionNumber;
            int baseIndex = portionNumberAsInt * portionSize;
            for (int i = (portionNumberAsInt - 1) * portionSize; i < baseIndex; i++)
            {
                sum += values[i];
            }
            portionResults[portionNumberAsInt - 1] = sum;
        }

        // Jamie King
        static void SumYourPortion(object portionNumber)
        {
            long sum = 0;
            int portionNumberAsInt = (int)portionNumber;
            int baseIndex = portionNumberAsInt * portionSize; // 0 * 5 = 0; 0 < 0 + 5; #2: 1 * 5 = 5; 5 + 5 = 10;
            for (int i = baseIndex; i < baseIndex + portionSize; i++)
            {
                sum += values[i];
            }
            portionResults[portionNumberAsInt] = sum;
        }

        static void Main(string[] args)
        {
            portionResults = new long[Environment.ProcessorCount];
            portionSize = values.Length / Environment.ProcessorCount;
            GenerateInts();
            Console.WriteLine("Summing...");
            long total = 0;
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < values.Length; i++)
            {
                total += values[i];
            }
            watch.Stop();
            Console.WriteLine("#1 Total value is: " + total);
            Console.WriteLine("#1 Time to sum: " + watch.Elapsed);
            Console.WriteLine();
            watch.Reset();

            var threads = new Thread[Environment.ProcessorCount];
            long total2 = 0;
            watch.Start();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i] = new Thread(SumYourPortion);
                //threads[i].Start(i + 1); // Ivandro
                threads[i].Start(i); // Jamie
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i].Join();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                total2 += portionResults[i];
            }
            watch.Stop();
            Console.WriteLine("#2 Total value is: " + total2);
            Console.WriteLine("#2 Time to sum: " + watch.Elapsed);
            Console.ReadLine();
        }
    }
}
