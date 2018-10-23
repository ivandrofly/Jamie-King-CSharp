using System;
using System.Windows.Forms;

namespace Unsubscribe_From_Events
{
    internal class Person
    {
        private Button myButton;

        public Person(Button but)
        {
            myButton = but;
            but.Click += cliffDive;
        }

        public void cliffDive(object sender, EventArgs e)
        {
            Console.WriteLine("Jumping!");
            myButton.Click -= cliffDive; // Unsubscribe from event
        }
    }

    internal class MainClass
    {
        private static void Main(string[] args)
        {
            var but2 = new Button
            {
                Text = "Close",
                Name = "buttonClose",
                Top = 100,
                Left = 100
            };
            but2.Click += but2_Click;

            var but = new Button { Text = "Ivandro", Top = 100 };
            new Person(but);
            var form = new Form();
            form.Controls.Add(but);
            form.Controls.Add(but2);
            Application.Run(form);
        }

        private static void but2_Click(object sender, EventArgs e)
        {
            int a;
            int b;
            int.TryParse("2", out a);
            int.TryParse("3", out b);
            Application.Exit();
        }
    }
}