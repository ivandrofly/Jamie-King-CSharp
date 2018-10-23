using System;
using System.Threading;

namespace Locking_Doesn_t_Necessarily_Lock
{
    internal class BathRoomStall
    {
        public void BeUse(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Being used by: " + num);
                Thread.Sleep(500);
            }
        }
    }

    internal class Program
    {
        private static BathRoomStall stall = new BathRoomStall();
        private static void Main()
        {
            for (int i = 0; i < 3; i++)
                new Thread(RegularUsers).Start();
            new Thread(TheWeirdGuy).Start();
        }

        private static void RegularUsers()
        {
            lock (stall)
                stall.BeUse(Thread.CurrentThread.ManagedThreadId);
        }

        private static void TheWeirdGuy()
        {
            //lock (stall)
            stall.BeUse(99);
        }
    }
}