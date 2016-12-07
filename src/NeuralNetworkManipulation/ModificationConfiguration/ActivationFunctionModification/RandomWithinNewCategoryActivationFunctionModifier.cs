using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.ActivationFunctions;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class RandomWithinNewCategoryActivationFunctionModifier : IActivationFunctionModifier
    {
        private ActivationFunctionCategory _newActivationFunctionCategory;

        private RandomWithinNewCategoryActivationFunctionModifier(ActivationFunctionCategory newActivationFunctionCategory)
        {
            _newActivationFunctionCategory = newActivationFunctionCategory;
        }

        public static RandomWithinNewCategoryActivationFunctionModifier Create(ActivationFunctionCategory newActivationFunctionCategory)
        {
            return new RandomWithinNewCategoryActivationFunctionModifier(newActivationFunctionCategory);
        }

        public IActivationFunction Modify(IActivationFunction originalValue)
        {
            return ActivationFunctionFactory.CreateRandomWithinNewCategory(_newActivationFunctionCategory);
        }
    }
}
