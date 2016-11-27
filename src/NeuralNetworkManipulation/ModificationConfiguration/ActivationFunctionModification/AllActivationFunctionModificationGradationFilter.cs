using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.Neurons;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class AllActivationFunctionModificationGradationFilter : IActivationFunctionModificationGradationFilter
    {
        private AllActivationFunctionModificationGradationFilter() { }

        public static AllActivationFunctionModificationGradationFilter Create()
        {
            return new AllActivationFunctionModificationGradationFilter();
        }

        public IEnumerable<ICalculatableNeuron> Filter(IEnumerable<ICalculatableNeuron> input)
        {
            return input;
        }
    }
}
