using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPortflio1
{
    public partial class Form1 : Form
    {

        Cell[,] universe = new Cell[5, 5];

        //Boolean[,] universe = new Boolean[5,5];

        enum dimensions { x , y }

        
        Timer timer = new Timer();

        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            for (int x = 0; x < universe.GetLength((int)dimensions.x); x++)
            {
                for (int y = 0; y < universe.GetLength((int)dimensions.y); y++)
                {
                    universe[x, y] = new Cell(false, x, y);
                }
            }

            timer.Interval = 20;
            timer.Start();
            timer.Enabled = false;
            timer.Tick += timer1_Tick;

            toolStripStatusLabel1.Text = "Generations: 0";

        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            float width = graphicsPanel1.ClientSize.Width / universe.GetLength((int)dimensions.x);
            float height = (graphicsPanel1.ClientSize.Height / universe.GetLength((int)dimensions.y));
            
            for (int x = 0; x < universe.GetLength((int)dimensions.x); x++)
            {
                for (int y = 0; y < universe.GetLength((int)dimensions.y); y++)
                {
                    float rx = (float)(x * width);
                    float ry = (float)(y * height);

                    universe[x, y].updateNearby(universe);

                    if (timer.Enabled)
                    {
                        if(universe[x,y].Total == 3 || universe[x,y].Total == 2)
                        {
                            universe[x, y].Alive = true;
                        }
                        else
                        {
                            universe[x, y].Alive = false;
                        }
                    }

                    if (universe[x, y].Alive)
                    {

                        e.Graphics.FillRectangle(Brushes.Red, new Rectangle((int)rx, (int)ry, (int)width, (int)height));
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)rx, (int)ry, (int)width, (int)height));
                    }


                    /*
                    //Draw Cell
                    if (universe[x, y].Alive)
                    {
                        universe[x, y].nearbyCells(universe);
                        if (universe[x,y].Total == 0)
                        {
                            Font font = new Font("Arial", 25f);

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;

                            Rectangle rect = new Rectangle((int)rx, (int)ry, (int)width, (int)height);
                            e.Graphics.FillRectangle(Brushes.Red, rect);

                            e.Graphics.DrawString(universe[x,y].Total + "", font, Brushes.Black, rect, stringFormat);

                        }else if (universe[x, y].Total == 1)
                        {
                            Font font = new Font("Arial", 25f);

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;

                            Rectangle rect = new Rectangle((int)rx, (int)ry, (int)width, (int)height);
                            e.Graphics.FillRectangle(Brushes.Orange, rect);

                            e.Graphics.DrawString(universe[x, y].Total + "", font, Brushes.Black, rect, stringFormat);
                        }
                        else if(universe[x, y].Total == 2)
                        {
                            Font font = new Font("Arial", 25f);

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;

                            Rectangle rect = new Rectangle((int)rx, (int)ry, (int)width, (int)height);
                            e.Graphics.FillRectangle(Brushes.Yellow, rect);

                            e.Graphics.DrawString(universe[x, y].Total + "", font, Brushes.Black, rect, stringFormat);
                        }
                        else if (universe[x, y].Total >= 3)
                        {
                            Font font = new Font("Arial", 25f);

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;

                            Rectangle rect = new Rectangle((int)rx, (int)ry, (int)width, (int)height);
                            e.Graphics.FillRectangle(Brushes.Green, rect);

                            e.Graphics.DrawString(universe[x, y].Total + "", font, Brushes.Black, rect, stringFormat);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.Black, new Rectangle((int)rx, (int)ry, (int)width, (int)height));
                        }
                    }
                    */


                    //Draw Grid

                }
            }
        }

        //Called when a cell is clicked
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            float width = graphicsPanel1.ClientSize.Width / universe.GetLength((int)dimensions.x);
            float height = graphicsPanel1.ClientSize.Height / universe.GetLength((int)dimensions.y);

            if (e.Button == MouseButtons.Left)
            {
                float sx = e.X / width;
                float sy = e.Y / height;

                universe[(int)sx, (int)sy].Alive = !universe[(int)sx, (int)sy].Alive;

                graphicsPanel1.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            generations++;

            toolStripStatusLabel1.Text = "Generations: " + generations.ToString();

            graphicsPanel1.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generations = 0;

            toolStripStatusLabel1.Text = "Generations " + generations.ToString();
            
            graphicsPanel1.Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }
    }
}
