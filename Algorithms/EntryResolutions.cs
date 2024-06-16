using AlgorithmExercises;

namespace ListaExercicios
{
    public class EntryResolutions
    {   
        public static void Main(string[]args)
        {
            #region Two Sum 7 feb 2024

            int[] nums = { 1, 2, 3 };
            int target = 5;

            TwoSumExercise t = new TwoSumExercise();
            var result1 = t.TwoSum(nums, target);
            Console.WriteLine($"Result{result1}");

            #endregion

            #region Roman To Int 9 feb 2024

            RomanToIntExercise r = new RomanToIntExercise();
            var result2 = r.RomanToInt("XXIV");

            Console.WriteLine($"Result{result2}");

            #endregion

            #region Longest common prefix string amongst an array of strings 12 feb 2024

            string[] words = { "fly", "flow", "flee" };

            LongestCommonPrefixExercise l = new LongestCommonPrefixExercise();
            var result3 = l.LongestCommonPrefix(words);

            Console.WriteLine($"Result{result3}");

            #endregion

            #region Valid Parentheses 17 feb 2024

            ValidParenthesesExercise v = new ValidParenthesesExercise();
            bool result4 = v.IsValid("([{}]])");
            Console.WriteLine($"Result{result4}");

            result4 = v.IsValid("([]");
            Console.WriteLine($"Result{result4}");

            result4 = v.IsValid("[([([[}])])]");
            Console.WriteLine($"Result{result4}");

            result4 = v.IsValid("}{}");
            Console.WriteLine($"Result{result4}");

            result4 = v.IsValid("()");
            Console.WriteLine($"Result{result4}");


            result4 = v.IsValid("()[]{}");
            Console.WriteLine($"Result{result4}");

            result4 = v.IsValid("(]");
            Console.WriteLine($"Result{result4}");

            #endregion

            #region Fibonacci

            Console.WriteLine("Fibonacci");

            Fibonacci f = new Fibonacci();
            //f.fibonnaci1(10);

            Console.WriteLine($"O {6}-ésimo número Fibonacci é: {f.fibonnaciRecursivo(6)}");
            f.mistNumber(6);
            #endregion

            Console.WriteLine("TESTE");
            ClassTest test = new ClassTest();
            int[] nums1 = { 4,1,2 };
            int[] nums2 = { 1,3,4,2 };
            string[] words2 = { "Hello", "Alaska", "Dad", "Peace" };

            test.Intersection(nums1, nums2);
            test.NextGreaterElement(nums1, nums2);
            test.FindWords(words2);
            test.IsPalindrome("A man, a plan, a canal: Panama");

            test.ValidPalindrome("abca");
            test.IsValidParentheses("(]");

            string[] pairs = { "40 D", "41 E", "41 D", "40 E" };
            test.BootsProblem(pairs);
            test.CardProblem(19);
        }
    }
}
