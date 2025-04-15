using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAndBlueBall
{
    class Ball
    {
        int x, y;
        int dx, dy;
        int radius = 20;
        public Color color = Color.Red;

        public Ball(int x,int y)
        {
            this.x = x;
            this.y = y;

            Random rnd = new Random();
            dx = rnd.Next(-5, 6);
            dy = rnd.Next(-5, 6);

        }

        public int GetX() { return x; }
        public int GetY() { return y; }
        public int GetDY() { return dy; }
        public int GetDX() { return dx; }
        public int GetRadius() { return radius; }

        public void SetDX(int newDx) { dx = newDx; }
        public void SetDY(int newDy) { dy = newDy; }



        public virtual void Move(int width,int  height)
        {
            x += dx;
            y += dy;
        }

        public virtual void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush,x-radius,y-radius,radius*2,radius*2);
        }
    }


    class BilliardBall : Ball
    { 
        public BilliardBall(int x,int y):base(x,y)
        {
            color = Color.Blue;
        }

        public override void Move(int width, int height)
        {
            base.Move(width, height);
            if (GetX() - GetRadius() < 0 || GetX() + GetRadius() > width)
                SetDX(-GetDX());
            if (GetY() - GetRadius() < 0 || GetY() + GetRadius() > width)
                SetDY(-GetDY());
        }
    }

}
