using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some_Good_Uses
{
    class ClassOne
    {

    }

    class Program
    {
        static void Take<T>(T arg)
            where T : IComparable
            where T : IEnumerable
        {

        }

        // can't be used in this method below
        //static void TakeA(IComparable IEnumerabla arg)
        //{

        //}
        static void Main(string[] args)
        {
            TakeA(5); // thie won't work cause '5' isn't type of IComparable and IEnumerable
        }
    }
}
