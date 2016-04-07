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

        Cell[,] universe = new Cell[15 , 15];

        int width, height, alive = 0;

        Dictionary<int, Cell[,]> history = new Dictionary<int, Cell[,]>();

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

            width = 15;
            height = 15;

            toolStripStatusLabel1.Text = "Generations " + generations.ToString() + " | Alive : " + alive;

        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            float width = graphicsPanel1.ClientSize.Width / universe.GetLength((int)dimensions.x);
            float height = (graphicsPanel1.ClientSize.Height / universe.GetLength((int)dimensions.y));

            for (int i = 0; i < universe.GetLength((int)dimensions.x); i++)
            {
                for (int j = 0; j < universe.GetLength((int)dimensions.y); j++)
                {
                    float rx = (float)(i * width);
                    float ry = (float)(j * height);

                    if (universe[i,j].Alive)
                    {

                        e.Graphics.FillRectangle(Brushes.Red, new Rectangle((int)rx, (int)ry, (int)width, (int)height));
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)rx, (int)ry, (int)width, (int)height));
                    }

                }
            }

            toolStripStatusLabel1.Text = "Generations " + generations.ToString() + " | Alive : " + alive;

        }
        /*
                Font font = new Font("Arial", 25f);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                Rectangle rect = new Rectangle((int)rx, (int)ry, (int)width, (int)height);
                e.Graphics.FillRectangle(Brushes.Red, rect);

                e.Graphics.DrawString(universe[x,y].Total + "", font, Brushes.Black, rect, stringFormat);
        */


        public void update()
        {
            alive = 0;

            Cell[,] temp = new Cell[width, height];

            for (int x = 0; x < temp.GetLength((int)dimensions.x); x++)
            {
                for (int y = 0; y < temp.GetLength((int)dimensions.y); y++)
                {
                    temp[x, y] = new Cell(false,x, y);
                }
            }
            

            for (int x = 0; x < universe.GetLength((int)dimensions.x); x++)
            {
                for (int y = 0; y < universe.GetLength((int)dimensions.y); y++)
                {
                    universe[x, y].updateNearby(universe);

                    if (universe[x, y].Total == 3 || (universe[x, y].Total == 2 && universe[x,y].Alive))
                    {
                        temp[x, y].Alive = true;
                        alive++;
                    }
                    else
                    {
                        temp[x, y].Alive = false;
                    }
                }
            }
            if (history.ContainsKey(generations))
            {
                history[generations] = universe;
            }
            else
            {
                history.Add(generations, universe);
            }

            universe = temp;

            generations++;

            toolStripStatusLabel1.Text = "Generations " + generations.ToString() + " | Alive : " + alive;

            graphicsPanel1.Invalidate();
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

                if (universe[(int)sx, (int)sy].Alive)
                {
                    alive++;
                }
                else
                {
                    alive--;
                }

                graphicsPanel1.Invalidate();
            }
        }

        //Timer Function called every Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            update();
        }

        //New Grid - Lets you pick grid size / Colors (TODO)
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generations = 0;

            update();
        }

        //Run button
        private void Run(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        //Step Button
        private void Step(object sender, EventArgs e)
        {
            update();
        }

        //Stop Button
        private void Stop(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        //Menu Clear
        private void MenuClear(object sender, EventArgs e)
        {
            clear();
        }
        //Customize the size of the grid and time between each tick.
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goBack_Click(object sender, EventArgs e)
        {

            if (history.ContainsKey(generations - 1))
            {
                timer.Enabled = false;
                if (generations - 1 != -1)
                {                    

                    universe = history[generations - 1];

                    generations--;

                    graphicsPanel1.Invalidate();

                }
            }
        }

        //Clear Button
        private void ClearButton(object sender, EventArgs e)
        {
            clear();
        }

        //Clear Function
        public void clear()
        {
            for (int x = 0; x < universe.GetLength((int)dimensions.x); x++)
            {
                for (int y = 0; y < universe.GetLength((int)dimensions.y); y++)
                {
                    universe[x, y] = new Cell(false, x, y);
                }
            }

            graphicsPanel1.Invalidate();
        }
    }
}
