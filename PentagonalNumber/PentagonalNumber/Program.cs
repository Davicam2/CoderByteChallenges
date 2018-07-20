using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentagonalNumber
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("number of dots = " + PentNumber(int.Parse(Console.ReadLine())));
            Console.ReadKey();            
        }
        static int PentNumber(int num){
            int sum = 1;
            int prev = 0;
            if (num < 2)
                return num;
            for (int i = 2; i <= num; i++){
                prev += 5;
                sum += prev;
            }
            return sum;
        }
    }
}
