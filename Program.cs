namespace Week11ChallengeLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 1
            Console.WriteLine("Part 1");
            int[] nums = { 2, 0, 1, 2, 0, 1 };
            Console.WriteLine("Unsorted colors: ");
            Console.WriteLine(string.Join(",", nums));

            Console.WriteLine("\nSorted colors: ");
            SortColors(nums);
            Console.WriteLine(string.Join(",", nums));
            #endregion

            Console.WriteLine("\nPart 2");
            string text = "loonbalxballpoon";

            int maxBalloons = MaxNumberOfBalloons(text);

            Console.WriteLine($"Number of balloons in {text}: {maxBalloons}");

        }

        public static void SortColors(int[] nums)
        {
            int low = 0;
            int mid = 0;
            int high = nums.Length - 1;

            while (mid <= high)
            {
                if (nums[mid] == 0)
                {
                    // Move 0 to the beginning
                    int temp = nums[low];
                    nums[low] = nums[mid];
                    nums[mid] = temp;

                    low++;
                    mid++;
                }
                else if (nums[mid] == 1)
                {
                    // 1 is already in the correct section
                    mid++;
                }
                else
                {
                    // Move 2 to the end
                    int temp = nums[mid];
                    nums[mid] = nums[high];
                    nums[high] = temp;

                    high--;
                }
            }
        }

        public static int MaxNumberOfBalloons(string text)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();

            // Count occurrences of each character
            foreach (char c in text)
            {
                if (count.ContainsKey(c))
                {
                    count[c]++;
                }
                else
                {
                    count[c] = 1;
                }
            }

            // Get the frequency of each required character
            int b = count.GetValueOrDefault('b', 0);
            int a = count.GetValueOrDefault('a', 0);
            int l = count.GetValueOrDefault('l', 0) / 2;
            int o = count.GetValueOrDefault('o', 0) / 2;
            int n = count.GetValueOrDefault('n', 0);

            return Math.Min(
                Math.Min(b, a),
                Math.Min(Math.Min(l, o), n)
            );
        }
    }
}
