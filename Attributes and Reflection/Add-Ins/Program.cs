using System;
using System.Reflection;
using System.Linq;

// Note: to run this opens the local directory
class MainClass
{
    static void Main()
    {
        Assembly player1Assembly = Assembly.Load("MyChessAlgorithm");
        Assembly player2Aseembly = Assembly.LoadFile(@"C:\Users\Ivandrofly\Documents\Visual Studio 2013\Projects\C# - Tutorials\C# - Jamie King\Attributes and Reflection\Add-Ins\YourChessAlgorithm.dll");
        IChessGame player1 = CreatePlayerAlgorithmInstance(player1Assembly);
        IChessGame player2 = CreatePlayerAlgorithmInstance(player2Aseembly);
        System.Diagnostics.Debugger.Break();
        ChessMove myMove = player1.MakeMove(null);
        ChessMove yourMove = player2.MakeMove(null);
        Console.WriteLine(myMove.StartColumn);
        Console.WriteLine(yourMove.StartColumn);
    }

    private static IChessGame CreatePlayerAlgorithmInstance(Assembly player1)
    {
        Type p1Algorithm = player1.GetTypes().Single(x => x.GetInterfaces().Any(i => i.Equals(typeof(IChessGame))));
        return Activator.CreateInstance(p1Algorithm) as IChessGame;
    }
}