using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UberStats
{
    
    class Program
    {
        static int trackCount;    
        static void Main(string[] args)
        {
            /*
            string a = "Final Fantasy VI (OST) (Disc 1)";
            string b = "Final Fantasy VII Advent Children (OST) (Disc 1)";
            float longer = 0;
            if (a.Length > b.Length)
            {
                longer = a.Length;
            }
            else
            {
                longer = b.Length;
            }
            Distance dist = new Distance();
            float diff = dist.LD(a, b);
            float percent = diff / longer;
            float result = (1 - percent) * 100;
            Console.WriteLine(dist.LD(a,b));
            Console.WriteLine(result.ToString());
            Console.ReadLine();
            */
            List<Album> albums = GetAlbums(@"K:\Uber\DL");
            Distance dist = new Distance();
            for (int i = 0; i < albums.Count - 1; i++)
            {
                for (int j = i + 1; j < albums.Count; j++)
                {
                    string artistA = albums[i].Artist;
                    string artistB = albums[j].Artist;
                    string albumA = albums[i].AlbumName;
                    string albumB = albums[j].AlbumName;
                    int yearA = albums[i].Year;
                    int yearB = albums[j].Year;
                    if (artistA == artistB && albumA == albumB && yearA != yearB)
                    {
                        Console.WriteLine(albums[i].ToString());
                        Console.WriteLine(albums[j].ToString());
                        break;
                    }
                    string a = albums[i].ToString();
                    string b = albums[j].ToString();
                    float large = Math.Max(a.Length, b.Length);
                    float diff = (1 - (dist.LD(a, b) / large)) * 100;
                    if (diff > 75)
                    {
                        Console.WriteLine(a);
                        Console.WriteLine(b);
                        Console.WriteLine("-- " + diff + "% similar.");
                    }

                }
            }

            Console.WriteLine(albums.Count.ToString());
            Console.WriteLine(trackCount);
            Console.ReadLine();


        }
        public static List<Album> GetAlbums(string dir)
        {
            List<Album> ret = new List<Album>();
            string[] dirs = Directory.GetDirectories(dir);
            foreach (string s in dirs)
            {
                List<Album> add = GetAlbums(s);
                foreach (Album a in add)
                    ret.Add(a);
            }
            if (dirs.Length == 0)
            {
                string[] files = Directory.GetFiles(dir,"*.mp3");
                if (files.Length > 0)
                {
                    trackCount += files.Length;
                    string dirname = Path.GetDirectoryName(dir);
                    try
                    {
                        ret.Add(new Album(dir.Substring(dirname.Length + 1)));
                    }
                    catch
                    {
                        Console.WriteLine(dir);
                    }
                    if (dir.IndexOf("(OST)") != -1)
                        if (dir.IndexOf("+OST") == -1)
                            Console.WriteLine(dir + " Needs to be moved");
                }
            }
            return ret;
        }
    }
    public class Distance
    {
        /// <summary>
        /// Compute Levenshtein distance
        /// </summary>
        /// <param name="s">String 1</param>
        /// <param name="t">String 2</param>
        /// <returns>Distance between the two strings.
        /// The larger the number, the bigger the difference.
        /// </returns>
        public int LD(string s, string t)
        {
            int n = s.Length; //length of s
            int m = t.Length; //length of t
            int[,] d = new int[n + 1, m + 1]; // matrix
            int cost; // cost
            // Step 1
            if (n == 0) return m;
            if (m == 0) return n;
            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 0; j <= m; d[0, j] = j++) ;
            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    cost = (t.Substring(j - 1, 1) == s.Substring(i - 1, 1) ? 0 : 1);
                    // Step 6
                    d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                              d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}
