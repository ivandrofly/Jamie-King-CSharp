using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerator_Example
{
    internal class MeList<T> : IEnumerable<T>
    {
        private int count;
        private T[] items = new T[3];

        public int Count { get { return items.Length; } }

        public void Add(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, items.Length * 2);
            items[count++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MeEnumerator : IEnumerator<T>
        {
            private int index = -1;
            private MeList<T> theList;

            public MeEnumerator(MeList<T> theList)
            {
                this.theList = theList;
            }

            public T Current
            {
                get
                {
                    Console.WriteLine("Returning the current");
                    if (index < 0 || theList.count < index)
                        return default(T);
                    return theList.items[index];
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                Console.WriteLine("I'm dispossing myself!");
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                return ++index < theList.Count;
            }

            public void Reset()
            {
                index = -1;
                //throw new NotSupportedException();
            }
        }
    }

    internal class Program
    {
        private static void Main()
        {
            // this is used in previsous tutorials // "LIST"
            MeList<int> meList = new MeList<int>();
            meList.Add(25);
            meList.Add(34);
            meList.Add(32);

            foreach (int i in meList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Now doing our version");
            IEnumerator<int> rator = meList.GetEnumerator();

            try
            {
                while (rator.MoveNext())
                {
                    //int i = rator.Current;
                    //Console.WriteLine(i);
                    //Console.WriteLine(i);
                    int i = rator.Current;
                    Console.WriteLine(i);
                }
            }
            finally
            {
                rator.Dispose();
            }
            Console.ReadLine();
        }
    }
}