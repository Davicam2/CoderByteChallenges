using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestEnemyII
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] board = {  "1000",
                                "0000",
                                "0020",
                                "0000" };

            Console.WriteLine(CheckNearest(board));
            Console.ReadKey();
        }

        static string CheckNearest(string[] board)
        {
            int i = 1, j = 1;
            int myX = 1, myY = 1;
            int eX, eY;
            int closest = board.Length * board[0].Count(), posibleClosest = 0;
            bool wrapX = false, wrapY = false;

            foreach(string row in board)
            {
                i = 1;
                foreach(char pos in row)
                {
                    if (pos == '1')
                    {
                        myX = i;
                        myY = j;
                        break;
                    }                 
                    i++;
                }
                j++;
            }

            i = 1;
            j = 1;

            foreach (string row in board)
            {
                i = 1;
                foreach (char pos in row)
                {
                    if (pos == '2')
                    {
                        eX = i;
                        eY = j;
                        wrapX = Math.Abs(myX - eX) > board[0].Count() / 2 ? true : false;
                        wrapY = Math.Abs(myY - eY) > board.Length / 2 ? true : false;
                        if (wrapX)
                            posibleClosest += board[0].Count() - Math.Abs(myX - eX);
                        else
                            posibleClosest += Math.Abs(myX - eX);
                        if (wrapY)
                            posibleClosest += board.Length - Math.Abs(myY - eY);
                        else
                            posibleClosest += Math.Abs(myY - eY);

                        if (posibleClosest < closest)
                            closest = posibleClosest;                                                            
                    }
                    i++;
                }
                j++;
            }
            return "the nearest enemy is - " + closest ;
        }                
    }
}
