using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSquares
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("-This problem is called MaximalSquares.\r\n");

            Console.WriteLine("-For this program you will enter a series of 1s and 0s that go into a 4 row 2D format for parsing.\r\n" +
                              " Once they have been entered you will be told the amount of square sections of 1s are present in the array.\r\n" +
                              "-Please enter a series of 1s and 0s, then press enter to move to the next row in the array.\r\n" +
                              "-keep it to 50 chars plz!");
            Console.WriteLine("enter nuber of columns you want. *LIMIT 50!*");
            int.TryParse(Console.ReadLine(), out int columns);
            string[] strArr = new string[columns];
            
            Console.WriteLine("________________________________________________");

            int i = 0;
            while (i < strArr.Length)
            {
                strArr[i] = Console.ReadLine();
                i++;
            }


            Console.WriteLine("\r\n" + "the maximum number of squares is-" + MaximalSquares(strArr));
            Console.ReadLine();
        }

        //========================================================================\\
        public static string MaximalSquares(string[] strArr)
        {
            int _j = 0;
            int _i = 0;
            int count = 0;
            
            char[,] charArr = new char[50, 50];

            foreach (string row in strArr)
            {
                _i = 0;
                
                foreach (char digit in row)
                {
                    charArr[_i, _j] = digit;
                    _i++;
                }
                _j++;
            }

            for (int j = 0; j < _j; j++)
            {
                for (int i = 0; i < _i; i++)
                {
                    if (charArr[i, j] == '1')
                    {
                        count += DiagonalCheck(charArr, 0, i, j);
                    }
                }
            }
            return count.ToString();
        }
        //========================================================================//
        //========================================================================\\
        static int DiagonalCheck(char[,] arr, int count, int i, int j)
        {
            int ii = i;
            int jj = j;
            while (j < arr.GetUpperBound(1) && i < arr.GetUpperBound(0))
            {
                if (arr[i + 1, j + 1] == '1')
                {
                    if (CheckLeft(arr, i + 1, j + 1, ii) && CheckUp(arr, i + 1, j + 1, jj))
                    {
                        count++;
                        i++;
                        j++;
                    }
                    else
                    {
                        return count;
                    }
                }
                else
                    return count;
            }
            return count;
        }
        //========================================================================//
        //========================================================================\\
        static bool CheckUp(char[,] arr, int i, int j, int stop)
        {
            if (arr[i, j] != '1')
                return false;
            if (j > stop)
                return CheckUp(arr, i, j - 1, stop);
            return true;
        }
        //========================================================================//
        //========================================================================\\
        static bool CheckLeft(char[,] arr, int i, int j, int stop)
        {
            if (arr[i, j] != '1')
                return false;
            if (i > stop)
                return CheckLeft(arr, i - 1, j, stop);
            return true;
        }
        //========================================================================//
    }
}
