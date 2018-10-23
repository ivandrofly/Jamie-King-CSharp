using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerator_
{
    class MeList<T>
    {
        T[] items = new T[5];
        int count;
        public void Add(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, items.Length * 2);
            items[count++] = item;
        }

        public int Count { get { return items.Length; } }
        public IEnumerable<T> GetEnumerator()
        {
            foreach (var value in items)
            {
                yield return value;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            // this is used in previsous tutorials // "LIST"
            List<int> list = new List<int>();
            list.Add(25);
            list.Add(23);
            list.Add(12);
            list.Add(2);
            list.Add(4);
            list.Add(6);
            list.Add(10);

            IEnumerator<int> rator = list.GetEnumerator();
            while (rator.MoveNext())
                Console.WriteLine(rator.Current);
        }
    }

}
