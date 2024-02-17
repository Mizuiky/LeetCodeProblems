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
        }

    }
}
