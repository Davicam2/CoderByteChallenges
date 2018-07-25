using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentagonalNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-This Problem is called Pentagonal Numbers.\r\n");

            Console.WriteLine("-The Problem is meant to simulate a figure of dots that starts with one and grows outward  \r\n" +
                              "in the form of 5 additional dots each layer that is added. You input the nuber of layers of dots \r\n" +
                              "and the program will tell you the total amount of dots that exist once that layer is added.\r\n");
            Console.Write("Please select the number of layers in the pentagonal structure:");
            int.TryParse(Console.ReadLine(), out int layers);

            Console.WriteLine("\r\nTotal Number of Dots = " +  PentNumber(layers));
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
