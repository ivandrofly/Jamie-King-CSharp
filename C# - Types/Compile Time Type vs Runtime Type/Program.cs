using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compile_Time_Type_vs_Runtime_Type
{
    abstract class Animal
    {
        protected string Name;
        protected int Age;
        protected string AnimalName;

        public abstract string GetInfo(); // this has to  be override in derived class
    }
    class Dog : Animal
    {
        public Dog()
        {
            Name = "Toffy";
            Age = 5;
            AnimalName = "Dog";
        }
        public override string GetInfo()
        {
            return string.Format("Name: {0}, Years-Old: {1}, Animal-Name: {2}", Name, Age, AnimalName);
        }
    }
    class Cat : Animal
    {
        public Cat()
        {
            Name = "Nialla";
            Age = 2;
            AnimalName = "Cat";
        }
        public override string GetInfo()
        {
            return string.Format("Name: {0}, Years-Old: {1}, Animal-Name: {2}", Name, Age, AnimalName);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            // BY: IVANDRO ISMAEL
            {
                Animal polyCat = new Cat();
                Dog dog = new Dog();
                Cat cat = new Cat();
                // These method will print out the animal info
                Console.WriteLine(cat.GetInfo());
                Console.WriteLine(dog.GetInfo());
            }

            // BY: JAMIE KING
            // Note: if you put the variable in the scope {} they will be accessible only from the inside.
            {
                var randy = new Random();
                bool randomBool = randy.Next() % 2 == 0;
                Animal animal = randomBool ? (Animal)new Cat() : (Animal)new Dog();
                Dog dog = (Dog)animal;
                while (true);
            }
        }
    }
}
