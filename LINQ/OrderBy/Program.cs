using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBy
{
    public class DataBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public string Country { get; set; }

        // This will print user customer full info;
        public void PrintInfo()
        {
            Console.WriteLine("First Name: {0}, Last-Name: {1}, Age: {2}, Sex: {3}, Country: {4}",
                FirstName, LastName, Age, Sex, Country);
        }
    }

    class Program
    {
        private static List<DataBase> ListDataBase = new List<DataBase>
        {
            new DataBase{FirstName = "Shena", LastName = "Anwar", Age = 20, Sex = 'F', Country  = "UK"},
            new DataBase{FirstName = "Sergio", LastName = "Olea", Age = 23, Sex = 'M', Country  = "USA"},
            new DataBase{FirstName = "Moses", LastName = "Aguayo", Age = 32, Sex = 'F', Country  = "USA"},
            new DataBase{FirstName = "Francesco", LastName = "Albro", Age = 56, Sex = 'M', Country  = "PT"},
            new DataBase{FirstName = "Dorthy", LastName = "Carmichael", Age = 1, Sex = 'M', Country  = "GB"},
            new DataBase{FirstName = "Clementine", LastName = "Placek", Age = 14, Sex = 'F', Country  = "AG"},
            new DataBase{FirstName = "Judi", LastName = "Craine", Age = 15, Sex = 'F', Country  = "USA"},
            new DataBase{FirstName = "Patience", LastName = "Sia", Age = 18, Sex = 'M', Country  = "SA"},
            new DataBase{FirstName = "Wilbert", LastName = "Wiedman", Age = 29, Sex = 'M', Country  = "SP"},
            new DataBase{FirstName = "Else", LastName = "Harring", Age = 60, Sex = 'F', Country  = "UK"},
        };

        static void Main(string[] args)
        {
            var result =
                from c in ListDataBase
                orderby c.Country ascending, c.FirstName // Comma will work just like ThenBy(c => c.Country) | Note: orderby is ascending by default
                select c;

            var result2 =
                ListDataBase.OrderByDescending(c => c.Country)
                .ThenBy(c => c.FirstName);

            var result3 =
                ListDataBase.OrderByDescending(c => c.Country)
                .OrderBy(c => c.FirstName);

            Console.WriteLine("List or Customers ordered by: First-Names:");
            Console.WriteLine();

            foreach (var r in result)
                Console.WriteLine("First-Name: {0}, Country: {1}", r.FirstName, r.Country);
        }
    }
}
