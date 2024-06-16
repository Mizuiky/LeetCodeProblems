using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmExercises
{
    public class Fibonacci
    {
        public int fiboNumber;
        public int[] array;
        public int index = 0;
        public int count = 0;
        public int iteracoes = 10;

        public void fibonnaci1(int iteracoes)
        {
            int[] array = new int[iteracoes];

            for (int i = 0; i < iteracoes; i++)
            {
                if (count == iteracoes)
                    break;

                if (i == 0)
                {
                    array[i] = 0;
                    Console.Write(0 + "\n");
                    continue;
                }
                else if (i == 1)
                {
                    array[i] = 1;
                    Console.Write(1 + "\n");
                    continue;
                }

                fiboNumber = array[i - 1] + array[i - 2];
                array[i] = fiboNumber;

                Console.Write(fiboNumber + "\n");
            }
        }

        public void Fibonacci2(int iteracoes)
        {
            int previous1 = 0;
            int previous2 = 0;
            int sum = 0;

            for(int i = 0; i < iteracoes; i++)
            {
                previous1 = i - 1;
                previous2 = i - 2;

                if (previous1 < 1 || previous2 < 1)
                    continue;

                sum = previous1 + previous2;
            }
        }

        public int fibonnaciRecursivo(int n)
        {
            if (n <= 1)
                return n;

            return (fibonnaciRecursivo(n - 1) + fibonnaciRecursivo(n - 2));
        }

        public int mistNumber(int n)
        {
            int result = 0;

            for(int outer = n/2; outer <= n; outer++)
            {
                for(int inner = 2; inner <=n; inner = inner * 2)
                {
                    result = result + n / 2;
                }
            }

            return result;
        }
    }
}
