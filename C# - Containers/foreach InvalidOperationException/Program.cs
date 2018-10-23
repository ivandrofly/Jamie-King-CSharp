using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreach_InvalidOperationException
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> thisList = new List<int>() { 2, 35, 6, 6, };

            IEnumerator<int> rator = thisList.GetEnumerator();

#if true
            while (rator.MoveNext())
            {
                Console.WriteLine(rator.Current);
                // this will thrown because list is ref type thisList.GetEnumerator will return a ref to rator
                thisList.RemoveAt(0);
                Console.WriteLine(rator.Current);
                // this will blow up cause once the list is modified the version are incremented
            }
#endif
            //foreach (int item in thisList)
            //{
            //    thisList.RemoveAt(0);
            //    // this will blow up cause once the list is modified the version are incremented
            //}
        }
    }
}
