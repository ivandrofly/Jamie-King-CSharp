using System;

class Program
{
    static void Main()
    {
        // Allocate a jagged array and put three subarrays into it.
        int[][] array = new int[3][];
        array[0] = new int[2];
        array[1] = new int[3];
        array[2] = new int[4];
        // Use the foreach method to modify each subarray's first element.
        // ... Because the closure variable is an array reference, you can change it.
        Array.ForEach(array, subarray => subarray[0]++);
        foreach (int[] subarray in array)
        {
            foreach (int i in subarray)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        // Apply the same routine with foreach again.
        Array.ForEach(array, subarray => subarray[0]++);
        foreach (int[] subarray in array)
        {
            foreach (int i in subarray)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}

//Output

//10
//100
//1000
//20
//200
//2000