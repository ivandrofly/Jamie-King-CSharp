using System;

class Program
{
    static void Main()
    {
        MyClass.MeFirstAttempt();
    }
}

class MyClass
{
    [Obsolete("I found better algorithem for this method", false)]
    public static void MeFirstAttempt()
    {
        Console.WriteLine("Some awesome code");
    }
}