using System;
using System.Linq;
using System.Reflection;

namespace Attributes_and_Reflection
{

    class TestAttribute : Attribute{}

    [TestAttribute]
    class MyTestSuite { }

    [TestAttribute]
    class YoutTestSuite { }

    class Program
    {
        static void Main( )
        {

            var testSuites =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
                select t;

            foreach (Type t in testSuites)
            {
                Console.WriteLine(t.Name + "is a test suite!");
            }
            Console.Read();
        }
    }
}
