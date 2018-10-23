using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_Consumer_Thread_Sync_Issues
{
    internal class Program
    {
        private static Queue<int> numbers = new Queue<int>();
        private static Random rand = new Random(987);
        private const int NumThreads = 3;
        private static int[] sums = new int[NumThreads];

        private static void ProducerNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                int numToEnqueue = rand.Next(10);
                Console.WriteLine("Producing thread adding " + numToEnqueue + " to the queue.");
                numbers.Enqueue(numToEnqueue);
                Thread.Sleep(rand.Next(1000));
            }
        }

        private static void SumNumbers(object threadNumber)
        {
            DateTime startTime = DateTime.Now;
            int mySum = 0;
            while ((DateTime.Now - startTime).Seconds < 11)
            {
                int numToSum = -1;
                lock (numbers)
                {
                    if (numbers.Count != 0)
                    {
                        numToSum = numbers.Dequeue();
                        //Console.WriteLine("Thread #" + threadNumber + " - having an issues!");
                    }
                }
                if (numToSum != -1)
                {
                    mySum += numToSum;
                    Console.WriteLine("Consuming thread #"
                        + numToSum + " adding"
                        + numToSum + " to its total sum making "
                        + numToSum + " for the thread total.");
                }
            }
            sums[(int)threadNumber] = mySum;
        }

        private static void Main(string[] args)
        {
            var producingThread = new Thread(ProducerNumbers);
            producingThread.Start();
            Thread[] threads = new Thread[NumThreads];
            for (int i = 0; i < NumThreads; i++)
            {
                threads[i] = new Thread(SumNumbers);
                threads[i].Start(i);
            }
            for (int i = 0; i < NumThreads; i++)
                threads[i].Join();
            int totalSum = 0;
            for (int i = 0; i < NumThreads; i++)
                totalSum += sums[i];
            Console.WriteLine("Done adding. total is " + totalSum);
        }
    }
}