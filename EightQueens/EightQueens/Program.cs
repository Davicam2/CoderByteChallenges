using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] queens = {"(2,1)","(5,3)","(6,3)","(8,4)","(3,4)","(1,8)","(7,7)","(5,8)"};

            Console.WriteLine(QueenFight(queens));
            Console.ReadLine();
        }

        static string QueenFight(string[] queens)
        {
            int[] x = new int[8];
            int[] y = new int[8];
            int count = 0;            

            foreach (string queen in queens)
            {                
                int.TryParse(queen.ElementAt(1).ToString(), out int xx);
                int.TryParse(queen.ElementAt(3).ToString(), out int yy);
                x[count] = xx;
                y[count] = yy;
                count++;                
            }

            for (int i = 0; i < queens.Length; i++)
            {
                for (int j = i + 1; j < queens.Length - 1; j++)
                {
                    if (x[i] == x[j] || y[i] == y[j])
                        return "(" + x[i] + "," + y[i] + ")";
                    if (x[i] - y[i] == x[j] - y[j])
                        return "(" + x[i] + "," + y[i] + ")";
                }
            }
            return "NOH";
        }
    }
}
