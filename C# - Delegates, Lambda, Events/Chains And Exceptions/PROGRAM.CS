using System;

namespace Chains_And_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Action del = new Action(Moo) + BeNaughty + Goo;
            Action del = (Action)Moo + BeNaughty + Goo;
            foreach (Action a in del.GetInvocationList())
            {
                try
                {
                    a();
                }
                catch { }
            }
        }

        static void Moo() { Console.WriteLine("Moo()"); }
        static void BeNaughty() { throw new Exception(); }
        static void Goo() { Console.WriteLine("Goo()"); }
    }
}
