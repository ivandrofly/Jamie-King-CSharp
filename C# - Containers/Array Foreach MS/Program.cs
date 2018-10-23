using System;

public class SamplesArray
{
    public static void Main()
    {
        // create a three element array of integers 
        int[] intArray = new[] { 2, 3, 4 };

        // set a delegate for the ShowSquares method
        Action<int> action = new Action<int>(ShowSquares);
        Action<int> action1 = ShowSquares; // this is the same as the one above

        Array.ForEach<int>(intArray, action);
    }

    private static void ShowSquares(int val)
    {
        Console.WriteLine("{0:D} squared = {1:d}", val, val * val);
    }
}

/*
This code produces the following output:

2 squared = 4
3 squared = 9
4 squared = 16
*/
// CODE DOWNLOADED IN: http://msdn.microsoft.com/en-us/library/zecdkyw2(v=vs.110).aspx