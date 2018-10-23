using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Using_Deleg
{
    public class TrainSignal
    {
        public event Action TrainsAComing;
        public void HereComesATrain()
        {
            // There is a ton of logic here
            TrainsAComing();
        }
    }

    class Car
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
    class Program
    {
        static void Main(string[] args)
        {
            var trainSignal = new TrainSignal(); //this object will allow the delegate to keep tracking the
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);
            new Car(trainSignal);

            // Invoking Delegate
            trainSignal.HereComesATrain(); // Supposed not to work
            trainSignal.HereComesATrain(); // Supposed not to work
            trainSignal.HereComesATrain(); // Supposed not to work
            trainSignal.TrainsAComing = null; // with event you are not allow to assign directly but (+=)
            trainSignal.HereComesATrain();
            Console.ReadLine();
        }
        // Note: There are to difference with Event:
        // 1 = "Direct Access" Visual Basic 2010 are not allowed |  Allowed with delegate
        // 2 = Assignement are not allowed |  Allowed with delegate
    }
}
