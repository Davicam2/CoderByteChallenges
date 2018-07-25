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
            Console.WriteLine("This Problem is called ClosestEnemyII\r\n");

            Console.WriteLine("-The program will take in a \"2D\" array of strings containing many zero's, one one, and one two. \r\n" +
                              "once the \"ChessBoard\" has been input it will give you the sortest path between the one and the two.");


            Console.WriteLine(String.Format("\r\n |{0}| \r\n |{1}| \r\n |{2}| \r\n |{3}| \r\n", board[0], board[1], board[2], board[3]));
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
            return "the nearest enemy is - " + closest  + " moves away.";
        }                
    }
}
