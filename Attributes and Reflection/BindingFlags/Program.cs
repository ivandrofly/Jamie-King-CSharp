using System;
using System.Collections.Generic;
using System.Reflection;
using BFF = System.Reflection.BindingFlags; // Name space nuance
namespace Binding_Flags
{
    class Cow
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private int NumHeartBeats { set; get; }
        public void Beat() { NumHeartBeats++; }
        private void Bigest() { Console.WriteLine("grind grind..."); }
        static void WhateverStaticMethod() { }
    }
    class Program
    {
        static void Main()
        {
            IEnumerable<MemberInfo> members =
                typeof(Cow).GetMembers(BFF.DeclaredOnly | BFF.Instance | BFF.Public | BFF.NonPublic | BFF.Static);
            IEnumerable<MemberInfo> members2 =
               typeof(Cow).GetMembers(BFF.Instance | BFF.Public | BFF.NonPublic | BFF.Static);

            //typeof(Cow).GetMembers().OrderByDescending(mi => mi.DeclaringType.Name);
            Console.WriteLine("Printing only the declared members in class");
            foreach (MemberInfo mInfo in members)
            {
                Console.WriteLine(mInfo);
            }
            Console.WriteLine("================================================");
            foreach (MemberInfo mInfo in members2)
            {
                Console.WriteLine(mInfo);
            }
            Console.ReadLine();
        }
    }
}
