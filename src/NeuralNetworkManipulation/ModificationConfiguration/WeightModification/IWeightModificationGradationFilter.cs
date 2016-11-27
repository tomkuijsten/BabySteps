using BabySteps.NeuralNetwork.Synapses;
using System.Collections.Generic;

namespace BabySteps.NeuralNetworkManipulation.ModificationConfiguration.WeightModification
{
    public interface IWeightModificationGradationFilter
    {
        IEnumerable<ISynapse> Filter(IEnumerable<ISynapse> input);
    }
}