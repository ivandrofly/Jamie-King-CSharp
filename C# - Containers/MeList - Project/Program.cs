using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MeList___Project
{
    //public static class MyClass
    //{
    //    public static int Count<T>(this IEnumerable<T> collection)
    //    {
    //        int ret = 0;
    //        foreach (T item in collection)
    //        {
    //            ret++;
    //        }
    //        return ret;
    //    }
    //}
    internal class MeList<T> : IEnumerable<T> // where T : struct
    {
        private T[] items;

        public MeList(int capacity = 5)
        {
            items = new T[capacity];
        }

        public int Capacity
        {
            get { return items.Length; }
        }

        public int Count { get; private set; }

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

        public void Add(T item)
        {
            EnsureCapacity();
            items[Count++] = item;
        }

        public void AddRange(IEnumerable<T> range)
        {
            //EnsureCapacity();
            this.InsertRange(this.Count, range);
        }

        public void Clear()
        {
            Count = 0;
            //if (typeof(T).BaseType.Equals(typeof(ValueType)))
            //    return;
            for (int i = 0; i < Count; i++)
            {
                items[i] = default(T);
            }
            Count = 0;
        }

        public MeList<U> ConvertAll<U>(Converter<T, U> convert)
        {
            MeList<U> ret = new MeList<U>(Count);
            for (int i = 0; i < Count; i++)
            {
                ret.items[i] = convert(items[i]);
            }
            ret.Count = Count;
            return ret;
        }

        public void Foreah(Action<T> action)
        {
            // 0.005120239 Elapsed Time
            //int i = 0;
            //while (i < this.Count)
            //{
            //    action(items[i]);
            //    i++;
            //}

            // 0.001839422
            //foreach (var item in items)
            //{
            //    action(item);
            //}

            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }

            // Elapsed time
            //while
            //0.005120239
            //0.0007787915
            //0.0007218636
            //
            //foreach
            //0.001839422
            //0.001009303
            //0.0008478515
            //0.0008693161
            //
            //fornum
            //0.0009561077
            //0.0009290436
            //0.0007213971
            //0.0007027322
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return items[i];
        }

        public MeList<T> GetRange(int index, int amount)
        {
            // this could have throw if exception out of range
            MeList<T> ret = new MeList<T>(amount); // this will be the amount of new list
            Array.Copy(items, index, ret.items, 0, amount);
            ret.Count = amount;
            return ret;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Insert(int index, T item)
        {
            //EnsureCapacity();
            Array.Copy(items, index, items, index + 1, Count - (index + 1));
            items[index] = item;
            Count++;
        }

        public void InsertRange(int index, IEnumerable<T> newItems)
        {
            T[] newItemAsArray = newItems.ToArray();
            //int newItemsCount = newItems.Count();
            // Take more time
            EnsureCapacity(Count + newItemAsArray.Length);

            #region MyRegion
            //if (Count + newItemAsArray.Length > Capacity)
            //{
            //    T[] newUnderlyingArray = new T[Count + newItemAsArray.Length];
            //    Array.Copy(items, newUnderlyingArray, index);
            //    Array.Copy(items, index, newUnderlyingArray,
            //        index + newItemAsArray.Length, Count - index);
            //    items = newUnderlyingArray;
            //}
            //else
            //{
            //    // Shuffle
            //    Array.Copy(items, index, items, index + newItemAsArray.Length, Count - index);
            //}
            #endregion MyRegion

            // copy current array from 'index' to 
            //Array.Copy(items, index, items, index + newItemAsArray.Length, Count - index);
            Array.Copy(items, index, items, Count, Count - index);
            Array.Copy(newItemAsArray, 0, items, index, newItemAsArray.Length);
            Count += newItemAsArray.Length;
        }

        public void RemoveAll(Predicate<T> match)
        {
            for (int i = 0; i < Count; i++)
            {
                if (match(items[i]))
                {
                    RemoveAt(i);
                    i--;
                }
            }
        }

        public void RemoveAt(int index)
        {
            // This could have boundChecking
            // 0,1,2,3,4,5
            Array.Copy(items, index + 1, items, index, Count - (index + 1));
            Count--;
        }

        public void RemoveRange(int startIdx, int count)
        {
            // count have don't some weird test here
            if (startIdx < Count || startIdx > Count)
                throw new ArgumentOutOfRangeException();
            while (startIdx <= count) // count >= 0
            {
                RemoveAt(startIdx);
                startIdx++;
                // count--
            }
        }

        public T[] ToArray()
        {
            T[] ret = new T[Count];
            Array.Copy(items, ret, Count);
            return ret;
        }

        public void TrimExcess()
        {
            T[] newArray = new T[Count];
            Array.Copy(items, newArray, Count);
            items = newArray;
        }

        public bool TrueForAll(Predicate<T> prediate)
        {
            for (int i = 0; i < Count; i++)
            {
                if (!prediate(items[i]))
                    return false;
            }
            return true;
        }

        private static bool IsMatch(int i)
        {
            return i > 65;
        }

        private void CheckBoundaries(int index)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();
        }

        private void EnsureCapacity()
        {
            EnsureCapacity(Count + 1);
        }

        private void EnsureCapacity(int neeedCapacity)
        {
            if (neeedCapacity > Capacity)
            {
                int targetSize = items.Length * 2;
                if (targetSize < neeedCapacity)
                    targetSize = neeedCapacity;
                Array.Resize(ref items, targetSize);
                Console.WriteLine("Resizing...");
            }
        }
    }

    internal class MainClass
    {
        private static void Main()
        {
            #region MyRegion

            //System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            //MeList<int> meList = new MeList<int>();

            //int[] aBunchOfItems = Enumerable.Range(0, 100000).ToArray();
            //meList.AddRange(aBunchOfItems);
            //Console.WriteLine("Inserting...");
            //SW.Start();
            //meList.InsertRange(5, aBunchOfItems);
            //SW.Stop();
            //Console.WriteLine(SW.ElapsedTicks / (float)System.Diagnostics.Stopwatch.Frequency);

            #endregion MyRegion

            // By Implementing IEnumerable it allow us the to (){23,34,2,34,23}
            // { 23, 43, 4, 2, 3, 2, 3 } will just be replaced wiith
            // myPartyAge.Add(23)
            /*
            MeList<int> myPartyAges = new MeList<int>() { 23, 43, 4, 2, 3, 2, 3 };
            var alist = myPartyAges.ConvertAll(x => x.ToString());
            return;
            // Diagnostics
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            myPartyAges.Foreah(Console.WriteLine);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks / (float)System.Diagnostics.Stopwatch.Frequency);*/

            //var t = new System.Timers.Timer();
            //t.Start();
            //var t1 = new System.Threading.Timer(new System.Threading.TimerCallback() )
            //Console.Out.WriteLine("ivandro");
            var newArray = new int[] { 100, 200, 300, 500, 600 };
            var meList = new MeList<int>(11) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0 };
            //meList.InsertRange(4, newArray);
            //meList.RemoveAt(9);
            meList.Insert(meList.Count - 2, 20);
        }
    }
}