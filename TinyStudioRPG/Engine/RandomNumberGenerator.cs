namespace Engine
{
    public static class RandonNumberGenerator
    {
        private static readonly Random _generator = new();

        public static int SimpleNumberBetween(int minValue, int maxValue)
        {
            return _generator.Next(minValue, maxValue + 1);
        }
    }
}
