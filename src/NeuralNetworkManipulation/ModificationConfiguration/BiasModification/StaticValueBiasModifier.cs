using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.BiasModification
{
    public class StaticValueBiasModifier : IBiasModifier
    {
        private double _staticValue;

        private StaticValueBiasModifier() { }

        public static StaticValueBiasModifier Create(double staticValue)
        {
            var instance = new StaticValueBiasModifier()
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
