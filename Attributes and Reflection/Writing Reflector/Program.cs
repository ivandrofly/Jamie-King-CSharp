using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Writing_Reflector
{
    class Person
    {
        public Person()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int meField;

        public void AnnounceThyself()
        {
            Console.WriteLine("Boooooooooahh");
        }
        public event Action GotSomeAction;
    }
    class Program
    {
        static void Main()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);
            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine("\t" + type.Name);
                Console.WriteLine("\r\rFields");
                foreach (FieldInfo field in type.GetFields())
                {
                    Console.WriteLine("\t\t\t" + field.FieldType + " " + field.Name);
                }

                Console.WriteLine("\t\tProperty");
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    Console.WriteLine("\t\t\t" + prop.PropertyType + " " + prop.Name);
                }

                Console.WriteLine("\t\tMethods");
                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine("\t\t\t" + method.ReturnType + " " + method.Name + "()");
                }

                Console.WriteLine("\t\tEvents");
                Console.WriteLine("\tEvents");
                foreach (EventInfo eventInfo in type.GetEvents())
                {
                    Console.WriteLine("\t\t" + eventInfo.EventHandlerType + " " + eventInfo.Name);
                    Console.WriteLine("\t\t\tAdd method: " + eventInfo.GetAddMethod().Name);
                    Console.WriteLine("\t\t\tRemove method: " + eventInfo.GetRemoveMethod().Name);
                }
            }
        }
    }
}
