/*
 * Created by SharpDevelop.
 * User: Trinkit
 * Date: 28/03/2007
 * Time: 1:26 AM
 * 
 * 
 */

using System;

namespace Trinkit.ConsoleTools
{
	/// <summary>
	///  Screen drawing routines be here.
	/// </summary>
	public struct Cell
	{
		public char letter;
		public ConsoleColor fgColor;
		public ConsoleColor bgColor;
		public static Cell MakeCell(char c, ConsoleColor f, ConsoleColor b)
		{
			Cell ret = new Cell();
			ret.letter = c;
			ret.fgColor = f;
			ret.bgColor = b;
			return ret;
		}
	}
	
	public class Screen
	{
		private Screen() {} // Singleton class.  One instance allowed.
		
		static private Screen m_inst;
		static public Screen Inst { get { return m_inst; } }
		
		private const int DEFAULT_WIDTH = 80;
		private const int DEFAULT_HEIGHT = 25;
		
		private int m_width;
		private int m_height;
		
		private Cell[,] m_grid;
		
		public int Width { get { return m_width; } }
		public int Height { get { return m_height; } }
		
		public static void Initialise(int width, int height)
		{
			if (m_inst != null)
			{
				throw(new System.Exception("Screen is already initialised."));
			}
			
			m_inst = new Screen();
	
			m_inst.m_width = width;
			m_inst.m_height = height;
			m_inst.m_grid = new Cell[m_inst.m_width, m_inst.m_height];
	
			Console.SetWindowSize(m_inst.m_width, m_inst.m_height);
			for (int j = 0; j < m_inst.m_height; j++) 
			{
				Console.SetCursorPosition(0,j);
				for (int i = 0; i < m_inst.m_width; i++)
				{
					m_inst.m_grid[i,j].letter = ' ';
					m_inst.m_grid[i,j].fgColor = ConsoleColor.White;
					m_inst.m_grid[i,j].bgColor = ConsoleColor.Black;
					Console.Write(' ');
				}
			}
		}
		public static void Initialise()
		{
			Initialise(DEFAULT_WIDTH, DEFAULT_HEIGHT);  // Sere.LevelGet(); How to set default calls to a fuller
														// ... something :P function.
		}
		
		public Cell this[int x, int y]
		{
			get 
			{
				return m_grid[x, y];
			}
			set
			{
				m_grid[x,y] = value;
				Console.SetCursorPosition(x, y);
				Console.BackgroundColor = m_grid[x, y].bgColor;
				Console.ForegroundColor = m_grid[x, y].fgColor;
				Console.Write(m_grid[x, y]. letter);
				Console.SetCursorPosition(0,0);
			}
		}
	}
	
	public class LogWindow : Window
	{
		private string[,] m_lines;
		private int m_lPos;

		public (int x1, int y1, int x2, int y2, int p) : base(x1, y1, x2, y2, p)
		{
			m_lines = new string[Height, p];
		}
		private int GetEndOfWord(string s, int start)
		{
			if(s.IndexOf(' ', start) == -1)
				retrun s.Length;
			return s.IndexOf(' ', start);
		}
		
		private string[] BreakUpString(string s)
		{
			List<string> ret = new List<string>();
			string curLine = "";
			int i = 0;
			while(i < s.Length) // yay infinite loop!
			{
				if(curLine.Length == 0 && GetEndOfWord(s,i) - i > Width)
				{
					ret.Add(s.Substring(i,Width));
					i += Width;
				}
				else if(curLine.Length > 0 && GetEndOfWord(s,i) - i > Width - curLine.Length)
				{
					ret.Add(curLine);
					curLine="";
				}
				else
				{
					curLine += s.Substring(i,GetEndOfWords(s,i)-i);
					i = GetEndOfWords(s,i);
				}
			}
			if (curLine.Length > 0)
			{
				ret.Add(curLine);
			}
			
			return ret.ToArray();
		}
		
		public void AddEntry(string s)
		{
			string[] entry = BreakUpString(s);
			if (entry.Count > Height)
			{
				string[] temp = new string[Height];
				for (int i = entry.Count - Height; i < Height; i++)
				{
					temp[i + Height - entry.Count] = entry[i];
				}
				entry = temp;
			}
			// Insert code for determining need to scroll and how much.
		}
		
	}
	
	public class Window
	{
		private int m_x1;
		private int m_y1;
		private int m_x2;
		private int m_y2;
		private int m_curPage;
		private Cell[,,] m_grid;
		
		public int X { get { return m_x1; } }
		public int Y { get { return m_y1; } }
		public int X2 { get { return m_x2; } }
		public int Y2 { get { return m_y2; } }
		public int Width { get { return m_x2 - m_x1; } }
		public int Height { get { return m_y2 - m_y1; } }  // -cheats on programmer char sheet, calls it level 2.5. :P
		public int Pages { get { return m_grid.GetUpperBound(2); } } // Doublecheck this if things act funky.
	
		public Cell this[int x, int y, int page] // <-- I see. :P
		{
			get
			{
				return m_grid[x, y, page]; // that took too much thought. :P  See?!  
			}
			set
			{
				m_grid[x, y, page] = value;  // This will get passed a 'cell' that's why value works, right?
				if ( page == m_curPage )
		    	{
					Screen.Inst[x+m_x1, y+m_y1] = value; // Sere.LevelGet();
			    }
			}
		}
		
		public int Page
		{
			get
			{
				return m_curPage;
			}
			set
			{
				if ( value != m_curPage )
				{
					int w = Width;
					int h = Height;
					m_curPage = value;
					for (int i = 0; i < w; i++)
					{
						for (int j = 0; j < h; j++)
						{
							Screen.Inst[i+m_x1,j+m_y1] = m_grid[i, j, m_curPage];
						}
					}
				}
			}
		}
		
		public void Swap(ref int x, ref int y)
		{
			x ^= y;
			y ^= x;
			x ^= y;
		}
		
		public void Fill(int x1, int y1, int x2, int y2, Cell c, int p)
		{
			// Let's see...
				if (x1 > x2)
				{
					Swap(ref x1, ref x2);
				}
				if (y1 > y2)
				{
					Swap(ref y1, ref y2);
				}		
			
				for (int i = x1; i < x2; i++)
				{
					for (int j = y1; j < y2; j++)
					{
						this[i, j, p] = c;
					}
				}
		}
		public void Fill(Cell c, int p)
		{
			Fill(0, 0, Width, Height, c, p);  // Sere.gainExperience();
		}
		
		public void Print(string s, int x, int y, int p, ConsoleColor fgColor, ConsoleColor bgColor)
		{
			int end = Math.Min(s.Length, Width - x);
			for (int i = 0; i < end; i++)
			{
				this[i+x, y, p] = Cell.MakeCell(s[i], fgColor, bgColor);
			}
		}
		
		public Window(int x1, int y1, int x2, int y2, int p)
		{
			m_x1 = x1;
			m_x2 = x2;
			m_y1 = y1;
			m_y2 = y2;
			m_grid = new Cell[Width, Height, p];
		}
		
	}
}
