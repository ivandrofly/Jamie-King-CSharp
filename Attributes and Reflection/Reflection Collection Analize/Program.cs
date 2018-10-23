using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
namespace Reflection_Collection_Analize
{
    class Program
    {
        static void Main()
        {
            new List<int> { 1, 3, 2, 3 };
            Assembly mscorlib = Assembly.Load("mscorlib");
            //var types = mscorlib.GetTypes().Where(t => t.Namespace == null ? false : t.Namespace.Contains("System.Collection")).Select(t => t.Name);


            var types = mscorlib.GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(it => it.IsGenericType ? it.GetGenericTypeDefinition().Equals(typeof(System.Collections.IEnumerable<>)) : false)).Count();

            //mscorlib.GetTypes()
            //.Where(t => t.GetInterfaces()
            //.Any(it => it.IsGenericType ? it.GetGenericTypeDefinition().Equals(typeof(System.Collections.ICollection)) : false))
            //.Count().P();

            foreach (var item in types)
            {
                Console.WriteLine(item);
            }
        }
    }
}
