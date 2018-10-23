using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Join
{
    class Program
    {

        // Not finished... Missing database! :)
        class Customer
        {
            public string CustomerID { get; set; }
            public string ContactName { get; set; }
            public string CompanyName { get; set; }
            public string Country { get; set; }
        }

        class Order
        {
            public string CustomerID { get; set; }
            public string OrderID { get; set; }
            public DateTime OrderDate { get; set; }
            public string ShipCountry { get; set; }
        }

        static void Main(string[] args)
        {

        }
    }
}
