using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlgorithmExercises
{
    public class ClassTest
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var nums3 = Enumerable.Range(3, 4);

            List<int> result = new List<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!map.ContainsKey(nums1[i]))
                    map.Add(nums1[i], 0);
            }

            for (int j = 0; j < nums2.Length; j++)
            {
                if (map.ContainsKey(nums2[j]))
                    map[nums2[j]] = 1;
            }

            foreach (KeyValuePair<int, int> kvp in map)
            {
                if (kvp.Value == 1)
                    result.Add(kvp.Value);
            }

            return result.ToArray();
        }

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int[] sortArray;
            List<int> result;

            sortArray = new int[nums.Length + 1];
            result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                sortArray[nums[i]] = nums[i];
            }

            for (int j = 0; j < sortArray.Length; j++)
            {
                if (sortArray[j] != 0 && j != 0)
                    continue;

                result.Add(j);
            }

            return result;
        }

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            int[] ans = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                map.Add(nums1[i], i);
                ans[i] = -1;
            }

            for (int j = 0; j < nums2.Length; j++)
            {
                var current = nums2[j];

                while (stack.Count != 0 && current > stack.Peek())
                {
                    var peekElement = stack.Pop();
                    ans[map[peekElement]] = current;
                }

                if (!map.ContainsKey(current))
                    continue;

                stack.Push(current);
            }

            return ans;
        }

        public string[] FindWords(string[] words)
        {
            string row1 = "qwertyuiop";
            string row2 = "asdfghjkl";
            string row3 = "zxcvbnm";

            Dictionary<char, int> mapRow1 = new Dictionary<char, int>();
            Dictionary<char, int> mapRow2 = new Dictionary<char, int>();
            Dictionary<char, int> mapRow3 = new Dictionary<char, int>();

            string[] rows = { row1, row2, row3 };
            List<string> result = new List<string>();

            Dictionary<char, int>[] keyBoard = new Dictionary<char, int>[]{
                mapRow1,
                mapRow2,
                mapRow3,
            };

            for (int i = 0; i < rows.Length; i++)
            {
                char[] r = rows[i].ToCharArray();

                for (int j = 0; j < r.Length; j++)
                {
                    keyBoard[i].Add(r[j], i);
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                var lower = words[i].ToLower();
                char[] word = lower.ToCharArray();
                bool hasAllLetters = true;

                int currentKeyBoard = 0;

                for (int j = 0; j < keyBoard.Length; j++)
                {
                    if (!keyBoard[j].ContainsKey(word[0]))
                        continue;
                    currentKeyBoard = j;
                }

                for (int k = 0; k < word.Length; k++)
                {
                    if (!keyBoard[currentKeyBoard].ContainsKey(word[k]))
                    {
                        hasAllLetters = false;
                        break;
                    }
                }

                if (hasAllLetters)
                    result.Add(words[i]);
            }

            return result.ToArray();
        }

        public bool IsPalindrome(string s)
        {
            string s1 = Regex.Replace(s, @"[^a-zA-Z0-9]", "");
            string s2 = s1.ToLower();

            int i = 0;
            int j = s2.Length - 1;

            while (j > i)
            {
                if (s2[i] != s2[j])
                    return false;

                j--;
                i++;
            }

            return true;

        }

        public bool ValidPalindrome(string s)
        {
            string s1 = s.ToLower();

            int i = 0;
            int j = s1.Length - 1;

            while (j > i)
            {
                if (s1[i] != s1[j])
                {
                    return IsValidPalindrome(s1, i + 1, j) || IsValidPalindrome(s1, i, j - 1); ;
                }

                i++;
                j--;
            }

            return true;
        }

        private bool IsValidPalindrome(string s, int i, int j)
        {
            while (j > i)
            {
                if (s[i] != s[j])
                    return false;

                i++;
                j--;
            }

            return true;
        }


        public bool IsValidParentheses(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    stack.Push(s[i]);
                    continue;
                }
                else if (stack.Count == 0)
                    return false;

                char peek = stack.Pop();

                if (peek == '(' && s[i] != ')')
                    return false;
                if (peek == '[' && s[i] != ']')
                    return false;
                if (peek == '{' && s[i] != '}')
                    return false;
            }

            if (stack.Count == 0)
                return true;

            return false;
        }

        public int BootsProblem(string[] boots)
        {
            Dictionary<int, int> leftBoots = new Dictionary<int, int>();
            Dictionary<int,int> rightBoots = new Dictionary<int, int>();
            int count = 0;
            int min = 0;

            for (int i = 0; i < boots.Length; i++)
            {
                string[] pair = GetBoot(boots[i]);
                int size = int.Parse(pair[0]);

                if (pair[1] == "D")
                {
                    if (!rightBoots.ContainsKey(size))
                    {
                        rightBoots.Add(size, 1);
                    }
                    else
                        rightBoots[size] += 1;
                }
                else
                {
                    if (!leftBoots.ContainsKey(size))
                    {
                        leftBoots.Add(size, 1);
                    }
                    else
                        leftBoots[size] += 1;
                }
            }

            foreach (KeyValuePair<int, int> kvp in leftBoots)
		    {
                if (rightBoots.ContainsKey(kvp.Key))
                {
                    if (kvp.Value == rightBoots[kvp.Key])
                    {
                        count += kvp.Value;
                        continue;
                    }

                    min = rightBoots[kvp.Key] < kvp.Value ? rightBoots[kvp.Key] : kvp.Value;             
                    count += min;                  
                }      
            }

            return count;
        }

        public string[] GetBoot(string bootPair)
        {
            string[] pair = bootPair.Split(" ");
            return pair;
        }

        
        // 1 2 3 4 5 6
        public void CardProblem(int deckSize)
        {
            Queue<int> deck = new Queue<int>();
            List<int> giveAway = new List<int>();
            int count = deckSize;

            for(int i = 1; i <= deckSize; i++)
            {
                deck.Enqueue(i);
            }

            while(count > 1)
            {
                int topCard = deck.Dequeue();
                giveAway.Add(topCard);
                int newTopCard = deck.Dequeue();
                deck.Enqueue(newTopCard);
                count--;
            }

            Console.Write("GivaAway Cards: ");

            for (int i = 0; i < giveAway.Count; i++) 
            {
                if(i == giveAway.Count - 1) 
                {
                    Console.Write(giveAway[i]);
                    Console.WriteLine("Developer Card: " + deck.Peek());
                }

                Console.Write(giveAway[i] + ",");
            }
        }
    }
}
