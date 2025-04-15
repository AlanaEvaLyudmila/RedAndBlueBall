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
            this.DoubleBuffered = true;
            Random rnd = new Random ();

            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(50, 750);
                int y = rnd.Next(50, 550);
                balls.Add(new Ball (x, y));
            }

            for (int i = 0; i < 5; i++)
            {
                int x = rnd.Next(50, 750);
                int y = rnd.Next(50, 550);
                balls.Add(new BilliardBall(x, y));
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
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (Ball ball in balls)
                ball.Draw(e.Graphics);
        }
    }
}
