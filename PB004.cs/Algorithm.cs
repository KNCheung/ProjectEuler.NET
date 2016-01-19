namespace ProjectEuler
{
    public class Algorithm : IAlgorithm
    {
        public string Compute()
        {
            int max = int.MinValue;
            for (int i = 100; i <= 999; i++)
                for (int j = i; j <= 999; j++)
                    if (TroyMath.isPalindrome((i * j).ToString()))
                        if (i * j > max)
                            max = i * j;
            return max.ToString();
        }

        public bool Prepare()
        {
            return true;
        }
    }
}
