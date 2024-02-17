using System.Linq;

namespace ListaExercicios
{
    internal class ValidParenthesesExercise
    {
        private Stack<char> _parentheses;
        char stackP;

        public bool IsValid(string s)
        {
            char[] p = s.ToCharArray();
            _parentheses = new Stack<char>();

            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '(' || p[i] == '{' || p[i] == '[')
                    _parentheses.Push(p[i]);
                else
                {
                    if (_parentheses.Count == 0)
                        return false;
                    
                    stackP = _parentheses.Pop();

                    if (p[i] == ')' && stackP != '(')
                        return false;

                    else if (p[i] == '}' && stackP != '{')
                        return false;

                    else if (p[i] == ']' && stackP != '[')
                        return false;
                }
            }

            if (_parentheses.Count > 0)
                return false;

            return true;
        }
    }
}
