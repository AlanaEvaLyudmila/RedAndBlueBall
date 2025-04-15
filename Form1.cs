using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAndBlueBall
{
    public partial class Form1 : Form
    {
        List <Ball> balls = new List <Ball> ();
        Timer timer = new Timer ();
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 600;
            Random rnd = new Random ();

            for (int i = 0; i < 5; i++)
            {
                var b = new Ball(rnd.Next(50, 750), rnd.Next(50, 550));
                balls.Add(b);
                this.Controls.Add(b); 
            }

            for (int i = 0; i < 5; i++)
            {
                var b = new BilliardBall(rnd.Next(50, 750), rnd.Next(50, 550));
                balls.Add(b);
                this.Controls.Add(b);
            }

            for (int i = 0; i < 3; i++)
            {
                var b = new GravityBall(rnd.Next(50, 750), rnd.Next(50, 550));
                balls.Add(b);
                this.Controls.Add(b);
            }

            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in balls)
            {
                ball.Move(this.ClientSize.Width, this.ClientSize.Height);
            }
        }

    }
}
