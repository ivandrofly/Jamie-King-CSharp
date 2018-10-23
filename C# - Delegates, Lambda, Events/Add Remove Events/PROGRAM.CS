using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Remove_Events
{
    class Cow
    {
        private Action mooning;

        public event Action Mooning
        {
            add
            {
                mooning += value;
                mooning += value;
                mooning += value;
                mooning += value;
                Console.WriteLine("Adding");
            }
            remove
            {
                mooning -= value;
                Console.WriteLine("Removing");
            }
        }
        public void PushSleepingCow()
        {
            if (mooning != null)
                mooning();
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            var c = new Cow();
            c.Mooning += () => Console.WriteLine("Giggle");
            c.PushSleepingCow(); // this will invoke(x4) method PushSleepingCow inside the class Cow
        }
    }
}
