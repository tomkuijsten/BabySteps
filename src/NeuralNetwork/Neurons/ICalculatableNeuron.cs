using BabySteps.NeuralNetwork.ActivationFunctions;
using BabySteps.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.Neurons
{
    public interface ICalculatableNeuron
    {
        ISynapse BiasSynapse { get; }
        IEnumerable<ISynapse> Incoming { get; }
        IActivationFunction ActivationFunction { get; set; }
    }
}
