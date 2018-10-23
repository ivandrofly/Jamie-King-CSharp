using System;

namespace Generic_Data_Structure
{
    class List<T>
    {
        T[] _tArray = new T[3];
        int currentIndex;

        public int Length { get { return _tArray.Length; } }

        public void Add(T i)
        {
            if (currentIndex == _tArray.Length)
                Grow();
            _tArray[currentIndex++] = i;
        }
        public T Get(int index)
        {
            return _tArray[index];
        }

        private void Grow()
        {
            T[] temp = new T[_tArray.Length * 2];
            Array.Copy(_tArray, temp, _tArray.Length);
            _tArray = temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // List<int>
            List<int> myInts = new List<int>();
            myInts.Add(12); myInts.Add(24); myInts.Add(99); myInts.Add(5);

            for (int i = 0; i < myInts.Length; i++)
                Console.WriteLine(myInts.Get(i));

            // List<string>
            List<string> myStrings = new List<string>();
            myStrings.Add("ivandro"); myStrings.Add("ismael"); myStrings.Add("gomes"); myStrings.Add("jao");

            for (int i = 0; i < myStrings.Length; i++)
                Console.WriteLine(myStrings.Get(i));
        }
    }
}
