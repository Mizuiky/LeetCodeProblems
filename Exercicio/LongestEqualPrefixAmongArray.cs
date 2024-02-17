namespace ListaExercicios
{
    internal class LongestEqualPrefixAmongArray
    {
        /*Extra exercise because I confuse the meaning of prefix */
        private List<string> _possiblePrefixs;
        private List<int> _substringPositionsList;
        private List<string> _acceptedPrefix;

        #region [Extra] Longest Prefix - array of strings cant only have one word and they cant be only single char 12 feb 2024
        public string LongestPrefix(string[] strs)
        {
            _substringPositionsList = new List<int>();
            _possiblePrefixs = new List<string>();
            _acceptedPrefix = new List<string>();
            bool hasPossibleResults = false;
            int nextWordIndex = 0;


            for (int i = 0; i < strs.Length; i++)
            {
                if (strs.Length < 1)
                    break;

                nextWordIndex = i + 1;
                if (nextWordIndex == strs.Length)
                    break;

                if (_possiblePrefixs.Count > 0)
                {
                    hasPossibleResults = CheckExistentPrefix(strs[nextWordIndex].ToLower());

                    if (!hasPossibleResults)
                    {
                        _possiblePrefixs.Clear();
                        break;
                    }
                }
                else
                    CompareWords(strs[i].ToLower(), strs[(i + 1)].ToLower());

                if (_possiblePrefixs.Count == 0)
                    break;
            }

            if (_possiblePrefixs.Count == 0)
            {
                //Console.WriteLine("There is no common prefix among the input strings");
                return "";
            }
            else
            {
                var bigger = GetBiggerPrefix(_possiblePrefixs);
                return bigger;
            }
        }

        private string CheckSubstring(string word, string substring)
        {
            if (word.Contains(substring))
                return substring;
            return "";
        }

        private bool CheckExistentPrefix(string word)
        {
            _acceptedPrefix.Clear();

            for (int i = 0; i < _possiblePrefixs.Count; i++)
            {
                var substring = CheckSubstring(word, _possiblePrefixs[i]);
                if (substring != "")
                    _acceptedPrefix.Add(substring);
            }

            if (_acceptedPrefix.Count > 0)
            {
                _possiblePrefixs.Clear();

                for (int i = 0; i < _acceptedPrefix.Count; i++)
                {
                    _possiblePrefixs.Add(_acceptedPrefix[i]);
                }

                return true;
            }

            return false;
        }

        private void CompareWords(string currentStrs, string nextStrs)
        {
            int i = 0;
            int letterPosition = 0;
            int nextLetterPosition = 0;

            char currentLetter;
            char nextLetter;

            string subString = "";
            string acceptableSubstring = "";
            string current = "";
            string next = "";
            string auxString = "";

            if (nextStrs.Length <= currentStrs.Length)
            {
                current = nextStrs;
                next = currentStrs;
            }
            else
            {
                current = currentStrs;
                next = nextStrs;
            }

            if (current.Length == 1)
            {
                if (_possiblePrefixs.Count > 0)
                {
                    _possiblePrefixs.Clear();
                }
            }
            else
            {
                for (i = 0; i < current.Length; i++)
                {

                    if ((i + 1) == current.Length)
                        break;

                    subString = current.Substring(i, 2);

                    acceptableSubstring = CheckSubstring(next, subString);

                    if (acceptableSubstring != "")
                    {
                        _possiblePrefixs.Add(subString);

                        int position = next.IndexOf(subString);

                        _substringPositionsList.Clear();

                        while (position != -1)
                        {
                            _substringPositionsList.Add(position);
                            position = next.IndexOf(subString, position + 1);
                        }

                        letterPosition = i + 2;

                        for (int k = 0; k < _substringPositionsList.Count; k++)
                        {
                            if (_substringPositionsList[k] + 2 >= next.Length)
                                break;

                            position = _substringPositionsList[k] + 2;

                            for (int j = position; j < next.Length; j++)
                            {
                                nextLetterPosition = j;

                                if (letterPosition == current.Length)
                                    break;

                                currentLetter = current[(letterPosition)];
                                nextLetter = next[nextLetterPosition];

                                if (currentLetter == nextLetter)
                                {
                                    auxString = _possiblePrefixs.Last() + currentLetter;
                                    _possiblePrefixs.Add(auxString);
                                    letterPosition++;
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
            }

            RemoveDuplicateEntries();
        }

        private void RemoveDuplicateEntries()
        {
            _possiblePrefixs.Distinct();
        }

        private string GetBiggerPrefix(List<string> prefixs)
        {
            string previous = "";
            string current = "";
            string biggerResult = "";

            for (int i = 0; i < prefixs.Count; i++)
            {
                current = prefixs[i];

                if (current.Length > previous.Length)
                    biggerResult = current;
                else
                    biggerResult = previous;

                previous = current;
            }

            return biggerResult;
        }
        #endregion
    }
}


