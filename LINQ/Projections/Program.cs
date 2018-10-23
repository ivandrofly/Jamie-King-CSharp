using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this is not full completed this is just a example it may not work correctly!!! ( In official tutorial they used northwind(DB)
namespace Projections
{
    class Program
    {
        /// <summary>
        /// Name and SureName Properties
        /// </summary>
        class DB
        {
            public string Name { get; set; }
            public string SureName { get; set; }
        }

        static List<DB> dataBase = new List<DB> { new DB { Name = "Ivandro", SureName = "Ismael" }, new DB { Name = "BlackBerry", SureName = "Iphone" } };

        static void Main(string[] args)
        {
            #region WithAnonymousTypes
            var result =
                from c in dataBase
                select new { c.Name, c.SureName };

            var result2 =
                dataBase.Select(c => new { c.Name, c.SureName });

            var result3 = dataBase.Select(c => new { c.Name, c.SureName });
            #endregion

            var result4 = Enumerable.Select<DB, jacko>(dataBase, fi); // this fi is the pointing function
            foreach (var jackObject in result4)
            {
                Console.WriteLine(jackObject.CompanyName);
                Console.WriteLine(jackObject.ContactName);
            }
        }

        /// <summary>
        /// This function will take the DB object and return it jacko object with all the values initilized
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static jacko fi(DB c)
        {
            return new jacko(c.Name, c.SureName); // this will return the objet of jacko with ContactName and CompanyName Initialized
        }

        class jacko
        {
            public string ContactName { get; private set; }
            public string CompanyName { get; private set; }

            public jacko(string contactName, string companyName)
            {
                ContactName = contactName;
                CompanyName = companyName;
            }
        }


    }
}
