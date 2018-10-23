using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace this_Constructor
{
    class Cow
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Cow(string name)
        {
            if (name.Length > 10)
                throw new Exception();
            Name = name;
        }
        public Cow(string name, int age)
            : this(name)
            // : base(name); THIS IS THE WAY OF CALLING BASE CLASS CONSTRUCTOR
        {
            Console.WriteLine("Cow(name, age)");
            Age = age;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cow cow = new Cow("Betsy", 5);
            Console.WriteLine(cow.Name);
            Console.WriteLine(cow.Age);
        }
    }
}
