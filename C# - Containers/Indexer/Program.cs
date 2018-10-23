using System;
using System.Collections;
using System.Collections.Generic;

namespace IndexerExample
{
    class MeList<T> : IEnumerable<T>
    {
        T[] items = new T[3];
        int count;
        public void Add(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, items.Length * 2);
        }

        public int Count { get { return items.Length; } }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        // index are not limited  could've been [int index, string name]
        public T this[int index]
        {
            get
            {
                CheckBoundaries(index);
                return items[index];
            }
            set
            {
                CheckBoundaries(index);
                items[index] = value;
            }
        }
        void CheckBoundaries(int index)
        {
            if (index >= count || index < 0)
                throw new IndexOutOfRangeException();
        }
    }

    class Program
    {
        static void Main()
        {
            MeList<int> thisList = new MeList<int>() { 23, 34, 3, 43 };
            Console.WriteLine(thisList[0]);
            thisList.Add(10);
        }
    }
}