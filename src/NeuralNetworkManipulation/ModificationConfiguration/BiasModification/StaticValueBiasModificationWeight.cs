using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class StaticValueBiasModificationWeight : IBiasModificationWeight
    {
        private double _staticValue;

        private StaticValueBiasModificationWeight() { }

        public static StaticValueBiasModificationWeight Create(double staticValue)
        {
            var instance = new StaticValueBiasModificationWeight()
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
