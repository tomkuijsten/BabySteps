using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation
{
    public static class Randomizer
    {
        private static Random _randomizer;

        static Randomizer()
        {
            _randomizer = new Random();
        }

        public static int NextInRange(IntRange range)
        {
            return _randomizer.Next(range.Min, range.Max+1);
        }

        public static double NextInRange(DoubleRange range)
        {
            var randomized = _randomizer.NextDouble();
            var spectrum = range.Max - range.Min;
            var spectrumRandom = spectrum * randomized;
            var randomWithinRange = spectrumRandom + range.Min;

            return randomWithinRange;
        }

        public static double Vary(DoubleRange percentageRange, double originalValue)
        {
            var random = _randomizer.NextDouble();
            var scope = percentageRange.Max - percentageRange.Min;
            var variationFactor = (scope * random) + percentageRange.Min;

            return variationFactor * originalValue;
        }
    }
}
