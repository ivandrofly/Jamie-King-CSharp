using System;

namespace Generic_Data_Structure
{
    class List<T>
    {
        T[] ints = new T[3];
        int currentIndex;

        public int Length { get { return ints.Length; } }

        public void Add(T i)
        {
            if (currentIndex == ints.Length)
                Grow();
            ints[currentIndex++] = i;
        }
        public T Get(int index)
        {
            return ints[index];
        }

        private void Grow()
        {
            T[] temp = new T[ints.Length * 2];
            Array.Copy(ints, temp, ints.Length);
            ints = temp;
        }
    }

    class Program
    {
        static void PrintItems<T>(List<T> items)
        {
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine(items.Get(i));
        }

        static void P<T>(T item)
        {
            Console.WriteLine(item);
        }

        static void Main()
        {
            P(4);
            P("Ivandro");

            // List<int>
            List<int> myInts = new List<int>();
            myInts.Add(12);
            myInts.Add(24);
            myInts.Add(99);
            myInts.Add(5);

            PrintItems<int>(myInts);

            // List<string>
            List<string> myStrings = new List<string>();
            myStrings.Add("ivandro");
            myStrings.Add("ismael");
            myStrings.Add("gomes");
            myStrings.Add("jao");
            PrintItems<string>(myStrings);
        }
    }
}
