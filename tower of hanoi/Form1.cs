using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tower_of_hanoi
{
    public class Actor
    {
        public int X, Y;
        public int W, H;
        public Color clr, clrPen;
        public int lvl;
    }

    public partial class Form1 : Form
    {
        private int xTower = 200;
        private int yTower;
        private List<Actor> actors = new List<Actor>();
        private List<Actor> actors2 = new List<Actor>();
        private List<Actor> actors3 = new List<Actor>();
        private int xOld;
        private int yOld;
        private int xOldActor;
        private int yOldActor;
        private bool isDrag = false;
        private int flag;
        private int ctsh;
        private int col;
        private Bitmap off;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;

            this.MouseDown += Form1_MouseDown; ;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            if (e.X >= xTower && e.X <= xTower + 23 && e.Y >= yTower - 400)
            {
                if (col == 1)
                {
                    actors[ctsh].X = xOldActor;
                    actors[ctsh].Y = yOldActor;
                }
                if (col == 2)
                {
                    if (actors.Count == 0)
                    {
                        actors2[ctsh].X = (xTower) - (actors2[ctsh].W - 23) / 2; // Center the block on the tower
                        actors2[ctsh].Y = yTower - actors2[ctsh].H;
                        actors.Add(actors2[ctsh]);
                        actors2.RemoveAt(ctsh);
                    }
                    else if (actors2[ctsh].lvl > actors[actors.Count - 1].lvl)
                    {
                        actors2[ctsh].X = (xTower) - (actors2[ctsh].W - 23) / 2; // Center the block on the tower
                        actors2[ctsh].Y = actors[actors.Count - 1].Y - actors[actors.Count - 1].H;
                        actors.Add(actors2[ctsh]);
                        actors2.RemoveAt(ctsh);
                    }
                    else
                    {
                        actors2[ctsh].X = xOldActor;
                        actors2[ctsh].Y = yOldActor;
                    }
                }
                if (col == 3)
                {
                    if (actors.Count == 0)
                    {
                        actors3[ctsh].X = (xTower) - (actors3[ctsh].W - 23) / 2; // Center the block on the tower
                        actors3[ctsh].Y = yTower - actors3[ctsh].H;
                        actors.Add(actors3[ctsh]);
                        actors3.RemoveAt(ctsh);
                    }
                    else if (actors3[ctsh].lvl > actors[actors.Count - 1].lvl)
                    {
                        actors3[ctsh].X = (xTower) - (actors3[ctsh].W - 23) / 2; // Center the block on the tower
                        actors3[ctsh].Y = actors[actors.Count - 1].Y - actors[actors.Count - 1].H;
                        actors.Add(actors3[ctsh]);
                        actors3.RemoveAt(ctsh);
                    }
                    else
                    {
                        actors3[ctsh].X = xOldActor;
                        actors3[ctsh].Y = yOldActor;
                    }
                }
            }
            else if (e.X >= xTower + 400 && e.X <= xTower + 423 && e.Y >= yTower - 400)
            {
                if (col == 2)
                {
                    actors2[ctsh].X = xOldActor;
                    actors2[ctsh].Y = yOldActor;
                }
                if (col == 1)
                {
                    if (actors2.Count == 0)
                    {
                        actors[ctsh].X = (xTower + 400) - (actors[ctsh].W - 23) / 2; // Center the block on the tower
                        actors[ctsh].Y = yTower - actors[ctsh].H;
                        actors2.Add(actors[ctsh]);
                        actors.RemoveAt(ctsh);
                    }
                    else if (actors[ctsh].lvl > actors2[actors2.Count - 1].lvl)
                    {
                        actors[ctsh].X = (xTower + 400) - (actors[ctsh].W - 23) / 2; // Center the block on the tower
                        actors[ctsh].Y = actors2[actors2.Count - 1].Y - actors2[actors2.Count - 1].H;
                        actors2.Add(actors[ctsh]);
                        actors.RemoveAt(ctsh);
                    }
                    else
                    {
                        actors[ctsh].X = xOldActor;
                        actors[ctsh].Y = yOldActor;
                    }
                }
                if (col == 3)
                {
                    if (actors2.Count == 0)
                    {
                        actors3[ctsh].X = (xTower + 400) - (actors3[ctsh].W - 23) / 2; // Center the block on the tower
                        actors3[ctsh].Y = yTower - actors3[ctsh].H;
                        actors2.Add(actors3[ctsh]);
                        actors3.RemoveAt(ctsh);
                    }
                    else if (actors3[ctsh].lvl > actors2[actors2.Count - 1].lvl)
                    {
                        actors3[ctsh].X = (xTower + 400) - (actors3[ctsh].W - 23) / 2; // Center the block on the tower
                        actors3[ctsh].Y = actors2[actors2.Count - 1].Y - actors2[actors2.Count - 1].H;
                        actors2.Add(actors3[ctsh]);
                        actors3.RemoveAt(ctsh);
                    }
                    else
                    {
                        actors3[ctsh].X = xOldActor;
                        actors3[ctsh].Y = yOldActor;
                    }
                }
            }
            else if (e.X >= xTower + 800 && e.X <= xTower + 823 && e.Y >= yTower - 400)
            {
                if (col == 3)
                {
                    actors3[ctsh].X = xOldActor;
                    actors3[ctsh].Y = yOldActor;
                }
                if (col == 1)
                {
                    if (actors3.Count == 0)
                    {
                        actors[ctsh].X = (xTower + 800) - (actors[ctsh].W - 23) / 2; // Center the block on the tower
                        actors[ctsh].Y = yTower - actors[ctsh].H;
                        actors3.Add(actors[ctsh]);
                        actors.RemoveAt(ctsh);
                    }
                    else if (actors[ctsh].lvl > actors3[actors3.Count - 1].lvl)
                    {
                        actors[ctsh].X = (xTower + 800) - (actors[ctsh].W - 23) / 2; // Center the block on the tower
                        actors[ctsh].Y = actors3[actors3.Count - 1].Y - actors3[actors3.Count - 1].H;
                        actors3.Add(actors[ctsh]);
                        actors.RemoveAt(ctsh);
                    }
                    else
                    {
                        actors[ctsh].X = xOldActor;
                        actors[ctsh].Y = yOldActor;
                    }
                }
                if (col == 2)
                {
                    if (actors3.Count == 0)
                    {
                        actors2[ctsh].X = (xTower + 800) - (actors2[ctsh].W - 23) / 2; // Center the block on the tower
                        actors2[ctsh].Y = yTower - actors2[ctsh].H;
                        actors3.Add(actors2[ctsh]);
                        actors2.RemoveAt(ctsh);
                    }
                    else if (actors2[ctsh].lvl > actors3[actors3.Count - 1].lvl)
                    {
                        actors2[ctsh].X = (xTower + 800) - (actors2[ctsh].W - 23) / 2; // Center the block on the tower
                        actors2[ctsh].Y = actors3[actors3.Count - 1].Y - actors3[actors3.Count - 1].H;
                        actors3.Add(actors2[ctsh]);
                        actors2.RemoveAt(ctsh);
                    }
                    else
                    {
                        actors2[ctsh].X = xOldActor;
                        actors2[ctsh].Y = yOldActor;
                    }
                }
            }
            else
            {
                if (col == 1)
                {
                    actors[ctsh].X = xOldActor;
                    actors[ctsh].Y = yOldActor;
                }
                if (col == 2)
                {
                    actors2[ctsh].X = xOldActor;
                    actors2[ctsh].Y = yOldActor;
                }
                if (col == 3)
                {
                    actors3[ctsh].X = xOldActor;
                    actors3[ctsh].Y = yOldActor;
                }
            }

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                int dx = e.X - xOld;
                int dy = e.Y - yOld;
                if (col == 1)
                {
                    actors[ctsh].X = actors[ctsh].X + dx;
                    actors[ctsh].Y = actors[ctsh].Y + dy;
                    xOld = e.X;
                    yOld = e.Y;
                }
                if (col == 2)
                {
                    actors2[ctsh].X = actors2[ctsh].X + dx;
                    actors2[ctsh].Y = actors2[ctsh].Y + dy;
                    xOld = e.X;
                    yOld = e.Y;
                }
                if (col == 3)
                {
                    actors3[ctsh].X = actors3[ctsh].X + dx;
                    actors3[ctsh].Y = actors3[ctsh].Y + dy;
                    xOld = e.X;
                    yOld = e.Y;
                }
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < actors.Count; i++)
                {
                    if (e.X >= actors[actors.Count - 1].X && e.X <= (actors[actors.Count - 1].X) + actors[actors.Count - 1].W && e.Y >= actors[actors.Count - 1].Y && e.Y <= (actors[actors.Count - 1].Y) + actors[actors.Count - 1].H)
                    {
                        xOld = e.X;
                        yOld = e.Y;
                        xOldActor = actors[actors.Count - 1].X;
                        yOldActor = actors[actors.Count - 1].Y;
                        ctsh = i;
                        col = 1;
                        isDrag = true;
                    }
                }
                for (int i = 0; i < actors2.Count; i++)
                {
                    if (e.X >= actors2[actors2.Count - 1].X && e.X <= (actors2[actors2.Count - 1].X) + actors2[actors2.Count - 1].W && e.Y >= actors2[actors2.Count - 1].Y && e.Y <= (actors2[actors2.Count - 1].Y) + actors2[actors2.Count - 1].H)
                    {
                        xOld = e.X;
                        yOld = e.Y;
                        xOldActor = actors2[actors2.Count - 1].X;
                        yOldActor = actors2[actors2.Count - 1].Y;
                        ctsh = i;
                        col = 2;
                        isDrag = true;
                    }
                }
                for (int i = 0; i < actors3.Count; i++)
                {
                    if (e.X >= actors3[actors3.Count - 1].X && e.X <= (actors3[actors3.Count - 1].X) + actors3[actors3.Count - 1].W && e.Y >= actors3[actors3.Count - 1].Y && e.Y <= (actors3[actors3.Count - 1].Y) + actors3[actors3.Count - 1].H)
                    {
                        xOld = e.X;
                        yOld = e.Y;
                        xOldActor = actors3[actors3.Count - 1].X;
                        yOldActor = actors3[actors3.Count - 1].Y;
                        ctsh = i;
                        col = 3;
                        isDrag = true;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            yTower = this.ClientSize.Height;
            CreateThem();
        }

        private void CreateThem()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Pen P = new Pen(Color.Black, 5);
            SolidBrush brsh = new SolidBrush(Color.Gray);

            g.FillRectangle(brsh, xTower, yTower - 400, 23, 400);
            g.DrawRectangle(P, xTower, yTower - 400, 23, 400);

            g.FillRectangle(brsh, xTower + 400, yTower - 400, 23, 400);
            g.DrawRectangle(P, xTower + 400, yTower - 400, 23, 400);

            g.FillRectangle(brsh, xTower + 800, yTower - 400, 23, 400);
            g.DrawRectangle(P, xTower + 800, yTower - 400, 23, 400);

            for (int i = 0; i < 10; i++)
            {
                Actor actor = new Actor();

                actor.W = 150 - i * 15; // Decrease width for each level to simulate the tower shape
                actor.H = 25;
                actor.X = xTower - (actor.W - 23) / 2; // Center the block on the tower
                actor.Y = yTower - (i + 1) * actor.H; // Stack the blocks on top of each other
                actor.lvl = i + 1;
                actor.clr = Color.Yellow;
                actor.clrPen = Color.Black;
                Pen P2 = new Pen(actor.clrPen, 3);
                SolidBrush brsh2 = new SolidBrush(actor.clr);
                g.FillRectangle(brsh2, actor.X, actor.Y, actor.W, actor.H);
                g.DrawRectangle(P2, actor.X, actor.Y, actor.W, actor.H);
                actors.Add(actor);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            Pen P = new Pen(Color.Black, 5);
            SolidBrush brsh = new SolidBrush(Color.Gray);

            g.FillRectangle(brsh, xTower, yTower - 400, 23, 400);
            g.DrawRectangle(P, xTower, yTower - 400, 23, 400);

            g.FillRectangle(brsh, xTower + 400, yTower - 400, 23, 400);
            g.DrawRectangle(P, xTower + 400, yTower - 400, 23, 400);

            g.FillRectangle(brsh, xTower + 800, yTower - 400, 23, 400);
            g.DrawRectangle(P, xTower + 800, yTower - 400, 23, 400);
            for (int i = 0; i < actors.Count; i++)
            {
                Pen P2 = new Pen(actors[i].clrPen, 3);
                SolidBrush brsh2 = new SolidBrush(actors[i].clr);
                g.FillRectangle(brsh2, actors[i].X, actors[i].Y, actors[i].W, actors[i].H);
                g.DrawRectangle(P2, actors[i].X, actors[i].Y, actors[i].W, actors[i].H);
            }

            for (int i = 0; i < actors2.Count; i++)
            {
                Pen P2 = new Pen(actors2[i].clrPen, 3);
                SolidBrush brsh2 = new SolidBrush(actors2[i].clr);
                g.FillRectangle(brsh2, actors2[i].X, actors2[i].Y, actors2[i].W, actors2[i].H);
                g.DrawRectangle(P2, actors2[i].X, actors2[i].Y, actors2[i].W, actors2[i].H);
            }

            for (int i = 0; i < actors3.Count; i++)
            {
                Pen P2 = new Pen(actors3[i].clrPen, 3);
                SolidBrush brsh2 = new SolidBrush(actors3[i].clr);
                g.FillRectangle(brsh2, actors3[i].X, actors3[i].Y, actors3[i].W, actors3[i].H);
                g.DrawRectangle(P2, actors3[i].X, actors3[i].Y, actors3[i].W, actors3[i].H);
            }
        }

        private void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}