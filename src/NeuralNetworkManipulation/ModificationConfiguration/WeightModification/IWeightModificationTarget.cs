using BabySteps.NeuralNetwork;
using BabySteps.NeuralNetwork.Synapses;
using System.Collections.Generic;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public interface IWeightModificationTarget
    {
        IEnumerable<ISynapse> GetTarget(INeuralNetwork neuralNetwork);
    }
}