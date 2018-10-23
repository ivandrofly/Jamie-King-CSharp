using System;

namespace Delegate_Contravariance
{
    class Base { }
    class Derived : Base { }

    delegate void DelegateTakeBase(Base b); // Full Signature required to be BASE
    delegate void DelegateTakeDerived(Derived d);
    class Program
    {
        /// <summary>
        /// Take only derived clas
        /// </summary>
        /// <param name="d"></param>
        static void TakeDerived(Derived d)
        {
            Console.WriteLine("Take Derived Called");
        }

        /// <summary>
        /// Take base of anything inheriting from base class
        /// </summary>
        /// <param name="b">take base or derived</param>
        static void TakeBase(Base b)
        {
            Console.WriteLine("Take Base Called");
        }

        static void Main()
        {
            // Note: take DelegateTakeBase assignature and try to plug it in assigning method
            // in this case TakeDerived can't plug
            // PS: d1 is going to point to a method wil take base as parameter
            // DelegateTakeBase d1 = TakeDerived; // What will happen if you decide to paste new Base()?! :)
            // d1(new Derived());
            // d1(new Base());
            // DelegateTakeBase d2 = TakeBase;
            // d2.Invoke(new Derived()); 

            // #2 this can only take derive
            DelegateTakeDerived del1 = TakeDerived;
            // Since the Derive classe inherits from Base this is allowed, "ANY METHOD WHO CAN TAKE DERIVED IS ALLOWED HERE, SINCE THE DEFIRE INHERITS FROM BASE..."
            DelegateTakeDerived del2 = TakeBase; // This require a derived or a full-match class but not the base
            del1.Invoke(new Derived());
            del2.Invoke(new Derived());
            // del2.Invoke(new Base()) // not going to work because it will not know if method you've assinged to it takes base as parameters(line #38 supposed to work)
            del2(new Base() as Derived);
            // PS: Very usefule :D
            Console.ReadLine();
        }
    }
}
