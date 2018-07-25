using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessboardTraveling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n-This Problem is called ChessBoardTraveling.\r\n");

            Console.WriteLine("-The program takes in two positions on a 2D plane and outputs the amount of possible routs \r\n" +
                          "from the first position to the second moving in any order of up and right cominations.");
            
            Console.Write( "\r\n-The amount of possible routs is " + ChessboardRouts("(2 2)(4 5)"));
            Console.ReadKey();
        }

        static string ChessboardRouts(string positions)
        {
            int myX = int.Parse(positions.ElementAt(1).ToString());
            int myY = int.Parse(positions.ElementAt(3).ToString());
            int targetX = int.Parse(positions.ElementAt(6).ToString());
            int targetY = int.Parse(positions.ElementAt(8).ToString());

            int nFact = Math.Abs((myX - targetX)) + Math.Abs((myY - targetY));
            int rFact = Math.Abs(myX - targetX);
                  
            int routs = 0;                       
            routs = Exponentiate(nFact,1) / (Exponentiate(rFact,1) * (Exponentiate(nFact - rFact,1)));            
            return routs.ToString();
        }

        static int Exponentiate(int i, int tot)
        {
            if (i > 1)
            {
                tot *= i;
                return Exponentiate(i - 1, tot);
            }
            else
                return tot;
        }
    }
}
