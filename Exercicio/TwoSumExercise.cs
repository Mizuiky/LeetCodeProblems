namespace ListaExercicios
{
    internal class TwoSumExercise
    {
        private int[] _result = new int[2];
        private int _sum = 0;
        private bool _hasFindResult = false;

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    _sum = nums[i] + nums[j];

                    if (_sum == target)
                    {
                        _result = new int[] { i, j };
                        _hasFindResult = true;
                        break;
                    }
                }

                if (_hasFindResult)
                    break;
            }

            return _result;
        }
    }
}
