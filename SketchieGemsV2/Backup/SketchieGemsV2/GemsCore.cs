using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace SketchieGemsV2
{
    struct Tile
    {
        public int tileInd;
        public Point tileLoc;
        public Tile(int i, Point l)
        {
            tileInd = i;
            tileLoc = l;
        }
    }
    
    class GemsCore
    {
        private int[,] m_grid;
        private int m_rows;
        private int m_cols;
        private int m_numTiles;
        private int m_swapSpeed;
        private int m_fallSpeed;
        private bool m_swapLock;
        
        public delegate void DManageTiles(Tile a, Tile b);

        public event DManageTiles SwapStart;
        public event DManageTiles SwapEnd;

        public delegate void DTileAnimations(List<Tile> t);

        public event DTileAnimations FallStart;
        public event DTileAnimations FallEnd;
        public event DTileAnimations ClearStart;
        public event DTileAnimations ClearEnd;

        public delegate void DAddTile(int x, int tile);
        public event DAddTile TileAdded;

        public event EventHandler GameOver;
        
        public int SwapSpeed
        {
            get { return m_swapSpeed; }
            set { m_swapSpeed = value; }
        }

        public int FallSpeed
        {
            get { return m_fallSpeed; }
            set { m_fallSpeed = value; }
        }
        
        /// <summary>
        /// Number of rows in the playing field
        /// </summary>
        public int Rows { get { return m_rows; }
                          set { m_rows = value; CreateGrid(); } }
        
        /// <summary>
        /// Number of columns in the playing field
        /// </summary>
        public int Cols { get { return m_cols; }
                          set { m_rows = value; CreateGrid(); } }

        /// <summary>
        /// Accessor for the playgrid.
        /// </summary>
        /// <param name="x">X Coordinate on grid</param>
        /// <param name="y">Y Coordinate on grid</param>
        /// <returns></returns>
        public int this[int x, int y] { get { return m_grid[x, y]; } }

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="numTiles">Number of tile types</param>
        /// <param name="numRows">Number of rows in the playing field</param>
        /// <param name="numCols">Number of columns in the playing field</param>
        public GemsCore(int numTiles, int numRows, int numCols)
        {
            m_numTiles = numTiles;
            m_rows = numRows;
            m_cols = numCols;
            m_swapSpeed = 500;
            m_fallSpeed = 500;
            CreateGrid();
        }

        private void CreateGrid()
        {   
            m_grid = new int[m_rows, m_cols];
            InitialiseGrid();
        }

        private void InitialiseGrid()
        {
            Random r = new Random();
            do
            {
                for (int j = 0; j < m_rows; j++)
                    for (int i = 0; i < m_cols; i++)
                        m_grid[i, j] = r.Next(m_numTiles);
                for (int j = 0; j < m_rows; j++)
                    for (int i = 0; i < m_cols; i++)
                        while (IsMatch(new Point(i, j)))
                            m_grid[i, j] = r.Next(m_numTiles);
            } while (!MovesLeft());
        }

        private List<Tile> GetFalls()
        {
            Random r = new Random();  
            int[,] g = new int[m_cols, m_rows];
            for (int j = 0; j < m_rows; j++)
                for (int i = 0; i < m_cols; i++)
                    g[i, j] = m_grid[i, j];
            List<Tile> ret = new List<Tile>();
            for (int j = m_rows -2; j >= 0; j--)
            {
                for (int i = 0; i < m_cols; i++)
                {
                    if (g[i,j+1] == -1 && g[i,j] != -1)
                    {
                        ret.Add(new Tile(g[i,j], new Point(i,j)));
                        g[i, j] = -1;
                    }
                }
            }
            for (int k = 0; k < m_cols; k++)
                if (g[k,0] == -1)
                    ret.Add(new Tile(r.Next(m_numTiles), new Point(k, -1)));
            return ret;
        }

        private Point HorizontalCheck(Point loc)
        {
            int tile = m_grid[loc.X, loc.Y];
            int min = loc.X;
            int max = loc.X;
            while (min > 0 && m_grid[min - 1, loc.Y] == tile) min--;
            while (max < m_cols - 1 && m_grid[max + 1, loc.Y] == tile) max++;
            return new Point(min,max);
        }

        private Point VerticalCheck(Point loc)
        {
            int tile = m_grid[loc.X, loc.Y];
            int min = loc.Y;
            int max = loc.Y;
            while (min > 0 && m_grid[loc.X, min - 1] == tile) min--;
            while (max < m_cols - 1 && m_grid[loc.X, max + 1] == tile) max++;
            return new Point(min, max);
        }

        private bool IsMatch(Point loc)
        {
            Point h = HorizontalCheck(loc);
            Point v = VerticalCheck(loc);
            return h.Y - h.X >= 2 || v.Y - v.X >= 2;
        }
        
        private bool MovesLeft()
        {
            for (int j = 0; j < m_rows; j++)
                for (int i = 0; i < m_cols - 1; i++)
                    if (ValidMove(new Point(i, j), new Point(i + 1, j)))
                        return true;

            for (int j = 0; j < m_rows - 1; j++)
                for (int i = 0; i < m_cols; i++)
                    if (ValidMove(new Point(i, j), new Point(i, j + 1)))
                        return true;
            
            return false;
        }

        private bool ValidMove(Point a, Point b)
        {
            bool ret = false;
            SwapTiles(a, b);
            ret = IsMatch(a) || IsMatch(b);
            SwapTiles(a, b);
            return ret;
        }

        private void SwapTiles(Point a, Point b)
        {
            m_grid[a.X, a.Y] ^= m_grid[b.X, b.Y];
            m_grid[b.X, b.Y] ^= m_grid[a.X, a.Y];
            m_grid[a.X, a.Y] ^= m_grid[b.X, b.Y];
        }

        private void ClearMatch(Point loc, bool drop)
        {
            Point h = HorizontalCheck(loc);
            Point v = VerticalCheck(loc);
            if (h.Y - h.X >= 2)
                for (int i = h.X; i <= h.Y; i++)
                    m_grid[i, loc.Y] = -1;
            if (v.Y - v.X >= 2)
                for (int i = v.X; i <= v.Y; i++)
                    m_grid[loc.X, i] = -1;
            if (drop)
            {
                if (h.Y - h.X >= 2)
                    for (int i = h.X; i <= h.Y; i++)
                        DropTiles(i);
                if (v.Y - v.X >= 2)
                    DropTiles(loc.X);
            }
        }

        void SwapTimerCallback(object o)
        {
            Thread.Sleep(m_swapSpeed);
            Tile[] p = (Tile[])o;
            m_grid[p[0].tileLoc.X, p[0].tileLoc.Y] = p[0].tileInd;
            m_grid[p[1].tileLoc.X, p[1].tileLoc.Y] = p[1].tileInd;
            Point a = p[0].tileLoc;
            Point b = p[1].tileLoc;
            if (IsMatch(b))
                ClearMatch(b, false);
            if (IsMatch(a))
                ClearMatch(a, false);
            /*for (int i = 0; i < m_cols; i++)
                DropTiles(i);
            do
                FillBlanks();
            while (CheckandClear());*/

            List<Tile> fall = GetFalls();
            HandleFalls(fall);
        }

        private void HandleFalls(List<Tile> fall)
        {
            if (fall.Count <= 0)
                return;
            foreach (Tile t in fall)
                if (t.tileLoc.Y >= 0)
                    m_grid[t.tileLoc.X, t.tileLoc.Y] = -1;

            if (FallStart != null)
                FallStart(fall);
            Thread th = new Thread(new ParameterizedThreadStart(FallTimerCallback));
            th.Start(fall);
        }

        void FallTimerCallback(object o)
        {
            Thread.Sleep(m_fallSpeed);
            List<Tile> fall = (List<Tile>)o;
            foreach (Tile t in fall)
                m_grid[t.tileLoc.X, t.tileLoc.Y + 1] = t.tileInd;
            fall = GetFalls();
            if (fall.Count > 0)
            {
                HandleFalls(fall);
            }
            else
            {
                if (!CheckandClear())
                {
                    if (SwapEnd != null)
                        SwapEnd(new Tile(), new Tile());
                    m_swapLock = false;
                    if (!MovesLeft())
                        if (GameOver != null)
                            GameOver(null, null);
                }
            }
        }

        public bool Swap(Point a, Point b)
        {
            if ((m_swapLock || (Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y)) != 1))
            {
                return false;
            }
            else
            {
                SwapTiles(b,a);
                if (IsMatch(b) || IsMatch(a))
                {
                    Tile[] p = new Tile[2];
                    p[0].tileInd = m_grid[a.X,a.Y];
                    p[0].tileLoc = a;
                    p[1].tileInd = m_grid[b.X,b.Y];
                    p[1].tileLoc = b;

                    m_swapLock = true;
                    m_grid[a.X, a.Y] = -1;
                    m_grid[b.X, b.Y] = -1;
                    if (SwapStart != null)
                        SwapStart(p[0], p[1]);
                    Thread th = new Thread(new ParameterizedThreadStart(SwapTimerCallback));
                    th.Start(p);
                    /*
                    
                    if (IsMatch(b))
                        ClearMatch(b, false);
                    if (IsMatch(a))
                        ClearMatch(a, false);
                    for (int i = 0; i < m_cols; i++)
                        DropTiles(i);
                    do
                        FillBlanks();
                    while (CheckandClear());
                     */
                }
                else
                {
                    SwapTiles(a, b);
                    return false;
                }
            }
            return true;
        }

        

        private void FillBlanks()
        {
            Random r = new Random();
            for (int j = 0; j < m_rows; j++)
                    for (int i = 0; i < m_cols; i++)
                        if (m_grid[i,j] == -1)
                            m_grid[i, j] = r.Next(m_numTiles);

        }

        private bool CheckandClear()
        {
            bool ret = false;
            for (int j = 0; j < m_rows; j++)
                for (int i = 0; i < m_cols; i++)
                    if(IsMatch(new Point(i,j)))
                    {
                        ret = true;
                        ClearMatch(new Point(i,j), false);
                    }
            HandleFalls(GetFalls());

            return ret;
        }

        private void DropTiles(int x)
        {
            int y = m_rows - 1;
            while (y > 1)
            {
                if (m_grid[x,y] == -1)
                {
                    int y2 = y - 1;
                    while (y2 > -1 && m_grid[x,y2] == -1)
                        y2--;
                    if (y2 != -1)
                        SwapTiles(new Point(x,y), new Point(x,y2));
                    else
                        break;
                }
                y--;
            }
        }

    }
}
