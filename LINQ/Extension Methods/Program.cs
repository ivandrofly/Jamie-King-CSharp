using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods
{

    static class MyClass // Note that this class is static 
    {
        public static DateTime Combine3(this DateTime datePart, DateTime timePart)
        {
            return new DateTime(datePart.Year, datePart.Month, datePart.Day,
                timePart.Hour, timePart.Minute, timePart.Second, timePart.Second);
        }
    }

    static class Program
    {
        static DateTime Combine(this DateTime datePart, DateTime timePart)
        {

            return new DateTime(datePart.Year, datePart.Month, datePart.Day,
                timePart.Hour, timePart.Minute, timePart.Second);
        }

        static void Main(string[] args)
        {
            goto WhyThis;
            DateTime date = DateTime.Parse("1/5/1025");
            DateTime time = DateTime.Parse("1/5/0001 9:55pm");
            Console.WriteLine(time);

            Console.WriteLine("======================================");
            DateTime combined = Combine(date, time);
            DateTime combined2 = date.Combine(time); // extension methods (date = this DateTime datePart, .Combine(time) => Datime timepart)
            Console.WriteLine("Combined #1: {0}", combined);
            Console.WriteLine("Combined #2: {0}", combined2);

            // #2 With MyClass
            Console.WriteLine("======================================");
            DateTime combined3 = MyClass.Combine3(date, time); // this has to Provide full class name and the method
            DateTime combined4 = date.Combine3(time); // extension methods (date = this DateTime datePart, .Combine(time) => Datime timepart)
            Console.WriteLine("Combined #1: {0}", combined3);
            Console.WriteLine("Combined #2: {0}", combined4);

            // # Why this in extension methods
        WhyThis:
            Cow c = new Cow();
            Cow c2 = new Cow();
            c2.Moo(); // Extension method
            //Cow.Moo(c2); Cow.Moo(c2); Cow.Moo(c2);
            //Cow.Moo(c); Cow.Moo(c); Cow.Moo(c);
        }
    }

    public class Cow
    {
        public int numMoos;
    }
    static class CowMethods
    {
        public static void Moo(this Cow _this)
        {
            _this.numMoos++;
            Console.WriteLine("Mooo " + _this.numMoos);
        }
    }
}
