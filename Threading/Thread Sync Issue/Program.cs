using System;
using System.Threading;

namespace Thread_Sync_Issue
{
    internal class Program
    {
        private static int count = 0;

        private static void IncrementCount()
        {
            while (true)
            {
                // this will unathomic increment the value
                int temp = count;
                Thread.Sleep(1000);
                count = count + 1;
                Console.WriteLine(
                    "Thread ID " + Thread.CurrentThread.ManagedThreadId +
                    " incremented count to " + count);
                Thread.Sleep(1000);
            }
        }

        private static void Main()
        {
            var thread1 = new Thread(IncrementCount);
            var thread2 = new Thread(IncrementCount);
            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();
        }
    }
}