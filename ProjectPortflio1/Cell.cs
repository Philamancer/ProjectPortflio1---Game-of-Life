using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPortflio1
{
    class Cell
    {
        //Specifices if Cell is alive or dead
        bool mAlive;

        //Keeps track of row and cols as well as how long each cell has been alive.
        private int mRow, mCol, mGenerationsAlive, mTotal;

        //Properties for member variables
        public int GenerationsAlive
        {
            get
            {
                return mGenerationsAlive;
            }

            set
            {
                mGenerationsAlive = value;
            }
        }

        public bool Alive
        {
            get
            {
                return mAlive;
            }

            set
            {
                mAlive = value;
            }
        }

        public int Row
        {
            get
            {
                return mRow;
            }

            set
            {
                mRow = value;
            }
        }

        public int Col
        {
            get
            {
                return mCol;
            }

            set
            {
                mCol = value;
            }
        }

        public int Total
        {
            get
            {
                return mTotal;
            }

            set
            {
                mTotal = value;
            }
        }

        public Cell(Boolean _Alive = true, int _row = -1, int _col = -1)
        {
            Alive = _Alive;
            GenerationsAlive = 0;
            Row = _row;
            Col = _col;
            
        }

        public void KillCell()
        {
            Alive = false;
            GenerationsAlive = 0;
        }

        //Counts total amount of nearby cells
        public void updateNearby(Cell[,] universe)
        {
            int curr = 0;
            for (int x = Row - 1; x <= Row + 1; x++)
            {
                for (int y = Col - 1; y <= Col + 1; y++)
                {
                    if (x != Row || y != Col)
                    {
                        //try
                        if (x >= 0 && y >= 0 && x < universe.GetLength(0) && y < universe.GetLength(1))
                        {
                            if (universe[x, y].Alive)
                            {
                                curr++;
                            }
                        }
                        //catch { }
                    }
                }

            }
            Total = curr;
        }

        public bool willLive()
        {
            if(Total < 2 || Total > 3)
            {
                if (Alive)
                {
                    return false;
                }
                else if(Total == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
