using System;
using System.Diagnostics;

[DebuggerDisplayAttribute("{Name}, Amount of meat: {Weight}")]
class Cow
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        var cow = new Cow { Name = "Betsy", Age = 20, Weight = 200 };
        Console.WriteLine(cow);
    }
}
