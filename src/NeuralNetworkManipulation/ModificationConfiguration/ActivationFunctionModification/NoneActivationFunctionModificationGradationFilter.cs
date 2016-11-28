using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BabySteps.NeuralNetwork.Neurons;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public class NoneActivationFunctionModificationGradationFilter : IActivationFunctionModificationGradationFilter
    {
        private NoneActivationFunctionModificationGradationFilter() { }

        public static NoneActivationFunctionModificationGradationFilter Create()
        {
            return new NoneActivationFunctionModificationGradationFilter();
        }

        public IEnumerable<ICalculatableNeuron> Filter(IEnumerable<ICalculatableNeuron> input)
        {
            return Enumerable.Empty<ICalculatableNeuron>();
        }
    }
}
