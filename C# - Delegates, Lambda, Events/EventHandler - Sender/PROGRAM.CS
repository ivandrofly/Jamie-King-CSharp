namespace Add_Remove_Events
{
    using System;
    class Cow
    {
        public string Name { get; set; }
        public event EventHandler Moo;
        public void BeTippedOver()
        {
            if (Moo != null)
                Moo(this, EventArgs.Empty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Cow { Name = "Betsy" };
            c1.Moo += giggle;

            var c2 = new Cow { Name = "Georgy" };
            c2.Moo += giggle;

            Cow victim = new Random().Next() % 2 == 0 ? c1 : c2;
            victim.BeTippedOver();
        }

        static void giggle(object sender, EventArgs e)
        {
            Cow c = sender as Cow; // this will work 'cause the Moon is cause the eventhandler(sender)
            Console.WriteLine("Giggle giggle.... We made " + c.Name + ", moo...");
        }
    }
}
