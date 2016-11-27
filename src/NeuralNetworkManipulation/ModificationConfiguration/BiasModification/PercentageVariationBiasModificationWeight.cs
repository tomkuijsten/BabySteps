using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class PercentageVariationBiasModificationWeight : IBiasModificationWeight
    {
        private Random _randomizer;
        private double _minVariationPercentage;
        private double _maxVariationPercentage;

        private PercentageVariationBiasModificationWeight() { }

        public static PercentageVariationBiasModificationWeight Create(double minVariation, double maxVariation)
        {
            var instance = new PercentageVariationBiasModificationWeight()
            {
                _randomizer = new Random(),
                _minVariationPercentage = minVariation,
                _maxVariationPercentage = maxVariation
            };
            return instance;
        }

        public double Modify(double originalValue)
        {
            var random = _randomizer.NextDouble();
            var scope = _maxVariationPercentage - _minVariationPercentage;
            var variationFactor = (scope * random) + _minVariationPercentage;

            return variationFactor * originalValue;
        }
    }
}
