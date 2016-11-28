using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class RandomWeightModifier : IWeightModifier
    {
        private DoubleRange _range;

        private RandomWeightModifier() { }

        public static RandomWeightModifier Create(DoubleRange range)
        {
            var instance = new RandomWeightModifier()
            {
                _range = range
            };
            return instance;
        }

        public double Modify(double originalValue)
        {
            return Randomizer.NextInRange(_range);
        }
    }
}
