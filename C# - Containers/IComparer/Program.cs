using System;
using System.Collections.Generic;

namespace IComparable
{
    internal class Cow : IComparable<Cow>
    {
        private static Random rand = new Random(100);

        public Cow(string name)
        {
            Name = name;
            Weight = rand.Next(500, 1000);
        }

        public string Name { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Cow other)
        {
            //-1 less
            // 0 = equal
            // 1 = greatter
            return Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return Name + ": " + Weight;
        }
    }

    internal class MyCowComparer : IComparer<Cow>
    {
        public int Compare(Cow left, Cow right)
        {
            //left.Weight.CompareTo(right.Weight);
            // 500 - 600
            // if retur nis negative 'right' if greatter than left
            return left.Weight - right.Weight;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Cow> meCows = new List<Cow>()
            {
                new Cow("betsy"), new Cow("Abby"),
                new Cow("Bacon"), new Cow("Georgy"),
                new Cow("Doug"), new Cow("Beef"),
            };

            // Now this will work cause Class Cow Implement IComparable which add CompareTo Method which
            // will alow os to add
            meCows.Sort(new MyCowComparer());
            meCows.ForEach(cow => Console.WriteLine(cow.Weight));
        }
    }
}