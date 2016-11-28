using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class PercentageVariationWeightModifier : IWeightModifier
    {
        private DoubleRange _percentageRange;

        private PercentageVariationWeightModifier() { }

        public static PercentageVariationWeightModifier Create(DoubleRange percentageRange)
        {
            var instance = new PercentageVariationWeightModifier()
            {
                _percentageRange = percentageRange
            };
            return instance;
        }

        public double Modify(double originalValue)
        {
            return Randomizer.Vary(_percentageRange, originalValue);
        }
    }
}
