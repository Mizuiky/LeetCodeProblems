namespace ListaExercicios
{
    internal class LongestCommonPrefixExercise
    {
        private string _commonString = "";

        public string LongestCommonPrefix(string[] strs)
        {
            string startWord = strs[0];

            for (int i = 0; i < startWord.Length; i++)
            {
                if (CheckLetter(startWord[i], strs, i))
                {
                    _commonString += startWord[i];
                    continue;
                }

                break;
            }

            return _commonString;
        }

        private bool CheckLetter(char letter, string[] words, int index)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (index > (words[i].Length - 1) || letter != GetFirstChar(words[i], index))
                    return false;
            }

            return true;
        }

        private char GetFirstChar(string word, int index)
        {
            char[] wordArray = word.ToCharArray();

            return wordArray[index];
        }
    }
}
