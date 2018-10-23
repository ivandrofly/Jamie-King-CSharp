namespace Delegates_Covariance
{
    class Base { }
    class Derived : Base { }
    class Derived2 : Base { }

    delegate Base ReturnBaseDelegate();
    delegate Derived ReturnDerivedDelegate();

    class Program
    {
        // Method
        static Base ReturnsBase() { return new Derived(); }
        static Derived ReturnsDerived() { return new Derived(); }

        static void Main()
        {
            ReturnBaseDelegate a;

            a = ReturnsBase;
            a = ReturnsDerived; // Covariance

            //a += ReturnsBase;
            //a += ReturnsDerived;
            a.Invoke();

            // This can't work 'cause Derived is inheriting from base
            ReturnDerivedDelegate b;
            b = ReturnsBase; // Can't assign Base to a derived
            b = ReturnsDerived;
        }
    }
}
