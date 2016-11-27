using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.ActivationFunctions;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class RandomActivationFunctionModificationManipulator : IActivationFunctionModificationManipulator
    {

        private RandomActivationFunctionModificationManipulator() { }

        public static RandomActivationFunctionModificationManipulator Create()
        {
            return new RandomActivationFunctionModificationManipulator();
        }

        public IActivationFunction Modify(IActivationFunction originalValue)
        {
            return ActivationFunctionFactory.CreateRandom();
        }
    }
}
