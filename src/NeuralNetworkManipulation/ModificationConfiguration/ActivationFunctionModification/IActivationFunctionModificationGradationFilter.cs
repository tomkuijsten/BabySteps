using BabySteps.NeuralNetwork.Neurons;
using System.Collections.Generic;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public interface IActivationFunctionModificationGradationFilter
    {
        IEnumerable<ICalculatableNeuron> Filter(IEnumerable<ICalculatableNeuron> input);
    }
}