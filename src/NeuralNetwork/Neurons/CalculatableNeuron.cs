using BabySteps.NeuralNetwork.ActivationFunctions;
using BabySteps.NeuralNetwork.Synapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySteps.NeuralNetwork.Neurons
{
    public abstract class CalculatableNeuron<TFrom, TTo> : Neuron where TFrom : Neuron where TTo : Neuron
    {
        public Synapse<Bias, Neuron> BiasSynapse { get; set; }
        public List<Synapse<TFrom, TTo>> Incoming { get; private set; }
        public IActivationFunction ActivationFunction { get; set; }

        public CalculatableNeuron()
        {
            Incoming = new List<Synapse<TFrom, TTo>>();
            ActivationFunction = ActivationFunctionCollection.GetRandom();
        }
    }
}
