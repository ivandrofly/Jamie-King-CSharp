
namespace Call_Stack
{
    struct CountingClass
    {
        static short counter = 0;
        short id;
        char c;

        public CountingClass(int hack)
        {
            id = counter;
            c = (char)(((short)'a') + counter);
            counter++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Recurse(3);
        }

        static void Recurse(int i)
        {
            var c1 = new CountingClass(1);
            if (i == 0)
                return;
            Recurse(i - 1);
            // after recursive all the date will be abandoned LIFO
        }
    }
}
