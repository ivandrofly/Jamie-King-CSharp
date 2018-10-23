using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type_Conversion_Operators
{
    class Scooter
    {
        public int Mileage { get; set; }

        // Use implicit when there are no data lost in this case 
        // implicit would be okay cause Mileage value its been returned
        public static implicit operator Car(Scooter scoot)
        {
            return new Car { Mileage = scoot.Mileage }; 
        }

        // use this explicit when you are losing some data... 
        public static explicit operator Car(Scooter scoot)
        {
            return new Car { Mileage = scoot.Mileage };
        }
    }
    class Car
    {
        public int Mileage { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Scooter meScooter = new Scooter();
            Car meCar = meScooter;
            //Car meCar1 = (Car)meScooter;
        }
    }
}
