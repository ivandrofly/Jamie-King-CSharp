using System;

namespace Closures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //int i = 0;
            //Action a = () => i++;
            //Console.WriteLine(i);

            //Action a = GiveMeAction();
            //a(); a(); a();

            //Action ba = () => Console.WriteLine("ivandro ismael");
            //ba.Invoke();

            Action b = GiveMeAction2();
            b();
            b();
            b();

            // Note: that the console.Writeline didn't take any params argument
            //Action<string> ismael_Ivandro = Console.WriteLine;
            //ismael_Ivandro.Invoke("Hello World!");
            Console.Read();
        }

        private static void Ismael()
        {
            Console.WriteLine("This is the  test :)");
        }

        private static Action GiveMeAction()
        {
            int i = 0;
            return () => i++; // this is called closure
        }

        private static Action GiveMeAction2()
        {
            Action ret = null;
            int i = 0;
            // this is what closure is!
            ret += () => // this is what will get called once the b is called
            {
                Console.WriteLine("First Method" + i++);
            };

            ret += () =>
            {
                Console.WriteLine("Second Method" + i++);
            };
            return ret;
        }
    }
}