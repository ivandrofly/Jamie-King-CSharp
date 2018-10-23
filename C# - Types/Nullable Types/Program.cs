using System;

namespace Nullable_Types
{
    class Program
    {
        static int? GetBalanceFromTaxMan()
        {
            return null;
        }

        static void Main(string[] args)
        {
            //int? myReturn = GetBalanceFromTaxMan();
            //Console.WriteLine(myReturn);
            
            // #2:
            int? i = 5;
            Nullable<int> j = null;
            int? sum = i + j;

            // 20 - C# Nullable Operators
            INullable<int> n1 = new INullable<int>(5);
            INullable<int> n2 = new INullable<int>(); // this can take a value
            //INullable<int> nSum = n1 + n2;
            INullable<int> iSum =
                (n1.HasValue && n2.HasValue) ?
                new INullable<int>(n1.Value + n2.Value) : new INullable<int>(); // this is used to initialize the values
            Console.WriteLine(iSum);
        }

        // Note: the struct constructor are used to initialize the value with their default values
        // Struct can't have CONSTROCTOR with inside with takes no parameters
    }
    
    struct INullable<T> where T : struct // this is saying where the T is Struct
    {
        T value;
        bool hasValue;

        public bool HasValue { get { return hasValue; } }
        public T Value { get { return value; } }
        // TODO: When new Inullable<int>() is called it will set the default values for all the fields

        public INullable(T value)
        {
            this.value = value;
            hasValue = true;
        }

        public override string ToString()
        {
            //return base.ToString();
            return value.ToString();
        }
    }
}
