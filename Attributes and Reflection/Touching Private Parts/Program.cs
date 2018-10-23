using System;
using System.Reflection;

namespace Touching_Private_Parts
{

    class Cow
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private int NumHeartBeats { set; get; }
        public void Beat() { NumHeartBeats++; }
        private void Bigest() { Console.WriteLine("grind grind..."); }

    }
    class Program
    {
        static void Main()
        {
            Cow betsy = new Cow() { Name = "Betsy", Age = 5 };
            betsy.Beat();
            betsy.Beat();
            betsy.Beat();
            betsy.Beat();
            PropertyInfo propInfo = typeof(Cow).GetProperty("NumHeartBeats",
                BindingFlags.NonPublic | BindingFlags.Instance);
            int numBeats = (int)propInfo.GetValue(betsy, null);
            System.Diagnostics.Debugger.Break();
        }
    }
}
