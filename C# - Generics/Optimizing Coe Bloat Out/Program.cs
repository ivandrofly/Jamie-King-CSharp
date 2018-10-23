using System;

namespace Optimizing_Coe_Bloat_Out
{
    class MainClass
    {
        //static void DoSomething(int arg) { }
        //static void DoSomething(char arg) { }
        //static void DoSomething(bool arg) { }
        //static void DoSomething(MainClass arg) { }
        static void DoSomething<T>(T arg) { }
        static void Main(string[] args)
        {
            DoSomething(5);
            DoSomething('j');
            DoSomething(false);
            DoSomething(new MainClass());
            DoSomething("Hello Dolly");
            DoSomething(new object());
            Console.ReadLine();
        }
    }
}

//Note: Note show up desassemble press: CTRL+ALT+D (while executing)