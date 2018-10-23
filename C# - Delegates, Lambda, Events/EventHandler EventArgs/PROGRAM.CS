using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Remove_Events
{
    public enum CowState
    {
        Awake,
        Sleeping,
        Dead
    }
    class CowTipedEventArgs : EventArgs
    {
        public CowState CurrentCowState { get; private set; }
        public CowTipedEventArgs(CowState CurrentState)
        {
            CurrentCowState = CurrentState;
        }
    }
    class Cow
    {
        public string Name { get; set; }
        public event EventHandler<CowTipedEventArgs> Moo;
        public void BeTippedOver()
        {
            if (Moo != null)
                Moo(this, new CowTipedEventArgs(CowState.Awake)); // this is going to invoke the EventHandler with paramtre
        }
    }
    class Program
    {
        static void giggle(object sender, CowTipedEventArgs e)
        {
            Cow c = sender as Cow; // this will work 'cause the Moon is cause the eventhandler(sender)
            Console.WriteLine("Giggle giggle... We made " + c.Name + ", moo...");
            switch (e.CurrentCowState)
            {
                case CowState.Awake:
                    Console.WriteLine("Run!");
                    break;
                case CowState.Sleeping:
                    Console.WriteLine("Tickle it!");
                    break;
                case CowState.Dead:
                    Console.WriteLine("Bucher it!");
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            var c1 = new Cow { Name = "Betsy" };
            c1.Moo += giggle;
            var c2 = new Cow { Name = "Georgy" };
            c2.Moo += giggle;

            Cow victim = new Random().Next() % 2 == 0 ? c1 : c2;
            victim.BeTippedOver();
        }
    }
}
