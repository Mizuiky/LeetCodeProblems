using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaExercicios
{
    internal class RomanToIntExercise
    {
        private Dictionary<char, int> _romanValues;

        public int RomanToInt(string s)
        {
            int sum = 0;
            char[] arr = new char[s.Length];

            _romanValues = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            arr = s.ToCharArray();
            int nextSymbol = 0;
            int currentSymbol = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                    nextSymbol = 0;
                else
                    nextSymbol = GetNumber(arr[(i + 1)]);

                currentSymbol = GetNumber(arr[(i)]);

                if (nextSymbol > currentSymbol)
                {
                    sum += (nextSymbol - currentSymbol);
                    i += 1;
                }
                else
                    sum += currentSymbol;
            }

            return sum;
        }

        private int GetNumber(char s)
        {
            return _romanValues[s];
        }
    }
}
