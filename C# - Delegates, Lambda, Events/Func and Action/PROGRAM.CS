using System;
using System.Collections.Generic;

namespace Func_and_Action
{
    internal class Program
    {
        private delegate T myDelegate<T>();

        private static IEnumerable<T> GetAllReturnValues<T>(Func<T> d)
        {
            foreach (Func<T> del in d.GetInvocationList())
                yield return del();
        }

        //
        private static IEnumerable<T> GetAllReturnValues<T>(myDelegate<T> d)
        {
            foreach (myDelegate<T> del in d.GetInvocationList())
                yield return del();
        }

        private static void Main()
        {
            WithDelegates(); //Call the Delegate
            WithFuncTionAndAction(); // Call the Func And Action "ITs also a delegate"
        }

        private static int Return22()
        {
            return 22;
        }

        private static int ReturnFive()
        {
            return 5;
        }

        private static void ReturnNone()
        {
            Console.WriteLine("Action method");
        }

        private static int ReturnTen()
        {
            return 10;
        }

        private static bool TakeIntAndReturnBool(int i)
        {
            return i.Equals(2);
        }

        private static void TakeStringReturnNone(string s)
        {
            Console.WriteLine("Actoin b");
        }

        private static void WithDelegates()
        {
            myDelegate<int> d = ReturnFive;
            d += ReturnTen; // return int
            d += Return22;
            d += ReturnFive;

            foreach (int i in GetAllReturnValues(d)) // return IEnumerable<int>
                Console.WriteLine(i);
        }

        private static void WithFuncTionAndAction()
        {
            Func<int> d = ReturnFive;
            d += ReturnTen;
            d += Return22;
            d += ReturnFive;
            Func<int, bool> f = TakeIntAndReturnBool; // Example With Function

            Action a = Main; // main return none
            Action<string> b = TakeStringReturnNone; // his method require params
            Action b1 = ReturnNone;

            foreach (int i in GetAllReturnValues(d))
                Console.WriteLine(i);
        }
    }
}