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
        GravityBall launchedBall;
        int score = 0;
        int CountLaunchedBall = 5;

        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 600;
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

            /*
            for (int i = 0; i < 3; i++)
            {
                var b = new GravityBall(rnd.Next(50, 750), rnd.Next(50, 550));
                balls.Add(b);
                this.Controls.Add(b);
            }
            */

            /*launchedBall = new GravityBall(100, 500);
            balls.Add(launchedBall);
            this.Controls.Add(launchedBall);
            */

            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            bool isBilliardBall = false;

            foreach (Ball ball in balls)
            {
                ball.Move(this.ClientSize.Width, this.ClientSize.Height);
            }

            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i] is GravityBall)
                {
                    for (int j = balls.Count - 1; j>=0; j--)
                    {
                        if (balls[j] is BilliardBall && balls[i].Bounds.IntersectsWith(balls[j].Bounds))
                        {
                            this.Controls.Remove(balls[j]);
                            balls.RemoveAt(j);
                            score++;
                            break;
                        }
                    }
                }
            }

            foreach(var ball in balls)
            {
                if(ball is BilliardBall)
                {
                    isBilliardBall = true;
                    break;
                }
            }

            if(!isBilliardBall || CountLaunchedBall==0)
            {
                timer.Stop();
                EndForm endForm = new EndForm(score);
                endForm.Show();
                this.Hide();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           if (CountLaunchedBall > 0)
            {
                var b = new GravityBall(e.X, 500);
                balls.Add(b);
                this.Controls.Add(b);
                CountLaunchedBall--;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}
