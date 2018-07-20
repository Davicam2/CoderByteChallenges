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
            string[] strArr = new string[4];
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
            char[,] charArr = new char[strArr[0].Count(), strArr.Length];

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
