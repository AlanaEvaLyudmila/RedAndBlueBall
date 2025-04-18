using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAndBlueBall
{
    class Ball : PictureBox
    {
        protected int dx, dy;
        protected int radius = 20;

        public Ball(int x,int y)
        {
            this.Width = radius * 2;
            this.Height = radius * 2;

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile("images/red.png");

            this.Left = x - radius;
            this.Top = y - radius;

            Random rnd = new Random();
            dx = rnd.Next(-5, 6);
            dy = rnd.Next(-5, 6);

        }

        public new virtual void Move(int width,int  height)
        {
            this.Left += dx;
            this.Top += dy;
        }

    }


    class BilliardBall : Ball
    {
        public BilliardBall(int x, int y) : base(x, y)
        {
            this.Image = Image.FromFile("images/blue.png");
        }

        public override void Move(int width, int height)
        {
            base.Move(width, height);

            if (Left < 0 || Right > width)
                dx = -dx;

            if (Top < 0 || Bottom > height)
                dy = -dy;
        }
    }

    class GravityBall : Ball 
    {
        double gravity = 0.8;
        double startY = -20;
        bool fallBall = false;

        public GravityBall(int x, int y): base(x,y)
        {
            this.Image = Image.FromFile("images/green.png");
        }

        public override void Move(int width, int height)
        {

            if(!fallBall)
            {
                startY += gravity;
                dy = (int)startY;

                base.Move(width, height);

                if (Bottom >= height)
                {
                    Top = height - Height;
                    fallBall = true;
                    dy = 0;
                }
            }
        }
    }

}
