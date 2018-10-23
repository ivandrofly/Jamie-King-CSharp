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
        private static List<DataBase> DB = new List<DataBase>
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
            var largestGroupsFirst =
                from g in
                    from c in DB
                    group c by c.Country
                let NumCustomers = g.Count()
                orderby NumCustomers descending
                select new { Country = g.Key, NumCustomers };

            var largestGroupsFirst2 =
                //from g in   
                //from c in ListDataBase
                //ListDataBase.GroupBy(c=>c.Country)
                    DB.GroupBy(c => c.Country)
                    .Select(g => new { g, NumCustomers = g.Count() })
                    .OrderByDescending(tp => tp.NumCustomers)
                    .Select(tp => new { County = tp.g.Key, tp.NumCustomers });

            var largestGroupsFirst3 =
                // With extension method
        Enumerable.Select(
            Enumerable.OrderByDescending(
                Enumerable.Select(
                    Enumerable.GroupBy(DB,
                    c => c.Country),
                    g => new { g, NumCustomers = g.Count() }),
                tp => tp.NumCustomers), tp => new { County = tp.g.Key, tp.NumCustomers });

            foreach (var result_ in largestGroupsFirst2)
                Console.WriteLine(result_);
            Console.ReadLine();
        }
    }
}
