using System;
using System.Collections.Generic;

namespace IComparable
{
    internal class Cow : IComparable<Cow>
    {
        private static Random rand = new Random(100);
        public bool IsDescending { get; set; }
        public Cow(string name)
        {
            Name = name;
            Weight = rand.Next(500, 1000);
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Cow other)
        {
            //-1 = less: this cow is less than the 'other' cow
            // 0 = equal: this cow is equal with 'other' cow
            // 1 = greater: his cow i > than the 'other' cow
            if(IsDescending)
            {
                var temp = this.Name;
                this.Name = other.Name;
                other.Name = temp;
            }
            return Name.CompareTo(other.Name);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var meCows = new List<Cow>()
            {
                new Cow("betsy"), new Cow("Abby"),
                new Cow("Bacon"), new Cow("Georgy"),
                new Cow("Doug"), new Cow("Beef"),
            };

            Console.WriteLine("===================== Ascending =====================");
            // Ascending sort
            //meCows.Sort(); // won't sort correctly
            /*
            meCows.Sort((x, y) => x.Name.CompareTo(y.Name)); // more readable than creating method 
            meCows.Sort((Cow x, Cow y) => x.Name.CompareTo(y.Name)); // more readable than creating method 
             */
            meCows.Sort(delegate(Cow x, Cow y) { return x.Name.CompareTo(y.Name); }); // more readable than creating method 
            meCows.ForEach(cow => Console.WriteLine(cow.Name));


            Console.WriteLine("===================== Descending =====================");
            // Descending sort
            /*
            meCows.Sort((x, y) => y.Name.CompareTo(x.Name)); // more readable than creating method 
            meCows.Sort((Cow x, Cow y) => y.Name.CompareTo(x.Name)); // more readable than creating method 
             */
            meCows.Sort(delegate(Cow x, Cow y) { return y.Name.CompareTo(x.Name); }); // more readable than creating method 
            meCows.ForEach(cow => Console.WriteLine(cow.Name));
            Console.ReadLine();


            Console.WriteLine("========================== Using the interface helper method compare to");
            meCows.Sort(); // ascending
        }
    }
}