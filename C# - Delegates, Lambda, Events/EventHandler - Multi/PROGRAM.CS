using System;
using System.Collections.Generic;

namespace EventHandler___Multi
{
    class Cow
    {
        // 4 bytes for each
        //public event EventHandler beginMoo;
        //public event EventHandler BeginMoo
        //{
        //    add { beginMoo += value; }
        //    remove { beginMoo -= value; }
        //}

        private Dictionary<string, EventHandler> subscribers = new Dictionary<string, EventHandler>();
        const string BeginMookey = "Begin moo";

        public event EventHandler BeginMoo
        {
            add
            {
                addSubscriber(BeginMookey, value);
            }
            remove
            {
                if (!subscribers.ContainsKey(BeginMookey))
                    return;
                subscribers[BeginMookey] -= value;
                if (subscribers[BeginMookey] == null)
                    subscribers.Remove(BeginMookey);
            }
        }

        void addSubscriber(string key, EventHandler subscriber)
        {
            if (subscribers.ContainsKey(BeginMookey))
                subscribers[BeginMookey] += subscriber;
        }

        public event EventHandler Moo;
        public event EventHandler EndMoo;
        public event EventHandler BeginWalking;
        public event EventHandler Walk;
        public event EventHandler EndWalking;
        public event EventHandler BeginSleep;
        public event EventHandler Sleeping;
        public event EventHandler EndSleeping;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cowObj = new Cow();
             // Not Finished
        }

        //private static return EventHandler Ismael()
        //{
        //    return new EventHandler(Ismael);
        //}
        //static void Ismael()
        //{
        //    Console.WriteLine("This is the test");
        //}
    }
}