using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.ActivationFunctions;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class RandomActivationFunctionModifier : IActivationFunctionModifier
    {

        private RandomActivationFunctionModifier() { }

        public static RandomActivationFunctionModifier Create()
        {
            return new RandomActivationFunctionModifier();
        }

        public IActivationFunction Modify(IActivationFunction originalValue)
        {
            return ActivationFunctionFactory.CreateRandom();
        }
    }
}
