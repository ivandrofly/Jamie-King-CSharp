using System;

namespace _list
{
    internal class Program
    {
        private static void Main()
        {
            MeList<int> list = new MeList<int>();
            list.Add(25);
            list.Add(25);
            list.Add(25);
            list.Add(25);
            list.Add(25);
            list.Add(25);
            Console.WriteLine(list.Count.ToString());

            // OUT
            string thisname;
            testingouto(out thisname);
            Console.WriteLine(thisname);
        }

        private static void testingouto(out string name)
        {
            // this name must be assigned before 'exiting'
            name = "Ivandro Ismael";
        }
    }
}

internal class MeList<T>
{
    private int count;
    private T[] items = new T[5];

    public int Count { get { return items.Length; } }

    public void Add(T item)
    {
        if (count == items.Length)
            Array.Resize(ref items, items.Length * 2);
        items[count++] = item;
    }
}