using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class StaticValueWeightModifier : IWeightModifier
    {
        private double _staticValue;

        private StaticValueWeightModifier() { }

        public static StaticValueWeightModifier Create(double staticValue)
        {
            var instance = new StaticValueWeightModifier()
            {
                _staticValue = staticValue
            };

            return instance;
        }
        public double Modify(double originalValue)
        {
            return _staticValue;
        }
    }
}
