using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Events___Forms
{
    class Program
    {
        static Button but1 = new Button { Text = "Button1" };
        static Random rand = new Random();
        static void Main(string[] args)
        {

            but1.MouseMove += but1_MouseMove;
            var but2 = new Button { Text = "Button2" };
            //but.Click += (s, e) => MessageBox.Show("Test"); // Will work
            but2.Click += TheButtonWasClicked;
            but1.Click += TheButtonWasClicked;
            var form = new Form();
            MouseEventHandler
            form.Controls.Add(but1);
            but2.Top = 100;
            form.Controls.Add(but2);
            Application.Run(form);
        }

        static void but1_MouseMove(object sender, MouseEventArgs e)
        {
            // this will show the condinates of mouse
            MessageBox.Show("You moved your mouse: " + e.Location);
            but1.Top += rand.Next() % 200;
            but1.Left += rand.Next() % 200;
        }
        public static void TheButtonWasClicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("You just clicked the " + b.Text);
        }
    }
}
