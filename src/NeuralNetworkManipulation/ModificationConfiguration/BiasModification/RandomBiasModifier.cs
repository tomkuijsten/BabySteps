using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class RandomBiasModifier : IBiasModifier
    {
        private DoubleRange _range;

        private RandomBiasModifier() { }

        public static RandomBiasModifier Create(DoubleRange range)
        {
            var instance = new RandomBiasModifier()
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
