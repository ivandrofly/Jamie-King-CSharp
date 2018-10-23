using System;
using System.Diagnostics;

class Cow
{
    public string Name
    {
        [DebuggerStepThrough]
        get { return "Bessy"; }
    }
    public int Age { get { return 5; } }
}

class MainClass
{
    static void Main()
    {
        //var cow = new Cow();
        //EyeCowForButchering(cow.Name, cow.Age);
        FirstMethod();
    }

    static void EyeCowForButchering(string name, int age)
    {
        Console.WriteLine(name + " " + age);
    }

    static void FirstMethod()
    {
        // F11 will stip stepthrough
        SecondMethod();
    }

    [DebuggerStepThrough]
    static void SecondMethod()
    {
        Console.WriteLine("Second metod from the past.....");
        ThridMethod();
    }

    static void ThridMethod()
    {

    }
}
