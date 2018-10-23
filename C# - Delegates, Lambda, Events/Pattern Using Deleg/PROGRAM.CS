using System;

namespace Pattern_Using_Deleg
{
    public class TrainSignal
    {
        public Action TrainsAComing;

        public void HereComesATrain()
        {
            // There is a ton of logic here
            TrainsAComing();
        }
    }

    internal class Car
    {
        public Car(TrainSignal trainSignal)
        {
            trainSignal.TrainsAComing += StopTheCar;
        }

        private void StopTheCar()
        {
            Console.WriteLine("Screeetch");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var trainSignal = new TrainSignal(); //this object will allow the delegate to keep tracking the
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);

            // Invoking Delegate
            trainSignal.HereComesATrain(); // this will invoke the delegates | Return 5 Delegates
            trainSignal.HereComesATrain(); // this will invoke the delegates | Return 5 Delegates
            trainSignal.HereComesATrain(); // this will invoke the delegates | Return 5 Delegates
            trainSignal.TrainsAComing = null;
            trainSignal.HereComesATrain(); //fails
            Console.ReadLine();
        }
    }
}