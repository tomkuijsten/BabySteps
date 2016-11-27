using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Neurons;
using System.Collections.Generic;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.ActivationFunctionModification
{
    public interface IActivationFunctionModificationTarget
    {
        IEnumerable<ICalculatableNeuron> GetTarget(INeuralNetwork neuralNetwork);
    }
}