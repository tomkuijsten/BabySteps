using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class PercentageVariationBiasModifier : IBiasModifier
    {
        private DoubleRange _percentageRange;

        private PercentageVariationBiasModifier() { }

        public static PercentageVariationBiasModifier Create(DoubleRange percentageRange)
        {
            var instance = new PercentageVariationBiasModifier()
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
