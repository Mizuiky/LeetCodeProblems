using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;

public class ArrayExercices : MonoBehaviour
{
    private Dictionary<char, int> romanValues;
    //-----------------------------------------
    private int[] result = new int[2];
    private int sum = 0;
    private bool hasFindResult = false;
    //-----------------------------------------
    /*Extra exercise because you confuse the wording of 3 */
    private List<string> possiblePrefixs;
    private List<int> substringPositionsList;
    private List<string> acceptedPrefix;
    //-----------------------------------------
    private string commonString = "";

    void Start()
    {
        string[] words = new string[] { "aB", "A" };
        LongestCommonPrefix(words);
    }

    #region Two Sum 7 feb 2024
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 1; j < nums.Length; j++)
            {
                sum = nums[i] + nums[j];

                if (sum == target)
                {
                    result = new int[] { i, j };
                    hasFindResult = true;
                    break;
                }
            }

            if (hasFindResult)
                break;
        }

        return result;
    }
    #endregion

    #region Roman To Int 9 feb 2024
    public int RomanToInt(string s)
    {
        int sum = 0;
        char[] arr = new char[s.Length];

        romanValues = new Dictionary<char, int>
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
        return romanValues[s];
    }

    #endregion

    #region Longest Prefix - array of strings cant have only one word and they cant be only single char 12 feb 2024
    public string LongestPrefix(string[] strs)
    {
        substringPositionsList = new List<int>();
        possiblePrefixs = new List<string>();
        acceptedPrefix = new List<string>();
        bool hasPossibleResults = false;
        int nextWordIndex = 0;


        for (int i = 0; i < strs.Length; i++)
        {
            if(strs.Length < 1)
                break;
              
            nextWordIndex = i + 1;
            if (nextWordIndex == strs.Length)
                break;

            if (possiblePrefixs.Count > 0)
            {
                hasPossibleResults = CheckExistentPrefix(strs[nextWordIndex].ToLower());

                if (!hasPossibleResults)
                {
                    possiblePrefixs.Clear();
                    break;
                }
            }
            else
                CompareWords(strs[i].ToLower(), strs[(i + 1)].ToLower());

            if (possiblePrefixs.Count == 0)
                break;
        }
       
        if (possiblePrefixs.Count == 0)
        {
            //Console.WriteLine("There is no common prefix among the input strings");
            return "";
        }
        else
        {
            var bigger = GetBiggerPrefix(possiblePrefixs);
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
        acceptedPrefix.Clear();

        for(int i = 0; i < possiblePrefixs.Count; i++)
        {
            var substring = CheckSubstring(word, possiblePrefixs[i]);
            if(substring != "")
                acceptedPrefix.Add(substring);
        }

        if (acceptedPrefix.Count > 0)
        {
            possiblePrefixs.Clear();

            for (int i = 0; i < acceptedPrefix.Count; i++)
            {
                possiblePrefixs.Add(acceptedPrefix[i]);
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

        if(nextStrs.Length <= currentStrs.Length)
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
            if (possiblePrefixs.Count > 0)
            {
                possiblePrefixs.Clear();
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
                    possiblePrefixs.Add(subString);

                    int position = next.IndexOf(subString);

                    substringPositionsList.Clear();

                    while (position != -1)
                    {
                        substringPositionsList.Add(position);
                        position = next.IndexOf(subString, position + 1);
                    }

                    letterPosition = i + 2;

                    for (int k = 0; k < substringPositionsList.Count; k++)
                    {
                        if (substringPositionsList[k] + 2 >= next.Length)
                            break;

                        position = substringPositionsList[k] + 2;

                        for (int j = position; j < next.Length; j++)
                        {
                            nextLetterPosition = j;

                            if (letterPosition == current.Length)
                                break;

                            currentLetter = current[(letterPosition)];
                            nextLetter = next[nextLetterPosition];

                            if (currentLetter == nextLetter)
                            {
                                auxString = possiblePrefixs.Last() + currentLetter;
                                possiblePrefixs.Add(auxString);
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
        possiblePrefixs.Distinct();
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

    #region Longest common prefix string amongst an array of strings 12 feb 2024

    public string LongestCommonPrefix(string[] strs)
    {
        string startWord = strs[0];

        for (int i = 0; i < startWord.Length; i++)
        {
            if (CheckLetter(startWord[i], strs, i))
            {
                commonString += startWord[i];
                continue;
            }

            break;
        }

        return commonString;
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

    #endregion


}
