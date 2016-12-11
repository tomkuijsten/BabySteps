using BabySteps.NeuralNetwork.Neurons;
using BabySteps.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork
{
    public interface INeuralNetwork
    {
        HashSet<Neuron> Neurons { get; }
        HashSet<ISynapse> Synapses { get; }
        HashSet<InputNeuron> Inputs { get; }
        HashSet<OutputNeuron> Output { get; }
        HashSet<Bias> Biases { get; }
        double[] CalculateNeuralNetwork(params double[] inputValues);
        INeuralNetwork Clone();
    }
}
