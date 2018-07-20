using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleBalancing
{
    class Program
    {
        int[] _weights, _scales;

        static void Main(string[] args)
        {
            string scales = "[13, 4]";
            string weights = "[1, 2, 3, 6, 14]";
            int[] Aweights = { 1, 2, 3, 10, 14 };
            int[] Ascales = { 13, 4 };

            Console.WriteLine(BalanceScales(Ascales, Aweights));
            Console.ReadKey();

        }

        static string BalanceScales(int[] scales, int[] weights)
        {
            int difference = Math.Abs(scales[0] - scales[1]);

            for (int i = 0; i < weights.Length - 1; i++)
            {
                for (int j = i + 1; j < weights.Length; j++)
                {
                    if (weights[i] == difference)
                        return weights[i].ToString();
                    else if (weights[i] + weights[j] == difference)
                        return (weights[i].ToString() + "," + weights[j].ToString());
                    else if (weights[i] + difference == weights[j])
                        return (weights[i].ToString() + ", " + weights[j].ToString());
                }
            }

            return "No weights balance the scales";
        }

    }
}
