using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public class StaticValueWeightModification : IWeightModification
    {
        private double _staticValue;

        private StaticValueWeightModification() { }

        public static StaticValueWeightModification Create(double staticValue)
        {
            var instance = new StaticValueWeightModification()
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
