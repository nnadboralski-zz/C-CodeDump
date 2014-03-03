using System;
using System.Collections.Generic;
using System.Text;

namespace Probability
{
    class Program
    {
        static Random m_r;
        static void Main(string[] args)
        {
            m_r = new Random();
            int dice = Convert.ToInt32(args[0]);
            int sides = Convert.ToInt32(args[1]);
            int setSize = Convert.ToInt32(args[2]);

            for (int i = 1; i <= dice; i++)
            {
            }



            /*List<List<double>> results = ComputeProbability(dice, sides, setSize, reps);
            int startNum = dice;
            foreach (List<double> set in results)
            {
                Console.Write(startNum.ToString() + ": ");
                foreach (double d in set)
                {
                    Console.Write(d.ToString() + "%, ");
                }
                Console.WriteLine();
                startNum++;
            }
             */

            /*List<List<int>> diceSets = new List<List<int>>();

            for (int k = 1; k <= reps; k++)
            {
                List<int> diceSet = new List<int>();            
                for (int j = 1; j <= setSize; j++)
                {
                    int total = 0;
                    for (int i = 1; i <= dice; i++)
                    {
                        total += m_r.Next(1, sides+1);
                    }
                    diceSet.Add(total);
                }
                diceSets.Add(diceSet);
            }
            for (int n = dice; n < dice * sides; n++)
            {
                foreach (List<int> l in diceSets)
                {
                    foreach (int m in l)
                    {
                        Console.Write(m.ToString() + " ");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
             */

        }

        static List<int> RollDice(int dice, int sides, int setSize)
        {           
            List<int> singleSet = new List<int>();
            for (int j = 1; j < setSize; j++) {
                int total = 0;
                for (int i = 1; i <= dice; i++)
                {
                    total += m_r.Next(1,sides);
                }
                singleSet.Add(total);
            }
            return singleSet;
        }

        static double NumberProbability(List<int> dRolls, int gtNum)
        {
            int count = 0;
            foreach (int i in dRolls)
            {
                if (i >= gtNum) count++;
            }
            return count * 100 / (double)dRolls.Count;
        }

        static List<List<double>> ComputeProbability(int dice, int sides, int setSize, int reps)
        {
            List<List<double>> ret = new List<List<double>>();
            List<List<int>> sets = new List<List<int>>();
            for (int i = 0; i < reps; i++)
            {
                sets.Add(RollDice(dice,sides,setSize));
            }
            for (int i = dice; i <= dice * sides; i++)
            {
                List<double> results = new List<double>();
                for (int j = 0; j < reps; j++)
                {
                    results.Add(NumberProbability(sets[j], i));
                }
                ret.Add(results);
            }
            return ret;
        }
    }
}
