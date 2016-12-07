using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.ActivationFunctions;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class RandomWithinExistingCategoryActivationFunctionModifier : IActivationFunctionModifier
    {
        private RandomWithinExistingCategoryActivationFunctionModifier() { }

        public static RandomWithinExistingCategoryActivationFunctionModifier Create()
        {
            return new RandomWithinExistingCategoryActivationFunctionModifier();
        }

        public IActivationFunction Modify(IActivationFunction originalValue)
        {
            return ActivationFunctionFactory.CreateRandomWithinExistingCategory(originalValue);
        }
    }
}
